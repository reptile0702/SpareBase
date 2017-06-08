namespace SparesBase
{
    partial class OrganizationCardForm
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
            this.lName = new System.Windows.Forms.Label();
            this.lSite = new System.Windows.Forms.Label();
            this.lTelephone = new System.Windows.Forms.Label();
            this.lCity = new System.Windows.Forms.Label();
            this.lAdminFirstName = new System.Windows.Forms.Label();
            this.lAdminLastName = new System.Windows.Forms.Label();
            this.lAdminSecondName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdminCard = new System.Windows.Forms.Button();
            this.lCard = new System.Windows.Forms.Label();
            this.lSiteLink = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(21, 25);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(125, 13);
            this.lName.TabIndex = 1;
            this.lName.Text = "Название организации";
            // 
            // lSite
            // 
            this.lSite.AutoSize = true;
            this.lSite.Location = new System.Drawing.Point(21, 64);
            this.lSite.Name = "lSite";
            this.lSite.Size = new System.Drawing.Size(34, 13);
            this.lSite.TabIndex = 2;
            this.lSite.Text = "Сайт:";
            // 
            // lTelephone
            // 
            this.lTelephone.AutoSize = true;
            this.lTelephone.Location = new System.Drawing.Point(21, 83);
            this.lTelephone.Name = "lTelephone";
            this.lTelephone.Size = new System.Drawing.Size(52, 13);
            this.lTelephone.TabIndex = 3;
            this.lTelephone.Text = "Телефон";
            // 
            // lCity
            // 
            this.lCity.AutoSize = true;
            this.lCity.Location = new System.Drawing.Point(21, 102);
            this.lCity.Name = "lCity";
            this.lCity.Size = new System.Drawing.Size(37, 13);
            this.lCity.TabIndex = 4;
            this.lCity.Text = "Город";
            // 
            // lAdminFirstName
            // 
            this.lAdminFirstName.AutoSize = true;
            this.lAdminFirstName.Location = new System.Drawing.Point(21, 25);
            this.lAdminFirstName.Name = "lAdminFirstName";
            this.lAdminFirstName.Size = new System.Drawing.Size(70, 13);
            this.lAdminFirstName.TabIndex = 5;
            this.lAdminFirstName.Text = "Имя админа";
            // 
            // lAdminLastName
            // 
            this.lAdminLastName.AutoSize = true;
            this.lAdminLastName.Location = new System.Drawing.Point(21, 45);
            this.lAdminLastName.Name = "lAdminLastName";
            this.lAdminLastName.Size = new System.Drawing.Size(97, 13);
            this.lAdminLastName.TabIndex = 6;
            this.lAdminLastName.Text = "Фамилия админа";
            // 
            // lAdminSecondName
            // 
            this.lAdminSecondName.AutoSize = true;
            this.lAdminSecondName.Location = new System.Drawing.Point(21, 64);
            this.lAdminSecondName.Name = "lAdminSecondName";
            this.lAdminSecondName.Size = new System.Drawing.Size(95, 13);
            this.lAdminSecondName.TabIndex = 7;
            this.lAdminSecondName.Text = "Отчество админа";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lSiteLink);
            this.groupBox1.Controls.Add(this.lName);
            this.groupBox1.Controls.Add(this.lSite);
            this.groupBox1.Controls.Add(this.lTelephone);
            this.groupBox1.Controls.Add(this.lCity);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 128);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdminCard);
            this.groupBox2.Controls.Add(this.lAdminLastName);
            this.groupBox2.Controls.Add(this.lAdminFirstName);
            this.groupBox2.Controls.Add(this.lAdminSecondName);
            this.groupBox2.Location = new System.Drawing.Point(274, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 128);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Администратор оргацизации";
            // 
            // btnAdminCard
            // 
            this.btnAdminCard.Location = new System.Drawing.Point(6, 97);
            this.btnAdminCard.Name = "btnAdminCard";
            this.btnAdminCard.Size = new System.Drawing.Size(229, 23);
            this.btnAdminCard.TabIndex = 8;
            this.btnAdminCard.Text = "Карточка администратора";
            this.btnAdminCard.UseVisualStyleBackColor = true;
            this.btnAdminCard.Click += new System.EventHandler(this.btnAdminCard_Click);
            // 
            // lCard
            // 
            this.lCard.AutoSize = true;
            this.lCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCard.Location = new System.Drawing.Point(164, 12);
            this.lCard.Name = "lCard";
            this.lCard.Size = new System.Drawing.Size(201, 20);
            this.lCard.TabIndex = 10;
            this.lCard.Text = "Карточка организации";
            this.lCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSiteLink
            // 
            this.lSiteLink.AutoSize = true;
            this.lSiteLink.Location = new System.Drawing.Point(61, 64);
            this.lSiteLink.Name = "lSiteLink";
            this.lSiteLink.Size = new System.Drawing.Size(58, 13);
            this.lSiteLink.TabIndex = 5;
            this.lSiteLink.TabStop = true;
            this.lSiteLink.Text = "SITE.COM";
            this.lSiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lSiteLink_LinkClicked);
            // 
            // OrganizationCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 180);
            this.Controls.Add(this.lCard);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrganizationCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка организации";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lSite;
        private System.Windows.Forms.Label lTelephone;
        private System.Windows.Forms.Label lCity;
        private System.Windows.Forms.Label lAdminFirstName;
        private System.Windows.Forms.Label lAdminLastName;
        private System.Windows.Forms.Label lAdminSecondName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdminCard;
        private System.Windows.Forms.Label lCard;
        private System.Windows.Forms.LinkLabel lSiteLink;
    }
}