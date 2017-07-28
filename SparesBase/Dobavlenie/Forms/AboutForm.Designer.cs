namespace SparesBase.Forms
{
    partial class AboutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "База запчастей";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(13, 59);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(47, 13);
            this.lVersion.TabIndex = 1;
            this.lVersion.Text = "Версия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Авторы: Ткаченко Дмитрий\r\n                Михалев Даниил";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(237, 119);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(189, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Покинуть форму \"AboutForm\"";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 154);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
    }
}