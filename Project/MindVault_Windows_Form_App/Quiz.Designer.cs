namespace CyberAcademy
{
    partial class Quiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quiz));
            this.lblQuestion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinish = new CyberAcademy.RoundedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAns1 = new CyberAcademy.RoundedButton();
            this.btnAns2 = new CyberAcademy.RoundedButton();
            this.btnAns3 = new CyberAcademy.RoundedButton();
            this.btnAns4 = new CyberAcademy.RoundedButton();
            this.gradientPanel1 = new CyberAcademy.GradientPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.lblQuestion.Location = new System.Drawing.Point(3, 138);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(1766, 124);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question here";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuestion.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(812, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 62);
            this.label1.TabIndex = 5;
            this.label1.Text = "QUIZ";
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(1287, 140);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(161, 58);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Visible = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(1497, 140);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(161, 58);
            this.btnNext.TabIndex = 7;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Location = new System.Drawing.Point(1032, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(152, 86);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "PASS";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.lblFinalScore.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.lblFinalScore.Location = new System.Drawing.Point(1233, 24);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(258, 41);
            this.lblFinalScore.TabIndex = 11;
            this.lblFinalScore.Text = "Score: 0/15";
            this.lblFinalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFinalScore.Visible = false;
            this.lblFinalScore.Click += new System.EventHandler(this.lblFinalScore_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.panel1.Controls.Add(this.btnFinish);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblFinalScore);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1765, 97);
            this.panel1.TabIndex = 12;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnFinish.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFinish.BorderRadius = 20;
            this.btnFinish.BorderSize = 0;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(1588, 30);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(150, 40);
            this.btnFinish.TabIndex = 22;
            this.btnFinish.Text = "FINISH";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(35)))), ((int)(((byte)(108)))));
            this.panel2.Controls.Add(this.lblQuestion);
            this.panel2.Location = new System.Drawing.Point(-1, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1765, 335);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 1013);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1765, 97);
            this.panel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(233)))), ((int)(((byte)(227)))));
            this.label2.Location = new System.Drawing.Point(483, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(799, 50);
            this.label2.TabIndex = 18;
            this.label2.Text = "\"The unexamined life is not worth living.\" - Socrates";
            // 
            // btnAns1
            // 
            this.btnAns1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAns1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAns1.BorderRadius = 20;
            this.btnAns1.BorderSize = 0;
            this.btnAns1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAns1.FlatAppearance.BorderSize = 0;
            this.btnAns1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAns1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAns1.ForeColor = System.Drawing.Color.White;
            this.btnAns1.Location = new System.Drawing.Point(26, 473);
            this.btnAns1.Name = "btnAns1";
            this.btnAns1.Size = new System.Drawing.Size(815, 75);
            this.btnAns1.TabIndex = 18;
            this.btnAns1.Text = "Answer Button";
            this.btnAns1.UseVisualStyleBackColor = false;
            this.btnAns1.Click += new System.EventHandler(this.CheckAnswer);
            // 
            // btnAns2
            // 
            this.btnAns2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAns2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAns2.BorderRadius = 20;
            this.btnAns2.BorderSize = 0;
            this.btnAns2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAns2.FlatAppearance.BorderSize = 0;
            this.btnAns2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAns2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAns2.ForeColor = System.Drawing.Color.White;
            this.btnAns2.Location = new System.Drawing.Point(26, 596);
            this.btnAns2.Name = "btnAns2";
            this.btnAns2.Size = new System.Drawing.Size(815, 75);
            this.btnAns2.TabIndex = 19;
            this.btnAns2.Text = "Answer Button";
            this.btnAns2.UseVisualStyleBackColor = false;
            this.btnAns2.Click += new System.EventHandler(this.CheckAnswer);
            // 
            // btnAns3
            // 
            this.btnAns3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAns3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAns3.BorderRadius = 20;
            this.btnAns3.BorderSize = 0;
            this.btnAns3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAns3.FlatAppearance.BorderSize = 0;
            this.btnAns3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAns3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAns3.ForeColor = System.Drawing.Color.White;
            this.btnAns3.Location = new System.Drawing.Point(18, 719);
            this.btnAns3.Name = "btnAns3";
            this.btnAns3.Size = new System.Drawing.Size(815, 75);
            this.btnAns3.TabIndex = 20;
            this.btnAns3.Text = "Answer Button";
            this.btnAns3.UseVisualStyleBackColor = false;
            this.btnAns3.Click += new System.EventHandler(this.CheckAnswer);
            // 
            // btnAns4
            // 
            this.btnAns4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAns4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAns4.BorderRadius = 20;
            this.btnAns4.BorderSize = 0;
            this.btnAns4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAns4.FlatAppearance.BorderSize = 0;
            this.btnAns4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAns4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAns4.ForeColor = System.Drawing.Color.White;
            this.btnAns4.Location = new System.Drawing.Point(18, 842);
            this.btnAns4.Name = "btnAns4";
            this.btnAns4.Size = new System.Drawing.Size(815, 75);
            this.btnAns4.TabIndex = 21;
            this.btnAns4.Text = "Answer Button";
            this.btnAns4.UseVisualStyleBackColor = false;
            this.btnAns4.Click += new System.EventHandler(this.CheckAnswer);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.btnPrev);
            this.gradientPanel1.Controls.Add(this.btnNext);
            this.gradientPanel1.Location = new System.Drawing.Point(3, 719);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1762, 299);
            this.gradientPanel1.TabIndex = 22;
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1764, 1098);
            this.Controls.Add(this.btnAns4);
            this.Controls.Add(this.btnAns3);
            this.Controls.Add(this.btnAns2);
            this.Controls.Add(this.btnAns1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz";
            this.Load += new System.EventHandler(this.Quiz_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private RoundedButton btnFinish;
        private RoundedButton btnAns1;
        private RoundedButton btnAns2;
        private RoundedButton btnAns3;
        private RoundedButton btnAns4;
        private GradientPanel gradientPanel1;
    }
}