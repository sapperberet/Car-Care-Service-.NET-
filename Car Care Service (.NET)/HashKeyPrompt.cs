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
    public partial class HashKeyPrompt : Form
    {
        public string HashKey { get; private set; }
        public HashKeyPrompt()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            HashKey = txtHashKey.Text; 
            if (string.IsNullOrWhiteSpace(HashKey))
            {
                MessageBox.Show("Please enter a valid hash key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                txtHashKey.Text = "";
                //this.Close();
            }
        }

        private void txtHashKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
