using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Security.AccessControl;

using System.Data.SqlClient;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Control = System.Windows.Forms.Control;
using System.Text.RegularExpressions;





namespace Car_Care_Service__.NET_
{
    public partial class Form1 : Form
    {
        //DisplayData displayData = new DisplayData();
        BindingSource TransactionsBS = new BindingSource();

        Bitmap memoryImage;

        public Form1()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            //this.BackColor = Color.FromArgb(29, 29, 66);
            btnExportToExcel.TabStop = false;
            btnExportToExcel.FlatStyle = FlatStyle.Flat;
            btnExportToExcel.FlatAppearance.BorderSize = 0;
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            //button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            textBox2.MaxLength = 11;
            txtCarID.MaxLength = 13;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //1280; 720
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

  
        private void elipseControl1_Click(object sender, EventArgs e)
        {

        }
        private Point offset;
        bool mouseDown;
        private void MD(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void MME(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {

                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);

            }

        }

        private void MU(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void DGV()
        {
            //con
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

       

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Graphics myGraphics = this.CreateGraphics();
            //Size s = this.Size;
            //memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            //printDocument1.Print();

            SaveExcel exporter = new SaveExcel(dataGridView1); // Pass the DataGridView
            exporter.ExportToExcel();

        }
        public class SaveExcel
        {
            private DataGridView dataGridView1;

            public SaveExcel(DataGridView dgv)
            {
                this.dataGridView1 = dgv;
            }

            public void ExportToExcel()
            {
                DialogResult result = MessageBox.Show("Do you want to export the data to Excel?",
                                                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("No data to export.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string filePath = string.Empty;
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Excel Files|*.xlsx";
                        sfd.Title = "Save an Excel File";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            filePath = sfd.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }

                    DateTime dtNow = DateTime.Now;
                    string sheetStrFormat = dtNow.ToString("yyyy-MM-dd") + " REPORT";

                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable dt = new DataTable();
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                dt.Columns.Add(column.HeaderText);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    DataRow dr = dt.NewRow();
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        dr[cell.ColumnIndex] = cell.Value;
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }

                            workbook.Worksheets.Add(dt, sheetStrFormat);
                            workbook.SaveAs(filePath);
                        }

                        MessageBox.Show("Data exported successfully to Excel.",
                                        "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data to Excel: " + ex.Message,
                                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void transactionIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_2(object sender, EventArgs e)
        {

        }
        
            string query = "" +@"                SELECT 
                    t.TransactionID AS ID,
                    c.Name AS CustomerName,
                    c.Telephone AS Phone,
                    t.CarID,
                    t.CurrentDate,
                    t.Total AS Total,
                    t.COM AS VehicleType,
                    STRING_AGG(s.ServiceName + ' (' + CAST(s.Price AS NVARCHAR) + ' LE)', ', ') AS Services,
                    sa.SaleDescription AS Deal,
                    sa.DiscountPercentage AS Discount,
                    t.Notes
                FROM 
                    Transactions t
                JOIN 
                    Customers c ON t.CustomerID = c.CustomerID
                JOIN 
                    TransactionServices ts ON t.TransactionID = ts.TransactionID
                JOIN 
                    Services s ON ts.ServiceID = s.ServiceID
                JOIN 
                    Sales sa ON t.SaleID = sa.SaleID
                GROUP BY 
                    t.TransactionID, c.Name, c.Telephone, t.CarID, t.CurrentDate, t.Total, t.COM, sa.SaleDescription, sa.DiscountPercentage, t.Notes;
            "
                
                ;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Example custom SQL query
            // Load the data when the form loads
            LoadData(query);
        }
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"J:\\Visual Studio\\Car Care Service (.NET)\\Car Care Service (.NET)\\Database.mdf\";Integrated Security=True";
        private void LoadData(string customQuery)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(customQuery, connection);

                    
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO Transactions (CustomerID, CarID, CurrentDate, Total, COM, SaleID, Notes) 
                                   VALUES (@CustomerID, @CarID, @CurrentDate, @Total, @COM, @SaleID, @Notes)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Example parameters (replace with your input controls)
                        command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@CarID", txtCarID.Text);
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Total", txtTotal.Text);
                        command.Parameters.AddWithValue("@COM", txtVehicleType.Text);
                        command.Parameters.AddWithValue("@SaleID", txtSaleID.Text);
                        command.Parameters.AddWithValue("@Notes", txtNotes.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(query); // Reload data
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE Transactions 
                                   SET Total = @Total, Notes = @Notes 
                                   WHERE TransactionID = @TransactionID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Example parameters
                        command.Parameters.AddWithValue("@Total", txtTotal.Text);
                        command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        command.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(query); // Reload data
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string deleteQuery = "DELETE FROM Transactions WHERE TransactionID = @TransactionID";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(query); // Reload data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label6_Click_1(object sender, EventArgs e)
        {

        }

 

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        //int number = 0;
        //int letter = 0;
        private int letterCount = 0;
        private int numberCount = 0;

        private void txtCarID_TextChanged(object sender, EventArgs e)
        {
            //Control ctrl = (sender as Control);

            //string s =ctrl.Text;
            //ctrl.Text = "q"; 
            //foreach (char c in s) {
            //    if (number < 4 && (c >= '0' && c <= '9'))
            //    {
            //        ctrl.Text += "a";
            //        number++;
            //    }
            //    else if (letter < 3 && (c >= '\u0600' && c <= '\u06FF'))
            //    {
            //        //ctrl.Text += c;
            //        letter++;
            //    }

            //}
            string input = txtCarID.Text;

            // Validate input
            if (IsValidInput(input))
            {
                txtCarID.BackColor = System.Drawing.Color.LightGreen; // Change background to indicate success
            }
            else
            {
                txtCarID.BackColor = System.Drawing.Color.LightCoral; // Change background to indicate failure
            }



            //string value = string.Concat(ctrl
            //  .Text
            //  .Where(c => c >= '0' && c <= '9'));

            //if (value != ctrl.Text)
            //    ctrl.Text = value;
        }
        private bool IsValidInput(string input)
        {
            // Regular expression to check for at least 3 letters and 4 numbers
            string pattern = @"^(?=(.*[^A-Za-z0-9!-/:-@[-`{-~]){3,})(?=(.*\d){4,}).+$";
            return Regex.IsMatch(input, pattern);
        }



        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            Control ctrl = (sender as Control);

            string value = string.Concat(ctrl
              .Text
              .Where(c => c >= '0' && c <= '9'));

            if (value != ctrl.Text)
                ctrl.Text = value;
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            //var textboxSender = (TextBox)sender;
            //var cursorPosition = textboxSender.SelectionStart;
            //textboxSender.Text = Regex.Replace(textboxSender.Text, @"/[^A-Za-z0-9!-/:-@[-`{-~]/g", "");
            //textboxSender.SelectionStart = cursorPosition;
            Control ctrl = (sender as Control);

            //string value = string.Concat(ctrl
            //  .Text
            //  .Where(c => c >= '\u0600' && c <= '\u06FF' || c >= '\u0750' && c <= '\u077F' || c==' '));
            string value = string.Concat(ctrl
              .Text
              .Where(c => Char.IsLetter(c) ));

            if (value != ctrl.Text)
                ctrl.Text = value;

        }

        private void elipseControl1_Click_1(object sender, EventArgs e)
        {

        }

  

        private void txtVehicleType_Leave(object sender, EventArgs e)
        {
            // Get the text box reference
            TextBox txtBox = sender as TextBox;

            // Ensure the control is a valid TextBox
            if (txtBox != null)
            {
                // Get the current text in the TextBox
                string inputText = txtBox.Text.Trim();

                // Check if the text is either "سيارة" or "سكوتر"
                if (inputText == "سيارة" || inputText == "سكوتر")
                {
                    // Input is valid; no action needed
                }
                else
                {
                    // Clear the invalid input
                    txtBox.Text = string.Empty;

                    // Notify the user about the issue
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة: سيارة أو سكوتر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtVehicleType_TextChanged(object sender, EventArgs e)
        {
            // Reference the ComboBox
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                string inputText = comboBox.Text.Trim(); // Get the current text

                // Check if the text is either "سيارة" or "سكوتر"
                if (inputText == "سيارة" || inputText == "سكوتر")
                {
                    // Valid input, do nothing
                }
                else
                {
                    // Clear the invalid input
                    comboBox.Text = string.Empty;

                    // Notify the user about the error
                    MessageBox.Show("الرجاء إدخال أو اختيار قيمة صحيحة: سيارة أو سكوتر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtTotal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtSaleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ctrl = (sender as ComboBox);

            string value = string.Concat(ctrl
              .Text
              .Where(c => c >= '0' && c <= '9'));

            if (value != ctrl.Text)
                ctrl.Text = value;
        }

        private void txtSaleID_Leave(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                string inputText = comboBox.Text.Trim();

                // Check if the input is a valid integer
                if (int.TryParse(inputText, out int value))
                {
                    // Ensure the value is within the allowed range
                    if (value >= 0 && value <= 100)
                    {
                        // Valid input, do nothing
                        return;
                    }
                }

                // If invalid, clear the text and notify the user
                comboBox.Text = "0" ;
                MessageBox.Show("الرجاء إدخال قيمة رقمية بين 0 و 100 فقط", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Allow backspace (handled in KeyDown) and new lines
            if (keyChar == '\b')
            {
                return;
            }

            if (char.IsLetter(keyChar))
            {
                // Allow letters if we haven't reached 3 yet
                if (letterCount < 3)
                {
                    letterCount++;
                }
                else
                {
                    e.Handled = true; // Reject input
                }
            }
            else if (char.IsDigit(keyChar))
            {
                // Allow numbers if we haven't reached 4 yet
                if (numberCount < 4)
                {
                    numberCount++;
                }
                else
                {
                    e.Handled = true; // Reject input
                }
            }
            else
            {
                // Reject any non-alphanumeric character
                e.Handled = true;
            }
        }

        private void txtCarID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                int cursorPosition = txtCarID.SelectionStart;

                // If the cursor is within the text, find the character to be deleted
                if (cursorPosition > 0 && cursorPosition <= txtCarID.Text.Length)
                {
                    char deletedChar;

                    // Handle Backspace (deletes the character before the cursor)
                    if (e.KeyCode == Keys.Back)
                    {
                        deletedChar = txtCarID.Text[cursorPosition - 1];
                    }
                    // Handle Delete (deletes the character at the cursor position)
                    else
                    {
                        if (cursorPosition == txtCarID.Text.Length)
                            return; // No character to delete
                        deletedChar = txtCarID.Text[cursorPosition];
                    }

                    // Adjust the counts based on the deleted character
                    if (char.IsLetter(deletedChar))
                    {
                        letterCount--;
                    }
                    else if (char.IsDigit(deletedChar))
                    {
                        numberCount--;
                    }
                }
            }
        }
        //private void HandleBackspace()
        //{

        //}

    }
}




