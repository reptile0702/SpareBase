using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class ChangePasswordForm : Form
    {
        private Account account;
        public ChangePasswordForm(Account account)
        {
            InitializeComponent();
            this.account = account;
        }
        

        private void ChangePassword()
        {
            if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Accounts WHERE(id=" + account.Id + " AND Password='" + tbOldPassword.Text + "')" ).ToString()) <= 0)
            {
                MessageBox.Show("Неверно введён старый пароль");
                return;
            }

            if (tbNewPassword.Text != tbRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            DatabaseWorker.SqlQuery("UPDATE Accounts SET Password='" + tbRepeatPassword.Text + "' WHERE(id=" + account.Id + ")");
            Close();
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
    }
}
