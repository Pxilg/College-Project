using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // Needed for the logo fix
using System.IO;              // Needed for file saving

namespace CyberAcademy
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // --- LOAD EVENT: FIX THE LOGO COLOR ---
        private void Register_Load(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Invert logo to White so it shows on dark background
                pictureBox1.Image = RecolorImage(pictureBox1.Image, Color.White);
            }

            // Optional: Set defaults for ComboBox
            if (cmbClass.Items.Count > 0) cmbClass.SelectedIndex = 0;
        }

        // --- REGISTER BUTTON CLICK ---
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Get Values from UI
            // Note: Make sure your textboxes are named exactly like this in Design View!
            string user = RegUsertxt.Text;
            string pass = RegPasstxt.Text;
            string conf = RegPassConfirmtxt.Text;
            string fullName = txtFullName.Text; // New Field
            string className = cmbClass.Text;   // New Field

            // 2. Validation
            if (pass != conf)
            {
                MessageBox.Show("Passwords do not match!", "Error");
                return;
            }

            if (user == "" || pass == "" || fullName == "" || className == "")
            {
                MessageBox.Show("Please fill in all fields (Name, Class, User, Pass).", "Error");
                return;
            }

            // 3. Save Logic (New Format: user,pass,name,class)
            try
            {
                string newUserLine = user + "," + pass + "," + fullName + "," + className + Environment.NewLine;

                // Write to file
                File.AppendAllText("users.txt", newUserLine);

                MessageBox.Show("Account Created Successfully!", "Success");

                // 4. Redirect to Login
                this.Hide();
                Loginbtn login = new Loginbtn();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
            }
        }

        // --- BACK BUTTON ---
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginbtn login = new Loginbtn();
            login.Show();
        }

        // --- HELPER: INVERT IMAGE COLOR ---
        private Image RecolorImage(Image originalImage, Color newColor)
        {
            Bitmap newBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {newColor.R/255f, newColor.G/255f, newColor.B/255f, 0, 1}
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(originalImage,
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }

        // Unused events (safe to leave empty)
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}