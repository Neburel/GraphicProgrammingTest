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
using GraphicTestProject.Classes.Data;

namespace GraphicTestProject
{
    public partial class FormSimpleAnimation : Form
    {
        // TODO: Verwaltungsklasse

        // Grafikobjekte
        private List<GraphicObjects> gobjects;
        private GraphicObjects player_graph; // -> Graf. Darst. des Spielers, sollte übrig bleiben wenn Verwaltungsklasse erstellt wird

        private int formHeight;
        private int formWidth;

        // Datenobjekte
        private Player player_obj; // -> Verschwindet später in Verwaltungsklasse

        //Nötige Variablen für FPS funktionalität
        private FPS fps;
        private Label fpslbl;

        public FormSimpleAnimation(List<GraphicObjects> objects)
        {
            //Set Styles for Painting without "Flackern"
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //Initate the Displayed Objects and the Player
            gobjects = new List<GraphicObjects>(objects);
            player_graph = gobjects[0];
            gobjects.RemoveAt(0);
            //Initialate the Form
            InitializeComponent();
            //Führt das SizeChanged Commando Zur Initalisierung der Labels und ihrer Beschriftung durch (ALternative: Labels Direkt Angeben was sie am Anfang machen sollen)
            //Entfernung des Ursprünglichen Codes zur Verhinderung von Code Duplezierung
            FormSimpleAnimation_SizeChanged(null, null);
            //Starte FPS_display
            fps_display_start(lblFPS);
            //Random Change the Direction of Objects
            randomDirectionChangeTimerforRandomObject();

            // Datenobjekte initialisieren
            player_obj = new Player(0, "Spieler");
            writePlayerHp(player_obj.Hp);
        }
        private void FormSpimpleAnimation_Paint(object sender, PaintEventArgs e)
        {
            foreach(GraphicObjects gobject in gobjects)
            {
                gobject.drawGraphicObject(e.Graphics);
            }
            player_graph.drawGraphicObject(e.Graphics);
        }
        private void FormSimpleAnimation_KeyDown(object sender, KeyEventArgs e)
        {
            // Test: Spieler verliert HP beim bewegen
            if (e.KeyCode == Keys.Left)
            {
                loseHp();
                player_graph.move(-10, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                loseHp();
                player_graph.move(+10, 0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                loseHp();
                player_graph.move(0, -10);
            }
            else if (e.KeyCode == Keys.Down)
            {
                loseHp();
                player_graph.move(0, +10);
            }
        }
        private void loseHp()
        {
            player_obj.Hp = player_obj.Hp - 1;
        }

        private void FormSimpleAnimation_Load(object sender, EventArgs e)
        {
            Timer myTimer = new Timer();
            myTimer.Interval = 20;
            myTimer.Tick += new EventHandler(tmrMoving_Tick);
            myTimer.Start();

        }
        /// <summary>
        /// Handles the SizeChanged event of the FormSimpleAnimation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
        private void fps_display_start(Label displaylbl)
        {
            fpslbl = displaylbl;
            fps = new FPS();

            Timer directionTimer = new Timer();
            directionTimer.Interval = 1000;
            directionTimer.Tick += new EventHandler(fps_display);
            directionTimer.Start();
        }
        private void fps_display(object sender, EventArgs e)
        {
            fpslbl.Text = fps.GetFps().ToString();
        }
        private void tmrMoving_Tick(object sender, EventArgs e)
        {
            foreach (GraphicObjects gobject in gobjects)
            {
                gobject.moveGraphicObject(formHeight, formWidth);
            }
            if (fps != null)
            {
                fps.OnMapUpdated();
            }
            writePlayerHp(player_obj.Hp);
            this.Refresh();
        }

        // Public Classes
        internal void writePlayerHp(int hp)
        {
            lbl_playerhp.Text = hp.ToString();
        }
    }
}
