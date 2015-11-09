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
    public partial class IndexConnect : Form
    {
        public string ipAddress = "192.168.1.1";
        public IndexConnect()
        {
            InitializeComponent();
            textBox2.Text = ipAddress;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            MainForm parentForm = Application.OpenForms["MainForm"] as MainForm;
            string ipAddress = textBox2.Text;
            Console.WriteLine(ipAddress); //Debug
            mainForm.connectKuka(ipAddress);
            this.Visible = false;
            mainForm.Show();
                        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
