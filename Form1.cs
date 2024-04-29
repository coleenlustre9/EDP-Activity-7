using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EDPAct4Lustre
{
    public partial class loginform : Form
    {
        private readonly Action<string, string, string> CreateAccountCallback;

        public loginform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;
           

            /*
            if ((username == "admin") && (password == "password"))
            {
                this.Hide();
                var myform = new dashboardform();
                myform.Show();
            }
            else
            {
                MessageBox.Show("INVALID USERNAME OR PASSWORD", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
             "pwd=lustre;database=my_kiosk";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                string sql = "SELECT COUNT(*) from accounts where username = @username and password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue ("@password", password);
                //object result = cmd.ExecuteScalar();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    var myform = new dashboardform();
                    this.Hide();
                    myform.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username/password, please try again",
                            "ERROR LOGIN",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to the server. Please contact the administrator for assistance.");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", 
                            "Password Problem", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            username.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var myform = new passwordrecoveryform();
            myform.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();

            var myform = new createaccountform(CreateAccountCallback, "connectionString");
            myform.FormClosed += (s, args) => this.Show(); // Show the main form when createaccountform is closed
            myform.Show();



        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
