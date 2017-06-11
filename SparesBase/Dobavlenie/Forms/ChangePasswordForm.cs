using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class ChangePasswordForm : Form
    {
        private Account account;

        // Конструктор
        public ChangePasswordForm(Account account)
        {
            InitializeComponent();
            this.account = account;
        }
        
        // Смена пароля
        private void ChangePassword()
        {
            // Проверка на старый пароль
            if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Accounts WHERE(id=" + account.Id + " AND Password='" + tbOldPassword.Text + "')" ).ToString()) <= 0)
            {
                MessageBox.Show("Неверно введён старый пароль");
                return;
            }

            // Проверка на новый пароль
            if (tbNewPassword.Text != tbRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            // Смена пароля в базе
            DatabaseWorker.SqlQuery("UPDATE Accounts SET Password='" + tbRepeatPassword.Text + "' WHERE(id=" + account.Id + ")");
            Close();
        }

        // Клик на "Сменить пароль"
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
    }
}
