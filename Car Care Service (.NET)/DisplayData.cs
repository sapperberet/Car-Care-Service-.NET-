//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//public class DisplayData
//{
//    private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"J:\\Visual Studio\\Car Wash Service\\Database.mdf\";Integrated Security=True;Connect Timeout=30";

//    public void LoadData(DataGridView dataGridView)
//    {
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            string query = @"
//                SELECT 
//                    t.TransactionID AS ID,
//                    c.Name AS CustomerName,
//                    c.Telephone AS Phone,
//                    t.CarID,
//                    t.CurrentDate,
//                    t.Total AS Total,
//                    t.COM AS VehicleType,
//                    STRING_AGG(s.ServiceName + ' (' + CAST(s.Price AS NVARCHAR) + ' LE)', ', ') AS Services,
//                    sa.SaleDescription AS Deal,
//                    sa.DiscountPercentage AS Discount,
//                    t.Notes
//                FROM 
//                    Transactions t
//                JOIN 
//                    Customers c ON t.CustomerID = c.CustomerID
//                JOIN 
//                    TransactionServices ts ON t.TransactionID = ts.TransactionID
//                JOIN 
//                    Services s ON ts.ServiceID = s.ServiceID
//                JOIN 
//                    Sales sa ON t.SaleID = sa.SaleID
//                GROUP BY 
//                    t.TransactionID, c.Name, c.Telephone, t.CarID, t.CurrentDate, t.Total, t.COM, sa.SaleDescription, sa.DiscountPercentage, t.Notes;
//            ";
//            string query = @"Select * From ";
//            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
//            DataTable table = new DataTable();

//            adapter.Fill(table);


//            dataGridView.DataSource = table;
//        }
//    }
//}
