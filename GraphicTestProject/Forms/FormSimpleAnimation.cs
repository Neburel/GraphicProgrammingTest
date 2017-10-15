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
        
        private int formHeight;
        private int formWidth;

        public FormSimpleAnimation(List<GraphicObjects> objects)
        {
            InitializeComponent();

            formHeight = Size.Height;
            formWidth = Size.Width;

            label_SizeFormHigh.Text = formHeight.ToString();
            label_SizeFormWidth.Text = formWidth.ToString();

            gobjects = new List<GraphicObjects>(objects);

            foreach (GraphicObjects gobject in gobjects)
            {
                Console.WriteLine("Hallo");
            }

            randomDirectionChangeTimerforRandomObject();
        }
        private void FormSpimpleAnimation_Paint(object sender, PaintEventArgs e)
        {
            foreach(GraphicObjects gobject in gobjects)
            {
                gobject.drawGraphicObject(e.Graphics);
            }
        }
        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            foreach (GraphicObjects gobject in gobjects)
            {
                gobject.moveGraphicObject(formHeight, formWidth);
            }
            Invalidate();
        }
        private void FormSimpleAnimation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                gobjects[0].MovingDirection = Direction.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                gobjects[0].MovingDirection = Direction.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gobjects[0].MovingDirection = Direction.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                gobjects[0].MovingDirection = Direction.Down;
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
            formHeight = this.Size.Height;
            formWidth = this.Size.Width;

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

    }
}
