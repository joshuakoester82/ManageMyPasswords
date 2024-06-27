using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ManageMyPasswords
{
    public partial class MainForm : Form
    {
        private PasswordGenerator passwordGenerator;
        private ConnectionManager connectionManager;
        private int passwordLength = 16;
        private bool useLowercase = true;
        private bool useUppercase = true;
        private bool useNumeric = true;
        private bool useSpecial = true;
        private ToolStripMenuItem configurationToolStripMenuItem;

        public MainForm(ConnectionManager connectionManager)
        {
            InitializeComponent();
            passwordGenerator = new PasswordGenerator();
            this.connectionManager = connectionManager;
            SetupListView();
            SetupServiceFilter();
            SetupCategoryFilter();
        }

        private void SetupListView()
        {
            listViewPasswords.View = View.Details;
            listViewPasswords.FullRowSelect = true;
            listViewPasswords.Columns.Add("ID", 50);
            listViewPasswords.Columns.Add("Service", 170);
            listViewPasswords.Columns.Add("Category", 170);
            listViewPasswords.Columns.Add("Username", 170);
            listViewPasswords.Columns.Add("Password", 170);
            listViewPasswords.Columns.Add("Notes", 200);
            listViewPasswords.MouseClick += ListViewPasswords_MouseClick;
        }

        private void SetupServiceFilter()
        {
            cmbServiceFilter.Items.Add("All Services");
            cmbServiceFilter.SelectedIndex = 0;
            LoadServices();
        }

        private void SetupCategoryFilter()
        {
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.SelectedIndex = 0;
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT category FROM passwords ORDER BY category";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategoryFilter.Items.Add(reader["category"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void LoadServices()
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT service FROM passwords ORDER BY service";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbServiceFilter.Items.Add(reader["service"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}");
            }
        }

        private void RetrievePasswords()
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, service, category, username, password, notes FROM passwords WHERE 1=1";
                    if (cmbServiceFilter.SelectedIndex > 0)
                    {
                        query += " AND service = @service";
                    }
                    if (cmbCategoryFilter.SelectedIndex > 0)
                    {
                        query += " AND category = @category";
                    }
                    query += " ORDER BY service, username";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (cmbServiceFilter.SelectedIndex > 0)
                        {
                            command.Parameters.AddWithValue("@service", cmbServiceFilter.SelectedItem.ToString());
                        }
                        if (cmbCategoryFilter.SelectedIndex > 0)
                        {
                            command.Parameters.AddWithValue("@category", cmbCategoryFilter.SelectedItem.ToString());
                        }
                        using (var reader = command.ExecuteReader())
                        {
                            listViewPasswords.Items.Clear();
                            while (reader.Read())
                            {
                                var item = new ListViewItem(reader["id"].ToString());
                                item.SubItems.Add(reader["service"].ToString());
                                item.SubItems.Add(reader["category"].ToString());
                                item.SubItems.Add(reader["username"].ToString());
                                item.SubItems.Add(reader["password"].ToString());
                                item.SubItems.Add(reader["notes"].ToString());
                                listViewPasswords.Items.Add(item);
                            }
                        }
                    }
                }

                listViewPasswords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewPasswords.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving passwords: {ex.Message}");
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            RetrievePasswords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPasswords.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a password to delete.");
                return;
            }

            int id = int.Parse(listViewPasswords.SelectedItems[0].Text);

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM passwords WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                listViewPasswords.SelectedItems[0].Remove();
                ClearInputFields();
                UpdateServiceFilter();
                UpdateCategoryFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting password: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPasswords.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a password to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWebsite.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please fill in all fields (Service, Category, Username, and Password) before updating.");
                return;
            }

            int id = int.Parse(listViewPasswords.SelectedItems[0].Text);

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE passwords SET service = @service, category = @category, username = @username, password = @password, notes = @notes WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@service", txtWebsite.Text);
                        command.Parameters.AddWithValue("@category", txtCategory.Text);
                        command.Parameters.AddWithValue("@username", txtUsername.Text);
                        command.Parameters.AddWithValue("@password", txtPassword.Text);
                        command.Parameters.AddWithValue("@notes", txtNotes.Text);
                        command.ExecuteNonQuery();
                    }
                }
                RetrievePasswords();
                UpdateServiceFilter();
                UpdateCategoryFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWebsite.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please fill in all fields (Service, Category, Username, and Password) before adding.");
                return;
            }

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO passwords (service, category, username, password, notes) VALUES (@service, @category, @username, @password, @notes)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@service", txtWebsite.Text);
                        command.Parameters.AddWithValue("@category", txtCategory.Text);
                        command.Parameters.AddWithValue("@username", txtUsername.Text);
                        command.Parameters.AddWithValue("@password", txtPassword.Text);
                        command.Parameters.AddWithValue("@notes", txtNotes.Text);
                        command.ExecuteNonQuery();
                    }
                }
                RetrievePasswords();
                ClearInputFields();
                UpdateServiceFilter();
                UpdateCategoryFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding password: {ex.Message}");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = passwordGenerator.GeneratePassword(passwordLength, useLowercase, useUppercase, useNumeric, useSpecial);
        }

        private void listViewPasswords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPasswords.SelectedItems.Count > 0)
            {
                var selectedItem = listViewPasswords.SelectedItems[0];
                txtWebsite.Text = selectedItem.SubItems[1].Text;
                txtCategory.Text = selectedItem.SubItems[2].Text;
                txtUsername.Text = selectedItem.SubItems[3].Text;
                txtPassword.Text = selectedItem.SubItems[4].Text;
                txtNotes.Text = selectedItem.SubItems[5].Text;
            }
        }

        private void ListViewPasswords_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hit = listViewPasswords.HitTest(e.Location);
                if (hit.SubItem != null && hit.Item.SubItems.IndexOf(hit.SubItem) == 4) // Password column
                {
                    Clipboard.SetText(hit.SubItem.Text);
                    MessageBox.Show("Password copied to clipboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearInputFields()
        {
            txtWebsite.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNotes.Text = string.Empty;
        }

        private void UpdateServiceFilter()
        {
            string currentSelection = cmbServiceFilter.SelectedItem?.ToString();
            cmbServiceFilter.Items.Clear();
            cmbServiceFilter.Items.Add("All Services");
            LoadServices();
            if (cmbServiceFilter.Items.Contains(currentSelection))
            {
                cmbServiceFilter.SelectedItem = currentSelection;
            }
            else
            {
                cmbServiceFilter.SelectedIndex = 0;
            }
        }

        private void UpdateCategoryFilter()
        {
            string currentSelection = cmbCategoryFilter.SelectedItem?.ToString();
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            LoadCategories();
            if (cmbCategoryFilter.Items.Contains(currentSelection))
            {
                cmbCategoryFilter.SelectedItem = currentSelection;
            }
            else
            {
                cmbCategoryFilter.SelectedIndex = 0;
            }
        }

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportCsv(filePath);
                }
            }
        }

        private void ImportCsv(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string line;
                    bool isFirstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine) // Skip header row
                        {
                            isFirstLine = false;
                            continue;
                        }

                        string[] values = line.Split(',');
                        if (values.Length >= 4) // Ensure we have service, category, username, and password
                        {
                            string service = values[0].Trim();
                            string category = values[1].Trim();
                            string username = values[2].Trim();
                            string password = values[3].Trim();
                            string notes = values.Length > 4 ? values[4].Trim() : string.Empty;

                            string query = "INSERT INTO passwords (service, category, username, password, notes) VALUES (@service, @category, @username, @password, @notes)";
                            using (var command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@service", service);
                                command.Parameters.AddWithValue("@category", category);
                                command.Parameters.AddWithValue("@username", username);
                                command.Parameters.AddWithValue("@password", password);
                                command.Parameters.AddWithValue("@notes", notes);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("CSV import completed successfully.");
                RetrievePasswords();
                UpdateServiceFilter();
                UpdateCategoryFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing CSV: {ex.Message}");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void passwordLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                string lengthText = menuItem.Text.Split(' ')[0];
                if (int.TryParse(lengthText, out int length))
                {
                    passwordLength = length;
                    MessageBox.Show($"Password length set to {passwordLength} characters.");
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ManageMyPasswords v0.1\nDeveloped as a learning project.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
{
    using (var configForm = new ConnectionSetupForm(connectionManager))
    {
        if (configForm.ShowDialog() == DialogResult.OK)
        {
            // Update the connection manager
            this.connectionManager = configForm.ConnectionManager;
            // Refresh the password list
            RetrievePasswords();
        }
    }
}

        private void helpContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple password manager application.\n\n" +
                "- Use the 'Add Password' button to add new entries.\n" +
                "- Select an entry and use 'Update Password' to modify it.\n" +
                "- Use 'Delete Password' to remove an entry.\n" +
                "- 'Generate Password' creates a new random password.\n" +
                "- Import CSV allows you to bulk import passwords.\n" +
                "- You can filter passwords by service and category using the dropdowns.\n" +
                "- Configuration lets you set connection parameters.",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void characterTypeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                switch (menuItem.Name)
                {
                    case "lowercaseToolStripMenuItem":
                        useLowercase = menuItem.Checked;
                        break;
                    case "uppercaseToolStripMenuItem":
                        useUppercase = menuItem.Checked;
                        break;
                    case "numericToolStripMenuItem":
                        useNumeric = menuItem.Checked;
                        break;
                    case "specialToolStripMenuItem":
                        useSpecial = menuItem.Checked;
                        break;
                }

                // Ensure at least one option is always selected
                if (!useLowercase && !useUppercase && !useNumeric && !useSpecial)
                {
                    menuItem.Checked = true;
                    MessageBox.Show("At least one character type must be selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbServiceFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrievePasswords();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrievePasswords();
        }
    }
}