namespace SparesBaseAdministrator
{
    partial class EditForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbPurchasePrice = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbRetailPrice = new System.Windows.Forms.TextBox();
            this.tbWholesalePrice = new System.Windows.Forms.TextBox();
            this.tbStorage = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbServicePrice = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.chbSearchAllowed = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFirmPrice = new System.Windows.Forms.TextBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnInOrder = new System.Windows.Forms.Button();
            this.btnDefect = new System.Windows.Forms.Button();
            this.cbSeller = new System.Windows.Forms.ComboBox();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.btnChangeCategories = new System.Windows.Forms.Button();
            this.lMainCategory = new System.Windows.Forms.Label();
            this.lSubCategory1 = new System.Windows.Forms.Label();
            this.lSubCategory2 = new System.Windows.Forms.Label();
            this.lSubCategory3 = new System.Windows.Forms.Label();
            this.lSubCategory4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.photoPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(111, 30);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(169, 20);
            this.tbItemName.TabIndex = 0;
            // 
            // tbPurchasePrice
            // 
            this.tbPurchasePrice.Location = new System.Drawing.Point(111, 56);
            this.tbPurchasePrice.Name = "tbPurchasePrice";
            this.tbPurchasePrice.Size = new System.Drawing.Size(169, 20);
            this.tbPurchasePrice.TabIndex = 2;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(403, 59);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(248, 20);
            this.tbQuantity.TabIndex = 3;
            // 
            // tbRetailPrice
            // 
            this.tbRetailPrice.Location = new System.Drawing.Point(111, 87);
            this.tbRetailPrice.Name = "tbRetailPrice";
            this.tbRetailPrice.Size = new System.Drawing.Size(83, 20);
            this.tbRetailPrice.TabIndex = 4;
            // 
            // tbWholesalePrice
            // 
            this.tbWholesalePrice.Location = new System.Drawing.Point(269, 87);
            this.tbWholesalePrice.Name = "tbWholesalePrice";
            this.tbWholesalePrice.Size = new System.Drawing.Size(83, 20);
            this.tbWholesalePrice.TabIndex = 5;
            // 
            // tbStorage
            // 
            this.tbStorage.Location = new System.Drawing.Point(111, 116);
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(540, 20);
            this.tbStorage.TabIndex = 8;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(111, 142);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(540, 103);
            this.tbNote.TabIndex = 9;
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto.Location = new System.Drawing.Point(0, 13);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(255, 424);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 14;
            this.pbPhoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Закупка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Розница";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Хранение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Примечание";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Мелкий опт";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Количество";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Поставщик";
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(255, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Фото";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPhoto.Location = new System.Drawing.Point(0, 437);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(255, 23);
            this.btnPhoto.TabIndex = 14;
            this.btnPhoto.Text = "Просмотр фотографий";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Сервисы";
            // 
            // tbServicePrice
            // 
            this.tbServicePrice.Location = new System.Drawing.Point(417, 87);
            this.tbServicePrice.Name = "tbServicePrice";
            this.tbServicePrice.Size = new System.Drawing.Size(83, 20);
            this.tbServicePrice.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 449);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(669, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "ДОБАВИТЬ / ИЗМЕНИТЬ";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chbSearchAllowed
            // 
            this.chbSearchAllowed.AutoSize = true;
            this.chbSearchAllowed.Location = new System.Drawing.Point(542, 251);
            this.chbSearchAllowed.Name = "chbSearchAllowed";
            this.chbSearchAllowed.Size = new System.Drawing.Size(110, 17);
            this.chbSearchAllowed.TabIndex = 32;
            this.chbSearchAllowed.Text = "Разрешён поиск";
            this.chbSearchAllowed.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(519, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 26);
            this.label11.TabIndex = 32;
            this.label11.Text = "Цена\r\nфирмы\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFirmPrice
            // 
            this.tbFirmPrice.Location = new System.Drawing.Point(568, 87);
            this.tbFirmPrice.Name = "tbFirmPrice";
            this.tbFirmPrice.Size = new System.Drawing.Size(83, 20);
            this.tbFirmPrice.TabIndex = 7;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(366, 48);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(315, 23);
            this.btnSell.TabIndex = 10;
            this.btnSell.Text = "Продажа";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnInOrder
            // 
            this.btnInOrder.Location = new System.Drawing.Point(366, 107);
            this.btnInOrder.Name = "btnInOrder";
            this.btnInOrder.Size = new System.Drawing.Size(315, 23);
            this.btnInOrder.TabIndex = 12;
            this.btnInOrder.Text = "В заказ";
            this.btnInOrder.UseVisualStyleBackColor = true;
            this.btnInOrder.Click += new System.EventHandler(this.btnInOrder_Click);
            // 
            // btnDefect
            // 
            this.btnDefect.Location = new System.Drawing.Point(366, 77);
            this.btnDefect.Name = "btnDefect";
            this.btnDefect.Size = new System.Drawing.Size(315, 23);
            this.btnDefect.TabIndex = 11;
            this.btnDefect.Text = "Брак";
            this.btnDefect.UseVisualStyleBackColor = true;
            this.btnDefect.Click += new System.EventHandler(this.btnDefect_Click);
            // 
            // cbSeller
            // 
            this.cbSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeller.FormattingEnabled = true;
            this.cbSeller.Location = new System.Drawing.Point(404, 30);
            this.cbSeller.Name = "cbSeller";
            this.cbSeller.Size = new System.Drawing.Size(248, 21);
            this.cbSeller.TabIndex = 1;
            this.cbSeller.DropDown += new System.EventHandler(this.cbSeller_DropDown);
            this.cbSeller.SelectedIndexChanged += new System.EventHandler(this.cbSeller_SelectedIndexChanged);
            // 
            // photoPanel
            // 
            this.photoPanel.Controls.Add(this.pbPhoto);
            this.photoPanel.Controls.Add(this.btnPhoto);
            this.photoPanel.Controls.Add(this.label9);
            this.photoPanel.Location = new System.Drawing.Point(687, 12);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(255, 460);
            this.photoPanel.TabIndex = 33;
            // 
            // btnChangeCategories
            // 
            this.btnChangeCategories.Location = new System.Drawing.Point(21, 105);
            this.btnChangeCategories.Name = "btnChangeCategories";
            this.btnChangeCategories.Size = new System.Drawing.Size(306, 23);
            this.btnChangeCategories.TabIndex = 34;
            this.btnChangeCategories.Text = "Поменять категории";
            this.btnChangeCategories.UseVisualStyleBackColor = true;
            this.btnChangeCategories.Click += new System.EventHandler(this.btnChangeCategories_Click);
            // 
            // lMainCategory
            // 
            this.lMainCategory.AutoSize = true;
            this.lMainCategory.Location = new System.Drawing.Point(18, 25);
            this.lMainCategory.Name = "lMainCategory";
            this.lMainCategory.Size = new System.Drawing.Size(104, 13);
            this.lMainCategory.TabIndex = 35;
            this.lMainCategory.Text = "Главная категория";
            // 
            // lSubCategory1
            // 
            this.lSubCategory1.AutoSize = true;
            this.lSubCategory1.Location = new System.Drawing.Point(18, 38);
            this.lSubCategory1.Name = "lSubCategory1";
            this.lSubCategory1.Size = new System.Drawing.Size(88, 13);
            this.lSubCategory1.TabIndex = 36;
            this.lSubCategory1.Text = "Подкатегория 1";
            // 
            // lSubCategory2
            // 
            this.lSubCategory2.AutoSize = true;
            this.lSubCategory2.Location = new System.Drawing.Point(18, 51);
            this.lSubCategory2.Name = "lSubCategory2";
            this.lSubCategory2.Size = new System.Drawing.Size(88, 13);
            this.lSubCategory2.TabIndex = 37;
            this.lSubCategory2.Text = "Подкатегория 2";
            // 
            // lSubCategory3
            // 
            this.lSubCategory3.AutoSize = true;
            this.lSubCategory3.Location = new System.Drawing.Point(18, 64);
            this.lSubCategory3.Name = "lSubCategory3";
            this.lSubCategory3.Size = new System.Drawing.Size(88, 13);
            this.lSubCategory3.TabIndex = 38;
            this.lSubCategory3.Text = "Подкатегория 3";
            // 
            // lSubCategory4
            // 
            this.lSubCategory4.AutoSize = true;
            this.lSubCategory4.Location = new System.Drawing.Point(18, 77);
            this.lSubCategory4.Name = "lSubCategory4";
            this.lSubCategory4.Size = new System.Drawing.Size(88, 13);
            this.lSubCategory4.TabIndex = 39;
            this.lSubCategory4.Text = "Подкатегория 4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSeller);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbQuantity);
            this.groupBox1.Controls.Add(this.tbNote);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbRetailPrice);
            this.groupBox1.Controls.Add(this.chbSearchAllowed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbServicePrice);
            this.groupBox1.Controls.Add(this.tbWholesalePrice);
            this.groupBox1.Controls.Add(this.tbFirmPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbStorage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPurchasePrice);
            this.groupBox1.Controls.Add(this.tbItemName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 278);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о предмете";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lMainCategory);
            this.groupBox2.Controls.Add(this.lSubCategory1);
            this.groupBox2.Controls.Add(this.btnChangeCategories);
            this.groupBox2.Controls.Add(this.lSubCategory4);
            this.groupBox2.Controls.Add(this.lSubCategory2);
            this.groupBox2.Controls.Add(this.lSubCategory3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 147);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Категории";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Чо то еще";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.photoPanel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnInOrder);
            this.Controls.Add(this.btnDefect);
            this.Controls.Add(this.btnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ДОБАВИТЬ / ИЗМЕНИТЬ ПРЕДМЕТ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.photoPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbPurchasePrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbRetailPrice;
        private System.Windows.Forms.TextBox tbWholesalePrice;
        private System.Windows.Forms.TextBox tbStorage;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbServicePrice;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbSeller;
        private System.Windows.Forms.Button btnInOrder;
        private System.Windows.Forms.Button btnDefect;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFirmPrice;
        private System.Windows.Forms.CheckBox chbSearchAllowed;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.Button btnChangeCategories;
        private System.Windows.Forms.Label lMainCategory;
        private System.Windows.Forms.Label lSubCategory1;
        private System.Windows.Forms.Label lSubCategory2;
        private System.Windows.Forms.Label lSubCategory3;
        private System.Windows.Forms.Label lSubCategory4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

