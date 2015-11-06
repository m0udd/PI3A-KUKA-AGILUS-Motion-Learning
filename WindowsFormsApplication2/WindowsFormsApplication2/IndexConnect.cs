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
        public string ipAddress;
        public IndexConnect()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            connect.connect();
            string ipAddress = textBox2.Text;
            Console.WriteLine(ipAddress); //Debug
            this.Visible = false;
            MainForm form2 = new MainForm();
            form2.Show();
                        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
