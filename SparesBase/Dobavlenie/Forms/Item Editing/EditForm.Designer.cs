﻿namespace SparesBase
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
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.photoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(101, 16);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(169, 20);
            this.tbItemName.TabIndex = 0;
            // 
            // tbPurchasePrice
            // 
            this.tbPurchasePrice.Location = new System.Drawing.Point(101, 42);
            this.tbPurchasePrice.Name = "tbPurchasePrice";
            this.tbPurchasePrice.Size = new System.Drawing.Size(169, 20);
            this.tbPurchasePrice.TabIndex = 2;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(393, 45);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(248, 20);
            this.tbQuantity.TabIndex = 3;
            // 
            // tbRetailPrice
            // 
            this.tbRetailPrice.Location = new System.Drawing.Point(101, 73);
            this.tbRetailPrice.Name = "tbRetailPrice";
            this.tbRetailPrice.Size = new System.Drawing.Size(83, 20);
            this.tbRetailPrice.TabIndex = 4;
            // 
            // tbWholesalePrice
            // 
            this.tbWholesalePrice.Location = new System.Drawing.Point(259, 73);
            this.tbWholesalePrice.Name = "tbWholesalePrice";
            this.tbWholesalePrice.Size = new System.Drawing.Size(83, 20);
            this.tbWholesalePrice.TabIndex = 5;
            // 
            // tbStorage
            // 
            this.tbStorage.Location = new System.Drawing.Point(101, 102);
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(540, 20);
            this.tbStorage.TabIndex = 8;
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(101, 128);
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
            this.pbPhoto.Size = new System.Drawing.Size(225, 259);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 14;
            this.pbPhoto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Закупка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Розница";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Хранение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Примечание";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Мелкий опт";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Количество";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 19);
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
            this.label9.Size = new System.Drawing.Size(225, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Фото";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPhoto
            // 
            this.btnPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPhoto.Location = new System.Drawing.Point(0, 272);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(225, 23);
            this.btnPhoto.TabIndex = 14;
            this.btnPhoto.Text = "Просмотр фотографий";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(349, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Сервисы";
            // 
            // tbServicePrice
            // 
            this.tbServicePrice.Location = new System.Drawing.Point(407, 73);
            this.tbServicePrice.Name = "tbServicePrice";
            this.tbServicePrice.Size = new System.Drawing.Size(83, 20);
            this.tbServicePrice.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(101, 288);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(540, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "ДОБАВИТЬ / ИЗМЕНИТЬ";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chbSearchAllowed
            // 
            this.chbSearchAllowed.AutoSize = true;
            this.chbSearchAllowed.Location = new System.Drawing.Point(532, 237);
            this.chbSearchAllowed.Name = "chbSearchAllowed";
            this.chbSearchAllowed.Size = new System.Drawing.Size(110, 17);
            this.chbSearchAllowed.TabIndex = 32;
            this.chbSearchAllowed.Text = "Разрешён поиск";
            this.chbSearchAllowed.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(509, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 26);
            this.label11.TabIndex = 32;
            this.label11.Text = "Цена\r\nфирмы\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFirmPrice
            // 
            this.tbFirmPrice.Location = new System.Drawing.Point(558, 73);
            this.tbFirmPrice.Name = "tbFirmPrice";
            this.tbFirmPrice.Size = new System.Drawing.Size(83, 20);
            this.tbFirmPrice.TabIndex = 7;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(101, 260);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(176, 23);
            this.btnSell.TabIndex = 10;
            this.btnSell.Text = "Продажа";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnInOrder
            // 
            this.btnInOrder.Location = new System.Drawing.Point(465, 260);
            this.btnInOrder.Name = "btnInOrder";
            this.btnInOrder.Size = new System.Drawing.Size(176, 23);
            this.btnInOrder.TabIndex = 12;
            this.btnInOrder.Text = "В заказ";
            this.btnInOrder.UseVisualStyleBackColor = true;
            this.btnInOrder.Click += new System.EventHandler(this.btnInOrder_Click);
            // 
            // btnDefect
            // 
            this.btnDefect.Location = new System.Drawing.Point(283, 260);
            this.btnDefect.Name = "btnDefect";
            this.btnDefect.Size = new System.Drawing.Size(176, 23);
            this.btnDefect.TabIndex = 11;
            this.btnDefect.Text = "Брак";
            this.btnDefect.UseVisualStyleBackColor = true;
            this.btnDefect.Click += new System.EventHandler(this.btnDefect_Click);
            // 
            // cbSeller
            // 
            this.cbSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeller.FormattingEnabled = true;
            this.cbSeller.Location = new System.Drawing.Point(393, 16);
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
            this.photoPanel.Location = new System.Drawing.Point(647, 16);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(225, 295);
            this.photoPanel.TabIndex = 33;
            // 
            // EditForm
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 321);
            this.Controls.Add(this.photoPanel);
            this.Controls.Add(this.chbSearchAllowed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbSeller);
            this.Controls.Add(this.tbFirmPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.tbPurchasePrice);
            this.Controls.Add(this.btnInOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDefect);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStorage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbWholesalePrice);
            this.Controls.Add(this.tbServicePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRetailPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ДОБАВИТЬ / ИЗМЕНИТЬ ПРЕДМЕТ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.photoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

