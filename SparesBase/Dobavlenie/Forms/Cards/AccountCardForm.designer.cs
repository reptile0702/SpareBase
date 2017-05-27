namespace SparesBase
{
    partial class AccountCardForm
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
            this.lId = new System.Windows.Forms.Label();
            this.lFirstName = new System.Windows.Forms.Label();
            this.lLastName = new System.Windows.Forms.Label();
            this.lSecondName = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.lCity = new System.Windows.Forms.Label();
            this.lPhone = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lAdmin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lCard = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(20, 26);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(18, 13);
            this.lId.TabIndex = 0;
            this.lId.Text = "ID";
            // 
            // lFirstName
            // 
            this.lFirstName.AutoSize = true;
            this.lFirstName.Location = new System.Drawing.Point(20, 52);
            this.lFirstName.Name = "lFirstName";
            this.lFirstName.Size = new System.Drawing.Size(29, 13);
            this.lFirstName.TabIndex = 1;
            this.lFirstName.Text = "Имя";
            // 
            // lLastName
            // 
            this.lLastName.AutoSize = true;
            this.lLastName.Location = new System.Drawing.Point(19, 71);
            this.lLastName.Name = "lLastName";
            this.lLastName.Size = new System.Drawing.Size(56, 13);
            this.lLastName.TabIndex = 2;
            this.lLastName.Text = "Фамилия";
            // 
            // lSecondName
            // 
            this.lSecondName.AutoSize = true;
            this.lSecondName.Location = new System.Drawing.Point(20, 90);
            this.lSecondName.Name = "lSecondName";
            this.lSecondName.Size = new System.Drawing.Size(54, 13);
            this.lSecondName.TabIndex = 3;
            this.lSecondName.Text = "Отчество";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(20, 125);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(38, 13);
            this.lLogin.TabIndex = 4;
            this.lLogin.Text = "Логин";
            // 
            // lCity
            // 
            this.lCity.AutoSize = true;
            this.lCity.Location = new System.Drawing.Point(20, 163);
            this.lCity.Name = "lCity";
            this.lCity.Size = new System.Drawing.Size(37, 13);
            this.lCity.TabIndex = 5;
            this.lCity.Text = "Город";
            // 
            // lPhone
            // 
            this.lPhone.AutoSize = true;
            this.lPhone.Location = new System.Drawing.Point(20, 182);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(52, 13);
            this.lPhone.TabIndex = 6;
            this.lPhone.Text = "Телефон";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(20, 201);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(32, 13);
            this.lEmail.TabIndex = 7;
            this.lEmail.Text = "Email";
            // 
            // lAdmin
            // 
            this.lAdmin.AutoSize = true;
            this.lAdmin.Location = new System.Drawing.Point(20, 231);
            this.lAdmin.Name = "lAdmin";
            this.lAdmin.Size = new System.Drawing.Size(36, 13);
            this.lAdmin.TabIndex = 8;
            this.lAdmin.Text = "Admin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lAdmin);
            this.groupBox1.Controls.Add(this.lEmail);
            this.groupBox1.Controls.Add(this.lId);
            this.groupBox1.Controls.Add(this.lFirstName);
            this.groupBox1.Controls.Add(this.lPhone);
            this.groupBox1.Controls.Add(this.lLastName);
            this.groupBox1.Controls.Add(this.lCity);
            this.groupBox1.Controls.Add(this.lSecondName);
            this.groupBox1.Controls.Add(this.lLogin);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 257);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // lCard
            // 
            this.lCard.AutoSize = true;
            this.lCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lCard.Location = new System.Drawing.Point(70, 12);
            this.lCard.Name = "lCard";
            this.lCard.Size = new System.Drawing.Size(170, 20);
            this.lCard.TabIndex = 9;
            this.lCard.Text = "Карточка аккаунта";
            // 
            // AccountCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 304);
            this.Controls.Add(this.lCard);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка аккаунта";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lId;
        private System.Windows.Forms.Label lFirstName;
        private System.Windows.Forms.Label lLastName;
        private System.Windows.Forms.Label lSecondName;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lCity;
        private System.Windows.Forms.Label lPhone;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lAdmin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lCard;
    }
}