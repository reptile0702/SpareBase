namespace SparesBase
{
    partial class UpdateProgramForm
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
            this.lVersion = new System.Windows.Forms.Label();
            this.rtbChangeLog = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lVersion.Location = new System.Drawing.Point(92, 9);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(298, 20);
            this.lVersion.TabIndex = 0;
            this.lVersion.Text = "Доступна новая версия: VERSION";
            this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbChangeLog
            // 
            this.rtbChangeLog.Location = new System.Drawing.Point(12, 57);
            this.rtbChangeLog.Name = "rtbChangeLog";
            this.rtbChangeLog.Size = new System.Drawing.Size(444, 177);
            this.rtbChangeLog.TabIndex = 1;
            this.rtbChangeLog.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(381, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UpdateProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 274);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rtbChangeLog);
            this.Controls.Add(this.lVersion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateProgramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Доступно обновление программы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateProgramForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.RichTextBox rtbChangeLog;
        private System.Windows.Forms.Button btnOk;
    }
}