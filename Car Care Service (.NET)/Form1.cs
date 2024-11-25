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

        //Bitmap memoryImage;
        private readonly Dictionary<string, int> operationPrices = new Dictionary<string, int>
        {
            { "غسيل كامل للسيارة و كيماوي موتور ، صالون", 450/2 },
            { "غسيل سقف كيماوي", 200/2 },






            { " غسيل داخلي وخارجي وموتور كيماوي", 170 / 2 },
            { " غسیل داخلي وخارجي", 135 /2 },
            { " غسیل موتور كيماوي", 60 / 2 },
            { " غسيل خارجي", 70 /2 },
            { " غسيل داخلي", 70 / 2 },
            { " اسکوتر", 50 / 2 }
        };

        private int totalPrice = 0;

        public Form1()
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
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

            Costs.Text = "0";
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

        }



        private void btnDailyTotal_Click(object sender, EventArgs e)
        {
            string selectedDate = Date.Text;
            if (!IsValidDate(Date.Text))
            {
                MessageBox.Show("Please enter a valid date in the format dd/MM/yyyy.", "wrong input format", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "SELECT SUM(Total) - SUM(Costs) AS DailyTotal FROM CarWashServices WHERE CurrentDate = @SelectedDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", DateTime.Parse(selectedDate));
                    object result = cmd.ExecuteScalar();
                    label9.Text = $"{result ?? 0} : الدخل اليومي";
                }
            }
        }

        private void btnMonthlyTotal_Click(object sender, EventArgs e)
        {

            // Validate date input
            if (!IsValidDate(Date.Text))
            {
                MessageBox.Show("Please enter a valid date in the format dd/MM/yyyy.");
                return;
            }

            string selectedDate = Date.Text; // e.g., "24/11/2024"
            DateTime date = DateTime.Parse(selectedDate);
            string query = @"
                SELECT SUM(Total) - SUM(Costs) AS MonthlyTotal 
                FROM CarWashServices 
                WHERE YEAR(CurrentDate) = @SelectedYear AND MONTH(CurrentDate) = @SelectedMonth";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SelectedYear", date.Year);
                    cmd.Parameters.AddWithValue("@SelectedMonth", date.Month);
                    object result = cmd.ExecuteScalar();
                    label10.Text = $"{result ?? 0} : الدخل الشهري";
                }
            }
        }
        private bool IsValidDate(string input)
        {
            return DateTime.TryParseExact(input, "dd/MM/yyyy",
                                          System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None, out _);
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            InitializeDatabaseConnection();
            //FetchDailyAndMonthlyTotals();
        }
        private void InitializeDatabaseConnection()
        {
            //string databasePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Database.mdf");
            //string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

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
        //private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(memoryImage, 0, 0);
        //}

  
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

            SaveExcel exporter = new SaveExcel(dataGridView1); 
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
            LoadData(query);
        }
        //string databasePath => System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Database.mdf");
        //string connectionString => $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;";
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        //private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"J:\\Visual Studio\\Car Care Service (.NET)\\Car Care Service (.NET)\\Database.mdf\";Integrated Security=True";
        
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";


        //private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf\";Integrated Security=True";
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
                System.Console.Write("tsk");
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
                        string insertQuery = "INSERT INTO CarWashServices (CustomerName, PhoneNumber, CurrentDate, CarID, VehicleType, Services, Discount, Costs, Total, Notes) " +
                           "VALUES (@CustomerName, @PhoneNumber, GETDATE(), @CarID, @VehicleType, @Services, @Discount, @Costs, @Total, @Notes)";

                        {
                            
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
                            ;
                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100)))- decimal.Parse(Costs.Text);
                        

                            command.Parameters.AddWithValue("@Total", total);
                            command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                            txtCustomerID.Text = "";
                            textBox2.Text = "";
                            txtCarID.Text = "";
                            Costs.Text = "0";
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            checkedListBox1.SetItemChecked(i, false);
                        }
                        ;
                        txtCarID.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox2.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox1.Text = "";
                        txtVehicleType.Text = "";
                        txtSaleID.Text = "0";
                            txtNotes.Text = "";
                            label8.Text = "0";

                        connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(query); 
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
                       "VehicleType = @VehicleType, Services = @Services, Discount = @Discount,Costs = @Costs ,Total = @Total, Notes = @Notes " +
                       "WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        
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
                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100))) - decimal.Parse(Costs.Text);
                        
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
                        textBox1.Text = "";
                        txtSaleID.Text = "0";
                        Costs.Text = "0";
                        txtNotes.Text = "";
                        label8.Text = "0";
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(query); 
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
                        ID.Text = "";
                    }
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(query); 
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
        private int nletterCount = 4;
        private int nnumberCount = 0;
        private int lletterCount = 0;
        private int lnumberCount = 4;

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

            if (textBox1.TextLength == 0)
            {
                textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
            }
            else
            {
                if (IsValidInput(input) || (nletterCount > 0 && nnumberCount > 0))
                {
                    txtCarID.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    txtCarID.BackColor = System.Drawing.Color.LightCoral;
                }
            }



            //string value = string.Concat(ctrl
            //  .Text
            //  .Where(c => c >= '0' && c <= '9'));

            //if (value != ctrl.Text)
            //    ctrl.Text = value;
        }
        private bool IsValidInput(string input)
        {
            
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

            
            if (IsValidInput2(input))
            {
                textBox2.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.LightCoral;
            }
        }
        private bool IsValidInput2(string input)
        {
            
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
              .Where(c => Char.IsLetter(c) || c=='\u0020' ));

            if (value != ctrl.Text)
                ctrl.Text = value;

        }

        private void elipseControl1_Click_1(object sender, EventArgs e)
        {

        }

  

        private void txtVehicleType_Leave(object sender, EventArgs e)
        {
            
            System.Windows.Forms.TextBox txtBox = sender as System.Windows.Forms.TextBox;

            
            if (txtBox != null)
            {
                
                string inputText = txtBox.Text.Trim();

                
                if (inputText == "سيارة" || inputText == "سكوتر")
                {
                    
                }
                else
                {
                    
                    txtBox.Text = string.Empty;

                    
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة: سيارة أو سكوتر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtVehicleType_TextChanged(object sender, EventArgs e)
        {
           
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                string inputText = comboBox.Text.Trim(); 

                
                if (inputText == "سيارة" || inputText == "سكوتر")
                {
                    
                }
                else
                {
                   
                    comboBox.Text = string.Empty;

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
            //ComboBox ctrl = (sender as ComboBox);

            //string value = string.Concat(ctrl
            //  .Text
            //  .Where(c => c >= '0' && c <= '9'));

            //if (value != ctrl.Text)
            //    ctrl.Text = value;
        }

        private void txtSaleID_Leave(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                string inputText = comboBox.Text.Trim();

               
                if (int.TryParse(inputText, out int value))
                {
                    
                    if (value >= 0 && value <= 100)
                    {
                        
                        return;
                    }
                }

                
                comboBox.Text = "0" ;
                MessageBox.Show("الرجاء إدخال قيمة رقمية بين 0 و 100 فقط", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char keyChar = e.KeyChar;

        //    if (keyChar == '\b' || keyChar == '\u0020')
        //    {
        //        return;
        //    }

        //    if (char.IsLetter(keyChar))
        //    {
        
        //        if (letterCount < 3)
        //        {
        //            letterCount++;
        //        }
        //        else
        //        {
        //            e.Handled = true; 
        //        }
        //    }
        //    else if (char.IsDigit(keyChar))
        //    {
        //        
        //        if (numberCount < 4)
        //        {
        //            numberCount++;
        //        }
        //        else
        //        {
        //            e.Handled = true; 
        //        }
        //    }
        //    else
        //    {
        //        
        //        e.Handled = true;
        //    }
        //}
        //private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char keyChar = e.KeyChar;

        //    
        //    if (keyChar == '\b')
        //    {
        //        if (txtCarID.Text.Length > 0)
        //        {
        //            
        //            int cursorPosition = txtCarID.SelectionStart;
        //            if (cursorPosition > 1 && txtCarID.Text[cursorPosition - 1] == ' ')
        //            {
        //                txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 2, 2);
        //                txtCarID.SelectionStart = cursorPosition - 2; 
        //            }
        //            else if (cursorPosition > 0)
        //            {
        //                txtCarID.Text = txtCarID.Text.Remove(cursorPosition - 1, 1);
        //                txtCarID.SelectionStart = cursorPosition - 1; 
        //            }
        //        }
        //        e.Handled = true;
        //        return;
        //    }

        //    
        //    if (char.IsLetterOrDigit(keyChar))
        //    {
        //        
        //        int cursorPosition = txtCarID.SelectionStart;
        //        txtCarID.Text = txtCarID.Text.Insert(cursorPosition, keyChar + " ");
        //        txtCarID.SelectionStart = cursorPosition + 2; 
        //        e.Handled = true; 
        //    }
        //    else
        //    {
        //        
        //        e.Handled = true;
        //    }
        //}
        //private void txtCarID_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
        //    {
        //        int cursorPosition = txtCarID.SelectionStart;

        //       
        //        if (cursorPosition > 0 && cursorPosition <= txtCarID.Text.Length)
        //        {
        //            char deletedChar;

        //            
        //            if (e.KeyCode == Keys.Back)
        //            {
        //                deletedChar = txtCarID.Text[cursorPosition - 1];
        //            }
        //            
        //            else
        //            {
        //                if (cursorPosition == txtCarID.Text.Length)
        //                    return; 
        //                deletedChar = txtCarID.Text[cursorPosition];
        //            }

        //           
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

            
            if (keyChar == '\b')
            {
                return; 
            }

            
            if (char.IsLetter(keyChar))
            {
                if (nletterCount < 3) 
                {
                    nletterCount++;
                }
                else
                {
                    e.Handled = true; 
                    return;
                }
            }
            
            else if (char.IsDigit(keyChar))
            {
                if (nnumberCount < 4) 
                {
                    nnumberCount++;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
               
                e.Handled = true;
                return;
            }

            
            int cursorPosition = txtCarID.SelectionStart;
            txtCarID.Text = txtCarID.Text.Insert(cursorPosition, keyChar + " ");
            txtCarID.SelectionStart = cursorPosition + 2; 
            e.Handled = true; 
        }

        private void txtCarID_KeyDown(object sender, KeyEventArgs e)
        {   
            
            if (txtCarID.Text.Length == 0) {
                
                nnumberCount = 0;

                    }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                int cursorPosition = txtCarID.SelectionStart;

                
                if (cursorPosition > 0 && cursorPosition <= txtCarID.Text.Length)
                {
                    char deletedChar;

                    
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

                    
                    if (char.IsLetter(deletedChar))
                    {
                        nletterCount--;
                    }
                    else if (char.IsDigit(deletedChar))
                    {
                        nnumberCount--;
                    }
                }

                e.Handled = true; 
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

            
            if (e.NewValue == CheckState.Checked)
            {
                totalPrice += operationPrices[operation];
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                totalPrice -= operationPrices[operation];
            }

            
            label8.Text = $"{totalPrice}";
           // decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text);
            
            label14.Text = $"{fs}";
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

            
            if (keyChar == '\b' )
            {
                return;
            }

            if (char.IsLetter(keyChar))
            {



                e.Handled = true;

            }
            else if (char.IsDigit(keyChar))
            {
                int x = int.Parse(txtSaleID.Text) + keyChar - '0';
                if (x > 100)
                {

                    //e.Handled = true;
                    txtSaleID.Text = "";
                }
                
            }
            else
            {
                
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            if (textBox1.TextLength == 0) {
                textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
            }
            else
            {

           
            if (IsValidInput(input) || (lletterCount > 0 && lnumberCount > 0))
            {
                textBox1.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                textBox1.BackColor = System.Drawing.Color.LightCoral;
            }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                lletterCount = 0;
                

            }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                int cursorPosition = textBox1.SelectionStart;


                if (cursorPosition > 0 && cursorPosition <= textBox1.Text.Length)
                {
                    char deletedChar;


                    if (e.KeyCode == Keys.Back)
                    {
                        if (cursorPosition > 1 && textBox1.Text[cursorPosition - 1] == ' ')
                        {
                            deletedChar = textBox1.Text[cursorPosition - 2];
                            textBox1.Text = textBox1.Text.Remove(cursorPosition - 2, 2);
                            textBox1.SelectionStart = cursorPosition - 2;
                        }
                        else
                        {
                            deletedChar = textBox1.Text[cursorPosition - 1];
                            textBox1.Text = textBox1.Text.Remove(cursorPosition - 1, 1);
                            textBox1.SelectionStart = cursorPosition - 1;
                        }
                    }

                    else
                    {
                        if (cursorPosition < textBox1.Text.Length - 1 && textBox1.Text[cursorPosition + 1] == ' ')
                        {
                            deletedChar = textBox1.Text[cursorPosition];
                            textBox1.Text = textBox1.Text.Remove(cursorPosition, 2);
                        }
                        else
                        {
                            deletedChar = textBox1.Text[cursorPosition];
                            textBox1.Text = textBox1.Text.Remove(cursorPosition, 1);
                        }
                        textBox1.SelectionStart = cursorPosition;
                    }


                    if (char.IsLetter(deletedChar))
                    {
                        lletterCount--;
                    }
                    else if (char.IsDigit(deletedChar))
                    {
                        lnumberCount--;
                    }
                }

                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;


            if (keyChar == '\b')
            {
                return;
            }


            if (char.IsLetter(keyChar) && !(keyChar >='a' && keyChar <= 'z')&& !(keyChar >= 'A' && keyChar <= 'Z'))
            {
                if (lletterCount < 3)
                {
                    lletterCount++;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            else if (char.IsDigit(keyChar))
            {
                if (lnumberCount < 4)
                {
                    lnumberCount++;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {

                e.Handled = true;
                return;
            }


            int cursorPosition = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(cursorPosition, keyChar + " ");
            textBox1.SelectionStart = cursorPosition + 2;
            e.Handled = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Costs_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));

            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100))))  - decimal.Parse(Costs.Text);
            label14.Text = $"{fs}";
        }

        private void txtSaleID_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));

            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100))))  - decimal.Parse(Costs.Text);
            label14.Text = $"{fs}";
        }
    }
        //private void HandleBackspace()
        //{

        //}

    
}




