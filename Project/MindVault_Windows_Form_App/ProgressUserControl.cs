using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Windows.Forms;

namespace CyberAcademy
{
    public partial class ProgressUserControl : UserControl
    {
        public ProgressUserControl()
        {
            InitializeComponent();
        }

        private void ProgressUserControl_Load(object sender, EventArgs e)
        {
            GenerateActivityGrid();
            GenerateModuleList();
        }

        //  THIS IS THE MISSING LINK 
        // We call this function from the Dashboard every time you click "My Progress"
        public void RefreshProgress(string username)
        {
            //  PART 1: GET PROFILE INFO (Name & Class) 
            string fullName = "Unknown";
            string className = "Unknown";

            if (File.Exists("users.txt"))
            {
                string[] lines = File.ReadAllLines("users.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    // Check if this line is our user
                    // Format: username,password,fullname,class
                    if (parts.Length >= 4 && parts[0] == username)
                    {
                        fullName = parts[2];
                        className = parts[3];
                        break; // Found them!
                    }
                }
            }

            // Update Profile Labels
            // Ensure your labels are named lblProfileName and lblProfileClass
            lblProfileName.Text = "Name: " + fullName;
            lblProfileClass.Text = "Class: " + className;


            //  PART 2: GET SCORE & RANK 
            int currentScore = 0;

            if (File.Exists("quiz_scores.txt"))
            {
                string[] lines = File.ReadAllLines("quiz_scores.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    // Format: username|score|date
                    if (parts.Length >= 2 && parts[0] == username)
                    {
                        if (int.TryParse(parts[1], out int score))
                        {
                            currentScore = score;
                        }
                    }
                }
            }

            // Update Score UI
            lblHighScore.Text = currentScore.ToString() + " / 15";

            // Calculate Percentage for Bar and Rank
            int percentage = (int)((currentScore * 100.0) / 15.0);
            circularProgressBar1.Value = percentage;
            circularProgressBar1.Text = percentage + "%";
            circularProgressBar1.Invalidate();


            //  PART 3: THE 4 RANKS 
            string rank = "Unranked";
            Color rankColor = Color.Gray;

            if (percentage >= 90)
            {
                rank = "CYBER ELITE 👑";
                rankColor = Color.Gold;
            }
            else if (percentage >= 70)
            {
                rank = "SPECIALIST 🛡️";
                rankColor = Color.Cyan;
            }
            else if (percentage >= 40)
            {
                rank = "APPRENTICE ⚔️";
                rankColor = Color.LightGreen;
            }
            else
            {
                rank = "NOVICE 👶";
                rankColor = Color.Gray;
            }

            // Update Rank Label (Ensure label is named lblRank)
            lblRank.Text = "Rank: " + rank;
            lblRank.ForeColor = rankColor;
        }

        private void GenerateActivityGrid()
        {
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 364; i++)
            {
                Panel p = new Panel();
                p.Margin = new Padding(1);
                p.Dock = DockStyle.Fill;
                Random rnd = new Random(i);
                int activityLevel = rnd.Next(0, 10);

                if (activityLevel > 8) p.BackColor = Color.FromArgb(57, 211, 83);
                else if (activityLevel > 6) p.BackColor = Color.FromArgb(14, 68, 41);
                else p.BackColor = Color.FromArgb(22, 27, 34);

                tableLayoutPanel1.Controls.Add(p);
            }
        }

        private void GenerateModuleList()
        {
            flpModules.Controls.Clear();
            string[] moduleNames = {
                "1. Introduction to Phishing", "2. Password Security",
                "3. Social Engineering", "4. Malware Analysis",
                "5. Network Defense", "6. Cryptography Basics",
                "7. Wi-Fi Security", "8. Data Privacy Laws",
                "9. Ethical Hacking 101", "10. Incident Response"
            };

            int modulesCompletedCount = 5;

            for (int i = 0; i < moduleNames.Length; i++)
            {
                string module = moduleNames[i];
                Panel card = new Panel();
                card.Size = new Size(flpModules.Width - 25, 50);
                card.BackColor = Color.FromArgb(200, 172, 214);
                card.Margin = new Padding(0, 0, 0, 5);

                Label lbl = new Label();
                lbl.Text = module;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 10);
                lbl.AutoSize = true;
                lbl.Location = new Point(10, 15);

                Label lblStatus = new Label();
                if (i < modulesCompletedCount)
                {
                    lblStatus.Text = "✅ Done";
                    lblStatus.ForeColor = Color.LightGreen;
                }
                else
                {
                    lblStatus.Text = "🔒 Undone";
                    lblStatus.ForeColor = Color.Red;
                }
                lblStatus.AutoSize = true;
                lblStatus.Location = new Point(card.Width - 80, 15);

                card.Controls.Add(lbl);
                card.Controls.Add(lblStatus);
                flpModules.Controls.Add(card);
            }
        }

        private void flpModules_Resize(object sender, EventArgs e)
        {
            foreach (Control card in flpModules.Controls)
            {
                card.Width = flpModules.Width - 25;
            }
        }
        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}