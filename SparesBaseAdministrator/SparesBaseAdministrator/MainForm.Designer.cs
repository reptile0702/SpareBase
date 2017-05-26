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
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnActionLogs = new System.Windows.Forms.Button();
            this.btnCities = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnOrganizations = new System.Windows.Forms.Button();
            this.btnSellers = new System.Windows.Forms.Button();
            this.lOrgCount = new System.Windows.Forms.Label();
            this.lAccCount = new System.Windows.Forms.Label();
            this.lItemsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(12, 12);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(283, 23);
            this.btnAccounts.TabIndex = 0;
            this.btnAccounts.Text = "Аккаунты";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
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
            this.btnCities.Location = new System.Drawing.Point(12, 70);
            this.btnCities.Name = "btnCities";
            this.btnCities.Size = new System.Drawing.Size(283, 23);
            this.btnCities.TabIndex = 2;
            this.btnCities.Text = "Города";
            this.btnCities.UseVisualStyleBackColor = true;
            this.btnCities.Click += new System.EventHandler(this.btnCities_Click);
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(12, 99);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(283, 23);
            this.btnItems.TabIndex = 3;
            this.btnItems.Text = "Предметы";
            this.btnItems.UseVisualStyleBackColor = true;
            // 
            // btnOrganizations
            // 
            this.btnOrganizations.Location = new System.Drawing.Point(12, 128);
            this.btnOrganizations.Name = "btnOrganizations";
            this.btnOrganizations.Size = new System.Drawing.Size(283, 23);
            this.btnOrganizations.TabIndex = 4;
            this.btnOrganizations.Text = "Организации";
            this.btnOrganizations.UseVisualStyleBackColor = true;
            // 
            // btnSellers
            // 
            this.btnSellers.Location = new System.Drawing.Point(12, 157);
            this.btnSellers.Name = "btnSellers";
            this.btnSellers.Size = new System.Drawing.Size(283, 23);
            this.btnSellers.TabIndex = 5;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 193);
            this.Controls.Add(this.lItemsCount);
            this.Controls.Add(this.lAccCount);
            this.Controls.Add(this.lOrgCount);
            this.Controls.Add(this.btnSellers);
            this.Controls.Add(this.btnOrganizations);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnCities);
            this.Controls.Add(this.btnActionLogs);
            this.Controls.Add(this.btnAccounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Button btnOrganizations;
        private System.Windows.Forms.Button btnSellers;
        private System.Windows.Forms.Label lOrgCount;
        private System.Windows.Forms.Label lAccCount;
        private System.Windows.Forms.Label lItemsCount;
    }
}

