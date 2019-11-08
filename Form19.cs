using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace library_management_new
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 form20 = new Form20();
            form20.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form22 form22 = new Form22();
            form22.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form23 form23 = new Form23();
            form23.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 form24 = new Form24();
            form24.Show();
        }
    }
}
