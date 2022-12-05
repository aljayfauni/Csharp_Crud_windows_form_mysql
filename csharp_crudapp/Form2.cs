using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace csharp_crudapp
{
    public partial class Form2 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3307;username=root;password= ;database=csharp_crud");
        MySqlCommand command;
        MySqlDataReader mdr;
        MySqlDataAdapter da;
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Welcome Admin";
            DisplayData();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

            //check if data already exist
            connection.Open();
            string check_if_exist = "SELECT * FROM tbl_users WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "';";
            command = new MySqlCommand(check_if_exist, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                MessageBox.Show(
                     "User already exist!",//message
                     "",//Window Title
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning// for Warning  
                                            //MessageBoxIcon.Error // for Error 
                                            //MessageBoxIcon.Information  // for Information
                                            //MessageBoxIcon.Question // for Question
                      );
                connection.Close();

            }
            else
            {
                //Insert data if not exist yet!
                connection.Close();
                connection.Open();
                string Insert_query = "Insert into tbl_users (username,password) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                command = new MySqlCommand(Insert_query, connection);
                mdr = command.ExecuteReader();
                MessageBox.Show("successfully Added New Record!");
                textBox1.Text = "";
                textBox2.Text = "";
                connection.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void DisplayData()
        {

            try
            {
                connection.Open();


                string SelectAll_query = "select * from tbl_users ";
                command = new MySqlCommand(SelectAll_query, connection);

                da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataTable data_table = new DataTable();
                da.Fill(data_table);
                dataGridView1.DataSource = data_table; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                       // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            connection.Close();







        }
    }
}
    

