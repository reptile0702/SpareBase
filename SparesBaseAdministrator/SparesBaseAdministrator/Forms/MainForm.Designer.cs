namespace SparesBaseAdministrator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnActionLogs = new System.Windows.Forms.Button();
            this.btnCities = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnSellers = new System.Windows.Forms.Button();
            this.lOrgCount = new System.Windows.Forms.Label();
            this.lAccCount = new System.Windows.Forms.Label();
            this.lItemsCount = new System.Windows.Forms.Label();
            this.lActionsCount = new System.Windows.Forms.Label();
            this.lSellersCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(12, 12);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(283, 23);
            this.btnAccounts.TabIndex = 0;
            this.btnAccounts.Text = "Организации";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnOrganizations_Click);
            // 
            // btnActionLogs
            // 
            this.btnActionLogs.Location = new System.Drawing.Point(12, 41);
            this.btnActionLogs.Name = "btnActionLogs";
            this.btnActionLogs.Size = new System.Drawing.Size(283, 23);
            this.btnActionLogs.TabIndex = 1;
            this.btnActionLogs.Text = "Журнал действий";
            this.btnActionLogs.UseVisualStyleBackColor = true;
            this.btnActionLogs.Click += new System.EventHandler(this.btnActionLogs_Click);
            // 
            // btnCities
            // 
            this.btnCities.Location = new System.Drawing.Point(12, 128);
            this.btnCities.Name = "btnCities";
            this.btnCities.Size = new System.Drawing.Size(283, 23);
            this.btnCities.TabIndex = 4;
            this.btnCities.Text = "Города";
            this.btnCities.UseVisualStyleBackColor = true;
            this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(12, 70);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(283, 23);
            this.btnItems.TabIndex = 2;
            this.btnItems.Text = "Предметы";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnSellers
            // 
            this.btnSellers.Location = new System.Drawing.Point(12, 99);
            this.btnSellers.Name = "btnSellers";
            this.btnSellers.Size = new System.Drawing.Size(283, 23);
            this.btnSellers.TabIndex = 3;
            this.btnSellers.Text = "Поставщики";
            this.btnSellers.UseVisualStyleBackColor = true;
            this.btnSellers.Click += new System.EventHandler(this.btnSellers_Click);
            // 
            // lOrgCount
            // 
            this.lOrgCount.AutoSize = true;
            this.lOrgCount.Location = new System.Drawing.Point(301, 17);
            this.lOrgCount.Name = "lOrgCount";
            this.lOrgCount.Size = new System.Drawing.Size(244, 13);
            this.lOrgCount.TabIndex = 6;
            this.lOrgCount.Text = "Количество зарегистрированных организаций";
            // 
            // lAccCount
            // 
            this.lAccCount.AutoSize = true;
            this.lAccCount.Location = new System.Drawing.Point(301, 46);
            this.lAccCount.Name = "lAccCount";
            this.lAccCount.Size = new System.Drawing.Size(231, 13);
            this.lAccCount.TabIndex = 7;
            this.lAccCount.Text = "Количество зарегистрированных аккаунтов";
            // 
            // lItemsCount
            // 
            this.lItemsCount.AutoSize = true;
            this.lItemsCount.Location = new System.Drawing.Point(301, 75);
            this.lItemsCount.Name = "lItemsCount";
            this.lItemsCount.Size = new System.Drawing.Size(160, 13);
            this.lItemsCount.TabIndex = 8;
            this.lItemsCount.Text = "Количество предметов в базе";
            // 
            // lActionsCount
            // 
            this.lActionsCount.AutoSize = true;
            this.lActionsCount.Location = new System.Drawing.Point(301, 104);
            this.lActionsCount.Name = "lActionsCount";
            this.lActionsCount.Size = new System.Drawing.Size(224, 13);
            this.lActionsCount.TabIndex = 9;
            this.lActionsCount.Text = "Количество совершенных действий в базе";
            // 
            // lSellersCount
            // 
            this.lSellersCount.AutoSize = true;
            this.lSellersCount.Location = new System.Drawing.Point(301, 133);
            this.lSellersCount.Name = "lSellersCount";
            this.lSellersCount.Size = new System.Drawing.Size(173, 13);
            this.lSellersCount.TabIndex = 10;
            this.lSellersCount.Text = "Количество поставщиков в базе";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 161);
            this.Controls.Add(this.lSellersCount);
            this.Controls.Add(this.lActionsCount);
            this.Controls.Add(this.lItemsCount);
            this.Controls.Add(this.lAccCount);
            this.Controls.Add(this.lOrgCount);
            this.Controls.Add(this.btnSellers);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnCities);
            this.Controls.Add(this.btnActionLogs);
            this.Controls.Add(this.btnAccounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База запчастей - Администратор";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnActionLogs;
        private System.Windows.Forms.Button btnCities;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnSellers;
        private System.Windows.Forms.Label lOrgCount;
        private System.Windows.Forms.Label lAccCount;
        private System.Windows.Forms.Label lItemsCount;
        private System.Windows.Forms.Label lActionsCount;
        private System.Windows.Forms.Label lSellersCount;
    }
}

