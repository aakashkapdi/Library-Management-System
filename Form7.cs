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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            fill_combo_city(); 
            fill_combo_max_books();
        }

        void fill_combo_city()
        {
            rcity.Items.AddRange(new string[] { "Panaji", "Margao", "Ponda", "Mhapusa" });


        }
        void fill_combo_max_books()
        {
            for (int i = 1; i<=4 ; i++)
                rmaxbooks.Items.Add(i.ToString());


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String query = "insert into reader(rid,fname,lname,city,max_books) values ('" + rid.Text + "','" + rfname.Text + "','" + rlname.Text + "','" + rcity.Text+ "','"+int.Parse(rmaxbooks.Text)+"')";
            obj1.Open();
            try
            {
                OleDbCommand cm2 = new OleDbCommand(query, obj1);
                cm2.ExecuteNonQuery();
                MessageBox.Show("Reader Added into Database");
                rid.Clear();
                rfname.Clear();
                rlname.Clear();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error...Reader not Added");
            }
            obj1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
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
            Form14 form14 = new Form14();
            form14.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
