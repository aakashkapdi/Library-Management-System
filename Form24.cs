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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
            fill_rname();
        }

        void fill_rname()
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
        void fill_rid()
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj2 = new OleDbConnection(connection);
            String query = "SELECT RID FROM READER WHERE CONCAT(FNAME,CONCAT(' ',LNAME))='" + textBox1.Text + "'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fill_rid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form19 form19 = new Form19();
            form19.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 form15 = new Form15();
            form15.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select count(*) from current_borrowings where rid='" + comboBox1.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            Int64 count = 0;
            while (rd.Read())
            {
                count = int.Parse(rd[0].ToString());
            }
            obj3.Close();


            if (count == 0)
            {

                String query = "delete from reader where rid = '" + comboBox1.Text + "'";
                obj3.Open();
                try
                {
                    OleDbCommand cm = new OleDbCommand(query, obj3);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Reader Deleted from Database");

                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error...Reader not Deleted");
                }
                obj3.Close();
            }
            else
            {
                MessageBox.Show("Please Settle all the borrowings of '" + textBox1.Text + "' before  deleting");
                this.Hide();
                Form15 form15 = new Form15();
                form15.Show();
            }
        }
    }
}
