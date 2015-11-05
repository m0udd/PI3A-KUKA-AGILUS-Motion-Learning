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
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class Connection
    {
        private readonly MainForm AccessForm2;

        public void connect()
        {
      
            RobotController robot = new RobotController();
            Form1 parentForm = Application.OpenForms["Form1"] as Form1;
            //robot.Connect(parentForm.ipAddress);
            //Console.WriteLine(AccessForm2.m_keyboard);

        }
    }
}
