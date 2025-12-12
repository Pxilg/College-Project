namespace CyberAcademy
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.lblDashboard = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlCourseInfo = new System.Windows.Forms.Panel();
            this.lblCourse = new System.Windows.Forms.Label();
            this.tmrAnimation = new System.Windows.Forms.Timer(this.components);
            this.pnlQuizInfo = new System.Windows.Forms.Panel();
            this.lblQuiz = new System.Windows.Forms.Label();
            this.pnlProgressInfo = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientPanel1 = new CyberAcademy.GradientPanel();
            this.btnMaterials = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProgress = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnQuiz = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressUserControl1 = new CyberAcademy.ProgressUserControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlCourseInfo.SuspendLayout();
            this.pnlQuizInfo.SuspendLayout();
            this.pnlProgressInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.lblDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Bold);
            this.lblDashboard.Location = new System.Drawing.Point(394, 14);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(214, 54);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(947, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "Welcome, username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(394, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1693, 80);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1294, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pnlCourseInfo
            // 
            this.pnlCourseInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.pnlCourseInfo.Controls.Add(this.lblCourse);
            this.pnlCourseInfo.Location = new System.Drawing.Point(480, 172);
            this.pnlCourseInfo.Name = "pnlCourseInfo";
            this.pnlCourseInfo.Size = new System.Drawing.Size(283, 863);
            this.pnlCourseInfo.TabIndex = 9;
            this.pnlCourseInfo.MouseEnter += new System.EventHandler(this.btnCourses_MouseEnter);
            this.pnlCourseInfo.MouseLeave += new System.EventHandler(this.btnCourses_MouseLeave);
            // 
            // lblCourse
            // 
            this.lblCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.lblCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.lblCourse.Location = new System.Drawing.Point(0, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Padding = new System.Windows.Forms.Padding(30, 20, 10, 10);
            this.lblCourse.Size = new System.Drawing.Size(283, 863);
            this.lblCourse.TabIndex = 0;
            this.lblCourse.Text = "label4";
            // 
            // tmrAnimation
            // 
            this.tmrAnimation.Interval = 15;
            this.tmrAnimation.Tick += new System.EventHandler(this.tmrAnimation_Tick);
            // 
            // pnlQuizInfo
            // 
            this.pnlQuizInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.pnlQuizInfo.Controls.Add(this.lblQuiz);
            this.pnlQuizInfo.Location = new System.Drawing.Point(932, 172);
            this.pnlQuizInfo.Name = "pnlQuizInfo";
            this.pnlQuizInfo.Size = new System.Drawing.Size(283, 863);
            this.pnlQuizInfo.TabIndex = 10;
            this.pnlQuizInfo.MouseEnter += new System.EventHandler(this.btnQuiz_MouseEnter);
            this.pnlQuizInfo.MouseLeave += new System.EventHandler(this.btnQuiz_MouseLeave);
            // 
            // lblQuiz
            // 
            this.lblQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.lblQuiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuiz.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.lblQuiz.Location = new System.Drawing.Point(0, 0);
            this.lblQuiz.Name = "lblQuiz";
            this.lblQuiz.Padding = new System.Windows.Forms.Padding(30, 20, 10, 10);
            this.lblQuiz.Size = new System.Drawing.Size(283, 863);
            this.lblQuiz.TabIndex = 0;
            this.lblQuiz.Text = "label4";
            // 
            // pnlProgressInfo
            // 
            this.pnlProgressInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.pnlProgressInfo.Controls.Add(this.lblProgress);
            this.pnlProgressInfo.Location = new System.Drawing.Point(1397, 172);
            this.pnlProgressInfo.Name = "pnlProgressInfo";
            this.pnlProgressInfo.Size = new System.Drawing.Size(283, 863);
            this.pnlProgressInfo.TabIndex = 11;
            this.pnlProgressInfo.MouseEnter += new System.EventHandler(this.btnProgress_MouseEnter);
            this.pnlProgressInfo.MouseLeave += new System.EventHandler(this.btnProgress_MouseLeave);
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.lblProgress.Location = new System.Drawing.Point(0, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Padding = new System.Windows.Forms.Padding(30, 20, 10, 10);
            this.lblProgress.Size = new System.Drawing.Size(283, 863);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "label4";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(370, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(25, 1099);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(326, 11);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(25, 1099);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(348, 11);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(25, 1099);
            this.flowLayoutPanel2.TabIndex = 8;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.gradientPanel1);
            this.panel1.Location = new System.Drawing.Point(-4, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 1113);
            this.panel1.TabIndex = 6;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(80)))), ((int)(((byte)(159)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(59)))));
            this.gradientPanel1.Controls.Add(this.btnMaterials);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.btnProgress);
            this.gradientPanel1.Controls.Add(this.btnExit);
            this.gradientPanel1.Controls.Add(this.lblAppName);
            this.gradientPanel1.Controls.Add(this.btnQuiz);
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Location = new System.Drawing.Point(3, 13);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(326, 1097);
            this.gradientPanel1.TabIndex = 13;
            // 
            // btnMaterials
            // 
            this.btnMaterials.BackColor = System.Drawing.Color.Transparent;
            this.btnMaterials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaterials.FlatAppearance.BorderSize = 0;
            this.btnMaterials.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.btnMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterials.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.btnMaterials.Image = global::CyberAcademy.Properties.Resources.icons8_study_100;
            this.btnMaterials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaterials.Location = new System.Drawing.Point(1, 172);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(391, 96);
            this.btnMaterials.TabIndex = 1;
            this.btnMaterials.Text = "            Courses";
            this.btnMaterials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaterials.UseVisualStyleBackColor = true;
            this.btnMaterials.Click += new System.EventHandler(this.btnMaterials_Click);
            this.btnMaterials.MouseEnter += new System.EventHandler(this.btnCourses_MouseEnter);
            this.btnMaterials.MouseLeave += new System.EventHandler(this.btnCourses_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Unlock the real potential.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnProgress
            // 
            this.btnProgress.BackColor = System.Drawing.Color.Transparent;
            this.btnProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProgress.FlatAppearance.BorderSize = 0;
            this.btnProgress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.btnProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgress.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.btnProgress.Image = global::CyberAcademy.Properties.Resources.icons8_progress_96;
            this.btnProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgress.Location = new System.Drawing.Point(3, 364);
            this.btnProgress.Name = "btnProgress";
            this.btnProgress.Size = new System.Drawing.Size(392, 96);
            this.btnProgress.TabIndex = 3;
            this.btnProgress.Text = "           My Progress";
            this.btnProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgress.UseVisualStyleBackColor = true;
            this.btnProgress.Click += new System.EventHandler(this.btnProgress_Click);
            this.btnProgress.MouseEnter += new System.EventHandler(this.btnProgress_MouseEnter);
            this.btnProgress.MouseLeave += new System.EventHandler(this.btnProgress_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.btnExit.Location = new System.Drawing.Point(0, 1035);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(395, 62);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Logout";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAppName.Location = new System.Drawing.Point(13, 21);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(129, 33);
            this.lblAppName.TabIndex = 8;
            this.lblAppName.Text = "MindVault";
            // 
            // btnQuiz
            // 
            this.btnQuiz.BackColor = System.Drawing.Color.Transparent;
            this.btnQuiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuiz.FlatAppearance.BorderSize = 0;
            this.btnQuiz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.btnQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuiz.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.btnQuiz.Image = global::CyberAcademy.Properties.Resources.icons8_quiz_100;
            this.btnQuiz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuiz.Location = new System.Drawing.Point(0, 268);
            this.btnQuiz.Name = "btnQuiz";
            this.btnQuiz.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnQuiz.Size = new System.Drawing.Size(392, 96);
            this.btnQuiz.TabIndex = 2;
            this.btnQuiz.Text = "           Quiz";
            this.btnQuiz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuiz.UseVisualStyleBackColor = true;
            this.btnQuiz.Click += new System.EventHandler(this.btnQuiz_Click);
            this.btnQuiz.MouseEnter += new System.EventHandler(this.btnQuiz_MouseEnter);
            this.btnQuiz.MouseLeave += new System.EventHandler(this.btnQuiz_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CyberAcademy.Properties.Resources.Untitled_design_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(137, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // progressUserControl1
            // 
            this.progressUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.progressUserControl1.Location = new System.Drawing.Point(392, 81);
            this.progressUserControl1.Name = "progressUserControl1";
            this.progressUserControl1.Size = new System.Drawing.Size(1372, 1019);
            this.progressUserControl1.TabIndex = 12;
            this.progressUserControl1.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1764, 1098);
            this.Controls.Add(this.pnlProgressInfo);
            this.Controls.Add(this.pnlQuizInfo);
            this.Controls.Add(this.pnlCourseInfo);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlCourseInfo.ResumeLayout(false);
            this.pnlQuizInfo.ResumeLayout(false);
            this.pnlProgressInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlCourseInfo;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Timer tmrAnimation;
        private System.Windows.Forms.Panel pnlQuizInfo;
        private System.Windows.Forms.Label lblQuiz;
        private System.Windows.Forms.Panel pnlProgressInfo;
        private System.Windows.Forms.Label lblProgress;
        private ProgressUserControl progressUserControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnQuiz;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}