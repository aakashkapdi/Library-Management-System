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
    public partial class Form20 : Form
    {
        public Form20()
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
            String query2 = "select count(*) from copy_book where isbn = '" + isbn + "'";
            OleDbCommand cm5 = new OleDbCommand(query2, obj3);
            obj3.Open();
            OleDbDataReader rd1 = cm5.ExecuteReader();
            Int64 cps = 0;
            while (rd1.Read())
            {
                cps = int.Parse(rd1[0].ToString());
            }
            obj3.Close();
            if(cps>0)
              {
                MessageBox.Show("Please Delete copies of the Books First");
                Form21 form21 = new Form21();
                form21.Show();
                }
            else
              {
                String query = "DELETE FROM book WHERE isbn ='" + isbn + "'";
                obj3.Open();
                try
                {
                    OleDbCommand cm2 = new OleDbCommand(query, obj3);
                    cm2.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted from Database");
                  
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error...Book not Deleted");
                }

                obj3.Close();




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 form21 = new Form21();
            form21.Show();
        }
    }
}
