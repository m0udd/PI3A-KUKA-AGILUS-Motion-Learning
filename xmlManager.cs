using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDx.TDxInput;
using NLX.Robot.Kuka.Controller;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ConsoleApplication1
{
    class xmlManager
    {
        public struct target {
            public int x, y, z, a, b, c;
            public bool gripperState;
        };

        public XmlDocument LoadDocument(String path)
        {
            XmlDocument document = new XmlDocument();
            using (StreamReader stream = new StreamReader(path, Encoding.GetEncoding("iso-8859-7")))
            {
                document.Load(stream);

            }
            return (document);
        }


        public XmlDocument SaveDocument(XmlDocument document, String path)
        {
            using (StreamWriter stream = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-7")))
            {
                document.Save(stream);
            }
            return (document);
        }
        public void writePoint(target Target)
        {
            /*// Create a new file in C:\\ dir
            StreamWriter textWriter = new StreamWriter("xmlmanager.xml", true);
            Console.WriteLine("File created");
            // Opens the document
            /*textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Point");
                textWriter.WriteStartElement("x");
                    textWriter.WriteString(Target.x.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("y");
                    textWriter.WriteString(Target.y.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("z");
                    textWriter.WriteString(Target.z.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("a");
                    textWriter.WriteString(Target.a.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("b");
                    textWriter.WriteString(Target.b.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("c");
                    textWriter.WriteString(Target.c.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("StateGripper");
                    textWriter.WriteString(Target.gripperState.ToString());
                textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();

            Console.WriteLine("Writing ended");
            System.Threading.Thread.Sleep(2000);*/

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("xmlmanager.xml");

            // Create a new element node.
            XmlNode newElem = doc.CreateNode("element", "pages", "");
            newElem.InnerText = "290";

            Console.WriteLine("Add the new element to the document...");
            XmlElement root = doc.DocumentElement;
            root.AppendChild(newElem);

            Console.WriteLine("Display the modified XML document...");
            Console.WriteLine(doc.OuterXml);

            System.Threading.Thread.Sleep(10000);


        }

        public List<target> readPoint()
        {
            List<target> targetList = new List<target>();

            XmlTextReader textReader = new XmlTextReader("xmlmanager.xml");
            textReader.Read();
            // If the node has value
            while (textReader.Read())
            {
                // Move to fist element
                textReader.MoveToElement();
                // Read this element's properties and display them on console
                Console.WriteLine("Point:" + textReader.Name);
                Console.WriteLine("Base URI:" + textReader.BaseURI);
                Console.WriteLine("Local Name:" + textReader.LocalName);
                Console.WriteLine("Attribute Count:" + textReader.AttributeCount.ToString());
                Console.WriteLine("Depth:" + textReader.Depth.ToString());
                Console.WriteLine("Line Number:" + textReader.LineNumber.ToString());
                Console.WriteLine("Node Type:" + textReader.NodeType.ToString());
                Console.WriteLine("Attribute Count:" + textReader.Value.ToString());
            }

            return targetList;
        } 
    }
}
