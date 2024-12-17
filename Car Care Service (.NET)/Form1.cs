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
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;
using System.Globalization;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Office2010.Excel;

using System.Reflection;
using DocumentFormat.OpenXml.Bibliography;






namespace Car_Care_Service__.NET_
{
    public partial class Form1 : Form

    {

        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private Bitmap logoImage; 
        private Bitmap qrCodeImage;
        //private TextBox PID;
        //private DataGridView dataGridView2;

        private string customerName, phoneNumber, carNumber, totalAmount, leftToPay ,dated ,notes ,tID , tprofit , tCosts , discp  , time , disc, Vehicletype , tincome;
        private string[] services;

        private bool necessaryphone = true;
        BindingSource TransactionsBS = new BindingSource();
        private bool isFullScreen = false;

        //Bitmap memoryImage;
        private readonly Dictionary<string, double> operationPrices = new Dictionary<string, double>
        {
            { " اشتراك شهري", 500/2 },
            { " عرض ال499", 500/2 },
            { " غسيل كامل للسيارة و كيماوي موتور ، صالون", 450/2 },
            { " غسيل سقف كيماوي", 200/2 },




            { " غسيل داخلي وخارجي وموتور كيماوي", 170 / 2 },
            { " عرض شهر 12", 100/2 },
            { " غسیل داخلي وخارجي", 67.5 },
            { " تنظيف جنوط كيماوي", 60/2 },
            { " غسیل موتور كيماوي", 60 / 2 },
            { " غسيل خارجي", 70 /2 },
            { " غسيل داخلي", 70 / 2 },
            { " اسکوتر", 50 / 2 },
            { " تنظيف شنطة كامل", 20 / 2 }

        };

        private double totalPrice = 0;

        private Dictionary<string, double> normalizedOperationPrices;
        public Form1()
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            InitializeComponent();

            System.Drawing.Font currentFont = dataGridView1.DefaultCellStyle.Font;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font(currentFont.FontFamily, 11);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(currentFont.FontFamily, 9);

            System.Drawing.Font currentFont2 = dataGridView2.DefaultCellStyle.Font;
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font(currentFont2.FontFamily, 11);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(currentFont2.FontFamily, 9);

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
            Date.MaxLength = 10;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (var operation in operationPrices.Keys)
            {
                checkedListBox1.Items.Add(operation);
            }

            //Costs.Text = "0";
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

            Timer timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += Timer_Tick;
            timer.Start();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;

            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.Resize += Form1_Resize;

            //this.KeyPreview = true; // Ensure form captures key events
            //this.KeyDown += Form1_KeyDown;
            txtVehicleType.SelectedIndex = 0;



            // Existing setup
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.EndPrint += PrintDocument_EndPrint; // Attach EndPrint event

            printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };

            var assembly = Assembly.GetExecutingAssembly();

            // Construct the resource name (use your project's default namespace + file path)
            string resourceName = "Car_Care_Service__.NET_.assets.qrlogo1.jpg";

            // Load the embedded resource as a stream
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Resource '{resourceName}' not found.");
               logoImage = new Bitmap(stream);
            }
            resourceName = "Car_Care_Service__.NET_.assets.IMG-20241216-WA0005.jpg";

            // Load the embedded resource as a stream
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Resource '{resourceName}' not found.");
                qrCodeImage = new Bitmap(stream);
            }

            normalizedOperationPrices = CreateNormalizedDictionary(operationPrices);

        }

        private bool isPrintedSuccessfully = false;

        // Print_Click logic
        private void Print_Click(object sender, EventArgs e)
        {
            string filterID = PID.Text.Trim();

            if (string.IsNullOrWhiteSpace(filterID))
            {
                MessageBox.Show("Please enter a valid PID.");
                return;
            }

            // Check if the ID exists in the DataGridView
            bool idExists = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ID"].Value?.ToString() == filterID)
                {
                    idExists = true;
                    break;
                }
            }

            if (!idExists)
            {
                MessageBox.Show($"No data found for PID: {filterID}");
                return;
            }

            // Reset the printing status
            isPrintedSuccessfully = false;

            // Show the PrintPreviewDialog
            string tsko = "هل انت متأكد من رقم العملية حيث انه سيتم محوها حين الموافقة";
            DialogResult result = MessageBox.Show(tsko,
                                                 "Confirm Deletion",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                FetchCarWashData(PID.Text);
                printPreviewDialog.ShowDialog();
            }
        }

        
        // TODO
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define starting position and font settings
            int startX = 5;
            int startY = 5;
            int offsetY = 20;
            int paperWidth = 280; // 72mm paper width (in pixels at 96 DPI)
            System.Drawing.Font regularFont = new System.Drawing.Font("Aria", 8, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("Readex Pro Deca Medium", 10, FontStyle.Bold);

            // Drawing Logo and Title
            if (logoImage != null)
            {
                e.Graphics.DrawImage(logoImage, startX+102, startY, 75, 75);
            }
            offsetY += 60;
            e.Graphics.DrawString("ON ROAD CAR CARE", boldFont, Brushes.Black, startX + 65, offsetY);
            offsetY += 20;

            // Draw Date and Time
            //string dateTime = DateTime.Now.ToString("yyyy/MM/dd - hh:mm tt");
            dated = dated.Substring(0, 10);
            DateTime today = DateTime.Now;
            CultureInfo arabicCulture = new CultureInfo("ar-SA");
            string dayNameInArabic = today.ToString("dddd", arabicCulture);
            
            

            // Client Information
            e.Graphics.DrawString($"{dated} / {time} / {dayNameInArabic}", regularFont, Brushes.Black, startX + 60, startY + offsetY);
            offsetY += 20; 
            e.Graphics.DrawString($"Name             : {customerName}", regularFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            e.Graphics.DrawString($"Telephone   : {phoneNumber}", regularFont, Brushes.Black, startX , startY + offsetY);
            offsetY += 20;
            

            e.Graphics.DrawString($"Num Car       : {carNumber}", regularFont, Brushes.Black, startX , startY + offsetY);
            offsetY += 20;

            // Table Header
            e.Graphics.DrawLine(Pens.Black, startX, startY + offsetY, startX + paperWidth-10, startY + offsetY);
            e.Graphics.DrawString("السعر", boldFont, Brushes.Black, startX, startY + offsetY);
            e.Graphics.DrawString("الخدمة", boldFont, Brushes.Black, startX + 200, startY + offsetY);
            offsetY += 20;
            e.Graphics.DrawLine(Pens.Black, startX, startY + offsetY, startX + paperWidth-10, startY + offsetY);
            offsetY += 5;

            // Table Rows (Example Rows)
            //string[,] services = {
            //    { "Car Wash", "150" },
            //    { "Oil Change", "200" },
            //    { "Interior Cleaning", "100" }
            //};

            Pen dottedPen1 = new Pen(System.Drawing.Color.Black, 1);
            dottedPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

           

            foreach (var service in services)
            {
                offsetY += 10;
                string normalizedService = NormalizeArabicText(service.Trim());
                if (normalizedOperationPrices.TryGetValue(normalizedService, out double price))
                {
                    e.Graphics.DrawString($"{price*2}", regularFont, Brushes.Black, startX+5, startY + offsetY);

            }

                //offsetY += 10;
               
                //offsetY += 10;
                int chunkSize = 17;
                for (int i = 0; i < service.Length; i += chunkSize)
                {
                    // Determine the length of the current chunk
                    int length = Math.Min(chunkSize, service.Length - i);

                    // Extract the substring chunk
                    string chunk = service.Substring(i, length);

                    // Draw the string
                    e.Graphics.DrawString(chunk, regularFont, Brushes.Black, startX+180, startY + offsetY);

                    // Move the Y offset for the next line
                    offsetY += 20;
                }
            }
            int a = 0;
            
                

                offsetY += 20;
                e.Graphics.DrawLine(dottedPen1, startX + 60, startY + offsetY-15 , startX + 220, startY + offsetY-15);
                 
                
            e.Graphics.DrawString("الحساب", boldFont, Brushes.Black, startX + 200, startY + offsetY-10);
                e.Graphics.DrawString($"{tprofit}",boldFont, Brushes.Black, startX + 20, startY + offsetY-10);
                e.Graphics.DrawString($"ج.م", regularFont, Brushes.Black, startX, startY + offsetY - 15);

            //e.Graphics.DrawLine(dottedPen1, startX + 60, startY + offsetY + 15, startX + 240, startY + offsetY + 15);
            //offsetY += 20;




            //if (decimal.Parse(disc) != 0) {
               
                    e.Graphics.DrawLine(dottedPen1, startX+60, startY + offsetY + 15, startX + 220, startY + offsetY + 15);
                    a = 1;
                offsetY += 20;
                e.Graphics.DrawString("خصم", regularFont, Brushes.Black, startX + 230, startY + offsetY);
               
                e.Graphics.DrawString($"{disc}", regularFont, Brushes.Black, startX + 20, startY + offsetY);
                e.Graphics.DrawString($"ج.م", regularFont, Brushes.Black, startX, startY + offsetY-2);
               
                
            //}
            //if (decimal.Parse(disc) != 0)
            //{

                    //e.Graphics.DrawLine(dottedPen1, startX + 60, startY + offsetY + 15, startX + 220, startY + offsetY + 15);
                //    a = 1;
                offsetY += 20;
                e.Graphics.DrawString("نسبة الخصم", regularFont, Brushes.Black, startX + 200, startY + offsetY);
                e.Graphics.DrawString($"% {discp}", regularFont, Brushes.Black, startX+5, startY + offsetY);
                offsetY += 20;
            //}

            //foreach (var service in services)
            //{
            //    string normalizedService = NormalizeArabicText(service.Trim());
            //    if (normalizedOperationPrices.TryGetValue(normalizedService, out double price))
            //    {
            //       e.Graphics.DrawString($"{price}", regularFont, Brushes.Black, startX, startY + offsetY);
            //      //  e.Graphics.DrawString($"{price}", regularFont, Brushes.Black, startX + 180, startY + offsetY);
            //     offsetY += 20;
            //    }
            //}

            // Draw Total
            e.Graphics.DrawLine(Pens.Black, startX, startY + offsetY, startX + paperWidth-10, startY + offsetY);
            offsetY += 10;
            e.Graphics.DrawString("الإجمالي", boldFont, Brushes.Black, startX + 200, startY + offsetY);
            e.Graphics.DrawString($"{totalAmount}", boldFont, Brushes.Black, startX+20, startY + offsetY);
            e.Graphics.DrawString($"ج.م", boldFont, Brushes.Black, startX, startY + offsetY-5);
            offsetY += 30;
            e.Graphics.DrawLine(Pens.Black, startX, startY + offsetY, startX + paperWidth-10, startY + offsetY);

            // Payment Details
            //e.Graphics.DrawString("Paid: $300", regularFont, Brushes.Black, startX, startY + offsetY);
            //offsetY += 15;
            //e.Graphics.DrawString("Left to Pay: $150", regularFont, Brushes.Black, startX, startY + offsetY);
            //offsetY += 25;
            offsetY += 10;
            
               

                    e.Graphics.DrawLine(dottedPen1, startX , startY + offsetY + 15, startX + paperWidth - 10 , startY + offsetY + 15);
                 

                if (notes != null) { 
                
                e.Graphics.DrawString($"Notes : {notes}", regularFont, Brushes.Black, startX + 5, startY + offsetY);
                offsetY += 20;
                }

               
          
            // Welcoming Sentence
            e.Graphics.DrawString("              Thank you for choosing", boldFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 15;
            e.Graphics.DrawString("                On Road Car Care❤", boldFont, Brushes.Black, startX, startY + offsetY);
            
            offsetY += 40;

            if (qrCodeImage != null)
            {
                e.Graphics.DrawImage(qrCodeImage, startX + 102, startY + offsetY-20, 75, 75);
            }
            // Contact Information
            offsetY += 57;
            e.Graphics.DrawString(": للمقترحات و الشكاوي يرجي التواصل فون-واتساب", regularFont, Brushes.Black, startX+30, startY + offsetY);
            offsetY += 20;
            e.Graphics.DrawString("01021536569 / 01010357975", regularFont, Brushes.Black, startX+60, startY + offsetY);
            //offsetY += 20;
            //e.Graphics.DrawString("01010357975", regularFont, Brushes.Black, startX, startY + offsetY-20);

            // QR Code at the Bottom




































            //int startX = 50, startY = 50;
            //int cellWidth = 100, cellHeight = 30;


            // Draw column headers
            //for (int col = 0; col < dataGridView2.Columns.Count; col++)
            //{
            //    e.Graphics.DrawRectangle(Pens.Black, startX + col * cellWidth, startY, cellWidth, cellHeight);
            //    e.Graphics.DrawString(dataGridView2.Columns[col].HeaderText,
            //                          this.Font, Brushes.Black,
            //                          startX + col * cellWidth + 5, startY + 5);
            //}

            // Draw filtered rows
            //int rowIndex = 1;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    if (row.Cells["ID"].Value?.ToString() == PID.Text.Trim())
            //    {
            //        for (int col = 0; col < dataGridView2.Columns.Count; col++)
            //        {
            //            e.Graphics.DrawRectangle(Pens.Black, startX + col * cellWidth, startY + rowIndex * cellHeight, cellWidth, cellHeight);
            //            e.Graphics.DrawString(row.Cells[col].Value?.ToString(),
            //                                  this.Font, Brushes.Black,
            //                                  startX + col * cellWidth + 5, startY + rowIndex * cellHeight + 5);
            //        }
            //        rowIndex++;
            //    }
            //}

            // Mark as printed
            isPrintedSuccessfully = true;

                // Parse the ID
                string enteredID = PID.Text;

                // Find the row with the matching ID
                DataGridViewRow matchingRow = dataGridView2.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(row => row.Cells["ID"].Value.ToString() == enteredID);

                if (matchingRow == null)
                {
                    MessageBox.Show("No matching row found for the entered ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extract data from the matching row
                var rowData = string.Empty;
                foreach (DataGridViewCell cell in matchingRow.Cells)
                {
                    if (cell.Value == "")
                    {
                        cell.Value = " ";

                    }
                    rowData += cell.Value + "\n";
                }
                rowData = rowData.TrimEnd(',');

                // Define the folder and file paths
                string folderPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "shared");
                string filePath = System.IO.Path.Combine(folderPath, "sync.txt");

                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //// Write data to the file
                //File.WriteAllText(filePath, rowData);

                //// Delete the row from DataGridView

                //dataGridView2.Rows.Remove(matchingRow);

                File.AppendAllText(filePath, rowData);


                delete(PID.Text);
            
        }

        // EndPrint logic
        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // Only delete if printing was successful and not canceled
            if (isPrintedSuccessfully && !e.Cancel)
            {
                string filterID = PID.Text.Trim();
                if (!string.IsNullOrEmpty(filterID))
                {
                  //  delete(filterID); 
                }
            }
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape) // Detect Ctrl+F
        //    {
        //        ToggleFullScreen();
        //    }
        //}

        //private void ToggleFullScreen()
        //{
        //}

        //private void exitButton_Click(object sender, EventArgs e)
        //{
        //    if (isFullScreen)
        //    {
        //        ToggleFullScreen(); // Revert to normal state
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
               
                    if (isFullScreen)
                    {
                    // Revert to normal state
                    this.TopMost = false;
                    this.FormBorderStyle = FormBorderStyle.Fixed3D; 
                isFullScreen = false;
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                    this.Width = 1366; 
                    this.Height = 768;//709
                    this.WindowState = FormWindowState.Normal;
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
                    else
                    {
                    // Enter full-screen mode
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.StartPosition = FormStartPosition.Manual;
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                    this.TopMost = true;
                    this.TopMost = false;
                    this.WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }

                
                //this.Close(); // Closes the form when Esc is pressed
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void CountHelloOccurrences()
        {
            int ccount = 0;
            int scount = 0;
            int acount = 0;

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new empty row at the bottom (if any)

                // Get the value in the 'words' column
                string cellValue = row.Cells["VehicleType"].Value?.ToString().ToLower() ?? string.Empty;

                // Check if the cell contains the word "hello"
                if (cellValue.Contains("سيارة"))
                {
                    ccount++;

                }
                if (cellValue.Contains("(أخرى)"))
                {
                    acount++;

                }
                if (cellValue.Contains("سكوتر"))
                {
                    scount++;

                }

            }

            // Update the label with the count of "hello"
            cc.Text = $"{ccount} : سيارة";
            sc.Text = $"{scount} : سكوتر";
            ac.Text = $"{acount} : أخرى";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current time
            //label9.Text = DateTime.Now.ToString("hh:mm:ss tt");
            label9.Text = DateTime.Now.ToString("dd/MM/yy hh:mm:ss");
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.Combine("shared", "sync.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The sync file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath).ToList();

                if (lines.Count <= 1) // No data to process after skipping the first line
                {
                    MessageBox.Show("Your Server is Up to Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Skip the first line (old ID)
                

                List<string[]> rows = new List<string[]>();

                // Process records in chunks of 12 lines (ignore the skipped ID)
                while (lines.Count >= 14)
                {
                    string[] record = lines.Take(14).ToArray();
                    rows.Add(record);
                    lines.RemoveRange(0, 14); // Remove the processed lines
                }
               



                InsertRecordsIntoDatabase(rows);

                // Insert records into the database

                // Overwrite the file with remaining lines
                File.WriteAllLines(filePath, lines);
                LoadData(query);
                MessageBox.Show("Data synced successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while syncing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertRecordsIntoDatabase(List<string[]> records)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var record in records)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO CarWashServices (CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,insert, Total, Notes) " +
                        "VALUES (@CustomerName, @PhoneNumber, @CurrentDate, @Time, @CarID, @VehicleType, @Services, @Profit, @Discountp, @Discount, @Costs, @insert, @Total, @Notes)", connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", record[1]);
                        cmd.Parameters.AddWithValue("@PhoneNumber", record[2]);

                        // Extract and parse the date portion
                        string tsk = record[3].Substring(0,10);

                        string input = tsk; // Original string
                        string swapped = "";
                        // Split the string by the dot
                        if (input.Contains("/")){ 
                        string[] parts = input.Split('/');
                           swapped = $"{parts[1]}/{parts[0]}/{parts[2]}";
                        }
                        else if (input.Contains("."))
                        {
                            string[] parts = input.Split('.');

                        swapped = $"{parts[1]}.{parts[0]}.{parts[2]}";
                        }


                        // Swap the first and second parts (day and month)

                        // Swapping
                        tsk = swapped;


                        

                        cmd.Parameters.AddWithValue("@CurrentDate", tsk);

                        // Keep the time as it is
                        cmd.Parameters.AddWithValue("@Time", TimeSpan.Parse(record[4]));

                        cmd.Parameters.AddWithValue("@CarID", record[5]);
                        cmd.Parameters.AddWithValue("@VehicleType", record[6]);
                        cmd.Parameters.AddWithValue("@Services", record[7]);

                        string strSale = record[8].Replace(",", "");
                        string fs = strSale.Substring(0, strSale.Length - 2);

                        cmd.Parameters.AddWithValue("@Profit", decimal.Parse(fs));


                        strSale = record[9].Replace(",", "");
                        fs = strSale.Substring(0, strSale.Length - 2);

                        cmd.Parameters.AddWithValue("@Discountp", decimal.Parse(fs));

                        strSale = record[10].Replace(",", "");
                        fs = strSale.Substring(0, strSale.Length - 2);

                        cmd.Parameters.AddWithValue("@Discount", decimal.Parse(fs));

                        strSale = record[11].Replace(",", "");
                        fs = strSale.Substring(0, strSale.Length - 2); 

                        cmd.Parameters.AddWithValue("@Costs", decimal.Parse(fs));

                        strSale = record[12].Replace(",", "");
                        fs = strSale.Substring(0, strSale.Length - 2);

                        cmd.Parameters.AddWithValue("@income", decimal.Parse(fs));

                        strSale = record[13].Replace(",", "");
                        fs = strSale.Substring(0, strSale.Length - 2);

                        cmd.Parameters.AddWithValue("@Total", decimal.Parse(fs));
                        


                        cmd.Parameters.AddWithValue("@Notes", record[14]);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }


        private void FetchCarWashData(string carWashID)
        {
            string query = "SELECT * FROM CarWashServices1 WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", carWashID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Assign data to variables
                    //ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, Total, Notes
                    tID= reader["ID"].ToString();
                    customerName = reader["CustomerName"].ToString();
                    phoneNumber = reader["PhoneNumber"].ToString();
                    dated = reader["CurrentDate"].ToString();
                    time = reader["Time"].ToString();
                    carNumber = reader["CarID"].ToString();
                    Vehicletype = reader["VehicleType"].ToString();
                    string servicesData = reader["Services"].ToString();

                    //leftToPay = (Convert.ToDecimal(reader["Total"]) - Convert.ToDecimal(reader["Profit"])).ToString("F2");
                    tprofit = reader["Profit"].ToString();
                    discp = reader["Discountp"].ToString();
                    disc  = reader["Discount"].ToString();
                    tCosts = reader["Costs"].ToString();
                    //tincome = reader["income"].ToString();
                    totalAmount = reader["income"].ToString();
                    totalAmount = reader["Total"].ToString();
                    notes = reader["Notes"].ToString();
                    // Parse Services into a table
                    services = ParseServices(servicesData);
                }
            }
        }
        private string[] ParseServices(string servicesData)
        {
          
            var items =  servicesData.Split('/')
                        .Select(item => NormalizeArabicText(item.Trim()))
                        .ToList();
            string[] parsedServices = items.ToArray();

            //for (int i = 0; i < rows.Length; i++)
            //{
            //    parsedServices[i, 0] = rows[i].Split('-')[0]; // Service Name
            //    parsedServices[i, 1] = rows[i].Split('-')[1]; // Price
            //}
            return parsedServices;
        }

        private void btnMonthlyTotal_Click(object sender, EventArgs e)
        {

            //// Validate date input
            //if (!IsValidDate(Date.Text))
            //{
            //    MessageBox.Show("Please enter a valid date in the format dd/MM/yyyy.");
            //    return;
            //}

            //string selectedDate = Date.Text; // e.g., "24/11/2024"
            //DateTime date = DateTime.Parse(selectedDate);
            //string query = @"
            //    SELECT SUM(Total)  AS MonthlyTotal 
            //    FROM CarWashServices 
            //    WHERE YEAR(CurrentDate) = @SelectedYear AND MONTH(CurrentDate) = @SelectedMonth";

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@SelectedYear", date.Year);
            //        cmd.Parameters.AddWithValue("@SelectedMonth", date.Month);
            //        object result = cmd.ExecuteScalar();
            //        MessageBox.Show($"{result ?? 0}" , "الدخل الشهري" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            //        //label10.Text = $"{result ?? 0} : الدخل الشهري";
            //    }
            //}
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
            InitializeDatabaseConnection2();
            fs();
            

            //FetchDailyAndMonthlyTotals();
        }

        private void DisplayMonthlyTotal()
        {
            
            string query = @"
                SELECT SUM(Total) AS MonthlyTotal
                FROM CarWashServices
                WHERE MONTH(CurrentDate) = MONTH(GETDATE()) 
                AND YEAR(CurrentDate) = YEAR(GETDATE());";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    decimal monthlyTotal = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    monthlyTotal = Convert.ToInt64(monthlyTotal);
                    month.Text = $" {monthlyTotal} EGP إجمالي الشهر";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void fs() {

            string userKey = PromptForHashKey();
            string validKey = "12345"; // Replace this with your actual hash key

            if (string.IsNullOrWhiteSpace(userKey) || userKey != validKey)
            {
                MessageBox.Show("Invalid or no hash key provided. The program will now exit.",
                                "Access Denied",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.Close(); // Close the application
            }
        }
        private string PromptForHashKey()
        {
            using (var hashKeyPrompt = new HashKeyPrompt())
            {
                if (hashKeyPrompt.ShowDialog() == DialogResult.OK)
                {
                    return hashKeyPrompt.HashKey; // Assume HashKeyPrompt has a `HashKey` property
                }
            }
            return null;
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
        private void InitializeDatabaseConnection2()
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
                            dataGridView2.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadTelephone(string searchQuery = "")
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
                        query = "SELECT * FROM CarWashServices WHERE PhoneNumber LIKE @SearchQuery";
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
                            dataGridView2.DataSource = dataTable;
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
        private Dictionary<string, double> CreateNormalizedDictionary(Dictionary<string, double> originalDict)
        {
            var normalizedDict = new Dictionary<string, double>();
            foreach (var kvp in originalDict)
            {
                string normalizedKey = NormalizeArabicText(kvp.Key.Trim());
                if (!normalizedDict.ContainsKey(normalizedKey))
                {
                    normalizedDict.Add(normalizedKey, kvp.Value);
                }
            }
            return normalizedDict;
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
        string query = "SELECT * FROM CarWashServices";
        string query1 = "SELECT * FROM CarWashServices1";

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData(query);
            LoadData1(query1);
        }
        //string databasePath => System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Database.mdf");
        //string connectionString => $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{databasePath}"";Integrated Security=True;";
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        //private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"J:\\Visual Studio\\Car Care Service (.NET)\\Car Care Service (.NET)\\Database.mdf\";Integrated Security=True";

        //private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        //private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ss"].ConnectionString;

        //private string connectionString = "Data Source=DESKTOP-VL1LIMA\\toxic;AttachDbFilename=\"J:\\VISUAL STUDIO\\CAR CARE SERVICE(.NET)\\CAR CARE SERVICE(.NET)\\BIN\\RELEASE\\DATABASE.MDF\";Integrated Security=True";



        //private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CarCareService\Data\Database.mdf;Integrated Security=True";

        //private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf\";Integrated Security=True";
        //string connData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CarCareService\Data\Database.mdf;Integrated Security=True;ectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CarWashServices"].ConnectionString;
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
        private void LoadData1(string customQuery)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(customQuery, connection);


                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);


                    dataGridView2.DataSource = dataTable;

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
                if (necessaryphone)
                {

                if (textBox2.TextLength < 8)
                {


                    MessageBox.Show("ادخل رقم تيليفون صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string insertQuery = "INSERT INTO CarWashServices (CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, income, Total, Notes) " +
                           "VALUES (@CustomerName, @PhoneNumber, GETDATE(),FORMAT(GETDATE(), 'hh:mm:ss'), @CarID, @VehicleType, @Services, @Profit, @Discountp , @Discount, @Costs, @income, @Total, @Notes)";

                        {
                            
                            SqlCommand command = new SqlCommand(insertQuery, connection);



                            command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                            command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);

                        //FORMAT([Time], 'HH:mm:ss') AS FormattedTime


                        string tsk = new string(txtCarID.Text.Reverse().ToArray());


                        command.Parameters.AddWithValue("@CarID", textBox1.Text+  tsk);
                            command.Parameters.AddWithValue("@Profit", label8.Text);
                            command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                            command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                             //command.Parameters.AddWithValue("@Time", "fs");
                        string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {   
                            cb += checkedListBox1.CheckedItems[i];
                            if(i < checkedListBox1.CheckedItems.Count - 1)
                            {

                               cb += " / ";
                            }
                        }
                        ;

                            command.Parameters.AddWithValue("@Services", cb);
                        command.Parameters.AddWithValue("@Discount", textBox6.Text);
                        command.Parameters.AddWithValue("@Discountp", txtSaleID.Text);
                            //command.Parameters.AddWithValue("@Total", label8.Text);
                            ;

                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100)))- decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text);

                         total = total + decimal.Parse(Income.Text);
                        command.Parameters.AddWithValue("@income", Income.Text);
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
                        textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox1.Text = "";
                        txtVehicleType.Text = "";
                        txtSaleID.Text = "0";
                        textBox6.Text = "0";
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
            CountHelloOccurrences();
            DisplayMonthlyTotal();
        }
        private void btnCreate_Click1(object sender, EventArgs e)
        {
            //{   if (txtCustomerID.TextLength < 11) {
            //        MessageBox.Show($"Error adding record: check the telephone number size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //   else {
            try
            {
                if (textBox2.TextLength < 6) {


                    MessageBox.Show("ادخل رقم تيليفون صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ;

                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO CarWashServices1 (CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,income , Total, Notes) " +
                       "VALUES (@CustomerName, @PhoneNumber, GETDATE(),FORMAT(GETDATE(), 'hh:mm:ss'), @CarID, @VehicleType, @Services, @Profit, @Discountp, @Discount, @Costs, @income, @Total, @Notes)";

                    {

                        SqlCommand command = new SqlCommand(insertQuery, connection);

                      

                        command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);

                        //FORMAT([Time], 'HH:mm:ss') AS FormattedTime


                        string tsk = new string(txtCarID.Text.Reverse().ToArray());


                        command.Parameters.AddWithValue("@CarID", textBox1.Text + tsk);
                        command.Parameters.AddWithValue("@Profit", label8.Text);
                        command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        //command.Parameters.AddWithValue("@Time", "fs");
                        string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            cb += checkedListBox1.CheckedItems[i];
                            if (i < checkedListBox1.CheckedItems.Count - 1)
                            {

                                cb += " / ";
                            }
                        }
                    ;

                        command.Parameters.AddWithValue("@Services", cb);
                        command.Parameters.AddWithValue("@Discount", textBox6.Text);
                        command.Parameters.AddWithValue("@Discountp", txtSaleID.Text);
                        //command.Parameters.AddWithValue("@Total", label8.Text);
                        ;

                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text);

                        total = total + decimal.Parse(Income.Text);
                        command.Parameters.AddWithValue("@income", Income.Text);

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
                        textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox1.Text = "";
                        txtVehicleType.Text = "";
                        txtSaleID.Text = "0";
                        textBox6.Text = "0";
                        txtNotes.Text = "";
                        label8.Text = "0";
                        Income.Text = "0";

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData1(query1);
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
                if (textBox2.TextLength < 6)
                {


                    MessageBox.Show("ادخل رقم تيليفون صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //string updateQuery = @"UPDATE Transactions 
                    //               SET Total = @Total, Notes = @Notes 
                    //               WHERE TransactionID = @TransactionID";
                    string updateQuery = "UPDATE CarWashServices SET CustomerName = @CustomerName, PhoneNumber = @PhoneNumber, CarID = @CarID, " +
                       "VehicleType = @VehicleType, Services = @Services, Profit = @Profit, Discountp = @Discountp, Discount = @Discount,Costs = @Costs ,Total = @Total,income = @income, Notes = @Notes " +
                       "WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        
                        //command.Parameters.AddWithValue("@Total", label8.Text);
                        //command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        //command.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);
                        command.Parameters.AddWithValue("@ID", ID.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
                        string tsk = new string(txtCarID.Text.Reverse().ToArray());
                        command.Parameters.AddWithValue("@CarID", textBox1.Text + tsk );
                        command.Parameters.AddWithValue("@Profit", label8.Text);
                        command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);

                        string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            cb += checkedListBox1.Items[i];
                        }
                        ;
                        command.Parameters.AddWithValue("@Services", cb);

                        command.Parameters.AddWithValue("@Discount", textBox6.Text);
                        command.Parameters.AddWithValue("@Discountp", txtSaleID.Text);
                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text);

                        total = total + decimal.Parse(Income.Text);
                        command.Parameters.AddWithValue("@income", Income.Text);
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
                        textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox1.Text = "";
                        txtSaleID.Text = "0";
                        textBox6.Text = "0";
                        Costs.Text = "0";
                        Income.Text = "0";
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
            CountHelloOccurrences();
            DisplayMonthlyTotal();
        }
        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //string updateQuery = @"UPDATE Transactions 
                    //               SET Total = @Total, Notes = @Notes 
                    //               WHERE TransactionID = @TransactionID";
                    string updateQuery = "UPDATE CarWashServices1 SET CustomerName = @CustomerName, PhoneNumber = @PhoneNumber, CarID = @CarID, " +
                       "VehicleType = @VehicleType, Services = @Services, Profit = @Profit, Discountp = @Discountp, Discount = @Discount,Costs = @Costs ,income = @income ,Total = @Total , Notes = @Notes " +
                       "WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {

                        //command.Parameters.AddWithValue("@Total", label8.Text);
                        //command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        //command.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);
                        command.Parameters.AddWithValue("@ID", ID1.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
                        string tsk = new string(txtCarID.Text.Reverse().ToArray());
                        command.Parameters.AddWithValue("@CarID", textBox1.Text + tsk);
                        command.Parameters.AddWithValue("@Profit", label8.Text);
                        command.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text);
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Time", DateTime.Now.TimeOfDay);

                        string cb = "";
                        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                        {
                            cb += checkedListBox1.Items[i];
                        }
                        ;
                        command.Parameters.AddWithValue("@Services", cb);
                        command.Parameters.AddWithValue("@Discountp", txtSaleID.Text);
                        command.Parameters.AddWithValue("@Discount", textBox6.Text);
                        command.Parameters.AddWithValue("@Costs", Costs.Text);
                        decimal total = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (decimal.Parse(txtSaleID.Text) / 100))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text);
                        total = total + decimal.Parse(Income.Text);
                        command.Parameters.AddWithValue("@income", Income.Text);
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
                        textBox1.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
                        textBox1.Text = "";
                        txtSaleID.Text = "0";
                        textBox6.Text = "0";
                        Costs.Text = "0";
                        Income.Text = "0";
                        txtNotes.Text = "";
                        label8.Text = "0";
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData1(query1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
        //                                              "Confirm Deletion",
        //                                              MessageBoxButtons.YesNo,
        //                                              MessageBoxIcon.Warning);
        //        if (result == DialogResult.Yes)
        //        {
        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                string deleteQuery = "DELETE FROM CarWashServices WHERE ID = @ID";
        //                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
        //                {
        //                    command.Parameters.AddWithValue("@ID", ID.Text);

        //                    connection.Open();
        //                    command.ExecuteNonQuery();
        //                }
        //                ID.Text = "";
        //            }
        //            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData(query); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    CountHelloOccurrences();
        //    DisplayMonthlyTotal();
        //}
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
                connection.Open();

                // Begin a transaction to ensure data integrity
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Delete the selected record
                    string deleteQuery = "DELETE FROM CarWashServices WHERE ID = @ID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", ID.Text);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Enable IDENTITY_INSERT for reordering
                    string enableIdentityInsert = "SET IDENTITY_INSERT CarWashServices ON;";
                    using (SqlCommand enableCommand = new SqlCommand(enableIdentityInsert, connection, transaction))
                    {
                        enableCommand.ExecuteNonQuery();
                    }

                    // Reorder IDs using a temporary table
                    string reorderQuery = @"
                        -- Create a temporary table
                        CREATE TABLE #TempTable (
                            ID INT NOT NULL,
                            CustomerName NVARCHAR(100) NOT NULL,
                            PhoneNumber NVARCHAR(15) NOT NULL,
                            CurrentDate DATE DEFAULT GETDATE(),
                            Time TIME(7) DEFAULT CONVERT(TIME, GETDATE()),
                            CarID NVARCHAR(50) NOT NULL,
                            VehicleType NVARCHAR(50) NOT NULL,
                            Services NVARCHAR(MAX) NOT NULL,
                            Profit DECIMAL(10, 2) DEFAULT 0.00,
                            Discountp    DECIMAL (10, 2) DEFAULT ((0.00)) NULL,
                            Discount DECIMAL(10, 2) DEFAULT 0.00,
                            Costs DECIMAL(10, 2) DEFAULT 0.00,
                            income  DECIMAL (10, 2) DEFAULT ((0.00)) NULL,
                            Total DECIMAL(10, 2) NOT NULL,
                            Notes NVARCHAR(MAX) NULL
                        );

                        -- Insert reordered data into the temporary table
                        INSERT INTO #TempTable (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, income, Total, Notes)
                        SELECT ROW_NUMBER() OVER (ORDER BY ID) AS ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp,Discount, Costs, income, Total, Notes
                        FROM CarWashServices;

                        -- Truncate the original table
                        TRUNCATE TABLE CarWashServices;

                        -- Reinsert data from the temporary table
                        INSERT INTO CarWashServices (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, income, Total, Notes)
                        SELECT ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, income, Total, Notes
                        FROM #TempTable;

                        -- Drop the temporary table
                        DROP TABLE #TempTable;
                    ";
                    using (SqlCommand reorderCommand = new SqlCommand(reorderQuery, connection, transaction))
                    {
                        reorderCommand.ExecuteNonQuery();
                    }

                    // Disable IDENTITY_INSERT after reordering
                    string disableIdentityInsert = "SET IDENTITY_INSERT CarWashServices OFF;";
                    using (SqlCommand disableCommand = new SqlCommand(disableIdentityInsert, connection, transaction))
                    {
                        disableCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Commit the transaction
                    ID.Text = "";

                    MessageBox.Show("Record deleted and IDs reordered successfully!", 
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    transaction.Rollback(); // Rollback on error
                    throw;
                }
            }

            LoadData(query); // Reload the updated data
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    CountHelloOccurrences();
    DisplayMonthlyTotal();
}
        private void btnDelete1_Click(object sender, EventArgs e)
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
                        connection.Open();

                        // Begin a transaction to ensure data integrity
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Delete the selected record
                            string deleteQuery = "DELETE FROM CarWashServices1 WHERE ID = @ID";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCommand.Parameters.AddWithValue("@ID", ID1.Text);
                                deleteCommand.ExecuteNonQuery();
                            }

                            // Enable IDENTITY_INSERT for reordering
                            string enableIdentityInsert = "SET IDENTITY_INSERT CarWashServices1 ON;";
                            using (SqlCommand enableCommand = new SqlCommand(enableIdentityInsert, connection, transaction))
                            {
                                enableCommand.ExecuteNonQuery();
                            }

                            // Reorder IDs using a temporary table
                            string reorderQuery = @"
                        -- Create a temporary table
                        CREATE TABLE #TempTable (
                            ID INT NOT NULL,
                            CustomerName NVARCHAR(100) NOT NULL,
                            PhoneNumber NVARCHAR(15) NOT NULL,
                            CurrentDate DATE DEFAULT GETDATE(),
                            Time TIME(7) DEFAULT CONVERT(TIME, GETDATE()),
                            CarID NVARCHAR(50) NOT NULL,
                            VehicleType NVARCHAR(50) NOT NULL,
                            Services NVARCHAR(MAX) NOT NULL,
                            Profit DECIMAL(10, 2) DEFAULT 0.00,
                            Discountp DECIMAL(10, 2) DEFAULT 0.00,
                            Discount DECIMAL(10, 2) DEFAULT 0.00,
                            Costs DECIMAL(10, 2) DEFAULT 0.00,
                            income  DECIMAL (10, 2) DEFAULT ((0.00)) NULL,
                            Total DECIMAL(10, 2) NOT NULL,
                            Notes NVARCHAR(MAX) NULL
                        );

                        -- Insert reordered data into the temporary table
                        INSERT INTO #TempTable (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,income ,Total, Notes)
                        SELECT ROW_NUMBER() OVER (ORDER BY ID) AS ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,income ,Total, Notes
                        FROM CarWashServices1;

                        -- Truncate the original table
                        TRUNCATE TABLE CarWashServices1;

                        -- Reinsert data from the temporary table
                        INSERT INTO CarWashServices1 (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,income, Total, Notes)
                        SELECT ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp,Discount, Costs,income ,Total, Notes
                        FROM #TempTable;

                        -- Drop the temporary table
                        DROP TABLE #TempTable;
                    ";
                            using (SqlCommand reorderCommand = new SqlCommand(reorderQuery, connection, transaction))
                            {
                                reorderCommand.ExecuteNonQuery();
                            }

                            // Disable IDENTITY_INSERT after reordering
                            string disableIdentityInsert = "SET IDENTITY_INSERT CarWashServices1 OFF;";
                            using (SqlCommand disableCommand = new SqlCommand(disableIdentityInsert, connection, transaction))
                            {
                                disableCommand.ExecuteNonQuery();
                            }

                            transaction.Commit(); // Commit the transaction
                            ID1.Text = "";

                            MessageBox.Show("Record deleted and IDs reordered successfully!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback(); // Rollback on error
                            throw;
                        }
                    }

                    LoadData1(query1); // Reload the updated data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void delete(string fs) {
            try
            {
                //DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                //                                      "Confirm Deletion",
                //                                      MessageBoxButtons.YesNo,
                //                                      MessageBoxIcon.Warning);
                //if (result == DialogResult.Yes)
                //{
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Begin a transaction to ensure data integrity
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Delete the selected record
                            string deleteQuery = "DELETE FROM CarWashServices1 WHERE ID = @ID";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCommand.Parameters.AddWithValue("@ID", fs);
                                deleteCommand.ExecuteNonQuery();
                            }

                            // Enable IDENTITY_INSERT for reordering
                            string enableIdentityInsert = "SET IDENTITY_INSERT CarWashServices1 ON;";
                            using (SqlCommand enableCommand = new SqlCommand(enableIdentityInsert, connection, transaction))
                            {
                                enableCommand.ExecuteNonQuery();
                            }

                            // Reorder IDs using a temporary table
                            string reorderQuery = @"
                        -- Create a temporary table
                        CREATE TABLE #TempTable (
                            ID INT NOT NULL,
                            CustomerName NVARCHAR(100) NOT NULL,
                            PhoneNumber NVARCHAR(15) NOT NULL,
                            CurrentDate DATE DEFAULT GETDATE(),
                            Time TIME(7) DEFAULT CONVERT(TIME, GETDATE()),
                            CarID NVARCHAR(50) NOT NULL,
                            VehicleType NVARCHAR(50) NOT NULL,
                            Services NVARCHAR(MAX) NOT NULL,
                            Profit DECIMAL(10, 2) DEFAULT 0.00,
                            Discountp DECIMAL(10, 2) DEFAULT 0.00,
                            Discount DECIMAL(10, 2) DEFAULT 0.00,
                            Costs DECIMAL(10, 2) DEFAULT 0.00,
                            income DECIMAL (10, 2) DEFAULT ((0.00)) NULL,
                            Total DECIMAL(10, 2) NOT NULL,
                            Notes NVARCHAR(MAX) NULL
                        );

                        -- Insert reordered data into the temporary table
                        INSERT INTO #TempTable (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp,Discount, Costs,income , Total, Notes)
                        SELECT ROW_NUMBER() OVER (ORDER BY ID) AS ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp,Discount, Costs,income , Total, Notes
                        FROM CarWashServices1;

                        -- Truncate the original table
                        TRUNCATE TABLE CarWashServices1;

                        -- Reinsert data from the temporary table
                        INSERT INTO CarWashServices1 (ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs,income , Total, Notes)
                        SELECT ID, CustomerName, PhoneNumber, CurrentDate, Time, CarID, VehicleType, Services, Profit, Discountp, Discount, Costs, income, Total, Notes
                        FROM #TempTable;

                        -- Drop the temporary table
                        DROP TABLE #TempTable;
                    ";
                            using (SqlCommand reorderCommand = new SqlCommand(reorderQuery, connection, transaction))
                            {
                                reorderCommand.ExecuteNonQuery();
                            }

                            // Disable IDENTITY_INSERT after reordering
                            string disableIdentityInsert = "SET IDENTITY_INSERT CarWashServices1 OFF;";
                            using (SqlCommand disableCommand = new SqlCommand(disableIdentityInsert, connection, transaction))
                            {
                                disableCommand.ExecuteNonQuery();
                            }

                            transaction.Commit(); // Commit the transaction
                            //ID1.Text = "";

                           // MessageBox.Show("Record deleted and IDs reordered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback(); // Rollback on error
                            throw;
                        }
                    }

                    LoadData1(query1); // Reload the updated data
                //}
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

            if (txtCarID.TextLength == 0)
            {
                txtCarID.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
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

            if (textBox2.TextLength != 0)
            {

                if (IsValidInput2(input))
                {
                    textBox2.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    textBox2.BackColor = System.Drawing.Color.LightCoral;
                }
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.FromArgb(222, 222, 222);
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
           
            //ComboBox comboBox = sender as ComboBox;

            //if (comboBox != null)
            //{
                
            //    //string inputText = comboBox.Text.Trim(); 

                
            //    //if (inputText == "سيارة" || inputText == "سكوتر" || inputText == "(أخرى)")
            //    //{
                    
            //    //}
            //    //else
            //    //{
                   
            //    //    comboBox.Text = string.Empty;

            //    //    MessageBox.Show("الرجاء إدخال أو اختيار قيمة صحيحة: سيارة أو سكوتر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //}
            //}
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
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

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
            decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text) + decimal.Parse(Income.Text) ;
            
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
            //if (Costs.Text.Length == 0) { 
            //Costs.Text = "0";
            //}
            txtVehicleType.SelectedIndex = 3 ;
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));
            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs;
            if (Costs.TextLength > 0)
            {
                fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text)+ decimal.Parse(Income.Text);

            }
            else {
                fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(textBox6.Text) + decimal.Parse(Income.Text);
            }
            label14.Text = $"{fs}";
        }

        private void txtSaleID_TextChanged(object sender, EventArgs e)
        {
            if (txtSaleID.Text.Length == 0)
            {
                txtSaleID.Text = "0";
            }
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));
            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text) + decimal.Parse(Income.Text);
            label14.Text = $"{fs}";


        }
        public float tyosk = 0.0f;
        private void UpdatetxtSaleID(System.Windows.Forms.ComboBox textBox, float value)
        {
            // Explicitly format the value as an integer if it is a whole number
            if (value % 1 == 0)
            {
                textBox.Text = ((int)value).ToString(); // Convert to int for cleaner formatting
            }
            else
            {
                textBox.Text = value.ToString(); // For non-integer values
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "3108")
            {
               // label19.Visible = true;
               // Income.Visible = true;
                PID.Visible = false;
                label17.Visible = false;
                button14.Visible = true;
                button12.Visible = false;
                button13.Visible = false;
                ID1.Visible = false;
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                button3.Visible = true;
                button9.Visible = false;
                button2.Visible = false;
                ID.Visible =  true;
                
                button1.Visible = true;
                button6.Visible = true;
                textBox3.Text = "";
                btnExportToExcel .Visible = true;
                textBox5.Visible = true;
                button7.Visible = true;
                //button8.Visible = true;
                //button9.Visible = true;
               //Date.Visible = true; //fs   
               //label11.Visible = true;  //fs
                //label10.Visible = true;
                //label9.Visible = true;
                button10.Visible = true;
                textBox4.Visible = true;
                textBox3.Visible = false;
                button11.Visible = true;
                label12.Visible = true;
                Costs.Visible = true;  
                panel6.Visible = true;
                dateTimePicker1 .Visible = true;    
                dateTimePicker2 .Visible = true; 
                label10.Visible=true;
                label16.Visible = true; 
                button8 .Visible = true;
                ac.Visible = true;
                sc.Visible = true;
                cc.Visible = true;
                month.Visible = true;

                //dataGridView1.Columns["CurrentDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                //dataGridView1.Columns["CurrentDate"].DefaultCellStyle.Format = "HH:mm:ss yyyy-MM-dd";
                // dataGridView1.Columns["Time"].DefaultCellStyle.Format = "HH:mm:ss";
                dataGridView1.Columns["CarID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["CarID"].Width = 130;
                dataGridView2.Columns["CarID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView2.Columns["CarID"].Width = 130;

                CountHelloOccurrences();
                DisplayMonthlyTotal();
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

      

        private void ID_TextChanged(object sender, EventArgs e)
        {
                string searchID = ID.Text; // Get ID from TextBox

            // Loop through DataGridView rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID"].Value != null && row.Cells["ID"].Value.ToString() == searchID)
                {
                    // Match found, populate the text boxes
                    txtCustomerID.Text = row.Cells["CustomerName"].Value?.ToString();
                    textBox2.Text = row.Cells["PhoneNumber"].Value?.ToString();
                    //txtAddress.Text = row.Cells["CarID"].Value?.ToString();
                   

                    //label8.Text = row.Cells["Profit"].Value?.ToString();

                    string strSalep = row.Cells["Discountp"].Value?.ToString();
                    txtSaleID.Text = strSalep.Substring(0,strSalep.Length-2);

                    string strSale = row.Cells["Discount"].Value?.ToString();
                    textBox6.Text = strSale.Substring(0, strSale.Length - 2);

                    //==========
                    string numericPart = Regex.Replace(txtSaleID.Text, @"[^0-9.]", "");
                    if (numericPart.StartsWith("."))
                        numericPart = numericPart.TrimStart('.');
                    if (txtSaleID.Text != numericPart)
                    {
                        // Format to avoid ".0" issue
                        txtSaleID.Text = numericPart.Contains(".") ? numericPart : int.Parse(numericPart).ToString();

                        // Reset cursor position
                        txtSaleID.SelectionStart = textBox1.Text.Length;
                    }

                    //=========

                    //string strara = row.Cells["CarID"].Value?.ToString();
                    //textBox1.Text = strara.Substring(0, 5);

                    //string strnum = row.Cells["CarID"].Value?.ToString();
                    // strnum= strnum.Substring(6, 8);
                    //txtCarID.Text = strnum;



                    // Get the CarID value from the row
                    string carId = row.Cells["CarID"].Value?.ToString();

                    if (!string.IsNullOrEmpty(carId))
                    {
                        
                        string arabicLetters = Regex.Replace(carId, @"[^\u0600-\u06FF]", "").Trim();
                        
                        textBox1.Text = string.Join(" ", arabicLetters.ToCharArray());

                        string numbers = Regex.Replace(carId, @"[^\d]", "").Trim();
                        
                        string reversedNumbers = string.Join(" ", numbers.Reverse()) + " ";
                        txtCarID.Text = reversedNumbers;

                        textBox1.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        // Handle null or empty CarID case
                        textBox1.Text = string.Empty;
                        txtCarID.Text = string.Empty;
                    }


                    string strCost =  row.Cells["Costs"].Value?.ToString();
                    Costs.Text = strCost.Substring(0 , strCost.Length -2);


                    string sIncome = row.Cells["income"].Value?.ToString();
                    Income.Text = sIncome.Substring(0, sIncome.Length - 2);

                    //label14.Text = row.Cells["Total"].Value?.ToString();
                    txtNotes.Text = row.Cells["Notes"].Value?.ToString();


                    string itemsToCheck = row.Cells["Services"].Value?.ToString();


                    var items = itemsToCheck.Split('/')
                        .Select(item => NormalizeArabicText(item.Trim()))
                        .ToList();

                    if (items.Count > 0) { 
                    
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        
                       
                            checkedListBox1.SetItemChecked(i, false);
                       
                    }
                    }

                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        string normalizedItem = NormalizeArabicText(checkedListBox1.Items[i].ToString());
                        if (items.Contains(normalizedItem))
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }

                    //    foreach (var item in items)
                    //    {
                    //        int index = checkedListBox1.Items.IndexOf(item);
                    //         txtNotes.Text += item.ToString();
                    //        if (index != -1) // Check if the item exists in the CheckedListBox
                    //        {
                    //            checkedListBox1.SetItemChecked(index, true);
                    //        }
                    //}


                    string fs = row.Cells["VehicleType"].Value?.ToString();
                    int a = 0;
                    if (fs == "سيارة")
                    {
                        a = 0;
                    }
                    if (fs == "سكوتر")
                    {
                        a = 1;
                    }
                    if (fs == "(أخرى)")
                    {
                        a = 2;
                    }
                    if (fs == "")
                    {
                        a = 3;
                    }
                    txtVehicleType.SelectedIndex = a;







                    return; // Exit loop once match is found






                }
            }

        }
        private void ID1_TextChanged(object sender, EventArgs e)
        {
            string searchID = ID1.Text; // Get ID from TextBox

            // Loop through DataGridView rows
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ID"].Value != null && row.Cells["ID"].Value.ToString() == searchID)
                {
                    // Match found, populate the text boxes
                    txtCustomerID.Text = row.Cells["CustomerName"].Value?.ToString();
                    textBox2.Text = row.Cells["PhoneNumber"].Value?.ToString();
                    //txtAddress.Text = row.Cells["CarID"].Value?.ToString();


                    //label8.Text = row.Cells["Profit"].Value?.ToString();

                    string strSalep = row.Cells["Discountp"].Value?.ToString();

                    txtSaleID.Text = strSalep.Substring(0, strSalep.Length - 2);

                    string strSale = row.Cells["Discount"].Value?.ToString();

                    textBox6.Text = strSale.Substring(0, strSale.Length - 2);

                    //==========
                    string numericPart = Regex.Replace(txtSaleID.Text, @"[^0-9.]", "");
                    if (numericPart.StartsWith("."))
                        numericPart = numericPart.TrimStart('.');
                    if (txtSaleID.Text != numericPart)
                    {
                        // Format to avoid ".0" issue
                        txtSaleID.Text = numericPart.Contains(".") ? numericPart : int.Parse(numericPart).ToString();

                        // Reset cursor position
                        txtSaleID.SelectionStart = textBox1.Text.Length;
                    }

                    //=========
                    //UpdatetxtSaleID(txtSaleID, tyosk);

                    //string strara = row.Cells["CarID"].Value?.ToString();
                    //textBox1.Text = strara.Substring(0, 5);

                    //string strnum = row.Cells["CarID"].Value?.ToString();
                    // strnum= strnum.Substring(6, 8);
                    //txtCarID.Text = strnum;



                    // Get the CarID value from the row
                    string carId = row.Cells["CarID"].Value?.ToString();

                    if (!string.IsNullOrEmpty(carId))
                    {

                        string arabicLetters = Regex.Replace(carId, @"[^\u0600-\u06FF]", "").Trim();

                        textBox1.Text = string.Join(" ", arabicLetters.ToCharArray());

                        string numbers = Regex.Replace(carId, @"[^\d]", "").Trim();

                        string reversedNumbers = string.Join(" ", numbers.Reverse()) + " ";
                        txtCarID.Text = reversedNumbers;

                        textBox1.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        // Handle null or empty CarID case
                        textBox1.Text = string.Empty;
                        txtCarID.Text = string.Empty;
                    }

                    string sIncome = row.Cells["Income"].Value?.ToString();
                    Income.Text = sIncome.Substring(0, sIncome.Length - 2);

                    string strCost = row.Cells["Costs"].Value?.ToString();
                    Costs.Text = strCost.Substring(0, strCost.Length - 2);

                    //label14.Text = row.Cells["Total"].Value?.ToString();
                    txtNotes.Text = row.Cells["Notes"].Value?.ToString();


                    string itemsToCheck = row.Cells["Services"].Value?.ToString();


                    var items = itemsToCheck.Split('/')
                        .Select(item => NormalizeArabicText(item.Trim()))
                        .ToList();

                    if (items.Count > 0)
                    {

                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {


                            checkedListBox1.SetItemChecked(i, false);

                        }
                    }

                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        string normalizedItem = NormalizeArabicText(checkedListBox1.Items[i].ToString());
                        if (items.Contains(normalizedItem))
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }

                    //    foreach (var item in items)
                    //    {
                    //        int index = checkedListBox1.Items.IndexOf(item);
                    //         txtNotes.Text += item.ToString();
                    //        if (index != -1) // Check if the item exists in the CheckedListBox
                    //        {
                    //            checkedListBox1.SetItemChecked(index, true);
                    //        }
                    //}


                    string fs = row.Cells["VehicleType"].Value?.ToString();
                    int a = 0;
                    if (fs == "سيارة")
                    {
                        a = 0;
                    }
                    if (fs == "سكوتر")
                    {
                        a = 1;
                    }
                    if (fs == "(أخرى)")
                    {
                        a = 2;
                    }
                    if (fs == "")
                    {
                        a = 3;
                    }
                    txtVehicleType.SelectedIndex = a;







                    return; // Exit loop once match is found






                }
            }

        }
        public static string NormalizeArabicText(string input)
        {
            // Normalize form and remove diacritics
            return string.Concat(input.Normalize(NormalizationForm.FormD)
                                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
                         .Trim();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Date_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (sender as Control);

            string value = string.Concat(ctrl
              .Text
              .Where(c => c >= '0' && c <= '9' || c == '/'));

            if (value != ctrl.Text)
                ctrl.Text = value;
            string input = textBox2.Text;
            if(Date.Text.Length == 0)
            {

                label11.Text = " الحساب بالتاريخ ";

            }
            else
            {
                label11.Text = "";
            }
        }

        private void Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char keyChar = e.KeyChar;
            //if (keyChar == '\u2386')
            //{
            //    e.Handled=false;
            //    //return;
            //}
        }

        private void Costs_Enter(object sender, EventArgs e)
        {
             System.Windows.Forms.TextBox Costs = sender as System.Windows.Forms.TextBox;
            if (Costs != null && Costs.Text.Length == 1) {
                Costs.SelectAll();
            }


        }

        private void txtSaleID_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txtSaleID = sender as System.Windows.Forms.TextBox;
            if (txtSaleID != null && txtSaleID.Text.Length == 1)
            {
                txtSaleID.SelectAll();
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {





        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
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
              .Where(c => Char.IsDigit(c)));

            if (value != ctrl.Text)
                ctrl.Text = value;
            string searchQuery = textBox4.Text.Trim();
            LoadTelephone(searchQuery);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //label19.Visible = false;
            //Income.Visible = false;
            PID.Visible = true;
            label17.Visible = true;
            button14.Visible = false;
            button12.Visible = true;
            button13.Visible = false;
            ID1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            button3.Visible = false;
            button9.Visible = true;
            button2.Visible = true;
            textBox3.Text = "";
            ID.Visible = false;
            
            button1.Visible = false;
            button6.Visible = false;
            btnExportToExcel.Visible = false;
            textBox5.Visible = false;
            button7.Visible = false;
            //button8.Visible = false;
            //button9.Visible = false;
            Date.Visible = false;
            label11.Visible = false;
            //label10.Visible = false;
            //label9.Visible = false;
            button10.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = true;
            button11.Visible = false;
            label12.Visible = false;
            Costs.Visible = false;
            panel6.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label10.Visible = false;
            label16.Visible = false;
            button8.Visible = false;
            ac.Visible = false;
            sc.Visible = false;
            cc.Visible = false;
            month.Visible = false;  
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string selectedDate = Date.Text;
                if (!IsValidDate(Date.Text))
                {
                    MessageBox.Show("Please enter a valid date in the format dd/MM/yyyy.", "wrong input format", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            DateTime startDate = DateTime.Parse(selectedDate);
            DateTime endDate = DateTime.Parse(selectedDate);

                // SELECT CurrentDate,Time, Total 
                string query = @"
        SELECT *
        FROM CarWashServices 
        WHERE CurrentDate BETWEEN @StartDate AND @EndDate";
            
            // Create a DataTable to hold the results
            System.Data.DataTable dataTable = new System.Data.DataTable();

            // Execute the query and fill the DataTable
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        
                        adapter.Fill(dataTable);
                    }
                }
            }

            DateForm dateForm = new DateForm();
            dateForm.SetDataSource(dataTable); // Pass the DataTable to the DateForm
            query = @"
            SELECT SUM(Total) AS TotalBetweenDates,
            
            FROM CarWashServices
            WHERE CurrentDate BETWEEN @StartDate AND @EndDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                     object result = cmd.ExecuteScalar();
                     dateForm.SetLabelText("Total : "+$"{result}"+ " EGP");
                   // MessageBox.Show($"{result ?? 0}", "الدخل بين التاريخين", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // label10.Text = $"{result ?? 0} : الدخل بين التاريخين";
                }
            }

            dateForm.ShowDialog();
            // Open DateForm and pass the data

                //string query = "SELECT SUM(Total)  AS DailyTotal FROM CarWashServices WHERE CurrentDate = @SelectedDate";

                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    conn.Open();
                //    using (SqlCommand cmd = new SqlCommand(query, conn))
                //    {
                //        cmd.Parameters.AddWithValue("@SelectedDate", DateTime.Parse(selectedDate));
                //        object result = cmd.ExecuteScalar();
                //        MessageBox.Show($"{result ?? 0}", "الدخل اليومي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        //label9.Text = $"{result ?? 0} : الدخل اليومي";
                //    }
                //}

                ////string selectedDate = Date.Text; // e.g., "24/11/2024"
                //DateTime date = DateTime.Parse(selectedDate);
                //query = @"
                //SELECT SUM(Total)  AS MonthlyTotal 
                //FROM CarWashServices 
                //WHERE YEAR(CurrentDate) = @SelectedYear AND MONTH(CurrentDate) = @SelectedMonth";

                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    conn.Open();
                //    using (SqlCommand cmd = new SqlCommand(query, conn))
                //    {
                //        cmd.Parameters.AddWithValue("@SelectedYear", date.Year);
                //        cmd.Parameters.AddWithValue("@SelectedMonth", date.Month);
                //        object result = cmd.ExecuteScalar();
                //        MessageBox.Show($"{result ?? 0}", "الدخل الشهري", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        //label10.Text = $"{result ?? 0} : الدخل الشهري";
                //    }
                //}
                //label11.Visible = true;
                //Date.Text = "";
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)

        {
            //        DateTime startDate = dateTimePicker1.Value.Date; 
            //        DateTime endDate = dateTimePicker2.Value.Date;   

            //        string query = @"
            //SELECT SUM(Total) AS TotalBetweenDates
            //FROM CarWashServices
            //WHERE CurrentDate BETWEEN @StartDate AND @EndDate";

            //        DataTable dataTable = new DataTable();


            //        using (SqlConnection conn = new SqlConnection(connectionString))
            //        {
            //            conn.Open();
            //            using (SqlCommand cmd = new SqlCommand(query, conn))
            //            {
            //                cmd.Parameters.AddWithValue("@StartDate", startDate);
            //                cmd.Parameters.AddWithValue("@EndDate", endDate);

            //                object result = cmd.ExecuteScalar();
            //                MessageBox.Show($"{result ?? 0}", "الدخل بين التاريخين", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                // label10.Text = $"{result ?? 0} : الدخل بين التاريخين";
            //            }
            //        }


            // Get date range from DateTimePickers
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // CurrentDate,Time, Total
            string query = @"
        SELECT *
        FROM CarWashServices 
        WHERE CurrentDate BETWEEN @StartDate AND @EndDate";
            
            // Create a DataTable to hold the results
            System.Data.DataTable dataTable = new System.Data.DataTable();

            // Execute the query and fill the DataTable
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        
                        adapter.Fill(dataTable);
                    }
                }
            }

            DateForm dateForm = new DateForm();
            dateForm.SetDataSource(dataTable); // Pass the DataTable to the DateForm
            query = @"
            SELECT SUM(Total) AS TotalBetweenDates
            FROM CarWashServices
            WHERE CurrentDate BETWEEN @StartDate AND @EndDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                     object result = cmd.ExecuteScalar();
                     dateForm.SetLabelText("Total : "+$"{result}"+ " EGP");
                   // MessageBox.Show($"{result ?? 0}", "الدخل بين التاريخين", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // label10.Text = $"{result ?? 0} : الدخل بين التاريخين";
                }
            }

            dateForm.ShowDialog();
            // Open DateForm and pass the data


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtVehicleType.SelectedIndex == 1 || txtVehicleType.SelectedIndex == 0) {

                necessaryphone = true;
            }
            if (txtVehicleType.SelectedIndex == 3 || txtVehicleType.SelectedIndex == 2)
            {

                necessaryphone = false;
            }
        }

        private void Income_TextChanged(object sender, EventArgs e)
        {
            //Costs.Text = "0";
            //}
            txtVehicleType.SelectedIndex = 3;
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));
            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs;
            
                fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text)+ decimal.Parse(Income.Text);

            
            
            label14.Text = $"{fs}";
        }

        private void Income_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox Income = sender as System.Windows.Forms.TextBox;
            if (Income != null && Income.Text.Length == 1)
            {
                Income.SelectAll();
            }

        }

        private void Income_Leave(object sender, EventArgs e)
        {
            if (Income.TextLength < 1)
            {
                Income.Text = "0";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Costs_Leave(object sender, EventArgs e)
        {
            if (Costs.TextLength < 1)
            {
                Costs.Text = "0";
            }
        }

        private void month_Click(object sender, EventArgs e)
        {

        }

        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    //foreach (Control control in this.Controls)
        //    //{
        //    //    control.Width = (int)(this.ClientSize.Width * 1);  // 30% of the form width
        //    //    control.Height = (int)(this.ClientSize.Height * 1); // 10% of the form height
        //    //}

        //    float fontSize = this.ClientSize.Width / 100f; // Adjust this factor as needed
        //    txtCarID.Font = new System.Drawing.Font(txtCarID.Font.FontFamily, fontSize);
        //    txtCustomerID.Font = new System.Drawing.Font(txtCustomerID.Font.FontFamily, fontSize);
        //    //txtNotes = new System.Drawing.Font(txtNotes.Font.FontFamily, fontSize);
        //    //txtSaleID.Font = new System.Drawing.Font(txtSaleID.FontFamily, fontSize);
        //    txtVehicleType.Font = new System.Drawing.Font(txtVehicleType.Font.FontFamily, fontSize);
        //    //Costs = new System.Drawing.Font(txtCarID.Font.FontFamily, fontSize);
        //    ac.Font = new System.Drawing.Font(ac.Font.FontFamily, fontSize);
            

        //}

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //if (Costs.Text.Length == 0) { 
            //Costs.Text = "0";
            //}
            
            Control ctrl = (sender as Control);
            string value = string.Concat(ctrl
                .Text
                 .Where(c => Char.IsDigit(c) || c == '\u0020'));
            if (value != ctrl.Text)
                ctrl.Text = value;
            //decimal fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * decimal.Parse(txtSaleID.Text) / 100)) - decimal.Parse(Costs.Text);
            decimal fs;
            if (textBox6.TextLength > 0)
            {
                fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text) - decimal.Parse(textBox6.Text) + decimal.Parse(Income.Text);

            }
            else
            {
                fs = (decimal.Parse(label8.Text) - (decimal.Parse(label8.Text) * (((decimal.Parse(txtSaleID.Text)) / 100)))) - decimal.Parse(Costs.Text)+ decimal.Parse(Income.Text);
            }
            label14.Text = $"{fs}";

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox ts = sender as System.Windows.Forms.TextBox;
            if (ts != null && ts.Text.Length == 1)
            {
                ts.SelectAll();
            }


        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.TextLength < 1)
            {
                textBox6.Text = "0";
            }

        }
    }
        //private void HandleBackspace()
        //{

        //}

    
}




