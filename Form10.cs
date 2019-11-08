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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("Check only One Checkbox");
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
                OleDbConnection obj1 = new OleDbConnection(connection);
                if (checkBox1.Checked == true)
                {
                    String query = "Select * from Reader";
                    obj1.Open();
                    OleDbCommand cm2 = new OleDbCommand(query, obj1);
                    {

                        OleDbDataReader reader = cm2.ExecuteReader();
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }

                    }
                    obj1.Close();
                }
                else
                {
                    String query = "SELECT * from reader where rid in(select rid from current_borrowings) ";
                    obj1.Open();
                    OleDbCommand cm2 = new OleDbCommand(query, obj1);
                    {

                        OleDbDataReader reader = cm2.ExecuteReader();
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }

                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 form8 = new Form8();
            form8.Show();
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
    }
}
