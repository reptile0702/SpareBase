namespace SparesBase
{
    partial class SearchingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchingForm));
            this.tbSearching = new System.Windows.Forms.TextBox();
            this.cbСities = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lPhoneSC = new System.Windows.Forms.Label();
            this.lNameSC = new System.Windows.Forms.Label();
            this.cbSearchByOrganization = new System.Windows.Forms.CheckBox();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv = new SparesBase.ItemsDataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.loadBannersDelay = new System.Windows.Forms.Timer(this.components);
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearching
            // 
            this.tbSearching.Location = new System.Drawing.Point(15, 25);
            this.tbSearching.Name = "tbSearching";
            this.tbSearching.Size = new System.Drawing.Size(150, 20);
            this.tbSearching.TabIndex = 0;
            this.tbSearching.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearching_KeyDown);
            // 
            // cbСities
            // 
            this.cbСities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbСities.FormattingEnabled = true;
            this.cbСities.Location = new System.Drawing.Point(15, 64);
            this.cbСities.Name = "cbСities";
            this.cbСities.Size = new System.Drawing.Size(150, 21);
            this.cbСities.TabIndex = 2;
            this.cbСities.SelectedIndexChanged += new System.EventHandler(this.cbOrganizations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поиск по имени и описанию";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadImage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pbPreview);
            this.panel1.Controls.Add(this.lPhoneSC);
            this.panel1.Controls.Add(this.lNameSC);
            this.panel1.Controls.Add(this.cbSearchByOrganization);
            this.panel1.Controls.Add(this.pbBanner);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbSearching);
            this.panel1.Controls.Add(this.cbСities);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 602);
            this.panel1.TabIndex = 5;
            // 
            // lPhoneSC
            // 
            this.lPhoneSC.AutoSize = true;
            this.lPhoneSC.Location = new System.Drawing.Point(12, 143);
            this.lPhoneSC.Name = "lPhoneSC";
            this.lPhoneSC.Size = new System.Drawing.Size(73, 13);
            this.lPhoneSC.TabIndex = 9;
            this.lPhoneSC.Text = "Телефон СЦ:";
            // 
            // lNameSC
            // 
            this.lNameSC.AutoSize = true;
            this.lNameSC.Location = new System.Drawing.Point(12, 114);
            this.lNameSC.Name = "lNameSC";
            this.lNameSC.Size = new System.Drawing.Size(78, 13);
            this.lNameSC.TabIndex = 8;
            this.lNameSC.Text = "Название СЦ:";
            // 
            // cbSearchByOrganization
            // 
            this.cbSearchByOrganization.AutoSize = true;
            this.cbSearchByOrganization.Location = new System.Drawing.Point(15, 92);
            this.cbSearchByOrganization.Name = "cbSearchByOrganization";
            this.cbSearchByOrganization.Size = new System.Drawing.Size(141, 17);
            this.cbSearchByOrganization.TabIndex = 7;
            this.cbSearchByOrganization.Text = "Поиск по организации";
            this.cbSearchByOrganization.UseVisualStyleBackColor = true;
            this.cbSearchByOrganization.CheckedChanged += new System.EventHandler(this.cbSearchByOrganization_CheckedChanged);
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(15, 340);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(150, 250);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBanner.TabIndex = 6;
            this.pbBanner.TabStop = false;
            this.pbBanner.Click += new System.EventHandler(this.pbBanner_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Город организации";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.retail,
            this.service,
            this.quantity,
            this.addDate,
            this.changeDate});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(184, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(747, 602);
            this.dgv.TabIndex = 6;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDoubleClick);
            // 
            // name
            // 
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // retail
            // 
            this.retail.HeaderText = "Розница";
            this.retail.Name = "retail";
            this.retail.ReadOnly = true;
            this.retail.Width = 80;
            // 
            // service
            // 
            this.service.HeaderText = "Сервисы";
            this.service.Name = "service";
            this.service.ReadOnly = true;
            this.service.Width = 80;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 80;
            // 
            // addDate
            // 
            this.addDate.HeaderText = "Дата добавления";
            this.addDate.Name = "addDate";
            this.addDate.ReadOnly = true;
            this.addDate.Width = 130;
            // 
            // changeDate
            // 
            this.changeDate.HeaderText = "Дата изменения";
            this.changeDate.Name = "changeDate";
            this.changeDate.ReadOnly = true;
            this.changeDate.Width = 130;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // loadBannersDelay
            // 
            this.loadBannersDelay.Interval = 3000;
            this.loadBannersDelay.Tick += new System.EventHandler(this.loadBannersDelay_Tick);
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(15, 194);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(150, 140);
            this.pbPreview.TabIndex = 10;
            this.pbPreview.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Фото";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(15, 194);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(150, 140);
            this.btnLoadImage.TabIndex = 12;
            this.btnLoadImage.Text = "Загрузить\r\n фотографию";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // SearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 602);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск предметов по организациям";
            this.Load += new System.EventHandler(this.SearchingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearching;
        private System.Windows.Forms.ComboBox cbСities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private ItemsDataGridView dgv;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer loadBannersDelay;
        private System.Windows.Forms.Label lPhoneSC;
        private System.Windows.Forms.Label lNameSC;
        private System.Windows.Forms.CheckBox cbSearchByOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn retail;
        private System.Windows.Forms.DataGridViewTextBoxColumn service;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn addDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnLoadImage;
    }
}