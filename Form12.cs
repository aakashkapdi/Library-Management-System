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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            fill_combo();
        }
        void fill_combo()
        {
            comboBox1.Items.AddRange(new string[] { "Current Borrowings", "All Transactions" });


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All Transactions")
            {
                String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
                OleDbConnection obj1 = new OleDbConnection(connection);
                String query = "Select * from borrowed_by";
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
            else
            {
                String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
                OleDbConnection obj1 = new OleDbConnection(connection);
                String query = "Select * from current_borrowings";
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



            }

        private void button2_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 form15 = new Form15();
            form15.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 form16 = new Form16();
            form16.Show();
        }
    }
    }


