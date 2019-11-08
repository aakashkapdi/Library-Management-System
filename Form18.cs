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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
            fill_max();
            
        }
        void fill_rid()
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj2 = new OleDbConnection(connection);
            String query = "SELECT RID FROM READER WHERE CONCAT(FNAME,CONCAT(' ',LNAME))='"+textBox1.Text+"'";
            OleDbCommand cm3 = new OleDbCommand(query, obj2);
            obj2.Open();
            OleDbDataReader rd1 = cm3.ExecuteReader();
            while (rd1.Read())
            {
                String to_add = rd1.GetString(0);
                comboBox1.Items.Add(to_add);
            }
            obj2.Close();


        }

        void fill_max()
        {
            comboBox2.Items.Add('1');
            comboBox2.Items.Add('2');
            comboBox2.Items.Add('3');



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

        
        private void Form18_Load(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select CONCAT(fname,Concat(' ',lname)) as Name from reader";
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            obj1.Open();
            OleDbDataReader reader = cm2.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            obj1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fill_rid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj5 = new OleDbConnection(connection);
            obj5.Open();
            string query3 = "UPDATE Reader SET max_books=" + int.Parse(comboBox2.Text) + "where rid='" + comboBox1.Text + "'";
            try
            {
                OleDbCommand cm7 = new OleDbCommand(query3, obj5);
                cm7.ExecuteNonQuery();
                MessageBox.Show("Update Successful");
                textBox1.Clear();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Update Unsuccessful");
            }
            obj5.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 form14 = new Form14();
            form14.Show();
        }
    }
}
