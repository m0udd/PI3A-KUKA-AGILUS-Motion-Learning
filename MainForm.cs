using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        int i = 5;
        int x = 1234;

        private bool gripperState = false;
        private bool pointState = false;
        public MainForm()
        {
            InitializeComponent();
            //ControlBox = false;
            this.MaximizeBox = false;
            pointStateShow();
            dataX.Text = x.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void m_back_Click(object sender, EventArgs e)
        {
            IndexConnect form1 = new IndexConnect();
            form1.Show();
            this.Visible = false;
        }

        private void m_keyboard_Click(object sender, EventArgs e)
        {
            Keyboard keyboardWindow = new Keyboard();
            keyboardWindow.Show();
            m_keyboard.Enabled = false;
        }

        public void UnlockButton()
        {
            m_keyboard.Enabled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case (Keys.E):
                    gripperMouvement();
                    break;
                case (Keys.A):
                    emergencyButton();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void gripperMouvement()
        {
            if (gripperState == false)
            {
                Console.WriteLine("E pushed");
                gripperOpened.Visible = true;
                gripperClosed.Visible = false;
                gripperState = true;
            }
            else
            {
                Console.WriteLine("E pushed");
                gripperOpened.Visible = false;
                gripperClosed.Visible = true;
                gripperState = false;
            }
        }

        private void emergencyButton()
        {
            Console.WriteLine("emergencyButton begin");
            Console.WriteLine("A pushed");
            //System.Threading.Thread.Sleep(500);
            emergency_pushed.Visible = true;
            emergency.Visible = false;
            Console.WriteLine("sleep");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("sleeped");
            //emergency_pushed.Visible = false;
            //semergency.Visible = true;
            Console.WriteLine("emergencyButton end");
        }

        private void pointStateShow()
        {
            if (pointState == false)
            {
                switch (i)
                {
                    case (1):
                        pointFull1.Visible = true;
                        pointState = true;
                        break;
                    case (2):
                        pointFull2.Visible = true;
                        pointState = true;
                        break;
                    case (3):
                        pointFull3.Visible = true;
                        pointState = true;
                        break;
                    case (4):
                        pointFull4.Visible = true;
                        pointState = true;
                        break;
                    case (5):
                        pointFull5.Visible = true;
                        pointState = true;
                        break;
                    case (6):
                        pointFull6.Visible = true;
                        pointState = true;
                        break;
                    case (7):
                        pointFull7.Visible = true;
                        pointState = true;
                        break;
                    case (8):
                        pointFull8.Visible = true;
                        pointState = true;
                        break;
                    case (9):
                        pointFull9.Visible = true;
                        pointState = true;
                        break;
                    case (10):
                        pointFull10.Visible = true;
                        pointState = true;
                        break;
                    case (11):
                        pointFull11.Visible = true;
                        pointState = true;
                        break;
                    case (12):
                        pointFull12.Visible = true;
                        pointState = true;
                        break;
                    case (13):
                        pointFull13.Visible = true;
                        pointState = true;
                        break;
                    case (14):
                        pointFull14.Visible = true;
                        pointState = true;
                        break;
                    case (15):
                        pointFull15.Visible = true;
                        pointState = true;
                        break;
                    case (16):
                        pointFull16.Visible = true;
                        pointState = true;
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case (1):
                        pointFull1.Visible = false;
                        pointState = false;
                        break;
                    case (2):
                        pointFull2.Visible = false;
                        pointState = false;
                        break;
                    case (3):
                        pointFull3.Visible = false;
                        pointState = false;
                        break;
                    case (4):
                        pointFull4.Visible = false;
                        pointState = false;
                        break;
                    case (5):
                        pointFull5.Visible = false;
                        pointState = false;
                        break;
                    case (6):
                        pointFull6.Visible = false;
                        pointState = false;
                        break;
                    case (7):
                        pointFull7.Visible = false;
                        pointState = false;
                        break;
                    case (8):
                        pointFull8.Visible = false;
                        pointState = false;
                        break;
                    case (9):
                        pointFull9.Visible = false;
                        pointState = false;
                        break;
                    case (10):
                        pointFull10.Visible = false;
                        pointState = false;
                        break;
                    case (11):
                        pointFull11.Visible = false;
                        pointState = false;
                        break;
                    case (12):
                        pointFull12.Visible = false;
                        pointState = false;
                        break;
                    case (13):
                        pointFull13.Visible = false;
                        pointState = false;
                        break;
                    case (14):
                        pointFull14.Visible = false;
                        pointState = false;
                        break;
                    case (15):
                        pointFull15.Visible = false;
                        pointState = false;
                        break;
                    case (16):
                        pointFull16.Visible = false;
                        pointState = false;
                        break;
                }
            }

        }

        private void gripperOpened_Click(object sender, EventArgs e)
        {

        }

        private void gripperClosed_Click(object sender, EventArgs e)
        {

        }

        private void emergency_pushed_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
