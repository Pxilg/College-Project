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
using System.IO;

namespace CyberAcademy
{
    public partial class Loginbtn : Form
    {
        public Loginbtn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = RecolorImage(pictureBox1.Image, Color.White);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputUser = Usertxt.Text;
            string inputPass = Passtxt.Text;
            bool loginSuccessful = false;
            string foundRealName = inputUser;

            // 1. Check if the database file exists
            if (File.Exists("users.txt"))
            {
                string[] allUsers = File.ReadAllLines("users.txt");

                foreach (string line in allUsers)
                {
                    // Format: username,password,fullname,class
                    string[] parts = line.Split(',');

                    // FIX: Check for at least 2 parts (Username & Password are at index 0 and 1)
                    if (parts.Length >= 2)
                    {
                        string savedUser = parts[0];
                        string savedPass = parts[1];

                        if (savedUser == inputUser && savedPass == inputPass)
                        {
                            loginSuccessful = true;

                            // Optional: If name exists (index 2), use it for the welcome message!
                            if (parts.Length >= 3) foundRealName = parts[2];

                            break;
                        }
                    }
                }
            }

            // 2. Master Admin Backup (Always works, even if file is missing)
            if (inputUser == "admin" && inputPass == "1234")
            {
                loginSuccessful = true;
            }

            // 3. Final Result
            if (loginSuccessful)
            {
                MessageBox.Show("Login Successful!", "Welcome");
                Dashboard dash = new Dashboard(inputUser);
                dash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Access Denied");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // link to register form
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            // Make it slightly bigger or brighter
            btnExit.Size = new Size(105, 80);
            btnExit.Location = new Point(btnExit.Location.X - 2, btnExit.Location.Y - 2); // Adjust position to keep centered
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            // Reset to normal
            btnExit.Size = new Size(95, 70); 
            btnExit.Location = new Point(btnExit.Location.X + 2, btnExit.Location.Y + 2);
        }
    }
}
