﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "s", password = "s";
            if (textBox1.Text==username && textBox2.Text==password)
              {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
               }
            else
              {
                MessageBox.Show("Invalid Username or Passowrd");
                textBox1.Clear();
                textBox2.Clear();
            
                 }
            

        }

     


    }
}
