using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphPaths
{
    public class RoundButton : Button
    {

        private bool MouseEntered = false;
        private bool MousePressed = false;

        private StringFormat SF = new StringFormat();

        public RoundButton() {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint,
                true
            );

            DoubleBuffered = true;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Parent.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Rectangle rect = new Rectangle(1, 1, Width - 3, Height - 3);

            g.FillEllipse(new SolidBrush(BackColor), rect);
            g.DrawEllipse(new Pen(ForeColor, 3), rect);

            g.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);

            if (MouseEntered)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.Black)), rect);
            }
            if (MousePressed)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(80, Color.Black)), rect);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseEntered = true;

            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseEntered = false;
            MousePressed = false;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MousePressed = true;

            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MousePressed = false;

            Invalidate();
        }
    }
}
