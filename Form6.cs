using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDPAct4Lustre
{
    public partial class createaccountform : Form
    {
        private readonly Action<string, string, string> createAccountCallback;
        private readonly string connectionString;

        public createaccountform(Action<string, string, string> createAccountCallback, string connectionString)
        {
            InitializeComponent();
            this.createAccountCallback = createAccountCallback;
            this.connectionString = connectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string email = this.email.Text;
            string password = this.password.Text;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO accounts (username, email, password) VALUES (@username, @email, @password)";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record added successfully!");
                        // Invoke the callback to handle the record in the main form
                        createAccountCallback(username, email, password);

                        // Close the form after adding the record
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add record.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
    }

