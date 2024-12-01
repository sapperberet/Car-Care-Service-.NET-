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
        }

        private void DateForm_Load(object sender, EventArgs e)
        {

        }
        public void SetDataSource(DataTable dataTable)
        {
            // Ensure you have a DataGridView named dataGridView1 on the form
            dataGridView2.DataSource = dataTable;
            dataGridView2.ReadOnly = true;        // Optional: make it read-only
            // Optional: disable adding rows
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SetLabelText(string text)
        {
            label1.Text = text; // Set the text of the label
        }
    }
}
