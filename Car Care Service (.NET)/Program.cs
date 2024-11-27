using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Care_Service__.NET_
{   

    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var hashKeyPrompt = new HashKeyPrompt())
            {
                bool validKeyEntered = false;
                while (!validKeyEntered)
                { 
                    if (hashKeyPrompt.ShowDialog() == DialogResult.OK)
                    {
                        //string userKey = hashKeyPrompt.HashKey;
                        //string validKey = "12345"; // Replace with your actual hash key
                        //List<string> ValidHashKeys = new List<string>   {"12345","abcde","67890"};
                        string userKey = hashKeyPrompt.HashKey;


                        if (HashKeyManager.ValidateAndRemoveHashKey(userKey))
                        {

                            // Launch the main form
                            validKeyEntered = true;
                            MessageBox.Show("Hash key accepted. Ya ahlan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Run(new Form1());
                            //ValidHashKeys.Remove(userKey);
                        }
                        else
                        {
                            MessageBox.Show("Invalid hash key. ", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // User closed the prompt or canceled

                        MessageBox.Show("No hash key entered \nPlease Contact +20106782976", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        validKeyEntered = true;
                    }
            }
                Application.Exit();
            }

            // Exit the application
            
            //Application.Exit();
        }

        //Application.Run(new Form1());
    }
    
}
