namespace SparesBaseAdministrator
{
    partial class BannerLoad
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
            this.tvBanners = new System.Windows.Forms.TreeView();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.tbLink = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnClearPicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // tvBanners
            // 
            this.tvBanners.Location = new System.Drawing.Point(12, 12);
            this.tvBanners.Name = "tvBanners";
            this.tvBanners.Size = new System.Drawing.Size(129, 165);
            this.tvBanners.TabIndex = 0;
            this.tvBanners.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBanners_AfterSelect);
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(147, 12);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(150, 250);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBanner.TabIndex = 1;
            this.pbBanner.TabStop = false;
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(12, 268);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(285, 20);
            this.tbLink.TabIndex = 2;
            this.tbLink.Leave += new System.EventHandler(this.tbLink_Leave);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(141, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(222, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(12, 183);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(129, 23);
            this.btnAddPhoto.TabIndex = 5;
            this.btnAddPhoto.Text = "Загрузить";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // btnClearPicture
            // 
            this.btnClearPicture.Location = new System.Drawing.Point(12, 212);
            this.btnClearPicture.Name = "btnClearPicture";
            this.btnClearPicture.Size = new System.Drawing.Size(129, 24);
            this.btnClearPicture.TabIndex = 6;
            this.btnClearPicture.Text = "Очистить";
            this.btnClearPicture.UseVisualStyleBackColor = true;
            this.btnClearPicture.Click += new System.EventHandler(this.btnClearPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ссылка";
            // 
            // BannerLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearPicture);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.tvBanners);
            this.Name = "BannerLoad";
            this.Text = "BannerLoad";
            this.Load += new System.EventHandler(this.BannerLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvBanners;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Button btnClearPicture;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bw;
    }
}