namespace UpdateToFtpServer
{
    partial class Form1
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
            this.tvSparesBase = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSparesBaseAddVersion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tvAdmin = new System.Windows.Forms.TreeView();
            this.btnAdminAddVersion = new System.Windows.Forms.Button();
            this.btnAdminDeleteVersion = new System.Windows.Forms.Button();
            this.btnSparesBaseDeleteVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvSparesBase
            // 
            this.tvSparesBase.Location = new System.Drawing.Point(12, 25);
            this.tvSparesBase.Name = "tvSparesBase";
            this.tvSparesBase.Size = new System.Drawing.Size(158, 223);
            this.tvSparesBase.TabIndex = 2;
            this.tvSparesBase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSparesBase_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Spares Base";
            // 
            // btnSparesBaseAddVersion
            // 
            this.btnSparesBaseAddVersion.Location = new System.Drawing.Point(12, 254);
            this.btnSparesBaseAddVersion.Name = "btnSparesBaseAddVersion";
            this.btnSparesBaseAddVersion.Size = new System.Drawing.Size(158, 23);
            this.btnSparesBaseAddVersion.TabIndex = 4;
            this.btnSparesBaseAddVersion.Text = "Добавить новую версию";
            this.btnSparesBaseAddVersion.UseVisualStyleBackColor = true;
            this.btnSparesBaseAddVersion.Click += new System.EventHandler(this.btnSparesBaseAddVersion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Spares Base Administrator";
            // 
            // tvAdmin
            // 
            this.tvAdmin.Location = new System.Drawing.Point(176, 25);
            this.tvAdmin.Name = "tvAdmin";
            this.tvAdmin.Size = new System.Drawing.Size(158, 223);
            this.tvAdmin.TabIndex = 5;
            // 
            // btnAdminAddVersion
            // 
            this.btnAdminAddVersion.Location = new System.Drawing.Point(176, 254);
            this.btnAdminAddVersion.Name = "btnAdminAddVersion";
            this.btnAdminAddVersion.Size = new System.Drawing.Size(158, 23);
            this.btnAdminAddVersion.TabIndex = 7;
            this.btnAdminAddVersion.Text = "Добавить новую версию";
            this.btnAdminAddVersion.UseVisualStyleBackColor = true;
            // 
            // btnAdminDeleteVersion
            // 
            this.btnAdminDeleteVersion.Location = new System.Drawing.Point(176, 283);
            this.btnAdminDeleteVersion.Name = "btnAdminDeleteVersion";
            this.btnAdminDeleteVersion.Size = new System.Drawing.Size(158, 23);
            this.btnAdminDeleteVersion.TabIndex = 9;
            this.btnAdminDeleteVersion.Text = "Удалить версию";
            this.btnAdminDeleteVersion.UseVisualStyleBackColor = true;
            // 
            // btnSparesBaseDeleteVersion
            // 
            this.btnSparesBaseDeleteVersion.Location = new System.Drawing.Point(12, 283);
            this.btnSparesBaseDeleteVersion.Name = "btnSparesBaseDeleteVersion";
            this.btnSparesBaseDeleteVersion.Size = new System.Drawing.Size(158, 23);
            this.btnSparesBaseDeleteVersion.TabIndex = 8;
            this.btnSparesBaseDeleteVersion.Text = "Удалить версию";
            this.btnSparesBaseDeleteVersion.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 314);
            this.Controls.Add(this.btnAdminDeleteVersion);
            this.Controls.Add(this.btnSparesBaseDeleteVersion);
            this.Controls.Add(this.btnAdminAddVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvAdmin);
            this.Controls.Add(this.btnSparesBaseAddVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvSparesBase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView tvSparesBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSparesBaseAddVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvAdmin;
        private System.Windows.Forms.Button btnAdminAddVersion;
        private System.Windows.Forms.Button btnAdminDeleteVersion;
        private System.Windows.Forms.Button btnSparesBaseDeleteVersion;
    }
}

