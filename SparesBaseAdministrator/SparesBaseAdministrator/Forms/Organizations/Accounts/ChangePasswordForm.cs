using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class ChangePasswordForm : Form
    {
        int accountId;

        // Конструктор
        public ChangePasswordForm(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
        }

        // Клик на кнопку "Поменять"
        private void btnChange_Click(object sender, System.EventArgs e)
        {
            if (tbPassword.Text != "" && tbRepPassword.Text != "")
            {
                if (tbPassword.Text == tbRepPassword.Text)
                {
                    DatabaseWorker.SqlQuery("UPDATE Accounts SET Password = " + tbPassword.Text + " WHERE(id = " + accountId + ")");
                    Close();
                }
                else
                    MessageBox.Show("Пароли не совпадают.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Введены не все данные.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
