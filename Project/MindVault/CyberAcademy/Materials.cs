using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberAcademy
{
    public partial class Materials : Form
    {
        // We need to know who the user is to go back to the dashboard correctly
        string currentUser;

        public Materials(string username)
        {
            InitializeComponent();
            currentUser = username;
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            // 1. Populate the ListBox when the screen opens
            lstTopics.Items.Add("Introduction to Phishing");
            lstTopics.Items.Add("Password Security");
            lstTopics.Items.Add("Social Engineering");
            lstTopics.Items.Add("Malware Basics");
            lstTopics.Items.Add("Network Defense");
            lstTopics.Items.Add("Cryptography Basics");
            lstTopics.Items.Add("Wi-Fi Security");
            lstTopics.Items.Add("Data Privacy Laws");
            lstTopics.Items.Add("Ethical Hacking 101");
            lstTopics.Items.Add("Incident Response");
        }

        private void lstTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 2. Change the text based on what they clicked
            string topic = lstTopics.SelectedItem.ToString();

            if (topic == "Introduction to Phishing")
            {
                rtbContent.Text = @"INTRODUCTION TO PHISHING

                Phishing is a cybercrime in which a target is contacted by email, telephone or text message by someone posing as a legitimate institution to lure individuals into providing sensitive data such as personally identifiable information, banking and credit card details, and passwords.
                
                The information is then used to access important accounts and can result in identity theft and financial loss.
                
                HOW TO SPOT IT:
                1. Check the sender's email address carefully (e.g., support@g00gle.com).
                2. Look for generic greetings like 'Dear Customer'.
                3. Be wary of urgent language threatening account closure.";
            
        }
            else if (topic == "Password Security")
            {
                rtbContent.Text = @"WHAT IS PASSWORD SECURITY?

                Password security or password protection are practices for esablishing and veryfing identity and restricting access to devices, files, and accounts. They help ensure that only those who can provide a correct password in response to a prompt are given access
                
                Why is password security needed?
                
                Passwords remain an effective solution for identity-based access control of digital assets when considering cost, security benefits, and ease of use and management.

                The average user manages more password than ever. Password security systems are used not just to protect data but also to verify and establish identity for personalized features and account access. Stolen credentials are commonly used by cyberattackers to deliver malwaer. For this reason, it's important to adpot password security best partices, such as mulfi-factor authentication (MFA)

                Best Practice for password security
                
                Change passwords frequently
                requiring users to change passwords on a regular basis is one of the easiest and most effective ways to increase the security of passwords.

                Safely store passwords
                verifiers must store passwords in the most secure way possible. One strategy is to avoid storing password in plaintext format, which attackers can easily read. Furthermore, never store your credentials in a browser";               
            }
            else if (topic == "Social Engineering")
            {
                rtbContent.Text = @"SOCIAL ENGINEERING

                Social engineering attacks manipulate people into sharing information that they shouldn’t share, downloading software that they shouldn’t download, visiting websites they shouldn’t visit, sending money to criminals or making other mistakes that compromise their personal or organizational security.

                An email that seems to be from a trusted coworker requesting sensitive information, a threatening voicemail claiming to be from the IRS and an offer of riches from a foreign potentate are just a few examples of social engineering. Because social engineering uses psychological manipulation and exploits human error or weakness rather than technical or digital system vulnerabilities, it is sometimes called ""human hacking"".

                Cybercriminals frequently use social engineering tactics to obtain personal data or financial information, including login credentials, credit card numbers, bank account numbers and Social Security numbers. They use the stolen information for identity theft, enabling them to make purchases using other peoples’ money or credit, apply for loans in someone else’s name, apply for other peoples’ unemployment benefits and more.

                But a social engineering attack can also be the first stage of a larger-scale cyberattack. For example, a cybercriminal might trick a victim into sharing a username and password and then use those credentials to plant ransomware on the victim’s employer’s network.

                Social engineering is attractive to cybercriminals because it enables them to access digital networks, devices and accounts without having to do the difficult technical work of getting around firewalls, antivirus software and other cybersecurity controls.";
            }
            else if (topic == "Malware Basics")
            {
                rtbContent.Text = @"WHAT IS MALWARE?
                
                Malware, short for malicious software, refers to any intrusive software developed by cybercriminals (often called hackers) to steal data and damage or destroy computers and computer systems. Examples of common malware include viruses, worms, Trojan viruses, spyware, adware, and ransomware. Recent malware attacks have exfiltrated data in mass amounts.

                What is the intent of malware?
                Malware is developed as harmful software that invades or corrupts your computer network. The goal of malware is to cause havoc and steal information or resources for monetary gain or sheer sabotage intent. 
                
                Intelligence and intrusion
                Exfiltrates data such as emails, plans, and especially sensitive information like passwords.
                
                Disruption and extortion
                Locks up networks and PCs, making them unusable. If it holds your computer hostage for financial gain, it's called ransomware.
                
                Destruction or vandalism
                Destroys computer systems to damage your network infrastructure.
                
                Steal computer resources
                Uses your computing power to run botnets, cryptomining programs (cryptojacking), or send spam emails.
                
                Monetary gain
                Sells your organization's intellectual property on the dark web.

                How do I protect my network against malware?
                Typically, businesses focus on preventative tools to stop breaches. By securing the perimeter, businesses assume they are safe. However, some advanced malware will eventually make their way into your network. As a result, it is crucial to deploy technologies that continually monitor and detect malware that has evaded perimeter defenses. Sufficient advanced malware protection requires multiple layers of safeguards along with high-level network visibility and intelligence.";
            }
            else if (topic == "Network Defense")
            {
                rtbContent.Text = @"NETWORK DEFENSE

                Network defense is a critical aspect of cybersecurity that focuses on safeguarding computer networks from various threats, including cyberattacks, data breaches, and unauthorized access. It encompasses a wide range of practices, tools, and technologies designed to detect, prevent, and respond to security incidents. Key components of network defense include firewalls, intrusion detection systems (IDS), intrusion prevention systems (IPS), and virtual private networks (VPNs). By implementing these measures, organizations can create layers of security that protect sensitive information and maintain the integrity of their network infrastructure. Effective network defense strategies also involve continuous monitoring and analysis of network traffic to identify potential threats in real-time. Moreover, educating employees about security best practices plays a significant role in enhancing network defense by reducing the risk of human error. As cyber threats evolve, organizations must stay vigilant and adapt their network defense strategies to ensure robust protection against emerging risks.
                
                EXAMPLES
                - The use of a firewall to block unauthorized access attempts to a company's internal network.
                - Implementing an intrusion detection system (IDS) that alerts administrators of suspicious activity on the network.

                How to Improve Computer Network Defense

                Provide employee training sessions related to password strength, spotting phishing emails, and other basic cyber security tips. Cybercriminals will always look for the path of least resistance or the weakest link in your defense systems. If your employees are not fully aware of the best practices and how to use digital solutions in a safe and secure way, they will become this weak spot. Giving them even basic training on cyber security will help you protect your business.";
            }
            else if (topic == "Cryptography Basics")
            {
                rtbContent.Text = @"FROM CAESAR TO HASHING

                Cryptography is the process of hiding or coding information so that only the person a message was intended for can read it. The art of cryptography has been used to code messages for thousands of years and continues to be used in bank cards, computer passwords, and ecommerce.

                Modern cryptography techniques include algorithms and ciphers that enable the encryption and decryption of information, such as 128-bit and 256-bit encryption keys. Modern ciphers, such as the Advanced Encryption Standard (AES), are considered virtually unbreakable—although emerging quantum algorithms are expected to challenge some traditional cryptographic models in the future.
                
                A common cryptography definition is the practice of coding information to ensure only the person that a message was written for can read and process the information. This cybersecurity practice, also known as cryptology, combines various disciplines like computer science, engineering, and mathematics to create complex codes that hide the true meaning of a message.
                
                Cryptography can be traced all the way back to ancient Egyptian hieroglyphics but remains vital to securing communication and information in transit and preventing it from being read by untrusted parties. It uses algorithms and mathematical concepts to transform messages into difficult-to-decipher codes through techniques like cryptographic keys and digital signing to protect data privacy, credit card transactions, email, and web browsing.

                The Importance of Cryptography

                - Privacy and confidentiality
                - Authentication
                - Nonrepudiation";
            }
            else if (topic == "Wi-Fi Security")
            {
                rtbContent.Text = @"WHAT IS WI-FI SECURITY?

                Wi-Fi security is the protection of devices and networks connected in a wireless environment. Without Wi-Fi security, a networking device such as a wireless access point or a router can be accessed by anyone using a computer or mobile device within range of the router's wireless signal.

                How unsecured wi-fi networks create risk
                When wireless devices in a network are ""open"" or unsecured, they're accessible to any Wi-Fi-enabled device, such as a computer or smartphone, that's within range of their wireless signals.

                Using open or unsecured networks can be risky for users and organizations. Adversaries using internet-connected devices can collect users' personal information and steal identities, compromise financial and other sensitive business data, ""eavesdrop"" on communications, and more.
                
                Ways to protect wi-fi network
                One basic best practice for Wi-Fi security is to change default passwords for network devices.

                Most devices feature default administrator passwords, which are meant to make setup of the devices easy. However, the default passwords created by device manufacturers can be easy to obtain online.
                
                Changing the default passwords for network devices to more-complex passwords—and changing them often—are simple but effective ways to improve Wi-Fi security. Following are other Wi-Fi network security methods:
                
                Media Access Control (MAC) addresses
                Another basic approach to Wi-Fi security is to use MAC addresses, which restrict access to a Wi-Fi network. A MAC address is a unique code or number used to identify individual devices on a network. While this tactic provides a higher measure of security than an open network, it is still susceptible to attack by adversaries using ""spoofed"" or modified addresses.
                
                Encryption
                A more common method of protecting Wi-Fi networks and devices is the use of security protocols that utilize encryption. Encryption in digital communications encodes data and then decodes it only for authorized recipients.
                
                There are several types of encryption standards in use today, including Wi-Fi Protected Access (WPA) and Wi-Fi Protected Access 2 (WPA2). See the section ""Types of wireless security protocols"" on this page for more details about these and other standards related to Wi-Fi security.
                
                Most newer network devices, such as access points and Wi-Fi routers, feature built-in wireless-security encryption protocols that provide Wi-Fi protection.
                
                Virtual private networks (VPNs)
                VPNs are another source of Wi-Fi network security. They allow users to create secure, identity-protected tunnels between unprotected Wi-Fi networks and the internet.
                
                A VPN can encrypt a user's internet connection. It also can conceal a user's IP address by using a virtual IP address it assigns to the user's traffic as it passes through the VPN server.
                
                Security software
                There are many types of consumer and enterprise software that also can provide Wi-Fi security. Some Wi-Fi protection software is bundled with related products, such as antivirus software. For more information about Wi-Fi security software, see the next question.";
            }
            else if (topic == "Data Privacy Laws")
            {
                rtbContent.Text = @"WHAT IS DATA PRIVACY?

                Data privacy, also called ""information privacy,"" is the principle that a person should have control over their personal data, including the ability to decide how organizations collect, store and use their data.

                Businesses regularly collect user data like email addresses, biometrics and credit card numbers. For organizations in this data economy, supporting data privacy means taking steps like obtaining user consent before processing data, protecting data from misuse and enabling users to actively manage their data.
                
                Many organizations have a legal obligation to uphold data privacy rights under laws like the General Data Protection Regulation (GDPR). Even in the absence of formal data privacy legislation, companies may benefit from adopting privacy measures. The same practices and tools that protect user privacy can defend sensitive data and systems from malicious hackers.

                the differences between data privacy and data security

                Data privacy and data security are distinct but related disciplines. Both are core components of a company's broader data governance strategy.

                Data privacy focuses on the individual rights of data subjects—that is, the users who own the data. For organizations, the practice of data privacy is a matter of implementing policies and processes that allow users to control their data in accordance with relevant data privacy regulations.
                
                Data security focuses on protecting data from unauthorized access and misuse. For organizations, the practice of data security is largely a matter of deploying controls to prevent hackers and insider threats from tampering with data.
                
                Data security reinforces data privacy by ensuring that only the right people can access personal data for the right reasons. Data privacy reinforces data security by defining the ""right people"" and ""right reasons"" for any set of data.";
            }
            else if (topic == "Ethical Hacking 101")
            {
                rtbContent.Text = @"WHAT IS ETHICAL HACKING

                Ethical hacking is the use of hacking techniques by friendly parties in an attempt to uncover, understand and fix security vulnerabilities in a network or computer system.

                Ethical hackers have the same skills and use the same tools and tactics as malicious hackers, but their goal is always to improve network security without harming the network or its users.
                
                In many ways, ethical hacking is like a rehearsal for real-world cyberattacks. Organizations hire ethical hackers to launch simulated attacks on their computer networks. During these attacks, the ethical hackers demonstrate how actual cybercriminals break into a network and the damage they could do once inside.
                
                The organization’s security analysts can use this information to eliminate vulnerabilities, strengthen security systems and protect sensitive data.
                
                The terms ""ethical hacking"" and ""penetration testing"" are sometimes used interchangeably. However, penetration tests are only one of the methods that ethical hackers use. Ethical hackers can also conduct vulnerability assessments, malware analysis and other information security services.
                
                Think Newsletter

                Ethical Hacker's Code of Ethics
                Ethical hackers follow a strict code of ethics to make sure their actions help rather than harm companies. Many organizations that train or certify ethical hackers, such as the International Council of E-Commerce Consultants (EC Council), publish their own formal written code of ethics. While stated ethics can vary among hackers or organizations, the general guidelines are:

                Ethical hackers get permission from the companies they hack: Ethical hackers are employed by or partnered with the organizations they hack. They work with companies to define a scope for their activities including hacking timelines, methods used and systems and assets tested. 
                Ethical hackers don't cause any harm: Ethical hackers don't do any actual damage to the systems they hack, nor do they steal any sensitive data they find. When white hats hack a network, they're only doing it to demonstrate what real cybercriminals might do. 
                Ethical hackers keep their findings confidential: Ethical hackers share the information they gather on vulnerabilities and security systems with the company—and only the company. They also assist the company in using these findings to improve network defenses.
                Ethical hackers work within the confines of the law: Ethical hackers use only legal methods to assess information security. They don't associate with black hats or participate in malicious hacks.";
            }
            else if (topic == "Incident Response")
            {
                rtbContent.Text = @"INCIDENT RESPONSE

                Incident response is the strategic, organized responsed an organization uses following a cyberattack. The response is executed according to planned procedures that seek to limit damage and repair breached vulnerabilities in systems.

                IT professionals use incident response plans to manage security incidents. Having a clearly defined incident response plan can limit attack damage, lower costs, and save time after a security breach.
                
                A cyberattack or data breach can cause huge damage to an organization, potentially affecting its customers, brand value, intellectual property, and time and resources. Incident response aims to reduce the damage an attack causes and help the organization recover as quickly as possible.

                Why Incident Response Planning Is Important
                With cyberattacks increasing in frequency, scale, and sophistication, an incident response plan plays an increasingly important role in organizations’ information security defense. It is vital for organizations to be fully prepared before an incident occurs to limit the success and damage of a potential attack and maximize their response.
                
                Cyberattacks can have a damaging effect on brand reputation, leading to an organization losing customers and suffering huge fines. Having a response plan in place and taking action based on the findings is vital to learning lessons and avoiding stringent punishments for suffering data loss.

                CSIRT: Computer Security Incident Response Team
                The computer or cybersecurity incident response team (CSIRT) is formed by the people responsible for leading or handling the response to an incident. The team is crucial to running incident response exercises, providing staff training, and maintaining security awareness.
                
                A CSIRT involves several core roles, which can be played by one or more people. These include senior and executive management, who are responsible for making critical decisions, and an incident manager, who ensures all actions are tracked and the incident is clearly documented, communicated to stakeholders, and escalated. 
                
                The CSIRT also includes leaders from customer service, human resources, legal, and public relations departments. It requires analysts, investigators, and IT infrastructure experts, who will typically be from an external organization, to explore, contain, and remediate the incident.";
            }
            else
            {
                rtbContent.Text = "Select a topic to begin reading.";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(currentUser);
            dashboard.Show();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Transparent;
        }
    }
}
