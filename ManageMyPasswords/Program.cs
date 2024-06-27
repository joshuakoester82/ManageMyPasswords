using System;
using System.Windows.Forms;

namespace ManageMyPasswords
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConnectionManager connectionManager = null;
            bool connectionEstablished = false;

            while (!connectionEstablished)
            {
                string connectionString = ConfigManager.LoadConnectionString();

                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionManager = new ConnectionManager(""); // Initialize with empty string
                }
                else
                {
                    connectionManager = new ConnectionManager(connectionString);
                    if (connectionManager.TestConnection())
                    {
                        connectionEstablished = true;
                        break;
                    }
                }

                using (var setupForm = new ConnectionSetupForm(connectionManager))
                {
                    if (setupForm.ShowDialog() == DialogResult.OK)
                    {
                        connectionManager = setupForm.ConnectionManager;
                        ConfigManager.SaveConnectionString(connectionManager.ConnectionString);
                        connectionEstablished = true;
                    }
                    else
                    {
                        return; // Exit if user cancels connection setup
                    }
                }
            }

            // At this point, we have a valid connection
            Application.Run(new MainForm(connectionManager));
        }
    }
}