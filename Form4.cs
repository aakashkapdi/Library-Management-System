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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            fill_combo_publisher();
            fill_combo_category();
            fill_combo_year();
        }
        void fill_combo_publisher() 
        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select pname from publisher";
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

        void fill_combo_category()
        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "Select cname from category";
            obj1.Open();
            OleDbCommand cm2 = new OleDbCommand(query, obj1);
            OleDbDataReader rd = cm2.ExecuteReader();
            while (rd.Read())
            {
                String to_add = rd.GetString(0);
                comboBox2.Items.Add(to_add);
            }
            obj1.Close();
        }

        void fill_combo_year()
        {
            for (int i = 2019; i>=1950; i--)
                year.Items.Add(i.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj3 = new OleDbConnection(connection);
            String nested_query_get_pid = "SELECT pid FROM publisher where PNAME='" + comboBox1.Text + "'";
            String nested_query_get_cid = "SELECT c_id FROM category where CNAME='" + comboBox2.Text + "'";
            OleDbCommand cm4 = new OleDbCommand(nested_query_get_pid, obj3);
            obj3.Open();
            OleDbDataReader rd = cm4.ExecuteReader();
            String pid = String.Empty;
            while (rd.Read())
            {
                pid =rd[0].ToString();
            }

            obj3.Close();
            OleDbCommand cm = new OleDbCommand(nested_query_get_cid, obj3);
            obj3.Open();
            OleDbDataReader rd1 = cm.ExecuteReader();
            Int64 cid = 0;
            while (rd1.Read())
            {
                cid = int.Parse(rd1[0].ToString());
            }

            obj3.Close();

            obj3.Open();
            int p_page = int.Parse(pages.Text);
            int p_year = int.Parse(year.Text);
            string query = "INSERT INTO book values('"+isbn.Text+"', '"+title.Text+"', '"+author.Text+"', "+p_page+","+p_year+","+cid+", '"+pid+"', '"+textBox1.Text+"')";

            try
            {
                OleDbCommand cm2 = new OleDbCommand(query, obj3);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Book Added into Database");
                isbn.Clear();
                title.Clear();
                author.Clear();
                pages.Clear();
                textBox1.Clear();
            }
            catch(Exception ee)
            { MessageBox.Show("Error...Book was not added in the database"); }
            
         
            obj3.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 form17 = new Form17();
            form17.Show();
        }
    }
}
