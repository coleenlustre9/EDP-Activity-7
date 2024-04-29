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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDPAct4Lustre
{
    public partial class usermanagement : Form
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
        public usermanagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the search keyword from the textbox
            string searchKeyword = searchbox.Text.Trim();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Search for records in the database
                        string sql = "SELECT username, email, password FROM accounts WHERE username LIKE @searchKeyword OR email LIKE @searchKeyword OR password LIKE @searchKeyword";
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Display search results in the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a search keyword.");
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the updated username and password from the textboxes
            string newUsername = this.username.Text;
            string newPassword = this.password.Text;
            string newEmail = this.email.Text;

            // Get the currently selected row from the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the current username and password from the selected row
                string currentUsername = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
                string currentPassword = dataGridView1.SelectedRows[0].Cells["password"].Value.ToString();
                string currentEmail = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Update the record in the database
                        string sql = "UPDATE accounts SET username = @newUsername, email = @newEmail, password = @newPassword WHERE username = @currentUsername AND email = @currentEmail AND password = @currentPassword";
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@newUsername", newUsername);
                        cmd.Parameters.AddWithValue("@newEmail", newEmail);
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@currentUsername", currentUsername);
                        cmd.Parameters.AddWithValue("@currentEmail", currentEmail);
                        cmd.Parameters.AddWithValue("@currentPassword", currentPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");
                            // Reload data to update DataGridView
                            Dataload();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update record.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Add button click event handler
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
                        // Reload data to update DataGridView
                        Dataload();
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

        private void Dataload()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT username, email, password FROM accounts";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the username, email, and password from the selected row
                string username = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
                string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
                string password = dataGridView1.SelectedRows[0].Cells["password"].Value.ToString();

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Delete the record from the database
                        string sql = "DELETE FROM accounts WHERE username = @username AND email = @email AND password = @password";
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!");
                            // Reload data to update DataGridView
                            Dataload();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete record.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new dashboardform();
            myform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new usermanagement();
            myform.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var myform = new loginform();
            myform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new reportform();
            myform.Show();
        }
    }
}
