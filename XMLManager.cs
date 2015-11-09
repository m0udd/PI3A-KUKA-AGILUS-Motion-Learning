using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Projet_Kuka
{
    class XMLManager
    {
        private string xmlPointPath = "listOfPoint.xml";

        public class Target
        {
            public double x, y, z, a, b, c;
            public bool gripperState;

            public Target()
            {
                x = y = z = a = b = c = 0;
                gripperState = false;
            }
        }

        public List<Target> GetAllPoints()
        {
            List<Target> targetList = new List<Target>();

            //Get the list
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPointPath);

            XmlNodeList elemList = doc.GetElementsByTagName("point");

            foreach (XmlNode nod in elemList)
            {
                Target tmp = new Target();
                tmp.x = float.Parse(nod.Attributes["x"].Value);
                tmp.y = float.Parse(nod.Attributes["y"].Value);
                tmp.z = float.Parse(nod.Attributes["z"].Value);
                tmp.a = float.Parse(nod.Attributes["a"].Value);
                tmp.b = float.Parse(nod.Attributes["b"].Value);
                tmp.c = float.Parse(nod.Attributes["c"].Value);
                if (Int32.Parse(nod.Attributes["gripperState"].Value) == 1)
                {
                    tmp.gripperState = true;
                }
                else
                {
                    tmp.gripperState = false;
                }

                targetList.Add(tmp);
            }

            return targetList;
        }


        public void addPoints(List<Target> targetList)
        {

            //Create file
            using (FileStream fs = new FileStream(xmlPointPath, FileMode.Create))
            {
                //Create XML skeleton
                XmlDocument doc = new XmlDocument();

                XmlElement listOfPoints = doc.CreateElement("ListeDesPoints");

                foreach (var target in targetList)
                {
                    XmlElement point = doc.CreateElement("point");
                    point.SetAttribute("x", target.x.ToString("0.00"));
                    point.SetAttribute("y", target.y.ToString("0.00"));
                    point.SetAttribute("z", target.z.ToString("0.00"));
                    point.SetAttribute("a", target.a.ToString("0.00"));
                    point.SetAttribute("b", target.b.ToString("0.00"));
                    point.SetAttribute("c", target.c.ToString("0.00"));
                    if (target.gripperState == true)
                    {
                        point.SetAttribute("gripperState", "1");
                    }
                    else
                    {
                        point.SetAttribute("gripperState", "0");
                    }

                    listOfPoints.AppendChild(point);
                }

                doc.AppendChild(listOfPoints);

                //Write to file
                byte[] info = new UTF8Encoding(true).GetBytes(doc.OuterXml);
                fs.Write(info, 0, info.Length);

            }

        }
    }
}
