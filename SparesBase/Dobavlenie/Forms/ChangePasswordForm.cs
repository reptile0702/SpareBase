using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class ChangePasswordForm : Form
    {
        #region Поля
        
        private Account account;

        #endregion Поля



        #region Конструкторы
        
        // Конструктор
        public ChangePasswordForm(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        #endregion Конструкторы



        #region Методы
        
        // Смена пароля
        private void ChangePassword()
        {
            // Проверка на старый пароль
            if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) " +
                "FROM Accounts " +
                "WHERE(id = " + account.Id + " AND Password='" + MD5hash.GetMD5Hash(tbOldPassword.Text) + "')" ).ToString()) <= 0)
            {
                MessageBox.Show("Неверно введён старый пароль", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на новый пароль
            if (tbNewPassword.Text != tbRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Смена пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Смена пароля в базе
            DatabaseWorker.SqlQuery("UPDATE Accounts SET " +
                "Password = '" + MD5hash.GetMD5Hash(tbRepeatPassword.Text) + "' " +
                "WHERE(id = " + account.Id + ")");

            Close();
        }

        #endregion Методы



        #region События
        
        // Клик на "Сменить пароль"
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        #endregion События
    }
}
