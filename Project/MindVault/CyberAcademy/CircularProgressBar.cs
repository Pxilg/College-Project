using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CyberAcademy
{
    public class CircularProgressBar : Control
    {
        // Settings
        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.Invalidate(); // Make sure the quiz value changes
            }
        }
        public int Maximum { get; set; } = 100;
        public int LineWidth { get; set; } = 10;
        public Color ProgressColor { get; set; } = Color.FromArgb(57, 211, 83); // Green
        public Color BaseColor { get; set; } = Color.FromArgb(40, 40, 70); 

        public CircularProgressBar()
        {
            this.Size = new Size(150, 150);
            this.DoubleBuffered = true;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 20, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Draw Background Ring (The Track)
            using (Pen penBase = new Pen(BaseColor, LineWidth))
            {
                penBase.StartCap = LineCap.Round;
                penBase.EndCap = LineCap.Round;
                // Draw full circle (minus a bit for the cap style)
                e.Graphics.DrawArc(penBase, LineWidth, LineWidth, this.Width - 2 * LineWidth, this.Height - 2 * LineWidth, 0, 360);
            }

            // 2. Draw Progress Ring (The Value)
            using (Pen penProgress = new Pen(ProgressColor, LineWidth))
            {
                penProgress.StartCap = LineCap.Round;
                penProgress.EndCap = LineCap.Round;

                // Calculate angle (Value / Max * 360 degrees)
                float angle = (float)Value / Maximum * 360;

                // Draw the arc starting from -90 (Top)
                if (Value > 0)
                {
                    e.Graphics.DrawArc(penProgress, LineWidth, LineWidth, this.Width - 2 * LineWidth, this.Height - 2 * LineWidth, -90, angle);
                }
            }

            // 3. Draw Text in the Middle
            string text = Value.ToString() + "%"; // Or just the number
            SizeF textSize = e.Graphics.MeasureString(text, this.Font);
            PointF textLocation = new PointF((this.Width - textSize.Width) / 2, (this.Height - textSize.Height) / 2);

            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(text, this.Font, textBrush, textLocation);
            }
        }
    }
}