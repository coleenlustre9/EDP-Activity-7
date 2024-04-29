using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EDPAct4Lustre
{
    public partial class passwordrecoveryform : Form
    {
        public passwordrecoveryform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            answer.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            string answer = this.answer.Text;
            if (answer == "nothing")
            {
                this.Hide();
                var nextform = new dashboardform();
                nextform.Show();
            }
            else
            { //pop up notification if the password did not match
                MessageBox.Show("YOU ENTERED A WRONG ANSWER. PLEASE TRY AGAIN.", "FAILED LOG IN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextform = new loginform();
            nextform.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       
        private void safetypin_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        
    }
}
