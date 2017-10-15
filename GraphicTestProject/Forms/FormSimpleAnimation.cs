using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace GraphicTestProject
{
    public partial class FormSimpleAnimation : Form
    {
        private List<GraphicObjects> gobjects;
        private GraphicObjects player;
        private FPS fps;

        private int formHeight;
        private int formWidth;

        public FormSimpleAnimation(List<GraphicObjects> objects)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            formHeight = this.ClientSize.Height;
            formWidth = this.ClientSize.Width;

            label_SizeFormHigh.Text = formHeight.ToString();
            label_SizeFormWidth.Text = formWidth.ToString();

            gobjects = new List<GraphicObjects>(objects);

            Timer directionTimer = new Timer();
            directionTimer.Interval = 1000;
            directionTimer.Tick += new EventHandler(show_fps);
            directionTimer.Start();

            player = gobjects[0];
            gobjects.RemoveAt(0);

            fps = new FPS();

            randomDirectionChangeTimerforRandomObject();
        }
        private void FormSpimpleAnimation_Paint(object sender, PaintEventArgs e)
        {
            foreach(GraphicObjects gobject in gobjects)
            {
                gobject.drawGraphicObject(e.Graphics);
            }
            player.drawGraphicObject(e.Graphics);
        }
        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            foreach (GraphicObjects gobject in gobjects)
            {
                gobject.moveGraphicObject(formHeight, formWidth);
            }
            fps.OnMapUpdated();
            this.Refresh();
        }
        private void FormSimpleAnimation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.move(-10, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                player.move(+10, 0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                player.move(0, -10);
            }
            else if (e.KeyCode == Keys.Down)
            {
                player.move(0, +10);
            }
        }
        private void FormSimpleAnimation_Load(object sender, EventArgs e)
        {
            Timer myTimer = new Timer();
            myTimer.Interval = 20;
            myTimer.Tick += new EventHandler(tmrMoving_Tick);
            myTimer.Start();

        }
        private void FormSimpleAnimation_SizeChanged(object sender, EventArgs e)
        {
            formHeight = this.ClientSize.Height;
            formWidth = this.ClientSize.Width;

            label_SizeFormHigh.Text = formHeight.ToString();
            label_SizeFormWidth.Text = formWidth.ToString();
        }
        private void randomDirectionChangeTimerforRandomObject()
        {
            Timer directionTimer = new Timer();
            directionTimer.Interval = 500;
            directionTimer.Tick += new EventHandler(randomDirectionChangeForRandomObject);
            directionTimer.Start();
        }
        private void randomDirectionChangeForRandomObject(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            int countObjects = gobjects.Count();


            randomDirectionChangeForRandomObject(rnd1.Next(countObjects));
        }
        private void randomDirectionChangeForRandomObject(int objectNumber)
        {
            //Chance for 
            //New Direction
            Random rnd1 = new Random();
            int countDirections = Enum.GetNames(typeof(Direction)).Length;
            gobjects[objectNumber].MovingDirection = (Direction)rnd1.Next(countDirections); 
        }
        private void show_fps(object sender, EventArgs e)
        {
            lblFPS.Text = fps.GetFps().ToString();
        }

    }
}
