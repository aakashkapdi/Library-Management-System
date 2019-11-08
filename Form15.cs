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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
            fill_rid();
            
        }
        void fill_rid() {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select rid from current_borrowings";
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
        void fill_bname() {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select Title from current_borrowings where rid='"+comboBox1.Text+"'";
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
        void fill_copyno() {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select copy_no from current_borrowings where rid='" + comboBox1.Text + "' and Title='"+comboBox2.Text+"'";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            OleDbDataReader rd = cm2.ExecuteReader();
            while (rd.Read())
            {
                string to_add = rd[0].ToString();
                comboBox3.Items.Add(to_add);
            }
            obj1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fill_bname();
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "select Title,Copy_no,Borrow_date,Due_date from current_borrowings where rid='" + comboBox1.Text + "'";
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
            {          }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_copyno();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select isbn from book where title = '" + comboBox2.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            string isbn = string.Empty;
            while (rd.Read())
            {
                isbn = rd[0].ToString();
            }

            obj3.Close();

            
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select Round(SYSDATE-due_date) from borrowed_by where rid='" + comboBox1.Text+"' and isbn='"+isbn+"' and copy_no='"+comboBox3.Text+"'";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            OleDbDataReader rd1 = cm2.ExecuteReader();
            Int64 difference = 0;
            while (rd1.Read())
            {
                 difference = int.Parse(rd1[0].ToString());
            }
            textBox1.Text = (difference * 5).ToString();
            obj1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String query1 = "select isbn from book where title = '" + comboBox2.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(query1, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            string isbn = string.Empty;
            while (rd.Read())
            {
                isbn = rd[0].ToString();
            }

            obj3.Close();



            OleDbConnection obj5 = new OleDbConnection(connection);
            obj5.Open();
            string query3 = string.Empty;
            if (checkBox1.Checked == true)
                query3 = "UPDATE borrowed_by SET Return = SYSDATE,Charges=" + int.Parse(textBox1.Text) + " WHERE rid = '" + comboBox1.Text + "' and isbn = '" + isbn + "' and copy_no = '" + comboBox3.Text + "'";
            else
                query3 = "UPDATE borrowed_by SET Return = SYSDATE,Charges=Null  WHERE rid = '" + comboBox1.Text + "' and isbn = '" + isbn + "' and copy_no = '" + comboBox3.Text + "'";
            try
            {
                OleDbCommand cm7 = new OleDbCommand(query3, obj5);
                cm7.ExecuteNonQuery();
                MessageBox.Show("Book Return Successful");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Book Return Unsuccessful");
            }
            obj5.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13();
            form13.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 form16 = new Form16();
            form16.Show();
        }
    }
}
