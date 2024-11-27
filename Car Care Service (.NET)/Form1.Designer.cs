using System.Drawing;
using System.Windows.Forms;
namespace Car_Care_Service__.NET_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Costs = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVehicleType = new System.Windows.Forms.ComboBox();
            this.txtSaleID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.elipseControl1 = new ElipseToolDemo.ElipseControl();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            label1.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(1055, 194);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 33);
            label1.TabIndex = 28;
            label1.Text = "رقم السيارة";
            label1.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            label2.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label2.Location = new System.Drawing.Point(1071, 123);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 33);
            label2.TabIndex = 29;
            label2.Text = "رقم التيلفون";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            label3.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label3.Location = new System.Drawing.Point(1071, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 33);
            label3.TabIndex = 30;
            label3.Text = "اسم العميل";
            label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.btnExportToExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.btnExportToExcel.FlatAppearance.BorderSize = 4;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToExcel.Location = new System.Drawing.Point(9, 3);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(141, 61);
            this.btnExportToExcel.TabIndex = 0;
            this.btnExportToExcel.Text = "حفظ الملف";
            this.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Visible = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.button2.FlatAppearance.BorderSize = 4;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(1109, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 61);
            this.button2.TabIndex = 2;
            this.button2.Text = "طباعة الريسيت";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.Costs);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.btnExportToExcel);
            this.panel2.Controls.Add(this.Date);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(0, 607);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 68);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MME);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // Costs
            // 
            this.Costs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.Costs.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Costs.Location = new System.Drawing.Point(873, 24);
            this.Costs.Name = "Costs";
            this.Costs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Costs.Size = new System.Drawing.Size(90, 28);
            this.Costs.TabIndex = 41;
            this.Costs.TextChanged += new System.EventHandler(this.Costs_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(969, 24);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(123, 29);
            this.label12.TabIndex = 45;
            this.label12.Text = "المصاريف :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(588, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 25);
            this.label11.TabIndex = 44;
            this.label11.Text = "التاريخ";
            this.label11.Visible = false;
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Location = new System.Drawing.Point(707, 28);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(124, 29);
            this.button9.TabIndex = 43;
            this.button9.Text = "اليومي";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.btnDailyTotal_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.ForeColor = System.Drawing.Color.AliceBlue;
            this.label9.Location = new System.Drawing.Point(207, 29);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(27, 29);
            this.label9.TabIndex = 38;
            this.label9.Text = "0";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.ForeColor = System.Drawing.Color.AliceBlue;
            this.label10.Location = new System.Drawing.Point(207, -4);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(27, 29);
            this.label10.TabIndex = 39;
            this.label10.Text = "0";
            this.label10.Visible = false;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(707, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(124, 29);
            this.button8.TabIndex = 40;
            this.button8.Text = "الشهري";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.btnMonthlyTotal_Click);
            // 
            // Date
            // 
            this.Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.Date.Location = new System.Drawing.Point(557, 29);
            this.Date.Multiline = true;
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(126, 28);
            this.Date.TabIndex = 42;
            this.Date.Visible = false;
            this.Date.TextChanged += new System.EventHandler(this.Date_TextChanged);
            //this.Date.Enter += new System.EventHandler(this.Date_Enter);
            this.Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Date_KeyPress);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(1203, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 55);
            this.button4.TabIndex = 3;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 55);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MME);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(81, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("MV Boli", 15F);
            this.textBox3.ForeColor = System.Drawing.Color.Lime;
            this.textBox3.Location = new System.Drawing.Point(433, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(237, 41);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1140, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 40);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(20)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.button3.FlatAppearance.BorderSize = 4;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(126)))), ((int)(((byte)(113)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Sakkal Majalla", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(969, 554);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(281, 52);
            this.button3.TabIndex = 9;
            this.button3.Text = "اضافة";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("MV Boli", 23F);
            this.textBox5.Location = new System.Drawing.Point(362, 71);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox5.Size = new System.Drawing.Size(589, 48);
            this.textBox5.TabIndex = 26;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Visible = false;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged_2);
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(927, 469);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtNotes.Location = new System.Drawing.Point(969, 513);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(170, 35);
            this.txtNotes.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label4.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1142, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 43);
            this.label4.TabIndex = 13;
            this.label4.Text = "الملاحظات";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Noto Kufi Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1067, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 41);
            this.label5.TabIndex = 15;
            this.label5.Text = "نوع الخدمة";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label6.Font = new System.Drawing.Font("Noto Kufi Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(983, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 37);
            this.label6.TabIndex = 24;
            this.label6.Text = "نوع السيارة";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtVehicleType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtVehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtVehicleType.FormattingEnabled = true;
            this.txtVehicleType.Items.AddRange(new object[] {
            "سيارة",
            "سكوتر"});
            this.txtVehicleType.Location = new System.Drawing.Point(969, 294);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVehicleType.Size = new System.Drawing.Size(134, 28);
            this.txtVehicleType.TabIndex = 6;
            this.txtVehicleType.TextChanged += new System.EventHandler(this.txtVehicleType_TextChanged);
            this.txtVehicleType.Leave += new System.EventHandler(this.txtVehicleType_Leave);
            // 
            // txtSaleID
            // 
            this.txtSaleID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSaleID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtSaleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtSaleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtSaleID.Font = new System.Drawing.Font("Noto Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleID.FormatString = "N2";
            this.txtSaleID.FormattingEnabled = true;
            this.txtSaleID.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.txtSaleID.Location = new System.Drawing.Point(1120, 294);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaleID.Size = new System.Drawing.Size(130, 31);
            this.txtSaleID.TabIndex = 5;
            this.txtSaleID.Text = "0";
            this.txtSaleID.SelectedIndexChanged += new System.EventHandler(this.txtSaleID_SelectedIndexChanged);
            this.txtSaleID.TextChanged += new System.EventHandler(this.txtSaleID_TextChanged);
            this.txtSaleID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleID_KeyPress);
            this.txtSaleID.Leave += new System.EventHandler(this.txtSaleID_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label7.Font = new System.Drawing.Font("Noto Kufi Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1143, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 37);
            this.label7.TabIndex = 19;
            this.label7.Text = "الخصومات";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // txtCarID
            // 
            this.txtCarID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtCarID.Location = new System.Drawing.Point(969, 227);
            this.txtCarID.MaxLength = 13;
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(144, 32);
            this.txtCarID.TabIndex = 4;
            this.txtCarID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCarID.TextChanged += new System.EventHandler(this.txtCarID_TextChanged);
            this.txtCarID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCarID_KeyDown);
            this.txtCarID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarID_KeyPress);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtCustomerID.Location = new System.Drawing.Point(969, 92);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerID.Size = new System.Drawing.Size(281, 32);
            this.txtCustomerID.TabIndex = 2;
            this.txtCustomerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.textBox2.Location = new System.Drawing.Point(969, 159);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(281, 32);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("Noto Naskh Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(189, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 48);
            this.button1.TabIndex = 31;
            this.button1.Text = "محو عملية";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.AliceBlue;
            this.button6.Font = new System.Drawing.Font("Noto Naskh Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(24, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 48);
            this.button6.TabIndex = 32;
            this.button6.Text = "تعديل عملية";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(902, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 48);
            this.button7.TabIndex = 33;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label8.Font = new System.Drawing.Font("Noto Sans", 12F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.label8.Location = new System.Drawing.Point(1123, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 30);
            this.label8.TabIndex = 36;
            this.label8.Text = "0";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Noto Serif Hebrew", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(969, 349);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedListBox1.Size = new System.Drawing.Size(281, 124);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ID.Location = new System.Drawing.Point(1236, 54);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(26, 32);
            this.ID.TabIndex = 1;
            this.ID.TextChanged += new System.EventHandler(this.ID_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.textBox1.Location = new System.Drawing.Point(1109, 227);
            this.textBox1.MaxLength = 13;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 32);
            this.textBox1.TabIndex = 37;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label14.Font = new System.Drawing.Font("Noto Sans", 12F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.label14.Location = new System.Drawing.Point(975, 482);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 30);
            this.label14.TabIndex = 39;
            this.label14.Text = "0";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label13.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(1181, 475);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 33);
            this.label13.TabIndex = 40;
            this.label13.Text = " الخدمة";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.label15.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(1036, 477);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 33);
            this.label15.TabIndex = 41;
            this.label15.Text = "الإجمالي";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1120, 477);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 35);
            this.panel3.TabIndex = 42;
            // 
            // elipseControl1
            // 
            this.elipseControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(42)))));
            this.elipseControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.elipseControl1.Location = new System.Drawing.Point(0, 43);
            this.elipseControl1.Name = "elipseControl1";
            this.elipseControl1.Size = new System.Drawing.Size(1267, 758);
            this.elipseControl1.TabIndex = 1;
            this.elipseControl1.Text = "elipseControl1";
            this.elipseControl1.Click += new System.EventHandler(this.elipseControl1_Click_1);
            this.elipseControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.elipseControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MME);
            this.elipseControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1258, 669);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtVehicleType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaleID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtCarID);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.elipseControl1);
            this.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ON ROAD (Car Care)";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnExportToExcel;


        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button2;
        private Panel panel2;
        private Button button4;
        private Panel panel1;
        private PageSetupDialog pageSetupDialog1;
        private Button button3;
        private TextBox textBox5;
        private DataGridView dataGridView1;
        private Button button5;
        private ElipseToolDemo.ElipseControl elipseControl1;
        private TextBox txtNotes;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox txtVehicleType;
        private ComboBox txtSaleID;
        private Label label7;
        private TextBox txtCarID;
        private TextBox txtCustomerID;
        private TextBox textBox2;
        private Button button1;
        private Button button6;
        private Button button7;
        private Label label8;
        private CheckedListBox checkedListBox1;
        private TextBox ID;
        private TextBox textBox1;
        private Label label9;
        private Label label10;
        private Button button8;
        private TextBox Costs;
        private TextBox Date;
        private Button button9;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label13;
        private Label label15;
        private TextBox textBox3;
        private PictureBox pictureBox1;
        private Panel panel3;
    }

}

