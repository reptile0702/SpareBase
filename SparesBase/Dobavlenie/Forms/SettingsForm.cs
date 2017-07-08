using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SparesBase
{
    public partial class SettingsForm : Form
    {
        #region Поля
        #endregion Поля



        #region Конструкторы

        public SettingsForm()
        {
            InitializeComponent();
            chkbLoadItemsImages.Checked = Settings.AutoLoadItemImages;
        }

        #endregion Конструкторы



        #region Методы
        #endregion Методы



        #region События

        // Нажатие на кнопку ОК
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();   
        }

        // Закрытие формы, сохраниение изменений
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.AutoLoadItemImages = chkbLoadItemsImages.Checked;

            Settings.SaveSettings();
        }

        #endregion События
    }
}
