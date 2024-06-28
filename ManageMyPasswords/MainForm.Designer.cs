using System.Windows.Forms;

namespace ManageMyPasswords
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listViewPasswords = new ListView();
            txtWebsite = new TextBox();
            txtCategory = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtNotes = new TextBox();
            btnRetrieve = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnGenerate = new Button();
            btnAdd = new Button();
            lblWebsite = new Label();
            lblCategory = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblNotes = new Label();
            cmbServiceFilter = new ComboBox();
            lblServiceFilter = new Label();
            cmbCategoryFilter = new ComboBox();
            lblCategoryFilter = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importCSVToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            passwordLengthToolStripMenuItem = new ToolStripMenuItem();
            lengthToolStripMenuItem = new ToolStripMenuItem();
            lengthToolStripMenuItem1 = new ToolStripMenuItem();
            lengthToolStripMenuItem2 = new ToolStripMenuItem();
            lengthToolStripMenuItem3 = new ToolStripMenuItem();
            passwordCharactersToolStripMenuItem = new ToolStripMenuItem();
            lowercaseToolStripMenuItem = new ToolStripMenuItem();
            uppercaseToolStripMenuItem = new ToolStripMenuItem();
            numericToolStripMenuItem = new ToolStripMenuItem();
            specialToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpContentsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewPasswords
            // 
            listViewPasswords.BackColor = SystemColors.Window;
            listViewPasswords.Location = new Point(20, 96);
            listViewPasswords.Margin = new Padding(5, 6, 5, 6);
            listViewPasswords.Name = "listViewPasswords";
            listViewPasswords.Size = new Size(1605, 916);
            listViewPasswords.TabIndex = 0;
            listViewPasswords.UseCompatibleStateImageBehavior = false;
            listViewPasswords.View = View.Details;
            listViewPasswords.SelectedIndexChanged += listViewPasswords_SelectedIndexChanged;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(20, 1060);
            txtWebsite.Margin = new Padding(5, 6, 5, 6);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(274, 31);
            txtWebsite.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(304, 1060);
            txtCategory.Margin = new Padding(5, 6, 5, 6);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(274, 31);
            txtCategory.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(588, 1060);
            txtUsername.Margin = new Padding(5, 6, 5, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(274, 31);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(872, 1060);
            txtPassword.Margin = new Padding(5, 6, 5, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(274, 31);
            txtPassword.TabIndex = 4;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(1168, 1060);
            txtNotes.Margin = new Padding(5, 6, 5, 6);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(457, 116);
            txtNotes.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new Point(1653, 96);
            btnRetrieve.Margin = new Padding(5, 6, 5, 6);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(200, 44);
            btnRetrieve.TabIndex = 6;
            btnRetrieve.Text = "Retrieve Passwords";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1653, 152);
            btnDelete.Margin = new Padding(5, 6, 5, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 44);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete Password";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(1653, 208);
            btnUpdate.Margin = new Padding(5, 6, 5, 6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(200, 44);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Password";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(1653, 264);
            btnGenerate.Margin = new Padding(5, 6, 5, 6);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(200, 44);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "Generate Password";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1653, 320);
            btnAdd.Margin = new Padding(5, 6, 5, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 44);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Password";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(20, 1029);
            lblWebsite.Margin = new Padding(5, 0, 5, 0);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(67, 25);
            lblWebsite.TabIndex = 11;
            lblWebsite.Text = "Service";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(304, 1029);
            lblCategory.Margin = new Padding(5, 0, 5, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 12;
            lblCategory.Text = "Category";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(590, 1029);
            lblUsername.Margin = new Padding(5, 0, 5, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 13;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(872, 1029);
            lblPassword.Margin = new Padding(5, 0, 5, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 14;
            lblPassword.Text = "Password";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(1168, 1029);
            lblNotes.Margin = new Padding(5, 0, 5, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(59, 25);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "Notes";
            // 
            // cmbServiceFilter
            // 
            cmbServiceFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServiceFilter.FormattingEnabled = true;
            cmbServiceFilter.Location = new Point(159, 51);
            cmbServiceFilter.Margin = new Padding(5, 6, 5, 6);
            cmbServiceFilter.Name = "cmbServiceFilter";
            cmbServiceFilter.Size = new Size(331, 33);
            cmbServiceFilter.TabIndex = 16;
            cmbServiceFilter.SelectedIndexChanged += cmbServiceFilter_SelectedIndexChanged;
            // 
            // lblServiceFilter
            // 
            lblServiceFilter.AutoSize = true;
            lblServiceFilter.Location = new Point(20, 54);
            lblServiceFilter.Margin = new Padding(5, 0, 5, 0);
            lblServiceFilter.Name = "lblServiceFilter";
            lblServiceFilter.Size = new Size(139, 25);
            lblServiceFilter.TabIndex = 17;
            lblServiceFilter.Text = "Filter by Service:";
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(703, 51);
            cmbCategoryFilter.Margin = new Padding(5, 6, 5, 6);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(331, 33);
            cmbCategoryFilter.TabIndex = 18;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // lblCategoryFilter
            // 
            lblCategoryFilter.AutoSize = true;
            lblCategoryFilter.Location = new Point(537, 54);
            lblCategoryFilter.Margin = new Padding(5, 0, 5, 0);
            lblCategoryFilter.Name = "lblCategoryFilter";
            lblCategoryFilter.Size = new Size(156, 25);
            lblCategoryFilter.TabIndex = 19;
            lblCategoryFilter.Text = "Filter by Category:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1898, 33);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importCSVToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // importCSVToolStripMenuItem
            // 
            importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            importCSVToolStripMenuItem.Size = new Size(206, 34);
            importCSVToolStripMenuItem.Text = "Import CSV";
            importCSVToolStripMenuItem.Click += importCSVToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(206, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { passwordLengthToolStripMenuItem, passwordCharactersToolStripMenuItem, configurationToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(92, 29);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // passwordLengthToolStripMenuItem
            // 
            passwordLengthToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lengthToolStripMenuItem, lengthToolStripMenuItem1, lengthToolStripMenuItem2, lengthToolStripMenuItem3 });
            passwordLengthToolStripMenuItem.Name = "passwordLengthToolStripMenuItem";
            passwordLengthToolStripMenuItem.Size = new Size(276, 34);
            passwordLengthToolStripMenuItem.Text = "Password Length";
            // 
            // lengthToolStripMenuItem
            // 
            lengthToolStripMenuItem.Name = "lengthToolStripMenuItem";
            lengthToolStripMenuItem.Size = new Size(218, 34);
            lengthToolStripMenuItem.Text = "8 characters";
            lengthToolStripMenuItem.Click += passwordLengthToolStripMenuItem_Click;
            // 
            // lengthToolStripMenuItem1
            // 
            lengthToolStripMenuItem1.Name = "lengthToolStripMenuItem1";
            lengthToolStripMenuItem1.Size = new Size(218, 34);
            lengthToolStripMenuItem1.Text = "12 characters";
            lengthToolStripMenuItem1.Click += passwordLengthToolStripMenuItem_Click;
            // 
            // lengthToolStripMenuItem2
            // 
            lengthToolStripMenuItem2.Name = "lengthToolStripMenuItem2";
            lengthToolStripMenuItem2.Size = new Size(218, 34);
            lengthToolStripMenuItem2.Text = "16 characters";
            lengthToolStripMenuItem2.Click += passwordLengthToolStripMenuItem_Click;
            // 
            // lengthToolStripMenuItem3
            // 
            lengthToolStripMenuItem3.Name = "lengthToolStripMenuItem3";
            lengthToolStripMenuItem3.Size = new Size(218, 34);
            lengthToolStripMenuItem3.Text = "20 characters";
            lengthToolStripMenuItem3.Click += passwordLengthToolStripMenuItem_Click;
            // 
            // passwordCharactersToolStripMenuItem
            // 
            passwordCharactersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lowercaseToolStripMenuItem, uppercaseToolStripMenuItem, numericToolStripMenuItem, specialToolStripMenuItem });
            passwordCharactersToolStripMenuItem.Name = "passwordCharactersToolStripMenuItem";
            passwordCharactersToolStripMenuItem.Size = new Size(276, 34);
            passwordCharactersToolStripMenuItem.Text = "Password Characters";
            // 
            // lowercaseToolStripMenuItem
            // 
            lowercaseToolStripMenuItem.Checked = true;
            lowercaseToolStripMenuItem.CheckOnClick = true;
            lowercaseToolStripMenuItem.CheckState = CheckState.Checked;
            lowercaseToolStripMenuItem.Name = "lowercaseToolStripMenuItem";
            lowercaseToolStripMenuItem.Size = new Size(197, 34);
            lowercaseToolStripMenuItem.Text = "Lowercase";
            lowercaseToolStripMenuItem.CheckedChanged += characterTypeToolStripMenuItem_CheckedChanged;
            // 
            // uppercaseToolStripMenuItem
            // 
            uppercaseToolStripMenuItem.Checked = true;
            uppercaseToolStripMenuItem.CheckOnClick = true;
            uppercaseToolStripMenuItem.CheckState = CheckState.Checked;
            uppercaseToolStripMenuItem.Name = "uppercaseToolStripMenuItem";
            uppercaseToolStripMenuItem.Size = new Size(197, 34);
            uppercaseToolStripMenuItem.Text = "Uppercase";
            uppercaseToolStripMenuItem.CheckedChanged += characterTypeToolStripMenuItem_CheckedChanged;
            // 
            // numericToolStripMenuItem
            // 
            numericToolStripMenuItem.Checked = true;
            numericToolStripMenuItem.CheckOnClick = true;
            numericToolStripMenuItem.CheckState = CheckState.Checked;
            numericToolStripMenuItem.Name = "numericToolStripMenuItem";
            numericToolStripMenuItem.Size = new Size(197, 34);
            numericToolStripMenuItem.Text = "Numeric";
            numericToolStripMenuItem.CheckedChanged += characterTypeToolStripMenuItem_CheckedChanged;
            // 
            // specialToolStripMenuItem
            // 
            specialToolStripMenuItem.Checked = true;
            specialToolStripMenuItem.CheckOnClick = true;
            specialToolStripMenuItem.CheckState = CheckState.Checked;
            specialToolStripMenuItem.Name = "specialToolStripMenuItem";
            specialToolStripMenuItem.Size = new Size(197, 34);
            specialToolStripMenuItem.Text = "Special";
            specialToolStripMenuItem.CheckedChanged += characterTypeToolStripMenuItem_CheckedChanged;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(276, 34);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, helpContentsToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(227, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // helpContentsToolStripMenuItem
            // 
            helpContentsToolStripMenuItem.Name = "helpContentsToolStripMenuItem";
            helpContentsToolStripMenuItem.Size = new Size(227, 34);
            helpContentsToolStripMenuItem.Text = "Help Contents";
            helpContentsToolStripMenuItem.Click += helpContentsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1898, 1205);
            Controls.Add(lblCategoryFilter);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(lblServiceFilter);
            Controls.Add(cmbServiceFilter);
            Controls.Add(lblNotes);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblCategory);
            Controls.Add(lblWebsite);
            Controls.Add(btnAdd);
            Controls.Add(btnGenerate);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRetrieve);
            Controls.Add(txtNotes);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtCategory);
            Controls.Add(txtWebsite);
            Controls.Add(listViewPasswords);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "ManageMyPasswords v0.1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewPasswords;
        private TextBox txtWebsite;
        private TextBox txtCategory;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtNotes;
        private Button btnRetrieve;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnGenerate;
        private Button btnAdd;
        private Label lblWebsite;
        private Label lblCategory;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblNotes;
        private ComboBox cmbServiceFilter;
        private Label lblServiceFilter;
        private ComboBox cmbCategoryFilter;
        private Label lblCategoryFilter;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importCSVToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem passwordLengthToolStripMenuItem;
        private ToolStripMenuItem lengthToolStripMenuItem;
        private ToolStripMenuItem lengthToolStripMenuItem1;
        private ToolStripMenuItem lengthToolStripMenuItem2;
        private ToolStripMenuItem lengthToolStripMenuItem3;
        private ToolStripMenuItem passwordCharactersToolStripMenuItem;
        private ToolStripMenuItem lowercaseToolStripMenuItem;
        private ToolStripMenuItem uppercaseToolStripMenuItem;
        private ToolStripMenuItem numericToolStripMenuItem;
        private ToolStripMenuItem specialToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpContentsToolStripMenuItem;
    }
}