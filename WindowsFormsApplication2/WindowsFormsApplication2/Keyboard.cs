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
    public partial class Keyboard : Form
    {
        private bool stateGripper;
        public Keyboard()
        {
            InitializeComponent();
            ControlBox = false;
        }

        private void m_gripper_Click(object sender, EventArgs e)
        {
            gripperMouvement();
        }

        private void m_back_Click(object sender, EventArgs e)
        {
            MainForm parentForm = Application.OpenForms["Form2"] as MainForm;
            this.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.E)
            {
                gripperMouvement();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gripperMouvement()
        {
            if (stateGripper == false)
            {
                Console.WriteLine("E pushed");
                gripperOpened.Visible = true;
                gripperClosed.Visible = false;
                stateGripper = true;
            }
            else
            {
                Console.WriteLine("E pushed");
                gripperOpened.Visible = false;
                gripperClosed.Visible = true;
                stateGripper = false;
            }
        }

        private void gripperOpened_Click(object sender, EventArgs e)
        {

        }
    }
}
