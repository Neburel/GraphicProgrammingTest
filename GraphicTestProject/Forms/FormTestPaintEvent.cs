using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicTestProject
{
    public partial class FormTestPaintEvent : Form
    {
        private Rectangle RcDraw;
        private float PenWidth = 5;

        public FormTestPaintEvent()
        {
            InitializeComponent();
        }

        private void FormTestPaintEvent_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
        }

        private void FormTestPaintEvent_MouseUp(object sender, MouseEventArgs e)
        {
            // Determine the width and height of the rectangle...
            if (e.X < RcDraw.X)
            {
                RcDraw.Width = RcDraw.X - e.X;
                RcDraw.X = e.X;
            }else{
                RcDraw.Width = e.X - RcDraw.X;
            }

            if (e.Y < RcDraw.Y)
            {
                RcDraw.Height = RcDraw.Y - e.Y;
                RcDraw.Y = e.Y;
            }else{
                RcDraw.Height = e.Y - RcDraw.Y;
            }

            // Force a repaint of the region occupied by the rectangle...
            this.Invalidate(RcDraw);
        }

        private void FormTestPaintEvent_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            e.Graphics.DrawRectangle(new Pen(Color.Blue, PenWidth), RcDraw);
        }
    }
}
