using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace library_management_new
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
            fill_combobox();
          
        }

        void fill_combobox()
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select Title from Book";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            OleDbDataReader rd = cm2.ExecuteReader();
            while (rd.Read())
            {
                string to_add = rd.GetString(0);
                comboBox1.Items.Add(to_add);
            }
            obj1.Close();
        }

        void fill_combobox2()
        {
            comboBox2.Items.Clear();
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select ISBN from Book where Title='"+comboBox1.Text+"'";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            OleDbDataReader rd = cm2.ExecuteReader();
            while (rd.Read())
            {
                string to_add = rd.GetString(0);
                comboBox2.Items.Add(to_add);
            }
            obj1.Close();




        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj5 = new OleDbConnection(connection);
            obj5.Open();
            string query3 = "Select isbn from book where Title='" + comboBox1.Text + "'";
            OleDbCommand cm6 = new OleDbCommand(query3, obj5);
            OleDbDataReader rd2 = cm6.ExecuteReader();
            String isbn = string.Empty;
            while (rd2.Read())
            {
                isbn = rd2[0].ToString();
            }
            string isbn_substring = isbn.Substring(isbn.Length -2);
            string copy_no = string.Concat(isbn_substring, textBox1.Text);
            String query4 = "insert into copy_book values ('"+isbn+"',"+int.Parse(copy_no)+")";
            try
            {
                OleDbCommand cm7 = new OleDbCommand(query4, obj5);
                cm7.ExecuteNonQuery();
                MessageBox.Show("copy Added into Database");
                textBox1.Clear();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error...copy not Added");
            }
            obj5.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_combobox2();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
