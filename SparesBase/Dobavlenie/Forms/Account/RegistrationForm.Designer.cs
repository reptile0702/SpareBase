namespace SparesBase.Forms
{
    partial class RegistrationForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbSecondPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFinishRegistration = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(115, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(158, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(115, 46);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(158, 20);
            this.tbLastName.TabIndex = 5;
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(115, 73);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(158, 20);
            this.tbSecondName.TabIndex = 6;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(115, 50);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(158, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbSecondPassword
            // 
            this.tbSecondPassword.Location = new System.Drawing.Point(115, 77);
            this.tbSecondPassword.Name = "tbSecondPassword";
            this.tbSecondPassword.Size = new System.Drawing.Size(158, 20);
            this.tbSecondPassword.TabIndex = 3;
            this.tbSecondPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Пароль";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Повторите пароль";
            // 
            // btnFinishRegistration
            // 
            this.btnFinishRegistration.Location = new System.Drawing.Point(12, 334);
            this.btnFinishRegistration.Name = "btnFinishRegistration";
            this.btnFinishRegistration.Size = new System.Drawing.Size(293, 23);
            this.btnFinishRegistration.TabIndex = 11;
            this.btnFinishRegistration.Text = "Зарегистрировать";
            this.btnFinishRegistration.UseVisualStyleBackColor = true;
            this.btnFinishRegistration.Click += new System.EventHandler(this.btnFinishRegistration_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(293, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Город";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Телефон";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(116, 46);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(158, 20);
            this.tbPhone.TabIndex = 9;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(116, 72);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(158, 20);
            this.tbMail.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "E-mail";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(115, 19);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(158, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Логин";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbLastName);
            this.groupBox1.Controls.Add(this.tbSecondName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 100);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ФИО";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbLogin);
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbSecondPassword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 104);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные для входа";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCity);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbMail);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbPhone);
            this.groupBox3.Location = new System.Drawing.Point(12, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 106);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дополнительные сведения";
            // 
            // cbCity
            // 
            this.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(116, 19);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(158, 21);
            this.cbCity.TabIndex = 8;
            // 
            // RegistrationForm
            // 
            this.AcceptButton = this.btnFinishRegistration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 398);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinishRegistration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация сотрудника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbSecondPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFinishRegistration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCity;
    }
}