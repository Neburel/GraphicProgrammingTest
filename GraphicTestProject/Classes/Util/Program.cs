using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicTestProject
{
    enum Error
    {
        okay, fileSystemExistingError
    }
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadGraphicObjectXML loadGraphicObjectXML = null; 
            try
            {
                loadGraphicObjectXML = new LoadGraphicObjectXML();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception----------------------------------");
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("-------------------------------------");
                return;
            }
            List<GraphicObjects> gobjcets = loadGraphicObjectXML.GraphiObjects;
            if(gobjcets.Count <= 0)
            {
                System.Console.WriteLine("To Low Elements");
                return;
            }
            
            DrawFormSimpleAnimation(loadGraphicObjectXML.GraphiObjects);
            //DrawFormTestPaintEvent();
        }

        static void DrawFormSimpleAnimation(List<GraphicObjects> objects)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSimpleAnimation(objects));
        }

        static void DrawFormTestPaintEvent()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTestPaintEvent());
        }
    }
}
