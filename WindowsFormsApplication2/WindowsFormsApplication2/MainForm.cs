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
        private bool gripperState = false;
        public MainForm()
        {
            InitializeComponent();
            //ControlBox = false;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void m_back_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
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

            if (keyData == Keys.E)
            {
                gripperMouvement();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gripperMouvement()
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

        private void gripperOpened_Click(object sender, EventArgs e)
        {

        }

        private void gripperClosed_Click(object sender, EventArgs e)
        {

        }
    }
}
