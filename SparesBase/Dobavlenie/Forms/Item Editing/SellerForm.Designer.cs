﻿namespace SparesBase
{
    partial class SellerForm
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
            this.lbSellers = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSite = new System.Windows.Forms.TextBox();
            this.tbTelephone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbOk = new System.Windows.Forms.Button();
            this.btnSellerEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSellers
            // 
            this.lbSellers.FormattingEnabled = true;
            this.lbSellers.Location = new System.Drawing.Point(12, 12);
            this.lbSellers.Name = "lbSellers";
            this.lbSellers.Size = new System.Drawing.Size(169, 264);
            this.lbSellers.TabIndex = 0;
            this.lbSellers.SelectedIndexChanged += new System.EventHandler(this.lbSellers_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(190, 28);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(241, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbSite
            // 
            this.tbSite.Location = new System.Drawing.Point(190, 67);
            this.tbSite.Name = "tbSite";
            this.tbSite.ReadOnly = true;
            this.tbSite.Size = new System.Drawing.Size(241, 20);
            this.tbSite.TabIndex = 2;
            // 
            // tbTelephone
            // 
            this.tbTelephone.Location = new System.Drawing.Point(190, 106);
            this.tbTelephone.Mask = "+9(999) 000-0000";
            this.tbTelephone.Name = "tbTelephone";
            this.tbTelephone.ReadOnly = true;
            this.tbTelephone.Size = new System.Drawing.Size(95, 20);
            this.tbTelephone.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название огранизации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Сайт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Телефон";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(169, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавть нового поставщика";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 340);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(169, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Удалить поставщика";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Контактное лицо";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(190, 176);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(241, 20);
            this.tbFirstName.TabIndex = 12;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(190, 215);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(241, 20);
            this.tbLastName.TabIndex = 13;
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(190, 254);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.ReadOnly = true;
            this.tbSecondName.Size = new System.Drawing.Size(241, 20);
            this.tbSecondName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Имя";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Фамилия";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Отчество";
            // 
            // tbOk
            // 
            this.tbOk.Location = new System.Drawing.Point(356, 340);
            this.tbOk.Name = "tbOk";
            this.tbOk.Size = new System.Drawing.Size(75, 23);
            this.tbOk.TabIndex = 18;
            this.tbOk.Text = "ОК";
            this.tbOk.UseVisualStyleBackColor = true;
            this.tbOk.Click += new System.EventHandler(this.tbOk_Click);
            // 
            // btnSellerEdit
            // 
            this.btnSellerEdit.Location = new System.Drawing.Point(12, 311);
            this.btnSellerEdit.Name = "btnSellerEdit";
            this.btnSellerEdit.Size = new System.Drawing.Size(169, 23);
            this.btnSellerEdit.TabIndex = 19;
            this.btnSellerEdit.Text = "Редактировать поставщика";
            this.btnSellerEdit.UseVisualStyleBackColor = true;
            this.btnSellerEdit.Click += new System.EventHandler(this.btnSellerEdit_Click);
            // 
            // SellerForm
            // 
            this.AcceptButton = this.tbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 379);
            this.Controls.Add(this.btnSellerEdit);
            this.Controls.Add(this.tbOk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSecondName);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTelephone);
            this.Controls.Add(this.tbSite);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbSellers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SellerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поставщики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellerForm_FormClosing);
            this.Load += new System.EventHandler(this.SellerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSellers;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSite;
        private System.Windows.Forms.MaskedTextBox tbTelephone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button tbOk;
        private System.Windows.Forms.Button btnSellerEdit;
    }
}