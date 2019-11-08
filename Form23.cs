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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
            fill_cname();
        }
        void fill_cname()
        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select cname from category";
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

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select count(*) from book where c_id=(select c_id from category where cname='" + textBox1.Text + "')";
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

                String query = "delete from category where cname = '" + textBox1.Text + "'";
                obj3.Open();
                try
                {
                    OleDbCommand cm = new OleDbCommand(query, obj3);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted from Database");

                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error...Category not Deleted");
                }
                obj3.Close();
            }
            else
            {
                MessageBox.Show("Please Delete all records of this '"+textBox1.Text+"' category in books table " );
                this.Hide();
                Form20 form20 = new Form20();
                form20.Show();
            }
        }

       
    }
}
