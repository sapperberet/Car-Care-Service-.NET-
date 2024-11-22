//using System;
//using System.Collections.Generic;
//using System.Data;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ClosedXML.Excel;

//namespace Car_Care_Service__.NET_
//{
//    internal class SaveExcel
//    {
//        private void ExportToExcel(string filePath)
//        {
//            DialogResult result = MessageBox.Show("Do you want to export the data to excel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                DateTime dtNow = DateTime.Now;  
//                string sheetStrFormat = dtNow.ToString("yyyy-MM-dd") + " REPORT";
//                try
//                {
//                    using (XLWorkbook workbook = new XLWorkbook())
//                    {
//                        using (DataTable dt = new DataTable())
//                        {
//                            foreach (DataGridViewColumn column in dataGridView1.Columns)
//                            {
//                                dt.Columns.Add(column.HeaderText);
//                            }

//                            foreach (DataGridViewRow row in dataGridView1.Rows)
//                            {
//                                DataRow dr = dt.NewRow();
//                                foreach (DataGridViewCell cell in row.Cells)
//                                {
//                                    dr[cell.ColumnIndex] = cell.Value;
//                                }
//                                dt.Rows.Add(dr);
//                            }

//                            workbook.Worksheets.Add(dt, sheetStrFormat);
//                            workbook.SaveAs(filePath);
//                        }
//                    }

//                    MessageBox.Show("Data exported successfully to Excel.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Error exporting data to Excel: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }

//        }
//    }
//}
