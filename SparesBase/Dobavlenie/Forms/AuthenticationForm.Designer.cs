namespace SparesBase.Forms
{
    partial class AuthenticationForm
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
            this.tbLogIn = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnRegOrg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLogIn
            // 
            this.tbLogIn.Location = new System.Drawing.Point(51, 25);
            this.tbLogIn.Name = "tbLogIn";
            this.tbLogIn.Size = new System.Drawing.Size(183, 20);
            this.tbLogIn.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(51, 64);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(183, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(103, 90);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(78, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Вход";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(51, 119);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(183, 23);
            this.btnRegistration.TabIndex = 5;
            this.btnRegistration.Text = "Регистрация";
            this.btnRegistration.UseVisualStyleBackColor = true;
            // 
            // btnRegOrg
            // 
            this.btnRegOrg.Location = new System.Drawing.Point(51, 201);
            this.btnRegOrg.Name = "btnRegOrg";
            this.btnRegOrg.Size = new System.Drawing.Size(183, 23);
            this.btnRegOrg.TabIndex = 6;
            this.btnRegOrg.Text = "Зарегистрировать органзацию";
            this.btnRegOrg.UseVisualStyleBackColor = true;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 236);
            this.Controls.Add(this.btnRegOrg);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AuthenticationForm";
            this.Text = "Вход в программу";
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogIn;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnRegOrg;
    }
}