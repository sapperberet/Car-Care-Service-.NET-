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
using System.Collections.Specialized;
//using System.Drawing.Printing;
using System.Security.AccessControl;

using System.Data.SqlClient;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Control = System.Windows.Forms.Control;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DocumentFormat.OpenXml.Drawing.Charts;





namespace Car_Care_Service__.NET_
{
    public partial class Form1 : Form
    {
        
        BindingSource TransactionsBS = new BindingSource();

        Bitmap memoryImage;
        private readonly Dictionary<string, int> operationPrices = new Dictionary<string, int>
        {
            { "غسيل كامل للسيارة و كيماوي موتور ، صالون", 450 },






            { " غسيل داخلي وخارجي وموتور كيماوي", 170 },
            { " غسیل داخلي وخارجي", 135 },
            { " غسیل موتور كيماوي", 60 },
            { " غسيل خارجي", 70 },
            { " غسيل داخلي", 70 },
            { " اسکوتر", 50 }
        };

        private int totalPrice = 0;

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
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (var operation in operationPrices.Keys)
            {
                checkedListBox1.Items.Add(operation);
            }

            // Subscribe to ItemCheck event
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            InitializeDatabaseConnection();
        }
        private void InitializeDatabaseConnection()
        {
            string databasePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Database.mdf");
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadCustomers(string searchQuery = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;

                    
                    if (string.IsNullOrWhiteSpace(searchQuery))
                    {
                        query = "SELECT * FROM CarWashServices";
                    }
                    else
                    {
                        query = "SELECT * FROM CarWashServices WHERE CustomerName LIKE @SearchQuery";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            cmd.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dataTable = new System.Data.DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                            System.Data.DataTable dt = new System.Data.DataTable();
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
              .Where(c => Char.IsLetter(c)));

            if (value != ctrl.Text)
                ctrl.Text = value;
            string searchQuery = textBox5.Text.Trim();
            LoadCustomers(searchQuery);
        }
        
            //string query = "" +@"                SELECT 
            //        t.TransactionID AS ID,
            //        c.Name AS CustomerName,
            //        c.Telephone AS Phone,
            //        t.CarID,
            //        t.CurrentDate,
            //        t.Total AS Total,
            //        t.COM AS VehicleType,
            //        STRING_AGG(s.ServiceName + ' (' + CAST(s.Price AS NVARCHAR) + ' LE)', ', ') AS Services,
            //        sa.SaleDescription AS Deal,
            //        sa.DiscountPercentage AS Discount,
            //        t.Notes
            //    FROM 
            //        Transactions t
            //    JOIN 
            //        Customers c ON t.CustomerID = c.CustomerID
            //    JOIN 
            //        TransactionServices ts ON t.TransactionID = ts.TransactionID
            //    JOIN 
            //        Services s ON ts.ServiceID = s.ServiceID
            //    JOIN 
            //        Sales sa ON t.SaleID = sa.SaleID
            //    GROUP BY 
            //        t.TransactionID, c.Name, c.Telephone, t.CarID, t.CurrentDate, t.Total, t.COM, sa.SaleDescription, sa.DiscountPercentage, t.Notes;
            //"
            string query = "SELECT * FROM CarWashServices"

                ;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Example custom SQL query
            // Load the data when the form loads
            LoadData(query);
        }
        string databasePath => System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Database.mdf");
        string connectionString => $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;";

        //private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"J:\\Visual Studio\\Car Care Service (.NET)\\Car Care Service (.NET)\\Database.mdf\";Integrated Security=True";
        //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CarWashServices"].ConnectionString;
        private void LoadData(string customQuery)
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(customQuery, connection);

                    
                    System.Data.DataTable dataTable = new System.Data.DataTable();
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
        //{   if (txtCustomerID.TextLength < 11) {
        //        MessageBox.Show($"Error adding record: check the telephone number size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
         //   else {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string insertQuery = "INSERT INTO CarWashServices (CustomerName, PhoneNumber, CurrentDate, CarID, VehicleType, Services, Discount, Total, Notes) " +
                           "VALUES (@CustomerName, @PhoneNumber, GETDATE(), @CarID, @VehicleType, @Services, @Discount, @Total, @Notes)";

                        {
                            // Example parameters (replace with your input controls)
                            SqlCommand command = new SqlCommand(insertQuery, connection);



                            command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                            command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
                            command.Parameters.AddWithValue("@CarID", txtCarID.Text);
                            command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                            command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                            string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            cb += checkedListBox1.Items[i];
                        }
                        ;

                        command.Parameters.AddWithValue("@Services", cb);
                            command.Parameters.AddWithValue("@Discount", txtSaleID.Text);
                            //command.Parameters.AddWithValue("@Total", label8.Text);
                            decimal total = decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100);
                            command.Parameters.AddWithValue("@Total", total);
                            command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                            txtCustomerID.Text = "";
                            textBox2.Text = "";
                            txtCarID.Text = "";
                            txtVehicleType.Text = "";
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, false);
                        }
                        ;
                        txtCarID.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox2.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        txtSaleID.Text = "";
                            txtNotes.Text = "";
                            label8.Text = "0";

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
       // }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //string updateQuery = @"UPDATE Transactions 
                    //               SET Total = @Total, Notes = @Notes 
                    //               WHERE TransactionID = @TransactionID";
                    string updateQuery = "UPDATE CarWashServices SET CustomerName = @CustomerName, PhoneNumber = @PhoneNumber, CarID = @CarID, " +
                       "VehicleType = @VehicleType, Services = @Services, Discount = @Discount, Total = @Total, Notes = @Notes " +
                       "WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Example parameters
                        //command.Parameters.AddWithValue("@Total", label8.Text);
                        //command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        //command.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
                        command.Parameters.AddWithValue("@CarID", txtCarID.Text);
                        command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            cb += checkedListBox1.Items[i];
                        }
                        ;
                        command.Parameters.AddWithValue("@Services", cb);
                        command.Parameters.AddWithValue("@Discount", txtSaleID.Text);
                        decimal total = decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100);
                        command.Parameters.AddWithValue("@Total", total);
                        command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        txtCustomerID.Text = "";
                        textBox2.Text = "";
                        txtCarID.Text = "";
                        txtVehicleType.Text = "";
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, false);
                        }
                        ;
                        txtCarID.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox2.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        txtSaleID.Text = "";
                        txtNotes.Text = "";
                        label8.Text = "0";
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
                        string deleteQuery = "DELETE FROM CarWashServices WHERE ID = @ID";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ID", ID.Text);

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
            if (IsValidInput(input) || (letterCount > 0 &&   numberCount > 0))
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
            string pattern = @"^(?=(.*[^A-Za-z0-9!-/:-@[-`{-~]){1,3})(?=(.*\d){1,4}).+$";
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
            string input = textBox2.Text;

            // Validate input
            if (IsValidInput2(input))
            {
                textBox2.BackColor = System.Drawing.Color.LightGreen; // Change background to indicate success
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.LightCoral; // Change background to indicate failure
            }
        }
        private bool IsValidInput2(string input)
        {
            // Regular expression to check for at least 3 letters and 4 numbers
            string pattern = @"([0-9]{11})";
            return Regex.IsMatch(input, pattern);
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
            System.Windows.Forms.TextBox txtBox = sender as System.Windows.Forms.TextBox;

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

        //private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char keyChar = e.KeyChar;

        //    // Allow backspace (handled in KeyDown) and new lines
        //    if (keyChar == '\b' || keyChar == '\u0020')
        //    {
        //        return;
        //    }

        //    if (char.IsLetter(keyChar))
        //    {
        //        // Allow letters if we haven't reached 3 yet
        //        if (letterCount < 3)
        //        {
        //            letterCount++;
        //        }
        //        else
        //        {
        //            e.Handled = true; // Reject input
        //        }
        //    }
        //    else if (char.IsDigit(keyChar))
        //    {
        //        // Allow numbers if we haven't reached 4 yet
        //        if (numberCount < 4)
        //        {
        //            numberCount++;
        //        }
        //        else
        //        {
        //            e.Handled = true; // Reject input
        //        }
        //    }
        //    else
        //    {
        //        // Reject any non-alphanumeric character
        //        e.Handled = true;
        //    }
        //}
        //private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char keyChar = e.KeyChar;

        //    // Allow backspace
        //    if (keyChar == '\b')
        //    {
        //        if (txtCarID.Text.Length > 0)
        //        {
        //            // Remove the last character and the preceding space
        //            int cursorPosition = txtCarID.SelectionStart;
        //            if (cursorPosition > 1 && txtCarID.Text[cursorPosition - 1] == ' ')
        //            {
        //                txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 2, 2);
        //                txtCarID.SelectionStart = cursorPosition - 2; // Adjust the cursor position
        //            }
        //            else if (cursorPosition > 0)
        //            {
        //                txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 1, 1);
        //                txtCarID.SelectionStart = cursorPosition - 1; // Adjust the cursor position
        //            }
        //        }
        //        e.Handled = true; // Prevent default backspace behavior
        //        return;
        //    }

        //    // Allow letters and numbers only
        //    if (char.IsLetterOrDigit(keyChar))
        //    {
        //        // Append the character and a space
        //        int cursorPosition = txtCarID.SelectionStart;
        //        txtCarID.Text = txtCarID.Text.Insert(cursorPosition, keyChar + " ");
        //        txtCarID.SelectionStart = cursorPosition + 2; // Move cursor past the character and space
        //        e.Handled = true; // Prevent default character handling
        //    }
        //    else
        //    {
        //        // Reject any non-alphanumeric character
        //        e.Handled = true;
        //    }
        //}
        //private void txtCarID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
        //    {
        //        int cursorPosition = txtCarID.SelectionStart;

        //        // If the cursor is within the text, find the character to be deleted
        //        if (cursorPosition > 0 && cursorPosition <= txtCarID.Text.Length)
        //        {
        //            char deletedChar;

        //            // Handle Backspace (deletes the character before the cursor)
        //            if (e.KeyCode == Keys.Back)
        //            {
        //                deletedChar = txtCarID.Text[cursorPosition - 1];
        //            }
        //            // Handle Delete (deletes the character at the cursor position)
        //            else
        //            {
        //                if (cursorPosition == txtCarID.Text.Length)
        //                    return; // No character to delete
        //                deletedChar = txtCarID.Text[cursorPosition];
        //            }

        //            // Adjust the counts based on the deleted character
        //            if (char.IsLetter(deletedChar))
        //            {
        //                letterCount--;
        //            }
        //            else if (char.IsDigit(deletedChar))
        //            {
        //                numberCount--;
        //            }
        //        }
        //    }
        //}
        private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Allow backspace
            if (keyChar == '\b')
            {
                return; // Handle deletion logic in KeyDown
            }

            // Allow letters within the maximum limit
            if (char.IsLetter(keyChar))
            {
                if (letterCount < 3) // Maximum of 3 letters
                {
                    letterCount++;
                }
                else
                {
                    e.Handled = true; // Reject input
                    return;
                }
            }
            // Allow digits within the maximum limit
            else if (char.IsDigit(keyChar))
            {
                if (numberCount < 4) // Maximum of 4 numbers
                {
                    numberCount++;
                }
                else
                {
                    e.Handled = true; // Reject input
                    return;
                }
            }
            else
            {
                // Reject any non-alphanumeric character
                e.Handled = true;
                return;
            }

            // Append the character and a space
            int cursorPosition = txtCarID.SelectionStart;
            txtCarID.Text = txtCarID.Text.Insert(cursorPosition, keyChar + " ");
            txtCarID.SelectionStart = cursorPosition + 2; // Move cursor past the character and space
            e.Handled = true; // Prevent default character handling
        }

        private void txtCarID_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCarID.Text.Length == 0) {
                letterCount = 0;
                numberCount = 0;

                    }

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
                        if (cursorPosition > 1 && txtCarID.Text[cursorPosition - 1] == ' ')
                        {
                            deletedChar = txtCarID.Text[cursorPosition - 2];
                            txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 2, 2);
                            txtCarID.SelectionStart = cursorPosition - 2;
                        }
                        else
                        {
                            deletedChar = txtCarID.Text[cursorPosition - 1];
                            txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 1, 1);
                            txtCarID.SelectionStart = cursorPosition - 1;
                        }
                    }
                    // Handle Delete (deletes the character at the cursor position)
                    else
                    {
                        if (cursorPosition < txtCarID.Text.Length - 1 && txtCarID.Text[cursorPosition + 1] == ' ')
                        {
                            deletedChar = txtCarID.Text[cursorPosition];
                            txtCarID.Text = txtCarID.Text.Remove(cursorPosition, 2);
                        }
                        else
                        {
                            deletedChar = txtCarID.Text[cursorPosition];
                            txtCarID.Text = txtCarID.Text.Remove(cursorPosition, 1);
                        }
                        txtCarID.SelectionStart = cursorPosition;
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

                e.Handled = true; // Prevent default deletion behavior
            }
        }
        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string operation = checkedListBox1.Items[e.Index].ToString();

            // Adjust the total price based on the check state
            if (e.NewValue == CheckState.Checked)
            {
                totalPrice += operationPrices[operation];
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                totalPrice -= operationPrices[operation];
            }

            // Update the label
            label8.Text = $"{totalPrice}";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtSaleID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Allow backspace (handled in KeyDown) and new lines
            if (keyChar == '\b' )
            {
                return;
            }

            if (char.IsLetter(keyChar))
            {
                // Allow letters if we haven't reached 3 yet
            
               
                    e.Handled = true; // Reject input
               
            }
            else if (char.IsDigit(keyChar))
            {
                int x = int.Parse(txtSaleID.Text) + keyChar - '0';
                if (x>=100)
                {

                   e.Handled = true; 
                }
               
            }
            else
            {
                // Reject any non-alphanumeric character
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox5.Text.Trim();
            LoadCustomers(searchQuery);

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
        //private void HandleBackspace()
        //{

        //}

    
}




