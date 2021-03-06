﻿namespace SparesBase
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddMainCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSubCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActionLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.организацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSellers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new SparesBase.CategoriesTreeView();
            this.cmsMainCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddMainCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExpandAllNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCollapseAllNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbSerial = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvItems = new SparesBase.ItemsDataGridView();
            this.inventNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholesalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.residue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lCategories = new System.Windows.Forms.Label();
            this.lresidue = new System.Windows.Forms.Label();
            this.lquantity = new System.Windows.Forms.Label();
            this.lnote = new System.Windows.Forms.Label();
            this.lstorage = new System.Windows.Forms.Label();
            this.lfirm = new System.Windows.Forms.Label();
            this.lservice = new System.Windows.Forms.Label();
            this.lwhole = new System.Windows.Forms.Label();
            this.lretail = new System.Windows.Forms.Label();
            this.lpurchase = new System.Windows.Forms.Label();
            this.lseller = new System.Windows.Forms.Label();
            this.lname = new System.Windows.Forms.Label();
            this.btnWriteOffList = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddSubCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRenameCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExpandNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCollapseNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWriteOff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSelling = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDefect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsMainCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.cmsItem.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsCategory.SuspendLayout();
            this.cmsWriteOff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAccount,
            this.категорииToolStripMenuItem,
            this.предметыToolStripMenuItem,
            this.tsmiSearch,
            this.деревоToolStripMenuItem,
            this.tsmiLogs,
            this.организацияToolStripMenuItem,
            this.tsmiSettings,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1444, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiAccount
            // 
            this.tsmiAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAccountInfo,
            this.tsmiChangeAccount,
            this.tsmiExit});
            this.tsmiAccount.Name = "tsmiAccount";
            this.tsmiAccount.Size = new System.Drawing.Size(63, 20);
            this.tsmiAccount.Text = "Аккаунт";
            // 
            // tsmiAccountInfo
            // 
            this.tsmiAccountInfo.Name = "tsmiAccountInfo";
            this.tsmiAccountInfo.Size = new System.Drawing.Size(225, 22);
            this.tsmiAccountInfo.Text = "Информация об аккаунте...";
            this.tsmiAccountInfo.Click += new System.EventHandler(this.tsmiAccountInfo_Click);
            // 
            // tsmiChangeAccount
            // 
            this.tsmiChangeAccount.Name = "tsmiChangeAccount";
            this.tsmiChangeAccount.Size = new System.Drawing.Size(225, 22);
            this.tsmiChangeAccount.Text = "Смена пользователя";
            this.tsmiChangeAccount.Click += new System.EventHandler(this.tsmiChangeAccount_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(225, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // категорииToolStripMenuItem
            // 
            this.категорииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddMainCategory,
            this.tsmiAddSubCategory,
            this.tsmiRenameCategory,
            this.tsmiDeleteCategory});
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.категорииToolStripMenuItem.Text = "Категория";
            // 
            // tsmiAddMainCategory
            // 
            this.tsmiAddMainCategory.Name = "tsmiAddMainCategory";
            this.tsmiAddMainCategory.Size = new System.Drawing.Size(247, 22);
            this.tsmiAddMainCategory.Text = "Добавить главную категорию...";
            this.tsmiAddMainCategory.Click += new System.EventHandler(this.AddMainCategory_Click);
            // 
            // tsmiAddSubCategory
            // 
            this.tsmiAddSubCategory.Name = "tsmiAddSubCategory";
            this.tsmiAddSubCategory.Size = new System.Drawing.Size(247, 22);
            this.tsmiAddSubCategory.Text = "Добавить подкатегорию...";
            this.tsmiAddSubCategory.Click += new System.EventHandler(this.AddSubCategory_Click);
            // 
            // tsmiRenameCategory
            // 
            this.tsmiRenameCategory.Name = "tsmiRenameCategory";
            this.tsmiRenameCategory.Size = new System.Drawing.Size(247, 22);
            this.tsmiRenameCategory.Text = "Переименовать категорию...";
            this.tsmiRenameCategory.Click += new System.EventHandler(this.RenameCategory_Click);
            // 
            // tsmiDeleteCategory
            // 
            this.tsmiDeleteCategory.Name = "tsmiDeleteCategory";
            this.tsmiDeleteCategory.Size = new System.Drawing.Size(247, 22);
            this.tsmiDeleteCategory.Text = "Удалить категорию";
            this.tsmiDeleteCategory.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // предметыToolStripMenuItem
            // 
            this.предметыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddItem,
            this.tsmiEditItem,
            this.tsmiDeleteItem});
            this.предметыToolStripMenuItem.Name = "предметыToolStripMenuItem";
            this.предметыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.предметыToolStripMenuItem.Text = "Предмет";
            // 
            // tsmiAddItem
            // 
            this.tsmiAddItem.Name = "tsmiAddItem";
            this.tsmiAddItem.Size = new System.Drawing.Size(212, 22);
            this.tsmiAddItem.Text = "Добавить предмет...";
            this.tsmiAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tsmiEditItem
            // 
            this.tsmiEditItem.Name = "tsmiEditItem";
            this.tsmiEditItem.Size = new System.Drawing.Size(212, 22);
            this.tsmiEditItem.Text = "Редактировать предмет...";
            this.tsmiEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // tsmiDeleteItem
            // 
            this.tsmiDeleteItem.Name = "tsmiDeleteItem";
            this.tsmiDeleteItem.Size = new System.Drawing.Size(212, 22);
            this.tsmiDeleteItem.Text = "Удалить предмет";
            this.tsmiDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(54, 20);
            this.tsmiSearch.Text = "Поиск";
            this.tsmiSearch.Click += new System.EventHandler(this.tsmiSearch_Click);
            // 
            // деревоToolStripMenuItem
            // 
            this.деревоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExpand,
            this.tsmiCollapse});
            this.деревоToolStripMenuItem.Name = "деревоToolStripMenuItem";
            this.деревоToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.деревоToolStripMenuItem.Text = "Дерево";
            // 
            // tsmiExpand
            // 
            this.tsmiExpand.Name = "tsmiExpand";
            this.tsmiExpand.Size = new System.Drawing.Size(177, 22);
            this.tsmiExpand.Text = "Раскрыть все узлы";
            this.tsmiExpand.Click += new System.EventHandler(this.ExpandAllNodes_Click);
            // 
            // tsmiCollapse
            // 
            this.tsmiCollapse.Name = "tsmiCollapse";
            this.tsmiCollapse.Size = new System.Drawing.Size(177, 22);
            this.tsmiCollapse.Text = "Скрыть все узлы";
            this.tsmiCollapse.Click += new System.EventHandler(this.CollapseAllNodes_Click);
            // 
            // tsmiLogs
            // 
            this.tsmiLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiActionLogs});
            this.tsmiLogs.Name = "tsmiLogs";
            this.tsmiLogs.Size = new System.Drawing.Size(72, 20);
            this.tsmiLogs.Text = "Журналы";
            // 
            // tsmiActionLogs
            // 
            this.tsmiActionLogs.Name = "tsmiActionLogs";
            this.tsmiActionLogs.Size = new System.Drawing.Size(180, 22);
            this.tsmiActionLogs.Text = "Журнал действий...";
            this.tsmiActionLogs.Click += new System.EventHandler(this.tsmiActionLogs_Click);
            // 
            // организацияToolStripMenuItem
            // 
            this.организацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEmployees,
            this.tsmiSellers});
            this.организацияToolStripMenuItem.Name = "организацияToolStripMenuItem";
            this.организацияToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.организацияToolStripMenuItem.Text = "Организация";
            // 
            // tsmiEmployees
            // 
            this.tsmiEmployees.Name = "tsmiEmployees";
            this.tsmiEmployees.Size = new System.Drawing.Size(153, 22);
            this.tsmiEmployees.Text = "Сотрудники...";
            this.tsmiEmployees.Click += new System.EventHandler(this.tsmiEmployees_Click);
            // 
            // tsmiSellers
            // 
            this.tsmiSellers.Name = "tsmiSellers";
            this.tsmiSellers.Size = new System.Drawing.Size(153, 22);
            this.tsmiSellers.Text = "Поставщики...";
            this.tsmiSellers.Click += new System.EventHandler(this.tsmiSellers_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(79, 20);
            this.tsmiSettings.Text = "Настройки";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(65, 20);
            this.tsmiHelp.Text = "Справка";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(158, 22);
            this.tsmiAbout.Text = "О программе...";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Panel1.Controls.Add(this.tbSearch);
            this.splitContainer1.Panel1.Controls.Add(this.cbSerial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1444, 520);
            this.splitContainer1.SplitterDistance = 181;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.ContextMenuStrip = this.cmsMainCategory;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 37);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(181, 483);
            this.treeView.TabIndex = 2;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            // 
            // cmsMainCategory
            // 
            this.cmsMainCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddMainCategory,
            this.cmsExpandAllNodes,
            this.cmsCollapseAllNodes});
            this.cmsMainCategory.Name = "cmsCategory";
            this.cmsMainCategory.Size = new System.Drawing.Size(239, 70);
            // 
            // cmsAddMainCategory
            // 
            this.cmsAddMainCategory.Name = "cmsAddMainCategory";
            this.cmsAddMainCategory.Size = new System.Drawing.Size(238, 22);
            this.cmsAddMainCategory.Text = "Добавить главную категорию";
            this.cmsAddMainCategory.Click += new System.EventHandler(this.AddMainCategory_Click);
            // 
            // cmsExpandAllNodes
            // 
            this.cmsExpandAllNodes.Name = "cmsExpandAllNodes";
            this.cmsExpandAllNodes.Size = new System.Drawing.Size(238, 22);
            this.cmsExpandAllNodes.Text = "Раскрыть все узлы";
            this.cmsExpandAllNodes.Click += new System.EventHandler(this.ExpandAllNodes_Click);
            // 
            // cmsCollapseAllNodes
            // 
            this.cmsCollapseAllNodes.Name = "cmsCollapseAllNodes";
            this.cmsCollapseAllNodes.Size = new System.Drawing.Size(238, 22);
            this.cmsCollapseAllNodes.Text = "Скрыть все узлы";
            this.cmsCollapseAllNodes.Click += new System.EventHandler(this.CollapseAllNodes_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbSearch.Location = new System.Drawing.Point(0, 17);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(181, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // cbSerial
            // 
            this.cbSerial.AutoSize = true;
            this.cbSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSerial.Location = new System.Drawing.Point(0, 0);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbSerial.Size = new System.Drawing.Size(181, 17);
            this.cbSerial.TabIndex = 3;
            this.cbSerial.Text = "Серийный номер";
            this.cbSerial.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvItems);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1259, 520);
            this.splitContainer2.SplitterDistance = 319;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inventNumber,
            this.name,
            this.seller,
            this.purchasePrice,
            this.retailPrice,
            this.wholesalePrice,
            this.servicePrice,
            this.firmPrice,
            this.storage,
            this.quantity,
            this.uploadDate,
            this.changeDate,
            this.residue,
            this.status});
            this.dgvItems.ContextMenuStrip = this.cmsItem;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 30;
            this.dgvItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1259, 319);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditItem_Click);
            this.dgvItems.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgvItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyUp);
            this.dgvItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseMove);
            // 
            // inventNumber
            // 
            this.inventNumber.HeaderText = "Номер";
            this.inventNumber.Name = "inventNumber";
            this.inventNumber.ReadOnly = true;
            this.inventNumber.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 250;
            // 
            // seller
            // 
            this.seller.HeaderText = "Поставщик";
            this.seller.Name = "seller";
            this.seller.ReadOnly = true;
            this.seller.Width = 120;
            // 
            // purchasePrice
            // 
            this.purchasePrice.HeaderText = "Закупка";
            this.purchasePrice.Name = "purchasePrice";
            this.purchasePrice.ReadOnly = true;
            this.purchasePrice.Width = 80;
            // 
            // retailPrice
            // 
            this.retailPrice.HeaderText = "Розница";
            this.retailPrice.Name = "retailPrice";
            this.retailPrice.ReadOnly = true;
            this.retailPrice.Width = 80;
            // 
            // wholesalePrice
            // 
            this.wholesalePrice.HeaderText = "Мелкий опт";
            this.wholesalePrice.Name = "wholesalePrice";
            this.wholesalePrice.ReadOnly = true;
            this.wholesalePrice.Width = 50;
            // 
            // servicePrice
            // 
            this.servicePrice.HeaderText = "Сервисы";
            this.servicePrice.Name = "servicePrice";
            this.servicePrice.ReadOnly = true;
            this.servicePrice.Width = 70;
            // 
            // firmPrice
            // 
            this.firmPrice.HeaderText = "Цена фирмы";
            this.firmPrice.Name = "firmPrice";
            this.firmPrice.ReadOnly = true;
            this.firmPrice.Width = 50;
            // 
            // storage
            // 
            this.storage.HeaderText = "Хранение";
            this.storage.Name = "storage";
            this.storage.ReadOnly = true;
            this.storage.Width = 90;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 70;
            // 
            // uploadDate
            // 
            this.uploadDate.HeaderText = "Добавлен";
            this.uploadDate.Name = "uploadDate";
            this.uploadDate.ReadOnly = true;
            this.uploadDate.Width = 70;
            // 
            // changeDate
            // 
            this.changeDate.HeaderText = "Изменен";
            this.changeDate.Name = "changeDate";
            this.changeDate.ReadOnly = true;
            this.changeDate.Width = 70;
            // 
            // residue
            // 
            this.residue.HeaderText = "Остаток";
            this.residue.Name = "residue";
            this.residue.ReadOnly = true;
            this.residue.Width = 70;
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 90;
            // 
            // cmsItem
            // 
            this.cmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddItem,
            this.cmsEditItem,
            this.cmsDeleteItem});
            this.cmsItem.Name = "cmsItem";
            this.cmsItem.Size = new System.Drawing.Size(204, 70);
            // 
            // cmsAddItem
            // 
            this.cmsAddItem.Name = "cmsAddItem";
            this.cmsAddItem.Size = new System.Drawing.Size(203, 22);
            this.cmsAddItem.Text = "Добавить предмет";
            this.cmsAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // cmsEditItem
            // 
            this.cmsEditItem.Name = "cmsEditItem";
            this.cmsEditItem.Size = new System.Drawing.Size(203, 22);
            this.cmsEditItem.Text = "Редактировать предмет";
            this.cmsEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // cmsDeleteItem
            // 
            this.cmsDeleteItem.Name = "cmsDeleteItem";
            this.cmsDeleteItem.Size = new System.Drawing.Size(203, 22);
            this.cmsDeleteItem.Text = "Удалить предмет";
            this.cmsDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1259, 197);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWriteOffList);
            this.groupBox1.Controls.Add(this.lCategories);
            this.groupBox1.Controls.Add(this.lresidue);
            this.groupBox1.Controls.Add(this.lquantity);
            this.groupBox1.Controls.Add(this.lnote);
            this.groupBox1.Controls.Add(this.lstorage);
            this.groupBox1.Controls.Add(this.lfirm);
            this.groupBox1.Controls.Add(this.lservice);
            this.groupBox1.Controls.Add(this.lwhole);
            this.groupBox1.Controls.Add(this.lretail);
            this.groupBox1.Controls.Add(this.lpurchase);
            this.groupBox1.Controls.Add(this.lseller);
            this.groupBox1.Controls.Add(this.lname);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предмет";
            // 
            // lCategories
            // 
            this.lCategories.AutoSize = true;
            this.lCategories.Location = new System.Drawing.Point(12, 16);
            this.lCategories.Name = "lCategories";
            this.lCategories.Size = new System.Drawing.Size(60, 13);
            this.lCategories.TabIndex = 16;
            this.lCategories.Text = "Категории";
            // 
            // lresidue
            // 
            this.lresidue.AutoSize = true;
            this.lresidue.Location = new System.Drawing.Point(182, 68);
            this.lresidue.Name = "lresidue";
            this.lresidue.Size = new System.Drawing.Size(49, 13);
            this.lresidue.TabIndex = 15;
            this.lresidue.Text = "Остаток";
            // 
            // lquantity
            // 
            this.lquantity.AutoSize = true;
            this.lquantity.Location = new System.Drawing.Point(182, 55);
            this.lquantity.Name = "lquantity";
            this.lquantity.Size = new System.Drawing.Size(66, 13);
            this.lquantity.TabIndex = 14;
            this.lquantity.Text = "Количество";
            // 
            // lnote
            // 
            this.lnote.AutoSize = true;
            this.lnote.Location = new System.Drawing.Point(182, 116);
            this.lnote.MaximumSize = new System.Drawing.Size(150, 0);
            this.lnote.Name = "lnote";
            this.lnote.Size = new System.Drawing.Size(57, 13);
            this.lnote.TabIndex = 13;
            this.lnote.Text = "Описание";
            // 
            // lstorage
            // 
            this.lstorage.AutoSize = true;
            this.lstorage.Location = new System.Drawing.Point(183, 90);
            this.lstorage.MaximumSize = new System.Drawing.Size(150, 0);
            this.lstorage.Name = "lstorage";
            this.lstorage.Size = new System.Drawing.Size(56, 13);
            this.lstorage.TabIndex = 12;
            this.lstorage.Text = "Хранение";
            // 
            // lfirm
            // 
            this.lfirm.AutoSize = true;
            this.lfirm.Location = new System.Drawing.Point(12, 129);
            this.lfirm.Name = "lfirm";
            this.lfirm.Size = new System.Drawing.Size(72, 13);
            this.lfirm.TabIndex = 11;
            this.lfirm.Text = "Цена фирмы";
            // 
            // lservice
            // 
            this.lservice.AutoSize = true;
            this.lservice.Location = new System.Drawing.Point(12, 116);
            this.lservice.Name = "lservice";
            this.lservice.Size = new System.Drawing.Size(52, 13);
            this.lservice.TabIndex = 10;
            this.lservice.Text = "Сервисы";
            // 
            // lwhole
            // 
            this.lwhole.AutoSize = true;
            this.lwhole.Location = new System.Drawing.Point(12, 103);
            this.lwhole.Name = "lwhole";
            this.lwhole.Size = new System.Drawing.Size(66, 13);
            this.lwhole.TabIndex = 9;
            this.lwhole.Text = "Мелкий опт";
            // 
            // lretail
            // 
            this.lretail.AutoSize = true;
            this.lretail.Location = new System.Drawing.Point(12, 90);
            this.lretail.Name = "lretail";
            this.lretail.Size = new System.Drawing.Size(50, 13);
            this.lretail.TabIndex = 8;
            this.lretail.Text = "Розница";
            // 
            // lpurchase
            // 
            this.lpurchase.AutoSize = true;
            this.lpurchase.Location = new System.Drawing.Point(12, 77);
            this.lpurchase.Name = "lpurchase";
            this.lpurchase.Size = new System.Drawing.Size(49, 13);
            this.lpurchase.TabIndex = 7;
            this.lpurchase.Text = "Закупка";
            // 
            // lseller
            // 
            this.lseller.AutoSize = true;
            this.lseller.Location = new System.Drawing.Point(12, 55);
            this.lseller.Name = "lseller";
            this.lseller.Size = new System.Drawing.Size(65, 13);
            this.lseller.TabIndex = 6;
            this.lseller.Text = "Поставщик";
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.Location = new System.Drawing.Point(12, 42);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(57, 13);
            this.lname.TabIndex = 5;
            this.lname.Text = "Название";
            // 
            // btnWriteOffList
            // 
            this.btnWriteOffList.Location = new System.Drawing.Point(15, 154);
            this.btnWriteOffList.Name = "btnWriteOffList";
            this.btnWriteOffList.Size = new System.Drawing.Size(157, 28);
            this.btnWriteOffList.TabIndex = 0;
            this.btnWriteOffList.Text = "Списки списания предмета";
            this.btnWriteOffList.UseVisualStyleBackColor = true;
            this.btnWriteOffList.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadImage);
            this.groupBox2.Controls.Add(this.pbPreview);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(553, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фото";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(6, 19);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(242, 163);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Загрузить картинку";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // cmsCategory
            // 
            this.cmsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddSubCategory,
            this.cmsRenameCategory,
            this.cmsDeleteCategory,
            this.cmsExpandNode,
            this.cmsCollapseNode});
            this.cmsCategory.Name = "cmsCategory";
            this.cmsCategory.Size = new System.Drawing.Size(224, 114);
            // 
            // cmsAddSubCategory
            // 
            this.cmsAddSubCategory.Name = "cmsAddSubCategory";
            this.cmsAddSubCategory.Size = new System.Drawing.Size(223, 22);
            this.cmsAddSubCategory.Text = "Добавить подкатегорию";
            this.cmsAddSubCategory.Click += new System.EventHandler(this.AddSubCategory_Click);
            // 
            // cmsRenameCategory
            // 
            this.cmsRenameCategory.Name = "cmsRenameCategory";
            this.cmsRenameCategory.Size = new System.Drawing.Size(223, 22);
            this.cmsRenameCategory.Text = "Переименовать категорию";
            this.cmsRenameCategory.Click += new System.EventHandler(this.RenameCategory_Click);
            // 
            // cmsDeleteCategory
            // 
            this.cmsDeleteCategory.Name = "cmsDeleteCategory";
            this.cmsDeleteCategory.Size = new System.Drawing.Size(223, 22);
            this.cmsDeleteCategory.Text = "Удалить категорию";
            this.cmsDeleteCategory.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // cmsExpandNode
            // 
            this.cmsExpandNode.Name = "cmsExpandNode";
            this.cmsExpandNode.Size = new System.Drawing.Size(223, 22);
            this.cmsExpandNode.Text = "Раскрыть узел";
            this.cmsExpandNode.Click += new System.EventHandler(this.cmsExpandNode_Click);
            // 
            // cmsCollapseNode
            // 
            this.cmsCollapseNode.Name = "cmsCollapseNode";
            this.cmsCollapseNode.Size = new System.Drawing.Size(223, 22);
            this.cmsCollapseNode.Text = "Скрыть узел";
            this.cmsCollapseNode.Click += new System.EventHandler(this.cmsCollapseNode_Click);
            // 
            // cmsWriteOff
            // 
            this.cmsWriteOff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSelling,
            this.cmsDefect,
            this.cmsInOrder});
            this.cmsWriteOff.Name = "cmsItem";
            this.cmsWriteOff.Size = new System.Drawing.Size(133, 70);
            // 
            // cmsSelling
            // 
            this.cmsSelling.Name = "cmsSelling";
            this.cmsSelling.Size = new System.Drawing.Size(132, 22);
            this.cmsSelling.Text = "В продажу";
            this.cmsSelling.Click += new System.EventHandler(this.cmsSelling_Click);
            // 
            // cmsDefect
            // 
            this.cmsDefect.Name = "cmsDefect";
            this.cmsDefect.Size = new System.Drawing.Size(132, 22);
            this.cmsDefect.Text = "В брак";
            this.cmsDefect.Click += new System.EventHandler(this.cmsDefect_Click);
            // 
            // cmsInOrder
            // 
            this.cmsInOrder.Name = "cmsInOrder";
            this.cmsInOrder.Size = new System.Drawing.Size(132, 22);
            this.cmsInOrder.Text = "В заказ";
            this.cmsInOrder.Click += new System.EventHandler(this.cmsInOrder_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(3, 16);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(248, 169);
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База запчастей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsMainCategory.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.cmsItem.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.cmsCategory.ResumeLayout(false);
            this.cmsWriteOff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip cmsCategory;
        private System.Windows.Forms.ToolStripMenuItem cmsAddSubCategory;
        private System.Windows.Forms.ToolStripMenuItem cmsRenameCategory;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteCategory;
        private System.Windows.Forms.ContextMenuStrip cmsItem;
        private System.Windows.Forms.ToolStripMenuItem cmsAddItem;
        private System.Windows.Forms.ToolStripMenuItem cmsEditItem;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddMainCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSubCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCategory;
        private System.Windows.Forms.ToolStripMenuItem предметыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem деревоToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMainCategory;
        private System.Windows.Forms.ToolStripMenuItem cmsAddMainCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiExpand;
        private System.Windows.Forms.ToolStripMenuItem tsmiCollapse;
        private System.Windows.Forms.ToolStripMenuItem cmsExpandNode;
        private System.Windows.Forms.ToolStripMenuItem cmsCollapseNode;
        private System.Windows.Forms.ToolStripMenuItem cmsExpandAllNodes;
        private System.Windows.Forms.ToolStripMenuItem cmsCollapseAllNodes;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lquantity;
        private System.Windows.Forms.Label lnote;
        private System.Windows.Forms.Label lstorage;
        private System.Windows.Forms.Label lfirm;
        private System.Windows.Forms.Label lservice;
        private System.Windows.Forms.Label lwhole;
        private System.Windows.Forms.Label lretail;
        private System.Windows.Forms.Label lpurchase;
        private System.Windows.Forms.Label lseller;
        private System.Windows.Forms.Label lname;
        private System.Windows.Forms.Label lresidue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogs;
        private System.Windows.Forms.ToolStripMenuItem tsmiActionLogs;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem организацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployees;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiSellers;
        private System.Windows.Forms.Label lCategories;
        private ItemsDataGridView dgvItems;
        private CategoriesTreeView treeView;
        private System.Windows.Forms.ContextMenuStrip cmsWriteOff;
        private System.Windows.Forms.ToolStripMenuItem cmsSelling;
        private System.Windows.Forms.ToolStripMenuItem cmsDefect;
        private System.Windows.Forms.ToolStripMenuItem cmsInOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountInfo;
        private System.Windows.Forms.CheckBox cbSerial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn seller;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholesalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn residue;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnWriteOffList;
    }
}