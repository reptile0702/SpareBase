namespace SparesBaseAdministrator
{
    partial class AccountsForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.cmsAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRegisterAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDesignateAnAdministrator = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegisterOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegisterAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDesignateAnAdministrator = new System.Windows.Forms.ToolStripMenuItem();
            this.tvOrganizations = new System.Windows.Forms.TreeView();
            this.cmsOrganization = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRegisterOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteOrganization = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.cmsAccount.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.cmsOrganization.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToResizeRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAccounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.firstName,
            this.lastName,
            this.secondName,
            this.login,
            this.admin});
            this.dgvAccounts.ContextMenuStrip = this.cmsAccount;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(121, 24);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(741, 396);
            this.dgvAccounts.TabIndex = 0;
            this.dgvAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellDoubleClick);
            // 
            // cmsAccount
            // 
            this.cmsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRegisterAccount,
            this.cmsEditAccount,
            this.cmsDeleteAccount,
            this.cmsDesignateAnAdministrator});
            this.cmsAccount.Name = "cmsAccount";
            this.cmsAccount.Size = new System.Drawing.Size(311, 92);
            // 
            // cmsRegisterAccount
            // 
            this.cmsRegisterAccount.Name = "cmsRegisterAccount";
            this.cmsRegisterAccount.Size = new System.Drawing.Size(310, 22);
            this.cmsRegisterAccount.Text = "Зарегистрировать";
            this.cmsRegisterAccount.Click += new System.EventHandler(this.RegisterAccount_Click);
            // 
            // cmsEditAccount
            // 
            this.cmsEditAccount.Name = "cmsEditAccount";
            this.cmsEditAccount.Size = new System.Drawing.Size(310, 22);
            this.cmsEditAccount.Text = "Редактировать";
            this.cmsEditAccount.Click += new System.EventHandler(this.EditAccount_Click);
            // 
            // cmsDeleteAccount
            // 
            this.cmsDeleteAccount.Name = "cmsDeleteAccount";
            this.cmsDeleteAccount.Size = new System.Drawing.Size(310, 22);
            this.cmsDeleteAccount.Text = "Удалить";
            this.cmsDeleteAccount.Click += new System.EventHandler(this.DeleteAccount_Click);
            // 
            // cmsDesignateAnAdministrator
            // 
            this.cmsDesignateAnAdministrator.Name = "cmsDesignateAnAdministrator";
            this.cmsDesignateAnAdministrator.Size = new System.Drawing.Size(310, 22);
            this.cmsDesignateAnAdministrator.Text = "Назначить администратором организации";
            this.cmsDesignateAnAdministrator.Click += new System.EventHandler(this.DesignateAnAdministrator_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrganization,
            this.tsmiAccount});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(862, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiOrganization
            // 
            this.tsmiOrganization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegisterOrganization,
            this.tsmiEditOrganization,
            this.tsmiDeleteOrganization});
            this.tsmiOrganization.Name = "tsmiOrganization";
            this.tsmiOrganization.Size = new System.Drawing.Size(91, 20);
            this.tsmiOrganization.Text = "Организация";
            // 
            // tsmiRegisterOrganization
            // 
            this.tsmiRegisterOrganization.Name = "tsmiRegisterOrganization";
            this.tsmiRegisterOrganization.Size = new System.Drawing.Size(174, 22);
            this.tsmiRegisterOrganization.Text = "Зарегистрировать";
            this.tsmiRegisterOrganization.Click += new System.EventHandler(this.RegisterOrganization_Click);
            // 
            // tsmiEditOrganization
            // 
            this.tsmiEditOrganization.Name = "tsmiEditOrganization";
            this.tsmiEditOrganization.Size = new System.Drawing.Size(174, 22);
            this.tsmiEditOrganization.Text = "Редактировать";
            this.tsmiEditOrganization.Click += new System.EventHandler(this.EditOrganization_Click);
            // 
            // tsmiDeleteOrganization
            // 
            this.tsmiDeleteOrganization.Name = "tsmiDeleteOrganization";
            this.tsmiDeleteOrganization.Size = new System.Drawing.Size(174, 22);
            this.tsmiDeleteOrganization.Text = "Удалить";
            this.tsmiDeleteOrganization.Click += new System.EventHandler(this.DeleteOrganization_Click);
            // 
            // tsmiAccount
            // 
            this.tsmiAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegisterAccount,
            this.tsmiEditAccount,
            this.tsmiDeleteAccount,
            this.tsmiDesignateAnAdministrator});
            this.tsmiAccount.Name = "tsmiAccount";
            this.tsmiAccount.Size = new System.Drawing.Size(63, 20);
            this.tsmiAccount.Text = "Аккаунт";
            // 
            // tsmiRegisterAccount
            // 
            this.tsmiRegisterAccount.Name = "tsmiRegisterAccount";
            this.tsmiRegisterAccount.Size = new System.Drawing.Size(310, 22);
            this.tsmiRegisterAccount.Text = "Зарегистрировать";
            this.tsmiRegisterAccount.Click += new System.EventHandler(this.RegisterAccount_Click);
            // 
            // tsmiEditAccount
            // 
            this.tsmiEditAccount.Name = "tsmiEditAccount";
            this.tsmiEditAccount.Size = new System.Drawing.Size(310, 22);
            this.tsmiEditAccount.Text = "Редактировать";
            this.tsmiEditAccount.Click += new System.EventHandler(this.EditAccount_Click);
            // 
            // tsmiDeleteAccount
            // 
            this.tsmiDeleteAccount.Name = "tsmiDeleteAccount";
            this.tsmiDeleteAccount.Size = new System.Drawing.Size(310, 22);
            this.tsmiDeleteAccount.Text = "Удалить";
            this.tsmiDeleteAccount.Click += new System.EventHandler(this.DeleteAccount_Click);
            // 
            // tsmiDesignateAnAdministrator
            // 
            this.tsmiDesignateAnAdministrator.Name = "tsmiDesignateAnAdministrator";
            this.tsmiDesignateAnAdministrator.Size = new System.Drawing.Size(310, 22);
            this.tsmiDesignateAnAdministrator.Text = "Назначить администратором организации";
            this.tsmiDesignateAnAdministrator.Click += new System.EventHandler(this.DesignateAnAdministrator_Click);
            // 
            // tvOrganizations
            // 
            this.tvOrganizations.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvOrganizations.Location = new System.Drawing.Point(0, 24);
            this.tvOrganizations.Name = "tvOrganizations";
            this.tvOrganizations.ShowRootLines = false;
            this.tvOrganizations.Size = new System.Drawing.Size(121, 396);
            this.tvOrganizations.TabIndex = 3;
            this.tvOrganizations.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganizations_AfterSelect);
            this.tvOrganizations.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOrganizations_NodeMouseDoubleClick);
            // 
            // cmsOrganization
            // 
            this.cmsOrganization.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRegisterOrganization,
            this.cmsEditOrganization,
            this.cmsDeleteOrganization});
            this.cmsOrganization.Name = "cmsAccount";
            this.cmsOrganization.Size = new System.Drawing.Size(175, 70);
            // 
            // cmsRegisterOrganization
            // 
            this.cmsRegisterOrganization.Name = "cmsRegisterOrganization";
            this.cmsRegisterOrganization.Size = new System.Drawing.Size(174, 22);
            this.cmsRegisterOrganization.Text = "Зарегистрировать";
            this.cmsRegisterOrganization.Click += new System.EventHandler(this.RegisterOrganization_Click);
            // 
            // cmsEditOrganization
            // 
            this.cmsEditOrganization.Name = "cmsEditOrganization";
            this.cmsEditOrganization.Size = new System.Drawing.Size(174, 22);
            this.cmsEditOrganization.Text = "Редактировать";
            this.cmsEditOrganization.Click += new System.EventHandler(this.EditOrganization_Click);
            // 
            // cmsDeleteOrganization
            // 
            this.cmsDeleteOrganization.Name = "cmsDeleteOrganization";
            this.cmsDeleteOrganization.Size = new System.Drawing.Size(174, 22);
            this.cmsDeleteOrganization.Text = "Удалить";
            this.cmsDeleteOrganization.Click += new System.EventHandler(this.DeleteOrganization_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "Имя";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 54;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Фамилия";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            this.lastName.Width = 81;
            // 
            // secondName
            // 
            this.secondName.HeaderText = "Отчество";
            this.secondName.Name = "secondName";
            this.secondName.ReadOnly = true;
            this.secondName.Width = 79;
            // 
            // login
            // 
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 63;
            // 
            // admin
            // 
            this.admin.HeaderText = "Администратор";
            this.admin.Name = "admin";
            this.admin.ReadOnly = true;
            this.admin.Width = 92;
            // 
            // AccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 420);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.tvOrganizations);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "AccountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Аккаунты";
            this.Load += new System.EventHandler(this.AccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.cmsAccount.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.cmsOrganization.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TreeView tvOrganizations;
        private System.Windows.Forms.ContextMenuStrip cmsAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrganization;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegisterOrganization;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditOrganization;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteOrganization;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegisterAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiDesignateAnAdministrator;
        private System.Windows.Forms.ContextMenuStrip cmsOrganization;
        private System.Windows.Forms.ToolStripMenuItem cmsRegisterAccount;
        private System.Windows.Forms.ToolStripMenuItem cmsEditAccount;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteAccount;
        private System.Windows.Forms.ToolStripMenuItem cmsDesignateAnAdministrator;
        private System.Windows.Forms.ToolStripMenuItem cmsRegisterOrganization;
        private System.Windows.Forms.ToolStripMenuItem cmsEditOrganization;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewCheckBoxColumn admin;
    }
}