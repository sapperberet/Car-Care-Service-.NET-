using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Care_Service__.NET_
{   

    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        private static int ar = 0;
       
        private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "namespace.txt");

        private static DateTime LoadLastPopupDate()
        {
            if (File.Exists(FilePath))
            {
                string dateText = File.ReadAllText(FilePath);
                if (DateTime.TryParse(dateText, out DateTime lastPopupDate))
                {
                    return lastPopupDate;
                }
            }
            return DateTime.MinValue;
        }
        private static void SaveLastPopupDate(DateTime date)
        {
            File.WriteAllText(FilePath, date.ToString("o")); // Save in ISO 8601 format
        }

        [STAThread]
        static void Main()
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DateTime lastPopupDate = LoadLastPopupDate();
            DateTime currentDate = DateTime.UtcNow;
            Application.Run(new Form1());
            SaveLastPopupDate(currentDate);
            //if (lastPopupDate == DateTime.MinValue || (currentDate - lastPopupDate).Days >= 30)
            //{
            //    using (var hashKeyPrompt = new HashKeyPrompt())
            //{
            //    bool validKeyEntered = false;
            //        while (!validKeyEntered)
            //        {
            //            if (hashKeyPrompt.ShowDialog() == DialogResult.OK)
            //            {
            //                //string userKey = hashKeyPrompt.HashKey;
            //                //string validKey = "12345"; // Replace with your actual hash key
            //                //List<string> ValidHashKeys = new List<string>   {"12345","abcde","67890"};
            //                string userKey = hashKeyPrompt.HashKey;


            //                //if (HashKeyManager.ValidateAndRemoveHashKey(userKey))
            //                //{

            //                    // Launch the main form
            //                    //validKeyEntered = true;
            //                    //MessageBox.Show("Ya ahlan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    Application.Run(new Form1());
            //                    SaveLastPopupDate(currentDate);
            //                    //ValidHashKeys.Remove(userKey);
            //                //}
            //                //else
            //                //{
            //                //    MessageBox.Show("Invalid hash key. ", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                //}
            //            }
            //            else
            //            {
            //                // User closed the prompt or canceled

            //                MessageBox.Show("No hash key entered \nPlease Contact +20106782976", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                validKeyEntered = true;
            //            }
            //        }
            //}
            //    Application.Exit();
            //    ar = 1;

            //}
            if (ar == 0)
            {
            Application.Run(new Form1());

            }

            // Exit the application

            //Application.Exit();
        }

        //Application.Run(new Form1());
    }
    
}
