namespace SparesBaseAdministrator
{
    partial class ItemsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddMainCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSubCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZeroResidueItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new SparesBaseAdministrator.CategoriesTreeView();
            this.cmsMainCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddMainCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExpandAllNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCollapseAllNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbOrganizations = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv = new SparesBaseAdministrator.ItemsDataGridView();
            this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lSubCategory4 = new System.Windows.Forms.Label();
            this.lSubCategory3 = new System.Windows.Forms.Label();
            this.lSubCategory2 = new System.Windows.Forms.Label();
            this.lSubCategory1 = new System.Windows.Forms.Label();
            this.lMainCategory = new System.Windows.Forms.Label();
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
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddSubCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRenameCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExpandNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCollapseNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSerial = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cmsItem.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.категорииToolStripMenuItem,
            this.предметыToolStripMenuItem,
            this.деревоToolStripMenuItem,
            this.tsmiDisplay});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1354, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
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
            this.tsmiAddMainCategory.Size = new System.Drawing.Size(238, 22);
            this.tsmiAddMainCategory.Text = "Добавить главную категорию";
            this.tsmiAddMainCategory.Click += new System.EventHandler(this.AddMainCategory_Click);
            // 
            // tsmiAddSubCategory
            // 
            this.tsmiAddSubCategory.Name = "tsmiAddSubCategory";
            this.tsmiAddSubCategory.Size = new System.Drawing.Size(238, 22);
            this.tsmiAddSubCategory.Text = "Добавить подкатегорию";
            this.tsmiAddSubCategory.Click += new System.EventHandler(this.AddSubCategory_Click);
            // 
            // tsmiRenameCategory
            // 
            this.tsmiRenameCategory.Name = "tsmiRenameCategory";
            this.tsmiRenameCategory.Size = new System.Drawing.Size(238, 22);
            this.tsmiRenameCategory.Text = "Переименовать категорию";
            this.tsmiRenameCategory.Click += new System.EventHandler(this.RenameCategory_Click);
            // 
            // tsmiDeleteCategory
            // 
            this.tsmiDeleteCategory.Name = "tsmiDeleteCategory";
            this.tsmiDeleteCategory.Size = new System.Drawing.Size(238, 22);
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
            this.tsmiAddItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiAddItem.Text = "Добавить предмет";
            this.tsmiAddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tsmiEditItem
            // 
            this.tsmiEditItem.Name = "tsmiEditItem";
            this.tsmiEditItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiEditItem.Text = "Редактировать предмет";
            this.tsmiEditItem.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // tsmiDeleteItem
            // 
            this.tsmiDeleteItem.Name = "tsmiDeleteItem";
            this.tsmiDeleteItem.Size = new System.Drawing.Size(203, 22);
            this.tsmiDeleteItem.Text = "Удалить предмет";
            this.tsmiDeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
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
            // tsmiDisplay
            // 
            this.tsmiDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiZeroResidueItems,
            this.tsmiDeletedItems});
            this.tsmiDisplay.Name = "tsmiDisplay";
            this.tsmiDisplay.Size = new System.Drawing.Size(95, 20);
            this.tsmiDisplay.Text = "Отображение";
            // 
            // tsmiZeroResidueItems
            // 
            this.tsmiZeroResidueItems.Checked = true;
            this.tsmiZeroResidueItems.CheckOnClick = true;
            this.tsmiZeroResidueItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiZeroResidueItems.Name = "tsmiZeroResidueItems";
            this.tsmiZeroResidueItems.Size = new System.Drawing.Size(203, 22);
            this.tsmiZeroResidueItems.Text = "Предметы с остатком 0";
            this.tsmiZeroResidueItems.Click += new System.EventHandler(this.tsmiZeroResidueItems_Click);
            // 
            // tsmiDeletedItems
            // 
            this.tsmiDeletedItems.Checked = true;
            this.tsmiDeletedItems.CheckOnClick = true;
            this.tsmiDeletedItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDeletedItems.Name = "tsmiDeletedItems";
            this.tsmiDeletedItems.Size = new System.Drawing.Size(203, 22);
            this.tsmiDeletedItems.Text = "Удаленные предметы";
            this.tsmiDeletedItems.Click += new System.EventHandler(this.tsmiDeletedItems_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.cbOrganizations);
            this.splitContainer1.Panel1.Controls.Add(this.cbSerial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1354, 518);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.ContextMenuStrip = this.cmsMainCategory;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 58);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(170, 460);
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
            this.tbSearch.Location = new System.Drawing.Point(0, 38);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(170, 20);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // cbOrganizations
            // 
            this.cbOrganizations.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbOrganizations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrganizations.FormattingEnabled = true;
            this.cbOrganizations.Location = new System.Drawing.Point(0, 17);
            this.cbOrganizations.Name = "cbOrganizations";
            this.cbOrganizations.Size = new System.Drawing.Size(170, 21);
            this.cbOrganizations.TabIndex = 3;
            this.cbOrganizations.SelectedIndexChanged += new System.EventHandler(this.cbOrganizations_SelectedIndexChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1180, 518);
            this.splitContainer2.SplitterDistance = 317;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.cmsItem;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1180, 317);
            this.dgv.TabIndex = 2;
            this.dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EditItem_Click);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            this.dgv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseMove);
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1180, 197);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lSubCategory4);
            this.groupBox1.Controls.Add(this.lSubCategory3);
            this.groupBox1.Controls.Add(this.lSubCategory2);
            this.groupBox1.Controls.Add(this.lSubCategory1);
            this.groupBox1.Controls.Add(this.lMainCategory);
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
            this.groupBox1.Size = new System.Drawing.Size(679, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предмет";
            // 
            // lSubCategory4
            // 
            this.lSubCategory4.AutoSize = true;
            this.lSubCategory4.Location = new System.Drawing.Point(22, 78);
            this.lSubCategory4.Name = "lSubCategory4";
            this.lSubCategory4.Size = new System.Drawing.Size(91, 13);
            this.lSubCategory4.TabIndex = 20;
            this.lSubCategory4.Text = "Подкатегория 4:";
            // 
            // lSubCategory3
            // 
            this.lSubCategory3.AutoSize = true;
            this.lSubCategory3.Location = new System.Drawing.Point(22, 65);
            this.lSubCategory3.Name = "lSubCategory3";
            this.lSubCategory3.Size = new System.Drawing.Size(91, 13);
            this.lSubCategory3.TabIndex = 19;
            this.lSubCategory3.Text = "Подкатегория 3:";
            // 
            // lSubCategory2
            // 
            this.lSubCategory2.AutoSize = true;
            this.lSubCategory2.Location = new System.Drawing.Point(22, 52);
            this.lSubCategory2.Name = "lSubCategory2";
            this.lSubCategory2.Size = new System.Drawing.Size(91, 13);
            this.lSubCategory2.TabIndex = 18;
            this.lSubCategory2.Text = "Подкатегория 2:";
            // 
            // lSubCategory1
            // 
            this.lSubCategory1.AutoSize = true;
            this.lSubCategory1.Location = new System.Drawing.Point(22, 39);
            this.lSubCategory1.Name = "lSubCategory1";
            this.lSubCategory1.Size = new System.Drawing.Size(91, 13);
            this.lSubCategory1.TabIndex = 17;
            this.lSubCategory1.Text = "Подкатегория 1:";
            // 
            // lMainCategory
            // 
            this.lMainCategory.AutoSize = true;
            this.lMainCategory.Location = new System.Drawing.Point(22, 26);
            this.lMainCategory.Name = "lMainCategory";
            this.lMainCategory.Size = new System.Drawing.Size(107, 13);
            this.lMainCategory.TabIndex = 16;
            this.lMainCategory.Text = "Главная категория:";
            // 
            // lresidue
            // 
            this.lresidue.AutoSize = true;
            this.lresidue.Location = new System.Drawing.Point(509, 39);
            this.lresidue.Name = "lresidue";
            this.lresidue.Size = new System.Drawing.Size(49, 13);
            this.lresidue.TabIndex = 15;
            this.lresidue.Text = "Остаток";
            // 
            // lquantity
            // 
            this.lquantity.AutoSize = true;
            this.lquantity.Location = new System.Drawing.Point(509, 26);
            this.lquantity.Name = "lquantity";
            this.lquantity.Size = new System.Drawing.Size(66, 13);
            this.lquantity.TabIndex = 14;
            this.lquantity.Text = "Количество";
            // 
            // lnote
            // 
            this.lnote.AutoSize = true;
            this.lnote.Location = new System.Drawing.Point(509, 100);
            this.lnote.MaximumSize = new System.Drawing.Size(150, 0);
            this.lnote.Name = "lnote";
            this.lnote.Size = new System.Drawing.Size(57, 13);
            this.lnote.TabIndex = 13;
            this.lnote.Text = "Описание";
            // 
            // lstorage
            // 
            this.lstorage.AutoSize = true;
            this.lstorage.Location = new System.Drawing.Point(510, 61);
            this.lstorage.MaximumSize = new System.Drawing.Size(150, 0);
            this.lstorage.Name = "lstorage";
            this.lstorage.Size = new System.Drawing.Size(56, 13);
            this.lstorage.TabIndex = 12;
            this.lstorage.Text = "Хранение";
            // 
            // lfirm
            // 
            this.lfirm.AutoSize = true;
            this.lfirm.Location = new System.Drawing.Point(289, 113);
            this.lfirm.Name = "lfirm";
            this.lfirm.Size = new System.Drawing.Size(72, 13);
            this.lfirm.TabIndex = 11;
            this.lfirm.Text = "Цена фирмы";
            // 
            // lservice
            // 
            this.lservice.AutoSize = true;
            this.lservice.Location = new System.Drawing.Point(289, 100);
            this.lservice.Name = "lservice";
            this.lservice.Size = new System.Drawing.Size(52, 13);
            this.lservice.TabIndex = 10;
            this.lservice.Text = "Сервисы";
            // 
            // lwhole
            // 
            this.lwhole.AutoSize = true;
            this.lwhole.Location = new System.Drawing.Point(289, 87);
            this.lwhole.Name = "lwhole";
            this.lwhole.Size = new System.Drawing.Size(66, 13);
            this.lwhole.TabIndex = 9;
            this.lwhole.Text = "Мелкий опт";
            // 
            // lretail
            // 
            this.lretail.AutoSize = true;
            this.lretail.Location = new System.Drawing.Point(289, 74);
            this.lretail.Name = "lretail";
            this.lretail.Size = new System.Drawing.Size(50, 13);
            this.lretail.TabIndex = 8;
            this.lretail.Text = "Розница";
            // 
            // lpurchase
            // 
            this.lpurchase.AutoSize = true;
            this.lpurchase.Location = new System.Drawing.Point(289, 61);
            this.lpurchase.Name = "lpurchase";
            this.lpurchase.Size = new System.Drawing.Size(49, 13);
            this.lpurchase.TabIndex = 7;
            this.lpurchase.Text = "Закупка";
            // 
            // lseller
            // 
            this.lseller.AutoSize = true;
            this.lseller.Location = new System.Drawing.Point(289, 39);
            this.lseller.Name = "lseller";
            this.lseller.Size = new System.Drawing.Size(65, 13);
            this.lseller.TabIndex = 6;
            this.lseller.Text = "Поставщик";
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.Location = new System.Drawing.Point(289, 26);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(57, 13);
            this.lname.TabIndex = 5;
            this.lname.Text = "Название";
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
            // cbSerial
            // 
            this.cbSerial.AutoSize = true;
            this.cbSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSerial.Location = new System.Drawing.Point(0, 0);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(170, 17);
            this.cbSerial.TabIndex = 4;
            this.cbSerial.Text = "Серийный номер";
            this.cbSerial.UseVisualStyleBackColor = true;
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 542);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Предметы";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cmsItem.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmsCategory.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbOrganizations;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmiZeroResidueItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletedItems;
        private System.Windows.Forms.Label lSubCategory4;
        private System.Windows.Forms.Label lSubCategory3;
        private System.Windows.Forms.Label lSubCategory2;
        private System.Windows.Forms.Label lSubCategory1;
        private System.Windows.Forms.Label lMainCategory;
        private CategoriesTreeView treeView;
        private ItemsDataGridView dgv;
        private System.Windows.Forms.CheckBox cbSerial;
    }
}