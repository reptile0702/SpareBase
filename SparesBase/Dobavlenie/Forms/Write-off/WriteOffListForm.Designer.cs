namespace SparesBase
{
    partial class WriteOffListForm
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.numberOfOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEditOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.продажаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditSell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteSell = new System.Windows.Forms.ToolStripMenuItem();
            this.дефектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditDefect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteDefect = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSells = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsSell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEditSell = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteSell = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDefects = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whoIndetified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDefect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEditDefect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteDefect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnDeleteSell = new System.Windows.Forms.Button();
            this.btnEditSell = new System.Windows.Forms.Button();
            this.btnDeleteDefect = new System.Windows.Forms.Button();
            this.btnEditDefect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.cmsOrder.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSells)).BeginInit();
            this.cmsSell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefects)).BeginInit();
            this.cmsDefect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfOrder,
            this.quantity,
            this.firmPrice,
            this.total});
            this.dgvOrders.ContextMenuStrip = this.cmsOrder;
            this.dgvOrders.Location = new System.Drawing.Point(12, 57);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(433, 397);
            this.dgvOrders.TabIndex = 0;
            // 
            // numberOfOrder
            // 
            this.numberOfOrder.HeaderText = "Номер заказа";
            this.numberOfOrder.Name = "numberOfOrder";
            this.numberOfOrder.ReadOnly = true;
            this.numberOfOrder.Width = 96;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 91;
            // 
            // firmPrice
            // 
            this.firmPrice.HeaderText = "Цена фирмы";
            this.firmPrice.Name = "firmPrice";
            this.firmPrice.ReadOnly = true;
            this.firmPrice.Width = 89;
            // 
            // total
            // 
            this.total.HeaderText = "Итого";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 62;
            // 
            // cmsOrder
            // 
            this.cmsOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditOrder,
            this.cmsDeleteOrder});
            this.cmsOrder.Name = "cmsOrder";
            this.cmsOrder.Size = new System.Drawing.Size(186, 48);
            // 
            // cmsEditOrder
            // 
            this.cmsEditOrder.Name = "cmsEditOrder";
            this.cmsEditOrder.Size = new System.Drawing.Size(185, 22);
            this.cmsEditOrder.Text = "Редактировать заказ";
            this.cmsEditOrder.Click += new System.EventHandler(this.EditOrder_Click);
            // 
            // cmsDeleteOrder
            // 
            this.cmsDeleteOrder.Name = "cmsDeleteOrder";
            this.cmsDeleteOrder.Size = new System.Drawing.Size(185, 22);
            this.cmsDeleteOrder.Text = "Удалить заказ";
            this.cmsDeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrder,
            this.продажаToolStripMenuItem,
            this.дефектToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(983, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiOrder
            // 
            this.tsmiOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditOrder,
            this.tsmiDeleteOrder});
            this.tsmiOrder.Name = "tsmiOrder";
            this.tsmiOrder.Size = new System.Drawing.Size(49, 20);
            this.tsmiOrder.Text = "Заказ";
            // 
            // tsmiEditOrder
            // 
            this.tsmiEditOrder.Name = "tsmiEditOrder";
            this.tsmiEditOrder.Size = new System.Drawing.Size(154, 22);
            this.tsmiEditOrder.Text = "Редактировать";
            this.tsmiEditOrder.Click += new System.EventHandler(this.EditOrder_Click);
            // 
            // tsmiDeleteOrder
            // 
            this.tsmiDeleteOrder.Name = "tsmiDeleteOrder";
            this.tsmiDeleteOrder.Size = new System.Drawing.Size(154, 22);
            this.tsmiDeleteOrder.Text = "Удалить";
            this.tsmiDeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // продажаToolStripMenuItem
            // 
            this.продажаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditSell,
            this.tsmiDeleteSell});
            this.продажаToolStripMenuItem.Name = "продажаToolStripMenuItem";
            this.продажаToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.продажаToolStripMenuItem.Text = "Продажа";
            // 
            // tsmiEditSell
            // 
            this.tsmiEditSell.Name = "tsmiEditSell";
            this.tsmiEditSell.Size = new System.Drawing.Size(154, 22);
            this.tsmiEditSell.Text = "Редактировать";
            this.tsmiEditSell.Click += new System.EventHandler(this.EditSell_Click);
            // 
            // tsmiDeleteSell
            // 
            this.tsmiDeleteSell.Name = "tsmiDeleteSell";
            this.tsmiDeleteSell.Size = new System.Drawing.Size(154, 22);
            this.tsmiDeleteSell.Text = "Удалить";
            this.tsmiDeleteSell.Click += new System.EventHandler(this.DeleteSell_Click);
            // 
            // дефектToolStripMenuItem
            // 
            this.дефектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditDefect,
            this.tsmiDeleteDefect});
            this.дефектToolStripMenuItem.Name = "дефектToolStripMenuItem";
            this.дефектToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.дефектToolStripMenuItem.Text = "Дефект";
            // 
            // tsmiEditDefect
            // 
            this.tsmiEditDefect.Name = "tsmiEditDefect";
            this.tsmiEditDefect.Size = new System.Drawing.Size(154, 22);
            this.tsmiEditDefect.Text = "Редактировать";
            this.tsmiEditDefect.Click += new System.EventHandler(this.EditDefect_Click);
            // 
            // tsmiDeleteDefect
            // 
            this.tsmiDeleteDefect.Name = "tsmiDeleteDefect";
            this.tsmiDeleteDefect.Size = new System.Drawing.Size(154, 22);
            this.tsmiDeleteDefect.Text = "Удалить";
            this.tsmiDeleteDefect.Click += new System.EventHandler(this.DeleteDefect_Click);
            // 
            // dgvSells
            // 
            this.dgvSells.AllowUserToAddRows = false;
            this.dgvSells.AllowUserToDeleteRows = false;
            this.dgvSells.AllowUserToResizeRows = false;
            this.dgvSells.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSells.BackgroundColor = System.Drawing.Color.White;
            this.dgvSells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvSells.ContextMenuStrip = this.cmsSell;
            this.dgvSells.Location = new System.Drawing.Point(451, 57);
            this.dgvSells.MultiSelect = false;
            this.dgvSells.Name = "dgvSells";
            this.dgvSells.ReadOnly = true;
            this.dgvSells.RowHeadersVisible = false;
            this.dgvSells.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSells.Size = new System.Drawing.Size(167, 397);
            this.dgvSells.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Количество";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 91;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 58;
            // 
            // cmsSell
            // 
            this.cmsSell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditSell,
            this.cmsDeleteSell});
            this.cmsSell.Name = "cmsOrder";
            this.cmsSell.Size = new System.Drawing.Size(206, 48);
            // 
            // cmsEditSell
            // 
            this.cmsEditSell.Name = "cmsEditSell";
            this.cmsEditSell.Size = new System.Drawing.Size(205, 22);
            this.cmsEditSell.Text = "Редактировать продажу";
            this.cmsEditSell.Click += new System.EventHandler(this.EditSell_Click);
            // 
            // cmsDeleteSell
            // 
            this.cmsDeleteSell.Name = "cmsDeleteSell";
            this.cmsDeleteSell.Size = new System.Drawing.Size(205, 22);
            this.cmsDeleteSell.Text = "Удалить продажу";
            this.cmsDeleteSell.Click += new System.EventHandler(this.DeleteSell_Click);
            // 
            // dgvDefects
            // 
            this.dgvDefects.AllowUserToAddRows = false;
            this.dgvDefects.AllowUserToDeleteRows = false;
            this.dgvDefects.AllowUserToResizeRows = false;
            this.dgvDefects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDefects.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.whoIndetified});
            this.dgvDefects.ContextMenuStrip = this.cmsDefect;
            this.dgvDefects.Location = new System.Drawing.Point(624, 57);
            this.dgvDefects.MultiSelect = false;
            this.dgvDefects.Name = "dgvDefects";
            this.dgvDefects.ReadOnly = true;
            this.dgvDefects.RowHeadersVisible = false;
            this.dgvDefects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefects.Size = new System.Drawing.Size(347, 397);
            this.dgvDefects.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Количество предметов в партии";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 147;
            // 
            // whoIndetified
            // 
            this.whoIndetified.HeaderText = "Кто выявил";
            this.whoIndetified.Name = "whoIndetified";
            this.whoIndetified.ReadOnly = true;
            this.whoIndetified.Width = 84;
            // 
            // cmsDefect
            // 
            this.cmsDefect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditDefect,
            this.cmsDeleteDefect});
            this.cmsDefect.Name = "cmsOrder";
            this.cmsDefect.Size = new System.Drawing.Size(196, 48);
            // 
            // cmsEditDefect
            // 
            this.cmsEditDefect.Name = "cmsEditDefect";
            this.cmsEditDefect.Size = new System.Drawing.Size(195, 22);
            this.cmsEditDefect.Text = "Редактировать дефект";
            this.cmsEditDefect.Click += new System.EventHandler(this.EditDefect_Click);
            // 
            // cmsDeleteDefect
            // 
            this.cmsDeleteDefect.Name = "cmsDeleteDefect";
            this.cmsDeleteDefect.Size = new System.Drawing.Size(195, 22);
            this.cmsDeleteDefect.Text = "Удалить дефект";
            this.cmsDeleteDefect.Click += new System.EventHandler(this.DeleteDefect_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(12, 460);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(433, 32);
            this.btnEditOrder.TabIndex = 4;
            this.btnEditOrder.Text = "Редактировать";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.EditOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(12, 498);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(433, 32);
            this.btnDeleteOrder.TabIndex = 5;
            this.btnDeleteOrder.Text = "Удалить";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // btnDeleteSell
            // 
            this.btnDeleteSell.Location = new System.Drawing.Point(451, 498);
            this.btnDeleteSell.Name = "btnDeleteSell";
            this.btnDeleteSell.Size = new System.Drawing.Size(167, 32);
            this.btnDeleteSell.TabIndex = 7;
            this.btnDeleteSell.Text = "Удалить";
            this.btnDeleteSell.UseVisualStyleBackColor = true;
            this.btnDeleteSell.Click += new System.EventHandler(this.DeleteSell_Click);
            // 
            // btnEditSell
            // 
            this.btnEditSell.Location = new System.Drawing.Point(451, 460);
            this.btnEditSell.Name = "btnEditSell";
            this.btnEditSell.Size = new System.Drawing.Size(167, 32);
            this.btnEditSell.TabIndex = 6;
            this.btnEditSell.Text = "Редактировать";
            this.btnEditSell.UseVisualStyleBackColor = true;
            this.btnEditSell.Click += new System.EventHandler(this.EditSell_Click);
            // 
            // btnDeleteDefect
            // 
            this.btnDeleteDefect.Location = new System.Drawing.Point(624, 498);
            this.btnDeleteDefect.Name = "btnDeleteDefect";
            this.btnDeleteDefect.Size = new System.Drawing.Size(347, 32);
            this.btnDeleteDefect.TabIndex = 9;
            this.btnDeleteDefect.Text = "Удалить";
            this.btnDeleteDefect.UseVisualStyleBackColor = true;
            this.btnDeleteDefect.Click += new System.EventHandler(this.DeleteDefect_Click);
            // 
            // btnEditDefect
            // 
            this.btnEditDefect.Location = new System.Drawing.Point(624, 460);
            this.btnEditDefect.Name = "btnEditDefect";
            this.btnEditDefect.Size = new System.Drawing.Size(347, 32);
            this.btnEditDefect.TabIndex = 8;
            this.btnEditDefect.Text = "Редактировать";
            this.btnEditDefect.UseVisualStyleBackColor = true;
            this.btnEditDefect.Click += new System.EventHandler(this.EditDefect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Заказы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(451, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Продажи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(620, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Дефекты";
            // 
            // WriteOffListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 541);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteDefect);
            this.Controls.Add(this.btnEditDefect);
            this.Controls.Add(this.btnDeleteSell);
            this.Controls.Add(this.btnEditSell);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.dgvDefects);
            this.Controls.Add(this.dgvSells);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "WriteOffListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заказы предмета \"ИМЯ ПРЕДМЕТА\"";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.cmsOrder.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSells)).EndInit();
            this.cmsSell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefects)).EndInit();
            this.cmsDefect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.ContextMenuStrip cmsOrder;
        private System.Windows.Forms.ToolStripMenuItem cmsEditOrder;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteOrder;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteOrder;
        private System.Windows.Forms.ToolStripMenuItem продажаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditSell;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSell;
        private System.Windows.Forms.ToolStripMenuItem дефектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditDefect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteDefect;
        private System.Windows.Forms.DataGridView dgvSells;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dgvDefects;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn whoIndetified;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnDeleteSell;
        private System.Windows.Forms.Button btnEditSell;
        private System.Windows.Forms.Button btnDeleteDefect;
        private System.Windows.Forms.Button btnEditDefect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsSell;
        private System.Windows.Forms.ToolStripMenuItem cmsEditSell;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteSell;
        private System.Windows.Forms.ContextMenuStrip cmsDefect;
        private System.Windows.Forms.ToolStripMenuItem cmsEditDefect;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteDefect;
    }
}