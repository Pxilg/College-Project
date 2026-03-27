using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CyberAcademy
{
    public partial class Dashboard : Form
    {
        private string currentUsername;
        public Dashboard(string username)
        {
            InitializeComponent();
            // When this window closes, it run the Dashboard_FormClosed function."
            this.FormClosed += Dashboard_FormClosed;

            this.currentUsername = username;

            this.FormClosed += Dashboard_FormClosed;
            label2.Text = "Welcome, " + username + "!"; 
        }

        private void Dashboard_FormClosed1(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // back to login screen
            Loginbtn login = new Loginbtn();
            login.Show();
            this.Hide();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = RecolorImage(pictureBox1.Image, Color.White);

            pnlCourseInfo.Height = 0;
            pnlQuizInfo.Height = 0;
            pnlProgressInfo.Height = 0;

            progressUserControl1.Visible = false;
        }

        // This function kills the hidden Login screen when you click 'X'
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            Materials mat = new Materials(this.currentUsername);
            mat.Show();
            this.Hide();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            Quiz quiz = new Quiz(this.currentUsername); //get the username from dashboard
            this.Hide();
            quiz.ShowDialog();
            this.Show();
        }
        private Image RecolorImage(Image originalImage, Color newColor)
        {
            // 1. Create a blank canvas the same size as the logo
            Bitmap newBitmap = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                // 2. Define the "Paint" logic (The Color Matrix)
                // This matrix says: "Ignore original colors, just keep the shape (Alpha), 
                // and fill it with the new color."
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] {0, 0, 0, 0, 0}, // Remove original Red
            new float[] {0, 0, 0, 0, 0}, // Remove original Green
            new float[] {0, 0, 0, 0, 0}, // Remove original Blue
            new float[] {0, 0, 0, 1, 0}, // Keep the Transparency (Alpha) exactly the same
            new float[] {newColor.R/255f, newColor.G/255f, newColor.B/255f, 0, 1} // Paint with New Color
                });

                // 3. Apply the settings
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                // 4. Draw the new painted image
                g.DrawImage(originalImage,
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Variable to track which panel *should* be open right now
        Panel activePanel = null;

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            // 1. Manage the Course Panel
            AnimatePanel(pnlCourseInfo);

            // 2. Manage the Quiz Panel
            AnimatePanel(pnlQuizInfo);

            // 3. Manage the Progress Panel
            AnimatePanel(pnlProgressInfo);

            // Optional: Stop timer if everything is settled to save CPU
            // (But keeping it running for this simple UI is fine and smoother)
        }

        // A Helper function to grow/shrink any panel
        private void AnimatePanel(Panel pnl)
        {
            int maxHeight = 863; // How tall you want them to be

            if (pnl == activePanel)
            {
                // OPEN IT: If this is the active one, grow it
                if (pnl.Height < maxHeight) pnl.Height += 20;
            }
            else
            {
                // CLOSE IT: If this is NOT the active one, shrink it
                if (pnl.Height > 0) pnl.Height -= 20;
            }
        }

        //  COURSES HOVER 
        private void btnCourses_MouseEnter(object sender, EventArgs e)
        {
            lblCourse.Text = @"ACCESS KNOWLEDGE BASE 
            
            Explore our comprehensive library of cybersecurity modules. From Phishing Defense to Network Security, these materials are designed to equip you with the theoretical foundation needed for the field.

            • Current Status: 10 Modules Available
            • Estimated Reading Time: 10 Minutes";

            activePanel = pnlCourseInfo; // Set Target
            tmrAnimation.Start();        // Start Engine
        }

        private void btnCourses_MouseLeave(object sender, EventArgs e)
        {
            // Only clear if we are leaving THIS button
            if (activePanel == pnlCourseInfo) activePanel = null;
        }

        //  QUIZ HOVER 
        private void btnQuiz_MouseEnter(object sender, EventArgs e)
        {
            lblQuiz.Text = @"SKILL ASSESMENT CENTER
        
            Challenge yourself with our rapid-fire security examinations. Test your recall on critical concept, instant feedback and detailed review modes are available upon completion

        • Difficulty: Beginner
        • Questions: 15 Randomized Scenarios";

            activePanel = pnlQuizInfo;
            tmrAnimation.Start();
        }

        private void btnQuiz_MouseLeave(object sender, EventArgs e)
        {
            if (activePanel == pnlQuizInfo) activePanel = null;
        }

        //  PROGRESS HOVER 
        private void btnProgress_MouseEnter(object sender, EventArgs e)
        {
            if(progressUserControl1.Visible == true)
            {
                return;
            }

            {
                progressUserControl1.Visible = false;
            }
            lblProgress.Text = @"ANALYTICS & PERFORMANCES
            
            Track your learning journey with real-time statistics. View your highest scores, completed modules, and currend certification readiness. Consistent practice i key to maintaining a high security clearance

            Regular review of your performance metrics is critical for identifying";

            activePanel = pnlProgressInfo;
            tmrAnimation.Start();
        }

        private void btnProgress_MouseLeave(object sender, EventArgs e)
        {
            if (activePanel == pnlProgressInfo) activePanel = null;
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            pnlCourseInfo.Height = 0;
            pnlQuizInfo.Height = 0;
            pnlProgressInfo.Height = 0;
            activePanel = null;

            // 1. Get the username
            string user = this.currentUsername;

            progressUserControl1.Visible = true;
            progressUserControl1.BringToFront();

            // Pass the safe username
            progressUserControl1.RefreshProgress(user);

            // Debugging Popup (Add this temporarily!)
            MessageBox.Show("Loading progress for: " + user);
        }

        private void lblDashboard_click(object sender, EventArgs e)
        {
            progressUserControl1.Visible = false;

            pnlCourseInfo.Height = 0;
            pnlQuizInfo.Height = 0;
            pnlProgressInfo.Height = 0;
            activePanel = null;
        }
    }
}