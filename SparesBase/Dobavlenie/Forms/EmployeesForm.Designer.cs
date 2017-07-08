namespace SparesBase.Forms
{
    partial class EmployeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.сотрудникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteEmployee = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.cmsEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowDrop = true;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastName,
            this.firstName,
            this.secondName});
            this.dgv.ContextMenuStrip = this.cmsEmployee;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(360, 359);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Фамилия";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "Имя";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // secondName
            // 
            this.secondName.HeaderText = "Отчество";
            this.secondName.Name = "secondName";
            this.secondName.ReadOnly = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(360, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // сотрудникToolStripMenuItem
            // 
            this.сотрудникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiEdit,
            this.tsmiDelete});
            this.сотрудникToolStripMenuItem.Name = "сотрудникToolStripMenuItem";
            this.сотрудникToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сотрудникToolStripMenuItem.Text = "Сотрудник";
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(154, 22);
            this.tsmiAdd.Text = "Добавить";
            this.tsmiAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(154, 22);
            this.tsmiEdit.Text = "Редактировать";
            this.tsmiEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(154, 22);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cmsEmployee
            // 
            this.cmsEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddEmployee,
            this.cmsEditEmployee,
            this.cmsDeleteEmployee});
            this.cmsEmployee.Name = "contextMenuStrip1";
            this.cmsEmployee.Size = new System.Drawing.Size(221, 92);
            // 
            // cmsAddEmployee
            // 
            this.cmsAddEmployee.Name = "cmsAddEmployee";
            this.cmsAddEmployee.Size = new System.Drawing.Size(220, 22);
            this.cmsAddEmployee.Text = "Добавить сотрудника";
            this.cmsAddEmployee.Click += new System.EventHandler(this.Add_Click);
            // 
            // cmsEditEmployee
            // 
            this.cmsEditEmployee.Name = "cmsEditEmployee";
            this.cmsEditEmployee.Size = new System.Drawing.Size(220, 22);
            this.cmsEditEmployee.Text = "Редактировать сотрудника";
            this.cmsEditEmployee.Click += new System.EventHandler(this.Edit_Click);
            // 
            // cmsDeleteEmployee
            // 
            this.cmsDeleteEmployee.Name = "cmsDeleteEmployee";
            this.cmsDeleteEmployee.Size = new System.Drawing.Size(220, 22);
            this.cmsDeleteEmployee.Text = "Удалить сотрудника";
            this.cmsDeleteEmployee.Click += new System.EventHandler(this.Delete_Click);
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 383);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "EmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сотрудники";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.cmsEmployee.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondName;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem сотрудникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ContextMenuStrip cmsEmployee;
        private System.Windows.Forms.ToolStripMenuItem cmsAddEmployee;
        private System.Windows.Forms.ToolStripMenuItem cmsEditEmployee;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteEmployee;
    }
}