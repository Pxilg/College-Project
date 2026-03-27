using System;
using System.Collections.Generic;
using System.Drawing; // needed for changing button colors
using System.Windows.Forms;
using System.IO; // needed for file saving

namespace CyberAcademy
{
    public partial class Quiz : Form
    {
        // global variables to keep track of the game
        int currentQuestionIndex = 0;
        int score = 0;
        string username;
        bool isReviewing = false; // this tells us if we are taking the quiz or reviewing the answers

        // simple class to hold our question info
        class QuestionData
        {
            public string Text { get; set; }
            public string[] Answers { get; set; }
            public int CorrectIndex { get; set; }
            public int UserChoice { get; set; } = -1; // -1 means they haven't picked anything yet
        }

        // list to store all our questions
        List<QuestionData> questions = new List<QuestionData>();

        public Quiz(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            currentQuestionIndex = 0;
            score = 0;
            isReviewing = false;

            // This code overrides the Designer to ensure the label is visible
            lblQuestion.Visible = true;
            lblQuestion.ForeColor = Color.White; 
            lblQuestion.AutoSize = false;        // Allow us to resize it
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter; // Center text

            // Manually place it below the "QUIZ" title
            lblQuestion.Location = new Point(0, 80);
            lblQuestion.Size = new Size(this.ClientSize.Width, 100); // Stretch across screen
            lblQuestion.BringToFront(); // Force it on top of everything else

            // ADD QUESTIONS 
            questions.Add(new QuestionData
            {
                Text = "What is the best way to handle your password?",
                Answers = new string[] { "Share it with friends", "Write it on a wall", "Keep it secret", "Post it on TikTok" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "What is a 'Computer Virus'?",
                Answers = new string[] { "A hardware bug", "Bad software that harms your PC", "Dust on the screen", "A broken keyboard" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "If you see a stranger's USB stick on the ground, you should:",
                Answers = new string[] { "Plug it in immediately", "Format it", "Leave it or give to IT", "See what photos are on it" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "Which password is the strongest?",
                Answers = new string[] { "123456", "password", "admin", "P@ssw0rd!23" },
                CorrectIndex = 3
            });

            questions.Add(new QuestionData
            {
                Text = "What does a padlock icon in the browser address bar mean?",
                Answers = new string[] { "The website is secure (HTTPS)", "The website is closed", "The internet is down", "You are locked out" },
                CorrectIndex = 0
            });

            questions.Add(new QuestionData
            {
                Text = "What is 'Spam'?",
                Answers = new string[] { "A type of meat", "Junk/Unwanted email", "A computer chip", "A fast internet speed" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "Why should you update your computer?",
                Answers = new string[] { "To change the color", "To fix security holes", "To make it slower", "To delete your files" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "What is the purpose of Antivirus software?",
                Answers = new string[] { "To make games faster", "To play music", "To detect and remove threats", "To cool down the PC" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "You get an email saying you won $1,000,000. It's likely:",
                Answers = new string[] { "Real money!", "A Phishing Scam", "A bank error", "Your lucky day" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "When you are done using a public computer, you should:",
                Answers = new string[] { "Just walk away", "Turn off the monitor", "Log out", "Leave your Facebook open" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "What is 'Two-Factor Authentication'?",
                Answers = new string[] { "Using two keyboards", "Logging in twice", "Using a password + a code", "Sharing accounts" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "Which of these is a web browser?",
                Answers = new string[] { "Microsoft Word", "Google Chrome", "Adobe Photoshop", "Calculator" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "Is it safe to use free public Wi-Fi for banking?",
                Answers = new string[] { "Yes, always", "No, it might be unsecure", "Only on Tuesdays", "Yes, if the signal is strong" },
                CorrectIndex = 1
            });

            questions.Add(new QuestionData
            {
                Text = "What does 'Backup' mean?",
                Answers = new string[] { "Walking backwards", "Deleting everything", "Saving a copy of your files", "Hacking a server" },
                CorrectIndex = 2
            });

            questions.Add(new QuestionData
            {
                Text = "Who is a 'Hacker'?",
                Answers = new string[] { "Someone who fixes hardware", "Someone who exploits computer systems", "A slow typist", "A video game character" },
                CorrectIndex = 1
            });

            // Start!
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            // get the current question from the list
            QuestionData q = questions[currentQuestionIndex];

            // update the labels and buttons
            lblQuestion.Text = "Q" + (currentQuestionIndex + 1) + ": " + q.Text;
            btnAns1.Text = "A. " + q.Answers[0];
            btnAns2.Text = "B. " + q.Answers[1];
            btnAns3.Text = "C. " + q.Answers[2];
            btnAns4.Text = "D. " + q.Answers[3];

            // reset colors back to white every time we change page
            ResetButtonColors();

            // if we are in review mode, we need to show the red/green colors
            if (isReviewing)
            {
                HighlightAnswers(q);

                // handle the next/prev buttons visibility
                btnPrev.Enabled = (currentQuestionIndex > 0);

                if (currentQuestionIndex < questions.Count - 1)
                {
                    btnNext.Visible = true;
                    btnFinish.Visible = false;
                }
                else
                {
                    // if it's the last page, show the finish button instead
                    btnNext.Visible = false;
                    btnFinish.Visible = true;
                }
            }
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            // SAFETY CHECK: If the sender is NOT a button, stop immediately.
            // This prevents the crash if you accidentally click a label.
            if (sender is Button clickedButton)
            {
                // 1. If reviewing, do nothing
                if (isReviewing) return;

                // 2. Identify which button was clicked
                int clickedIndex = -1;

                if (clickedButton == btnAns1) clickedIndex = 0;
                if (clickedButton == btnAns2) clickedIndex = 1;
                if (clickedButton == btnAns3) clickedIndex = 2;
                if (clickedButton == btnAns4) clickedIndex = 3;

                // 3. Logic: Check Answer
                if (clickedIndex == questions[currentQuestionIndex].CorrectIndex)
                {
                    score++;
                }

                // 4. Save & Next
                questions[currentQuestionIndex].UserChoice = clickedIndex;

                if (currentQuestionIndex < questions.Count - 1)
                {
                    currentQuestionIndex++;
                    LoadQuestion();
                }
                else
                {
                    CalculateScore();
                    StartReviewMode();
                }
            }
        }

        private void StartReviewMode()
        {
            isReviewing = true;
            currentQuestionIndex = 0; // go back to the start

            // SHOW SCORE 
            // Calculate raw count again just for display
            int correctCount = 0;
            foreach (var q in questions) if (q.UserChoice == q.CorrectIndex) correctCount++;

            // Update Label: "Score: 80% (12/15)"
            lblFinalScore.Text = "Score: " + correctCount + " / 15";
            lblFinalScore.Visible = true; // make sure it's visible


            // 2. Determine Pass (Green) or Fail (Red)
            if (score >= 10)
            {
                lblStatus.Text = "PASS";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "FAIL";
                lblStatus.ForeColor = Color.Red;
            }
            lblStatus.Visible = true; // Show the badge!
            lblStatus.BringToFront(); // Ensure it's on top

            MessageBox.Show($"Quiz Completed!\nYour Score: {score}/{questions.Count}\n\nEntering Review Mode...", "Result");

            // show the navigation controls
            btnPrev.Visible = true;
            btnNext.Visible = true;

            // reload the page to see the colors
            LoadQuestion();
        }

        private void HighlightAnswers(QuestionData q)
        {
            // 1. CORRECT ANSWER (Green)
            if (q.CorrectIndex == 0) { btnAns1.BackColor = Color.LawnGreen; btnAns1.Invalidate(); }
            if (q.CorrectIndex == 1) { btnAns2.BackColor = Color.LawnGreen; btnAns2.Invalidate(); }
            if (q.CorrectIndex == 2) { btnAns3.BackColor = Color.LawnGreen; btnAns3.Invalidate(); }
            if (q.CorrectIndex == 3) { btnAns4.BackColor = Color.LawnGreen; btnAns4.Invalidate(); }

            // 2. WRONG ANSWER (Red)
            if (q.UserChoice != q.CorrectIndex)
            {
                if (q.UserChoice == 0) { btnAns1.BackColor = Color.Salmon; btnAns1.Invalidate(); }
                if (q.UserChoice == 1) { btnAns2.BackColor = Color.Salmon; btnAns2.Invalidate(); }
                if (q.UserChoice == 2) { btnAns3.BackColor = Color.Salmon; btnAns3.Invalidate(); }
                if (q.UserChoice == 3) { btnAns4.BackColor = Color.Salmon; btnAns4.Invalidate(); }
            }
        }

        private void ResetButtonColors()
        {
            // simple reset back to white
            btnAns1.BackColor = Color.MediumSlateBlue;
            btnAns2.BackColor = Color.MediumSlateBlue;
            btnAns3.BackColor = Color.MediumSlateBlue;
            btnAns4.BackColor = Color.MediumSlateBlue;
        }
        private void SaveQuizScore(int finalScore)
        {
            try
            {
                string filepath = "quiz_scores.txt";
                string date = DateTime.Now.ToString("dd-MM-yyyy");

                // Format: Dave|100|05-12-2025
                string dataLine = username + "|" + finalScore + "|" + date + Environment.NewLine;

                File.AppendAllText(filepath, dataLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving score: " + ex.Message);
            }
        }

        private void CalculateScore()
        {
            int correctCount = 0;
            foreach (var q in questions)
            {
                if (q.UserChoice == q.CorrectIndex) correctCount++;
            }

            // Save "5", "10", "15", etc.
            SaveQuizScore(correctCount);
        }

        // navigation button clicks

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                LoadQuestion();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                LoadQuestion();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblFinalScore_Click(object sender, EventArgs e)
        {

        }


    }
}