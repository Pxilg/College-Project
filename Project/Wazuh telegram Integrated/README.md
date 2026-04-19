# 🛡️ Real-Time Intrusion Alert & Active Response System

## 💡 What is this?
A fully automated security pipeline integrating **Wazuh (SIEM)** with a custom **Telegram bot**. Because who wants to stare at a dashboard all day? This setup pushes real-time threat alerts straight to your phone and lets you actively block attackers (like SSH brute-forcers) with a single tap in the chat. 

## 🚀 Core Features
* **📲 Real-Time Alerts:** Wazuh threat detections forwarded instantly to your Telegram.
* **🕹️ Interactive Response:** Inline chat buttons let you acknowledge alerts, pull raw JSON, trigger email reports, or run AbuseIPDB lookups on the fly.
* **🔨 The Ban Hammer:** Permanently block malicious IPs across all your agents using `iptables` directly from the Telegram chat.
* **📊 Daily Briefings:** Automated daily recaps showing total alerts, severity levels, top attacking IPs, and your most targeted agents.

## 🛠️ Tech Stack
* **SIEM:** Wazuh (Manager & Agent)
* **Brain/Logic:** Python 3 (Custom integration & long-polling bot handler)
* **API:** Telegram Bot API
* **Testing Env:** Ubuntu LTS (Target) & Kali Linux (Attacker)

## 🤖 Bot Commands
<img width="584" height="687" alt="Screenshot 2026-04-19 093324" src="https://github.com/user-attachments/assets/00ae10e7-a8b6-4c6c-a00d-2f4de216cc3f" />

The bot runs as a persistent daemon (`wazuh-telegram-bot.service`) and listens for:
* `/block <ip> [agent_id]` 🛑 - Permanently drops the IP on all agents (or a specific one).
* `/agents` 🕵️‍♂️ - Lists all active Wazuh agents.
* `/summary` 📉 - Pulls today's alert summary.
* `/summary <YYYY-MM-DD>` 📅 - Pulls the summary for a specific date.
* `/help` 🆘 - Shows the command list.

## 💥 Attack Simulation
<img width="515" height="523" alt="Screenshot 2026-04-19 093105" src="https://github.com/user-attachments/assets/c6c00c5c-8acf-4301-8787-a31c86e5a293" />

Tested the active response capabilities using standard penetration testing tools:
* **Nmap:** Recon and port scanning.
* **Hydra:** SSH brute-forcing (which triggers the Wazuh alert and gets the attacker automatically blocked).
