using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Care_Service__.NET_
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
            System.Drawing.Font currentFont = dataGridView2.DefaultCellStyle.Font;
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font(currentFont.FontFamily, 11);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(currentFont.FontFamily, 9);
            dataGridView2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void DateForm_Load(object sender, EventArgs e)
        {

        }
        public void SetDataSource(DataTable dataTable)
        {
            // Ensure you have a DataGridView named dataGridView1 on the form
            dataGridView2.DataSource = dataTable;
            dataGridView2.ReadOnly = true;        // Optional: make it read-only

            dataGridView2.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Time"].Width = 100;
            dataGridView2.Columns["CarID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["CarID"].Width = 130;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SetLabelText(string text)
        {
            label1.Text = text; // Set the text of the label
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }
    }
}
