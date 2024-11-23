﻿using System.Drawing;
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
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.elipseControl1 = new ElipseToolDemo.ElipseControl();
            this.ID = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            label1.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(126, 189);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 33);
            label1.TabIndex = 28;
            label1.Text = "رقم السيارة";
            label1.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            label2.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label2.Location = new System.Drawing.Point(128, 118);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 33);
            label2.TabIndex = 29;
            label2.Text = "رقم التيلفون";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            label3.Font = new System.Drawing.Font("Noto Kufi Arabic", 9F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label3.Location = new System.Drawing.Point(128, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 33);
            label3.TabIndex = 30;
            label3.Text = "اسم العميل";
            label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.Black;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(70)))));
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToExcel.Location = new System.Drawing.Point(1087, 0);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(141, 61);
            this.btnExportToExcel.TabIndex = 0;
            this.btnExportToExcel.Text = "حفظ الملف";
            this.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(85)))), ((int)(((byte)(70)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(912, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 61);
            this.button2.TabIndex = 2;
            this.button2.Text = "طباعة الريسيت";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnExportToExcel);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(0, 607);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 68);
            this.panel2.TabIndex = 6;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MME);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(1203, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 55);
            this.button4.TabIndex = 3;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 55);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MME);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1140, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 40);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(191)))), ((int)(((byte)(184)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(126)))), ((int)(((byte)(113)))));
            this.button3.FlatAppearance.BorderSize = 4;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(126)))), ((int)(((byte)(113)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Sakkal Majalla", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.button3.Location = new System.Drawing.Point(26, 549);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(281, 52);
            this.button3.TabIndex = 4;
            this.button3.Text = "اضافة";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("MV Boli", 23F);
            this.textBox5.Location = new System.Drawing.Point(661, 71);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox5.Size = new System.Drawing.Size(589, 48);
            this.textBox5.TabIndex = 26;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged_2);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(323, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(927, 469);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtNotes.Location = new System.Drawing.Point(26, 476);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(170, 67);
            this.txtNotes.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            this.label4.Font = new System.Drawing.Font("Noto Kufi Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(202, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 43);
            this.label4.TabIndex = 13;
            this.label4.Text = "الملاحظات";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Noto Kufi Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(124, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 41);
            this.label5.TabIndex = 15;
            this.label5.Text = "نوع الخدمة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            this.label6.Font = new System.Drawing.Font("Noto Kufi Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(40, 254);
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
            this.txtVehicleType.Location = new System.Drawing.Point(26, 289);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVehicleType.Size = new System.Drawing.Size(134, 28);
            this.txtVehicleType.TabIndex = 25;
            this.txtVehicleType.TextChanged += new System.EventHandler(this.txtVehicleType_TextChanged);
            this.txtVehicleType.Leave += new System.EventHandler(this.txtVehicleType_Leave);
            // 
            // txtSaleID
            // 
            this.txtSaleID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSaleID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtSaleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtSaleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.txtSaleID.Location = new System.Drawing.Point(177, 289);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaleID.Size = new System.Drawing.Size(130, 28);
            this.txtSaleID.TabIndex = 20;
            this.txtSaleID.Text = "0";
            this.txtSaleID.SelectedIndexChanged += new System.EventHandler(this.txtSaleID_SelectedIndexChanged);
            this.txtSaleID.Leave += new System.EventHandler(this.txtSaleID_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            this.label7.Font = new System.Drawing.Font("Noto Kufi Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(200, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 37);
            this.label7.TabIndex = 19;
            this.label7.Text = "الخصومات";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // txtCarID
            // 
            this.txtCarID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtCarID.Location = new System.Drawing.Point(26, 222);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCarID.Size = new System.Drawing.Size(281, 32);
            this.txtCarID.TabIndex = 10;
            this.txtCarID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCarID.TextChanged += new System.EventHandler(this.txtCarID_TextChanged);
            this.txtCarID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCarID_KeyDown);
            this.txtCarID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarID_KeyPress);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.txtCustomerID.Location = new System.Drawing.Point(26, 87);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerID.Size = new System.Drawing.Size(281, 32);
            this.txtCustomerID.TabIndex = 6;
            this.txtCustomerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.textBox2.Location = new System.Drawing.Point(26, 154);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(281, 32);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("Noto Naskh Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(488, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 48);
            this.button1.TabIndex = 31;
            this.button1.Text = "محو عملية";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.AliceBlue;
            this.button6.Font = new System.Drawing.Font("Noto Naskh Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(323, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 48);
            this.button6.TabIndex = 32;
            this.button6.Text = "تعديل عملية";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(1201, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 48);
            this.button7.TabIndex = 33;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
            this.label8.Font = new System.Drawing.Font("MV Boli", 19F);
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Location = new System.Drawing.Point(156, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 41);
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
            this.checkedListBox1.Items.AddRange(new object[] {
            "غسيل كامل للسيارة و كيماوي موتور ، صالون",
            "غسيل داخلي وخارجي وموتور كيماوي",
            "غسیل داخلي وخارجي",
            "غسیل موتور كيماوي",
            "غسيل خارجي",
            "غسيل داخلي",
            "اسکوتر"});
            this.checkedListBox1.Location = new System.Drawing.Point(26, 344);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkedListBox1.Size = new System.Drawing.Size(281, 84);
            this.checkedListBox1.TabIndex = 37;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            // 
            // elipseControl1
            // 
            this.elipseControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(95)))), ((int)(((byte)(78)))));
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
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(0, 55);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(26, 32);
            this.ID.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1262, 673);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ON ROAD (Car Care)";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
    }

}
