using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string connetionString = null;
            SqlConnection conn;
            connetionString = @"Data Source=LAPTOP-J13BRS1L\MSSQLSERVER02; Initial Catalog=DBstoredP;Integrated Security=SSPI;";
            conn = new SqlConnection(connetionString);
            try
            {
                SqlDataReader myReader;
                conn.Open();
                //MessageBox.Show("Connection Open ! ");
                //string myQuery = "select * from \"01_VIRTUAL_BAG_PLC28\";";
                string myQuery = "select * from Employees";
                SqlCommand myCommand = new SqlCommand(myQuery, conn);

                myReader = myCommand.ExecuteReader();

                dt.Load(myReader);
                foreach (DataRow dataRow in dt.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        ;
                        Console.Write("hello");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            dataGridView1.DataSource = dt;

        }
    }
}
