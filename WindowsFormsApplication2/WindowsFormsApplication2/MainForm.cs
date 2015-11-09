using NLX.Robot.Kuka.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        int i = 0;
        private bool pointState = false;
        bool isInLearningMode = true;
        Thread myThread;
        Thread myThreadMove;

        public Class_Kuka_Manager kuka;
        public Class_Mouse mouse;


        public MainForm()
        {
            kuka = new Class_Kuka_Manager();
            mouse = new Class_Mouse(kuka);
            InitializeComponent();
            //ControlBox = false;
            this.MaximizeBox = false;
            pointStateShow();
        }



        public void connectKuka(string ipAddress)
        {
            kuka.connectKuka(ipAddress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mouse.connectMouse();
            myThread = new Thread(new ThreadStart(mouse.Loop_Mouse));
            myThread.Start();
            m_playMotion.Enabled = false;
            isInLearningMode = true;
            m_stopLearning.Visible = true;
            m_learning.Visible = false;
        }

        private void m_back_Click(object sender, EventArgs e)
        {
            IndexConnect form1 = new IndexConnect();
            form1.Show();
            this.Visible = false;
        }

        private void m_keyboard_Click(object sender, EventArgs e)
        {
            m_learning.Enabled = false;
            m_stopLearning.Visible = false;
            m_stopPlaying.Visible = true;

            myThreadMove = new Thread(new ThreadStart(kuka.Mode_Move));
            myThreadMove.Start();
            //Start Thread AutoMotion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isInLearningMode) {
                switch (keyData)
                {
                    case (Keys.G):
                        kuka.changeGripperState();
                        break;
                    case (Keys.Space):
                        emergencyButton();
                        break;
                    case (Keys.S):
                        kuka.Save_Point(); //Save Points in XML file
                        break;
                    case (Keys.L):
                        kuka.Save_Position(); //Learn points to kuka
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void gripperMouvement(bool gripperState)
        {
            if (gripperState == false)
            {
                gripperOpened.Visible = true;
                gripperClosed.Visible = false;
                gripperState = true;
            }
            else
            {
                gripperOpened.Visible = false;
                gripperClosed.Visible = true;
                gripperState = false;
            }
        }

        private void updateGripper()
        {

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

            kuka.stopModeMove();
            mouse.stopLoopMouse();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CartesianPosition position = kuka.Donne_Position();
            dataX.Text = position.X.ToString();
            dataY.Text = position.Y.ToString();
            dataZ.Text = position.Z.ToString();
            dataA.Text = position.A.ToString();
            dataB.Text = position.B.ToString();
            dataC.Text = position.C.ToString();
            gripperMouvement(!kuka.getGripperState());
        }

        private void m_stopLearning_Click(object sender, EventArgs e)
        {
            m_learning.Visible = true;
            m_stopLearning.Visible = false;
            m_playMotion.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            m_stopPlaying.Visible = false;
            m_playMotion.Enabled = true;
            m_learning.Enabled = true;
            kuka.stopModeMove();
        }
    }
}