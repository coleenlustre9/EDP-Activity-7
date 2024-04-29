using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Excel = Microsoft.Office.Interop.Excel;





namespace EDPAct4Lustre
{
    public partial class reportform : Form
    {
        public reportform()
        {
            InitializeComponent();
        }

 

            private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new dashboardform();
            myform.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var myform = new loginform();
            myform.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new usermanagement();
            myform.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM orders"; 

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable; // Bind the retrieved data to dataGridView1
                        }
                    }
                }

                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }


        
        private void button8_Click_1(object sender, EventArgs e)
        {

            
    
           
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet dataSheet = null;
            Excel.Worksheet chartSheet = null;
            Excel.ChartObjects xlCharts = null;
            Excel.ChartObject myChart = null;
            Excel.Chart chart = null;

            try
            {
                // Create a new Excel application
                excelApp = new Excel.Application();
                excelApp.Visible = true;

                // Load the Excel template file
                workbook = excelApp.Workbooks.Open(@"C:\Users\Asus-User\Downloads\MSTemplate.xlsx");

                // Ensure there are exactly 2 sheets in the workbook (delete extra sheets if present)
                while (workbook.Sheets.Count > 2)
                {
                    workbook.Sheets[workbook.Sheets.Count].Delete();
                }

                // Get references to Sheet1 (data sheet) and create Sheet2 (chart sheet)
                dataSheet = (Excel.Worksheet)workbook.Sheets[1]; // Index 1 refers to the first sheet
                chartSheet = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                chartSheet.Name = "Chart Sheet";

                // Clear existing data on Sheet1 starting from row 3
                int startRow = 3;
                int rowCount = dataSheet.Cells[dataSheet.Rows.Count, 1].End[Excel.XlDirection.xlUp].Row;
                Excel.Range clearRange = dataSheet.Range[dataSheet.Cells[startRow, 1], dataSheet.Cells[rowCount, dataSheet.Columns.Count]];
                clearRange.ClearContents();

                // Fill Sheet1 with data from DataGridView starting at A3
                int startColumn = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataSheet.Cells[i + startRow, j + startColumn] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Create the chart on Sheet2 (Chart Sheet)
                xlCharts = (Excel.ChartObjects)chartSheet.ChartObjects(Type.Missing);
                myChart = xlCharts.Add(100, 100, 300, 250);
                chart = myChart.Chart;
                chart.SetSourceData(dataSheet.Range[dataSheet.Cells[startRow, startColumn], dataSheet.Cells[startRow + dataGridView1.Rows.Count - 1, startColumn + dataGridView1.Columns.Count - 1]], Type.Missing);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;

                // Save the modified Excel workbook
                workbook.Save();

                MessageBox.Show("Excel file updated successfully with data on Sheet1 and chart on the Chart Sheet.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Release Excel objects from memory
                if (chart != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(chart);
                if (myChart != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(myChart);
                if (xlCharts != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCharts);
                if (dataSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(dataSheet);
                if (chartSheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(chartSheet);
                if (workbook != null)
                {
                    workbook.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
            


        }






        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new usermanagement();
            myform.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var myform = new dashboardform();
            myform.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var myform = new loginform();
            myform.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM payments";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable; // Bind the retrieved data to dataGridView1
                        }
                    }
                }

                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM products";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable; // Bind the retrieved data to dataGridView1
                        }
                    }
                }

                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM customers";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable; // Bind the retrieved data to dataGridView1
                        }
                    }
                }

                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = "server=127.0.0.1;uid=root;pwd=lustre;database=my_kiosk";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM customerlogs";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable; // Bind the retrieved data to dataGridView1
                        }
                    }
                }

                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }



}
