#!/var/ossec/venv/bin/python
import json
import os
import re
import sys
from datetime import datetime
import requests

bot_token = ""
chat_id   = ""

CACHE_DIR = "/tmp/wazuh_alerts"
os.makedirs(CACHE_DIR, exist_ok=True)

excluded_rules: list = []

PRIVATE_RANGES = [
    re.compile(r"^10\."),
    re.compile(r"^172\.(1[6-9]|2[0-9]|3[0-1])\."),
    re.compile(r"^192\.168\."),
    re.compile(r"^127\."),
]


def is_private_ip(ip: str) -> bool:
    return any(p.match(ip) for p in PRIVATE_RANGES)


def get_public_ip() -> str:
    for url in ["https://api.ipify.org", "https://ifconfig.me/ip", "https://icanhazip.com"]:
        try:
            resp = requests.get(url, timeout=5)
            if resp.status_code == 200:
                return resp.text.strip()
        except Exception:
            continue
    return "unavailable"


def get_ip_location(ip: str) -> str:
    if ip == "unavailable" or not ip:
        return "unavailable"
    try:
        resp = requests.get(f"http://ip-api.com/json/{ip}", timeout=5)
        if resp.status_code == 200:
            data = resp.json()
            if data.get("status") == "success":
                city    = data.get("city", "")
                region  = data.get("regionName", "")
                country = data.get("country", "")
                isp     = data.get("isp", "")
                parts   = [p for p in [city, region, country] if p]
                loc     = ", ".join(parts)
                return f"{loc} — {isp}" if isp else loc
    except Exception:
        pass
    return "unavailable"


def escape_markdown_v2(text):
    if not isinstance(text, str):
        text = str(text)
    escape_chars = r"_*[]()~`>#+-=|{}.!"
    return re.sub(r"([%s])" % re.escape(escape_chars), r"\\\1", text)


def build_inline_keyboard(alert_id: str, srcip: str, agent_id: str, rule_id: str, public_ip: str) -> dict:
    lookup_ip  = public_ip if (is_private_ip(srcip) and public_ip != "unavailable") else srcip
    lookup_url = f"https://www.abuseipdb.com/check/{lookup_ip}"

    return {
        "inline_keyboard": [
            [
                {"text": "✅ Acknowledge",  "callback_data": f"ack|{rule_id}"[:64]},
                {"text": "📋 Raw JSON",     "callback_data": f"json|{alert_id}"[:64]},
                {"text": "📧 Email Report", "callback_data": f"email|{alert_id}"[:64]},
            ],
            [
                {"text": "🔍 Lookup Public IP (AbuseIPDB)", "url": lookup_url},
            ],
        ]
    }


def main():
    if len(sys.argv) < 2:
        print("[ERROR] No alert file path provided.")
        sys.exit(1)

    alert_file = sys.argv[1]
    try:
        with open(alert_file, "r") as f:
            alert = json.load(f)
    except Exception as e:
        print(f"[ERROR] Failed to read or parse alert JSON: {e}")
        sys.exit(1)

    rule_id = alert.get("rule", {}).get("id", None)
    if rule_id in excluded_rules:
        print(f"[INFO] Skipping excluded rule ID: {rule_id}")
        sys.exit(0)

    data       = alert.get("data", {})
    srcuser    = data.get("srcuser") or data.get("dstuser") or "unknown"
    srcport    = data.get("srcport", "unknown")
    srcip      = data.get("srcip", "unknown")
    agent      = alert.get("agent", {})
    agent_id   = agent.get("id", "000")
    agent_name = agent.get("name", "unknown")
    alert_level   = alert.get("rule", {}).get("level", "unknown")
    rule_id       = alert.get("rule", {}).get("id", "unknown")
    description   = alert.get("rule", {}).get("description", "No description")
    full_log      = alert.get("full_log", "No full log available")
    timestamp_raw = alert.get("timestamp", "unknown")
    alert_id      = alert.get("id", timestamp_raw.replace(":", "").replace(".", ""))

    try:
        dt = datetime.fromisoformat(timestamp_raw.replace("Z", "+00:00"))
        timestamp = dt.strftime("%Y-%m-%d %H:%M:%S")
    except Exception:
        timestamp = timestamp_raw

    public_ip = get_public_ip() if is_private_ip(srcip) else srcip
    location  = get_ip_location(public_ip)

    alert["_public_ip"] = public_ip
    alert["_location"]  = location

    cache_path = os.path.join(CACHE_DIR, f"{alert_id}.json")
    try:
        with open(cache_path, "w") as f:
            json.dump(alert, f, indent=2)
    except Exception as e:
        print(f"[WARN] Failed to cache alert: {e}")

    # Append to daily summary log
    summary_log = f"/tmp/wazuh_alerts/summary_{datetime.now().strftime('%Y-%m-%d')}.jsonl"
    try:
        with open(summary_log, "a") as f:
            f.write(json.dumps({
                "ts": timestamp,
                "rule_id": rule_id,
                "description": description,
                "srcip": srcip,
                "level": alert_level,
                "agent": agent_name,
            }) + "\n")
    except Exception as e:
        print(f"[WARN] Failed to write summary log: {e}")

    message = (
        "*🚨 Wazuh Alert Notification*\n\n"
        f"🕒 *Time:* `{escape_markdown_v2(timestamp)}`\n"
        f"👤 *Username:* `{escape_markdown_v2(srcuser)}`\n"
        f"🖥️ *Private IP:* `{escape_markdown_v2(srcip)}`\n"
        f"🌍 *Public IP:* `{escape_markdown_v2(public_ip)}`\n"
        f"📍 *Location:* {escape_markdown_v2(location)}\n"
        f"🚪 *Source Port:* `{escape_markdown_v2(srcport)}`\n"
        f"💻 *Agent:* {escape_markdown_v2(agent_name)}\n\n"
        f"🆔 *Rule ID:* `{escape_markdown_v2(rule_id)}`\n"
        f"🧱 *Level:* *{escape_markdown_v2(str(alert_level))}*\n\n"
        f"📄 *Description:*\n{escape_markdown_v2(description)}\n\n"
        f"🔍 *Full Log:*\n{escape_markdown_v2(full_log)}"
    )

    vuln      = alert.get("vulnerability", {})
    cve_id    = vuln.get("cve", "")
    cve_title = vuln.get("title", "")
    cve_url   = f"https://cti.wazuh.com/vulnerabilities/cves/{cve_id}" if cve_id else ""

    if cve_id:
        message += (
            f"\n\n*🛡️ CVE:* `{escape_markdown_v2(cve_id)}`\n"
            f"*📄 Details:* {escape_markdown_v2(cve_title)}\n"
            f"[🔗 View in CTI]({escape_markdown_v2(cve_url)})"
        )

    keyboard = build_inline_keyboard(alert_id, srcip, agent_id, rule_id, public_ip)

    url = f"https://api.telegram.org/bot{bot_token}/sendMessage"
    payload = {
        "chat_id": chat_id,
        "text": message,
        "parse_mode": "MarkdownV2",
        "reply_markup": keyboard,
    }
    response = requests.post(url, json=payload)
    if response.status_code != 200:
        print(f"[ERROR] Telegram response: {response.status_code} - {response.text}")


if __name__ == "__main__":
    main()
