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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
            fill_bname();
        }

        void fill_bname()
        {
                                                                                              
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select Title from book";
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

        void fill_cno(string isbn)

        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select copy_no from copy_book where isbn='"+isbn+"'";
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            obj1.Open();
            OleDbDataReader reader = cm2.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader[0].ToString());

            }
            textBox2.AutoCompleteCustomSource = MyCollection;
            obj1.Close();



        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form19 form19 = new Form19();
            form19.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 form20 = new Form20();
            form20.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select isbn from book where title = '" + textBox1.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            string isbn = string.Empty;
            while (rd.Read())
            {
                isbn = rd[0].ToString();
            }
            obj3.Close();
                        
            String query = "Select Title,Copy_no from book natural join copy_book where isbn='"+isbn+"'";
            OleDbCommand cm2 = new OleDbCommand(query, obj3);
            obj3.Open();
            OleDbDataReader reader = cm2.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
            obj3.Close();
            fill_cno(isbn);
        

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select isbn from book where title = '" + textBox1.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            string isbn = string.Empty;
            while (rd.Read())
            {
                isbn = rd[0].ToString();
            }
            obj3.Close();



            OleDbConnection obj4 = new OleDbConnection(connection);
        

            String query = "DELETE FROM copy_book WHERE isbn ='" + isbn + "'and copy_no="+textBox2.Text+"";
            obj4.Open();
            try
            {
                OleDbCommand cm2 = new OleDbCommand(query, obj4);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Copy Deleted from Database");

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error...Copy not Deleted. Make sure the copy is not listed in 'ALL TRANSACTIONS'");
            }
            obj4.Close();
        }
    }
}
