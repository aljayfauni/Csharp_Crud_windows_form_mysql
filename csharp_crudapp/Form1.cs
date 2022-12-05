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
    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3307;username=root;password= ;database=csharp_crud");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // LOGIN BUTTON

            connection.Open();
            string selectQuery = "SELECT * FROM tbl_users WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "';";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

                var form2 = new Form2();
                var form1 = new Form1();
                form2.Show();
                form1.Hide();
                


            }
            else
            {

                MessageBox.Show("Incorrect Login Information! Try again.");
            }

            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
