using System;
using System.Data.Common;
using System.Windows.Forms;

namespace ManageMyPasswords
{
    public partial class ConnectionSetupForm : Form
    {
        public ConnectionManager ConnectionManager { get; private set; }

        public ConnectionSetupForm(ConnectionManager connectionManager)
        {
            InitializeComponent();
            ConnectionManager = connectionManager;
            LoadExistingSettings();
        }

        private void LoadExistingSettings()
        {
            if (ConfigManager.LoadConnectionString() != null)
            {
                var builder = new DbConnectionStringBuilder();
                builder.ConnectionString = ConfigManager.LoadConnectionString();

                // Extract specific values
                string server = builder["server"] as string;
                string port = builder["port"] as string;
                string database = builder["database"] as string;
                string user = builder["user"] as string;
                string password = builder["password"] as string;

                txtServer.Text = builder["server"] as string;
                txtPort.Text = builder["port"] as string;
                txtDatabase.Text = builder["database"] as string;
                txtUsername.Text = builder["user"] as string;
                // We don't set the password for security reasons
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string port = txtPort.Text;
            string database = txtDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = ConnectionManager.BuildConnectionString(server, port, database, username, password);
            ConnectionManager = new ConnectionManager(connectionString);

            if (ConnectionManager.TestConnection())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Unable to connect to the database. Please check your settings and try again.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}