#!/usr/bin/env python3
import json
import logging
import os
import re
import smtplib
import subprocess
import time
from collections import Counter
from datetime import datetime
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

import requests

# ─── Configuration ────────────────────────────────────────────────────────────
BOT_TOKEN   = ""
CHAT_ID     = ""

WAZUH_API_URL  = "https://localhost:55000"
WAZUH_USER     = "wazuh-wui"
WAZUH_PASSWORD = ""

GMAIL_SENDER    = ""
GMAIL_PASSWORD  = ""
EMAIL_RECIPIENT = ""

CACHE_DIR     = "/tmp/wazuh_alerts"
AGENT_CONTROL = "/var/ossec/bin/agent_control"
DEFAULT_AGENT = "001"
SUMMARY_HOUR  = 20
# ──────────────────────────────────────────────────────────────────────────────

TELEGRAM_API = f"https://api.telegram.org/bot{BOT_TOKEN}"
IP_PATTERN   = re.compile(r"^(\d{1,3}\.){3}\d{1,3}$")

logging.basicConfig(
    level=logging.INFO,
    format="%(asctime)s [%(levelname)s] %(message)s",
    datefmt="%Y-%m-%d %H:%M:%S",
)
log = logging.getLogger(__name__)


# ─── Telegram helpers ─────────────────────────────────────────────────────────

def answer_callback(callback_query_id: str, text: str, show_alert: bool = False):
    requests.post(f"{TELEGRAM_API}/answerCallbackQuery", json={
        "callback_query_id": callback_query_id,
        "text": text,
        "show_alert": show_alert,
    })


def edit_reply_markup(chat_id: str, message_id: int, reply_markup: dict | None = None):
    requests.post(f"{TELEGRAM_API}/editMessageReplyMarkup", json={
        "chat_id": chat_id,
        "message_id": message_id,
        "reply_markup": reply_markup or {},
    })


def send_message(text: str, parse_mode: str = "Markdown"):
    requests.post(f"{TELEGRAM_API}/sendMessage", json={
        "chat_id": CHAT_ID,
        "text": text,
        "parse_mode": parse_mode,
    })


def send_document(filename: str, content: bytes, caption: str = ""):
    requests.post(f"{TELEGRAM_API}/sendDocument", data={
        "chat_id": CHAT_ID,
        "caption": caption,
    }, files={"document": (filename, content, "application/json")})


# ─── Cache helper ─────────────────────────────────────────────────────────────

def load_alert(alert_id: str) -> dict | None:
    path = os.path.join(CACHE_DIR, f"{alert_id}.json")
    try:
        with open(path, "r") as f:
            return json.load(f)
    except Exception as e:
        log.error("Failed to load cached alert %s: %s", alert_id, e)
        return None


# ─── Daily summary ────────────────────────────────────────────────────────────

def load_summary_log(date_str: str) -> list[dict]:
    path = os.path.join(CACHE_DIR, f"summary_{date_str}.jsonl")
    entries = []
    try:
        with open(path, "r") as f:
            for line in f:
                line = line.strip()
                if line:
                    try:
                        entries.append(json.loads(line))
                    except Exception:
                        pass
    except FileNotFoundError:
        pass
    except Exception as e:
        log.error("Failed to load summary log: %s", e)
    return entries


def build_daily_summary(date_str: str) -> str:
    entries = load_summary_log(date_str)

    if not entries:
        return f"📊 *Daily Summary — {date_str}*\n\nNo alerts recorded today."

    total  = len(entries)
    levels = [int(e.get("level", 0)) for e in entries if str(e.get("level", "")).isdigit()]
    avg_level = round(sum(levels) / len(levels), 1) if levels else 0
    max_level = max(levels) if levels else 0
    min_level = min(levels) if levels else 0

    ip_counter    = Counter()
    agent_counter = Counter()

    for e in entries:
        srcip = e.get("srcip", "")
        if srcip and srcip != "unknown":
            ip_counter[srcip] += 1
        agent = e.get("agent", "")
        if agent and agent != "unknown":
            agent_counter[agent] += 1

    top_ips    = ip_counter.most_common(3)
    top_agents = agent_counter.most_common(3)

    top_ip_lines    = "\n".join(f"  • `{ip}` ({count}x)" for ip, count in top_ips) or "  N/A"
    top_agent_lines = "\n".join(f"  • {agent} ({count}x)" for agent, count in top_agents) or "  N/A"

    sep = "\u2500" * 28

    return (
        f"📊 *Daily Alert Summary*\n"
        f"📅 Date: `{date_str}`\n"
        f"`{sep}`\n"
        f"🔢 Total Alerts   : `{total}`\n"
        f"📈 Average Level  : `{avg_level}`\n"
        f"🔴 Highest Level  : `{max_level}`\n"
        f"🟢 Lowest Level   : `{min_level}`\n"
        f"`{sep}`\n"
        f"🌐 *Top Attacking IPs:*\n{top_ip_lines}\n"
        f"`{sep}`\n"
        f"💻 *Most Targeted Agents:*\n{top_agent_lines}"
    )


def send_daily_summary(date_str: str = None):
    if not date_str:
        date_str = datetime.now().strftime("%Y-%m-%d")
    summary = build_daily_summary(date_str)
    send_message(summary)
    log.info("Daily summary sent for %s", date_str)


# ─── Active response ──────────────────────────────────────────────────────────

def run_ar(command: str, srcip: str, agent_id: str) -> bool:
    cmd = [AGENT_CONTROL, "-b", srcip, "-f", f"{command}0", "-u", agent_id]
    try:
        result = subprocess.run(cmd, capture_output=True, text=True, timeout=15)
        output = result.stdout.strip()
        log.info("agent_control [%s %s on %s]: %s", command, srcip, agent_id, output)
        if "Running active response" in output:
            return True
        log.error("agent_control unexpected output: %s", output)
    except Exception as e:
        log.error("agent_control error: %s", e)
    return False


def run_ar_all_agents(command: str, srcip: str) -> list[str]:
    agents = wazuh_get_agents()
    results = []
    for agent in agents:
        agent_id = agent.get("id", "")
        if not agent_id or agent_id == "000":
            continue
        if run_ar(command, srcip, agent_id):
            results.append(f"{agent.get('name', agent_id)} ({agent_id})")
    return results


# ─── Wazuh API (agent listing only) ──────────────────────────────────────────

def wazuh_get_token() -> str | None:
    try:
        resp = requests.get(
            f"{WAZUH_API_URL}/security/user/authenticate",
            auth=(WAZUH_USER, WAZUH_PASSWORD),
            verify=False,
            timeout=10,
        )
        if resp.status_code == 200:
            return resp.json().get("data", {}).get("token")
    except Exception as e:
        log.error("Wazuh auth error: %s", e)
    return None


def wazuh_get_agents() -> list[dict]:
    token = wazuh_get_token()
    if not token:
        return []
    try:
        resp = requests.get(
            f"{WAZUH_API_URL}/agents",
            headers={"Authorization": f"Bearer {token}"},
            params={"status": "active", "limit": 100},
            verify=False,
            timeout=10,
        )
        if resp.status_code == 200:
            return resp.json().get("data", {}).get("affected_items", [])
    except Exception as e:
        log.error("Get agents error: %s", e)
    return []


# ─── Email helper ─────────────────────────────────────────────────────────────

def build_html_report(alert: dict) -> str:
    data          = alert.get("data", {})
    rule          = alert.get("rule", {})
    agent         = alert.get("agent", {})
    vuln          = alert.get("vulnerability", {})
    timestamp_raw = alert.get("timestamp", "unknown")
    full_log      = alert.get("full_log", "No full log available")
    public_ip     = alert.get("_public_ip", "N/A")
    location      = alert.get("_location", "N/A")

    try:
        dt = datetime.fromisoformat(timestamp_raw.replace("Z", "+00:00"))
        timestamp = dt.strftime("%Y-%m-%d %H:%M:%S UTC%z")
    except Exception:
        timestamp = timestamp_raw

    cve_id    = vuln.get("cve", "")
    cve_title = vuln.get("title", "")
    cve_block = f"""
        <tr><td><b>CVE ID</b></td><td>{cve_id}</td></tr>
        <tr><td><b>CVE Title</b></td><td>{cve_title}</td></tr>
        <tr><td><b>CVE Link</b></td>
            <td><a href="https://cti.wazuh.com/vulnerabilities/cves/{cve_id}">View in CTI</a></td></tr>
    """ if cve_id else ""

    mitre       = rule.get("mitre", {})
    mitre_block = ""
    if mitre:
        tactics    = ", ".join(mitre.get("tactic", []))
        techniques = ", ".join(mitre.get("technique", []))
        mitre_ids  = ", ".join(mitre.get("id", []))
        mitre_block = f"""
        <tr><td><b>MITRE Tactic</b></td><td>{tactics}</td></tr>
        <tr><td><b>MITRE Technique</b></td><td>{techniques} ({mitre_ids})</td></tr>
        """

    return f"""<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<style>
  body {{ font-family: Arial, sans-serif; background: #f4f4f4; padding: 20px; }}
  .container {{ background: #fff; border-radius: 8px; padding: 24px; max-width: 700px; margin: auto; }}
  h2 {{ color: #c0392b; border-bottom: 2px solid #c0392b; padding-bottom: 8px; }}
  h3 {{ color: #2c3e50; margin-top: 20px; }}
  table {{ width: 100%; border-collapse: collapse; margin-top: 8px; }}
  td {{ padding: 8px 12px; border: 1px solid #ddd; vertical-align: top; }}
  td:first-child {{ width: 160px; background: #f9f9f9; font-weight: bold; color: #555; }}
  .log {{ background: #1e1e1e; color: #d4d4d4; padding: 12px; border-radius: 4px;
          font-family: monospace; font-size: 13px; word-break: break-all; white-space: pre-wrap; }}
  .badge {{ display: inline-block; padding: 3px 10px; border-radius: 12px; font-size: 13px;
            font-weight: bold; background: #e74c3c; color: white; }}
  .footer {{ margin-top: 24px; font-size: 12px; color: #999; text-align: center; }}
</style>
</head>
<body>
<div class="container">
  <h2>🚨 Wazuh Security Alert Report</h2>
  <h3>📋 Alert Overview</h3>
  <table>
    <tr><td>Timestamp</td><td>{timestamp}</td></tr>
    <tr><td>Alert ID</td><td>{alert.get("id", "N/A")}</td></tr>
    <tr><td>Level</td><td><span class="badge">Level {rule.get("level", "N/A")}</span></td></tr>
    <tr><td>Rule ID</td><td>{rule.get("id", "N/A")}</td></tr>
    <tr><td>Description</td><td>{rule.get("description", "N/A")}</td></tr>
    {mitre_block}
  </table>
  <h3>💻 Agent Information</h3>
  <table>
    <tr><td>Agent Name</td><td>{agent.get("name", "N/A")}</td></tr>
    <tr><td>Agent ID</td><td>{agent.get("id", "N/A")}</td></tr>
    <tr><td>Agent IP</td><td>{agent.get("ip", "N/A")}</td></tr>
  </table>
  <h3>🌐 Attack Source</h3>
  <table>
    <tr><td>Private IP</td><td>{data.get("srcip", "N/A")}</td></tr>
    <tr><td>Public IP</td><td>{public_ip}</td></tr>
    <tr><td>Location</td><td>{location}</td></tr>
    <tr><td>Source Port</td><td>{data.get("srcport", "N/A")}</td></tr>
    <tr><td>Username</td><td>{data.get("srcuser") or data.get("dstuser") or "N/A"}</td></tr>
  </table>
  {f'<h3>🛡️ Vulnerability</h3><table>{cve_block}</table>' if cve_id else ''}
  <h3>🔍 Full Log</h3>
  <div class="log">{full_log}</div>
  <div class="footer">Generated by Wazuh Telegram Alert Bot — {datetime.now().strftime("%Y-%m-%d %H:%M:%S")}</div>
</div>
</body>
</html>"""


def send_email_report(alert: dict) -> bool:
    try:
        rule  = alert.get("rule", {})
        data  = alert.get("data", {})
        srcip = data.get("srcip", "unknown")

        subject = f"[Wazuh Alert] Level {rule.get('level','?')} | Rule {rule.get('id','?')} | {srcip} — {rule.get('description','')[:60]}"

        msg = MIMEMultipart("alternative")
        msg["Subject"] = subject
        msg["From"]    = GMAIL_SENDER
        msg["To"]      = EMAIL_RECIPIENT
        msg.attach(MIMEText(build_html_report(alert), "html"))

        with smtplib.SMTP_SSL("smtp.gmail.com", 465) as server:
            server.login(GMAIL_SENDER, GMAIL_PASSWORD)
            server.sendmail(GMAIL_SENDER, EMAIL_RECIPIENT, msg.as_string())

        log.info("Email report sent for rule %s", rule.get("id"))
        return True
    except Exception as e:
        log.error("Email send error: %s", e)
        return False


# ─── Command handlers ─────────────────────────────────────────────────────────

def handle_command(text: str):
    parts = text.strip().split()
    cmd   = parts[0].lower().split("@")[0]
    args  = parts[1:]

    if cmd == "/help":
        send_message(
            "*🤖 Wazuh Bot Commands*\n\n"
            "`/block <ip> [agent_id]` — Permanently block IP on all agents or specific agent\n"
            "`/agents` — List all active agents\n"
            "`/summary` — Today's alert summary\n"
            "`/summary <YYYY-MM-DD>` — Summary for specific date\n"
            "`/help` — Show this message"
        )
        return

    if cmd == "/agents":
        agents = wazuh_get_agents()
        if not agents:
            send_message("❌ No active agents found or API unreachable.")
            return
        lines = ["*💻 Active Agents*\n"]
        for a in agents:
            lines.append(f"`{a.get('id')}` — *{a.get('name')}* ({a.get('ip', 'N/A')})")
        send_message("\n".join(lines))
        return

    if cmd == "/summary":
        date_str = args[0] if args else datetime.now().strftime("%Y-%m-%d")
        send_daily_summary(date_str)
        return

    if cmd == "/block":
        if not args:
            send_message("⚠️ Usage: `/block <ip> [agent_id]`\nExample: `/block 192.168.200.128`")
            return

        srcip    = args[0]
        agent_id = args[1] if len(args) > 1 else None

        if not IP_PATTERN.match(srcip):
            send_message(f"⚠️ Invalid IP address: `{srcip}`")
            return

        if agent_id:
            send_message(f"⏳ Blocking `{srcip}` on agent `{agent_id}`…")
            if run_ar("firewall-block-persistent", srcip, agent_id):
                send_message(f"🔒 *Blocked* `{srcip}` on agent `{agent_id}`")
            else:
                send_message(f"❌ Failed to block `{srcip}` on agent `{agent_id}`")
        else:
            send_message(f"⏳ Blocking `{srcip}` on all agents…")
            results = run_ar_all_agents("firewall-block-persistent", srcip)
            if results:
                send_message(f"🔒 *Blocked* `{srcip}` on:\n" + "\n".join(f"• {a}" for a in results))
            else:
                send_message(f"❌ Failed to block `{srcip}` on any agent")
        return

    send_message(f"❓ Unknown command: `{cmd}`\nType `/help` for available commands.")


# ─── Callback handlers ────────────────────────────────────────────────────────

def handle_acknowledge(callback_query_id: str, rule_id: str, message_id: int):
    answer_callback(callback_query_id, "✅ Alert acknowledged.")
    edit_reply_markup(CHAT_ID, message_id, {
        "inline_keyboard": [[{"text": "✅ Acknowledged", "callback_data": "noop"}]]
    })


def handle_raw_json(callback_query_id: str, alert_id: str):
    alert = load_alert(alert_id)
    if not alert:
        answer_callback(callback_query_id, "❌ Alert data not found in cache.", show_alert=True)
        return

    answer_callback(callback_query_id, "📋 Sending raw JSON…")
    raw = json.dumps(alert, indent=2)

    if len(raw) <= 4000:
        send_message(f"```json\n{raw}\n```")
    else:
        send_document(
            filename=f"alert_{alert_id}.json",
            content=raw.encode("utf-8"),
            caption=f"📋 Alert JSON — Rule {alert.get('rule', {}).get('id', 'N/A')}",
        )


def handle_email_report(callback_query_id: str, alert_id: str):
    alert = load_alert(alert_id)
    if not alert:
        answer_callback(callback_query_id, "❌ Alert data not found in cache.", show_alert=True)
        return

    answer_callback(callback_query_id, "⏳ Sending email report…")
    if send_email_report(alert):
        send_message(f"📧 *Email report sent* to `{EMAIL_RECIPIENT}`")
    else:
        answer_callback(callback_query_id, "❌ Failed to send email. Check bot logs.", show_alert=True)


def handle_noop(callback_query_id: str):
    answer_callback(callback_query_id, "Already processed.")


# ─── Dispatcher ───────────────────────────────────────────────────────────────

def dispatch(update: dict):
    if "callback_query" in update:
        cq          = update["callback_query"]
        callback_id = cq["id"]
        data        = cq.get("data", "")
        message_id  = cq.get("message", {}).get("message_id")
        parts       = data.split("|")
        action      = parts[0] if parts else ""

        if action == "ack":
            handle_acknowledge(callback_id, parts[1] if len(parts) > 1 else "unknown", message_id)
        elif action == "json":
            handle_raw_json(callback_id, parts[1] if len(parts) > 1 else "")
        elif action == "email":
            handle_email_report(callback_id, parts[1] if len(parts) > 1 else "")
        elif action == "noop":
            handle_noop(callback_id)
        else:
            answer_callback(callback_id, "Unknown action.")

    elif "message" in update:
        msg     = update["message"]
        text    = msg.get("text", "").strip()
        from_id = str(msg.get("from", {}).get("id", ""))

        if from_id != CHAT_ID:
            log.warning("Ignored message from unauthorized user: %s", from_id)
            return

        if text.startswith("/"):
            handle_command(text)


# ─── Daily summary scheduler ──────────────────────────────────────────────────

def check_daily_summary(last_summary_date: list):
    now   = datetime.now()
    today = now.strftime("%Y-%m-%d")
    if now.hour >= SUMMARY_HOUR and last_summary_date[0] != today:
        last_summary_date[0] = today
        send_daily_summary(today)


# ─── Long-polling loop ────────────────────────────────────────────────────────

def poll():
    offset            = None
    last_summary_date = [""]

    log.info("Telegram bot handler started — polling for updates…")

    while True:
        try:
            check_daily_summary(last_summary_date)

            params = {"timeout": 30, "allowed_updates": ["callback_query", "message"]}
            if offset is not None:
                params["offset"] = offset

            resp = requests.get(f"{TELEGRAM_API}/getUpdates", params=params, timeout=35)
            if resp.status_code != 200:
                log.error("getUpdates error: %s", resp.text)
                time.sleep(5)
                continue

            updates = resp.json().get("result", [])
            for update in updates:
                try:
                    dispatch(update)
                except Exception as e:
                    log.error("Dispatch error: %s", e)
                offset = update["update_id"] + 1

        except requests.exceptions.Timeout:
            pass
        except Exception as e:
            log.error("Polling error: %s", e)
            time.sleep(5)


if __name__ == "__main__":
    poll()
