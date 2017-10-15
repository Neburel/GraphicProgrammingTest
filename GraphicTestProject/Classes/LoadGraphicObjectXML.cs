using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Collections;

namespace GraphicTestProject
{

    class LoadGraphicObjectXML
    {
        private String ressourcePath;
        private String[] files;

        private List<GraphicObjects> graphicObjects;

        public LoadGraphicObjectXML()  
        {
            if (getFilestoLoad() != Error.okay)
            {
                throw new Exception("Fehler Beim Laden der GraphicObject Dateien");
            }

            graphicObjects = new List<GraphicObjects>();

            for(int i=0; i<files.Length; i++)
            {
                loadFile(files[i]);
            }
        }
        public List<GraphicObjects> GraphiObjects
        {
            set
            {
                graphicObjects = value;
            }
            get
            {
                return graphicObjects;
            }
        }
        private Error getFilestoLoad()
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @"Ressouces\GraphicObjects"; ;
            String completePath = Path.Combine(directoryPath, destinationPath);

            DirectoryInfo graphicObjectsDirectory = new DirectoryInfo(completePath);
            if (!(graphicObjectsDirectory.Exists))
            {
                Console.WriteLine("Directory Path:  " + directoryPath);
                Console.WriteLine("destinationPath: " + destinationPath);
                Console.WriteLine("Path Info:   " + completePath);
                return Error.fileSystemExistingError;
            }

            ressourcePath = completePath;
            files = Directory.GetFileSystemEntries(completePath, "*.xml");

            for(int i=0; i<files.Length; i++)
            {
                Console.WriteLine(files[i]);
            }
            
            return Error.okay;
        }
        private Error loadFile(String fileName)
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(fileName);

            String type = null;
            Color color  = Color.Red;
            SolidBrush color_brush = null;
            int width = 0;
            int hight = 0;
            String startDirection = null;
            Direction startMovingDirection;
            String[] startPosition = null;

            //Read the tags out of the File in Strings
            while (reader.Read())
            {
                if (reader.IsEmptyElement)
                {
                    //damit weniger Überprüfungen Stattfinden müssen...
                }
                else 
                {
                    switch(reader.Name){
                        case "Type": type = (reader.ReadString()).ToLower(); break;
                        case "Color": color = Color.FromName(reader.ReadString().ToLower()); break;
                        case "Width": width = Int32.Parse(reader.ReadString()); break;
                        case "Hight": hight = Int32.Parse(reader.ReadString()); break;
                        case "StartDirection": startDirection = (reader.ReadString()).ToLower(); break;
                        case "StartPosition": startPosition = (reader.ReadString()).ToLower().Split(','); break;
                    }
                }
            }

            //Interpret the tags
            int start_x = Int32.Parse(startPosition[0]);
            int start_y = Int32.Parse(startPosition[1]);

            color_brush = new SolidBrush(color);

            switch (startDirection)
            {
                case "up": startMovingDirection = Direction.Up; break;
                case "down": startMovingDirection = Direction.Down; break;
                case "left": startMovingDirection = Direction.Left; break;
                case "right": startMovingDirection = Direction.Right; break;
                case "upleft": startMovingDirection = Direction.Up_Left; break;
                case "upright": startMovingDirection = Direction.Up_Right; break;
                case "downleft": startMovingDirection = Direction.Down_Left; break;
                case "downright": startMovingDirection = Direction.Down_Right; break;
                default: startMovingDirection = Direction.Down; break;
            }

            //Construct the new Graphic Object
            GraphicObjects gobject = null;

            switch (type)
            {
                case "rectangle":
                    gobject = new GraphicObjectRectangle(start_x, start_y, width, hight, startMovingDirection, color_brush);
                    break;
                case "ellipse":
                    gobject = new GraphicObjectEllipse(start_x, start_y, width, hight, startMovingDirection, color_brush);
                    break;
            }


            if (gobject != null)
            {
                graphicObjects.Add(gobject);
            }


            return Error.okay;
        }

        
    }
   
}
