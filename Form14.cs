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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            fill_combo1();
       
        }

        void fill_combo1()
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select Distinct(Title) from current_avaliable";
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

      
        
        
        private void button1_Click(object sender, EventArgs e)
        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "select Title, count(copy_no) as Copies_Avaliable from current_avaliable group by title";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            try
            {

                OleDbDataReader reader = cm2.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;


            }

            catch (Exception ee)
            { }
            obj1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select rid,CONCAT(fname,CONCAT(' ',lname)) as Name,city from reader";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            try
            {

                OleDbDataReader reader = cm2.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView2.DataSource = dataTable;


            }

            catch (Exception ee)
            { }
            obj1.Close();


            



        }



        private void button3_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select * from current_avaliable Where Title='"+comboBox1.Text+"'";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            try
            {

                OleDbDataReader reader = cm2.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;


            }

            catch (Exception ee)
            { }
            obj1.Close();

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj2 = new OleDbConnection(connection);
            String query1 = "SELECT RID FROM READER";
            obj2.Open();
            OleDbCommand cm3 = new OleDbCommand(query1, obj2);
            AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
            OleDbDataReader rd = cm3.ExecuteReader();
            while (rd.Read())
            {
                myCollection.Add(rd.GetString(0));
            }
            textBox4.AutoCompleteCustomSource = myCollection;
            obj2.Close();

       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select max_books from reader where rid = '"+textBox4.Text+"'";
            String query2 = "select count(rid) from current_borrowings where rid='"+textBox4.Text+"'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            Int64 Max_books=0;
            while(rd.Read())
             {
                Max_books = int.Parse(rd[0].ToString());
            }
            
            obj3.Close();
            OleDbConnection obj4 = new OleDbConnection(connection);
            OleDbCommand cm5 = new OleDbCommand(query2, obj4);
            obj4.Open();
            OleDbDataReader rd1 = cm5.ExecuteReader();
            Int64 current_taken = 0;
            while (rd1.Read())
            {
                current_taken = int.Parse(rd1[0].ToString());
            }
            obj4.Close();
            if(current_taken+1>Max_books)
            {
                string error_string = "The Reader has exceeded its maximum books limit";
                MessageBox.Show(error_string);
                comboBox1.ResetText();
                textBox2.Clear();
                textBox4.Clear();
              }
            else 
             {
                
                OleDbConnection obj5 = new OleDbConnection(connection);
                obj5.Open();
                string query3 = "Select isbn from book where Title='" + comboBox1.Text + "'";
                OleDbCommand cm6 = new OleDbCommand(query3, obj5);
                OleDbDataReader rd2 = cm6.ExecuteReader();
                String isbn = string.Empty;
                while (rd2.Read())
                {
                    isbn= rd2[0].ToString();

                }



                Int64 trans = Int64.Parse(textBox1.Text);
                Int64 copy = Int64.Parse(textBox2.Text);
                String query4 = "insert into borrowed_by(Transaction_no, isbn, copy_no, rid,return) values("+trans+",'"+isbn+"',"+copy+",'"+textBox4.Text+"', NULL)";
                try
                {
                    OleDbCommand cm7 = new OleDbCommand(query4, obj5);
                    cm7.ExecuteNonQuery();
                    MessageBox.Show("Successful");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();

                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error...");
                }
                obj5.Close();



            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13();
            form13.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2= new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13();
            form13.Show();
        }

      
    }
}
