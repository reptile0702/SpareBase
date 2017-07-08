using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class AccountEditor : Form
    {
        #region Поля
        
        private Account account;

        #endregion Поля



        #region Конструктор

        // Конструктор
        public AccountEditor(Account account)
        {
            InitializeComponent();
            this.account = account;
            FillCities();
            FillAccountData();
        }

        #endregion Конструктор



        #region Методы

        // Редактирование аккаунта
        private void EditAccount()
        {
            // Проверка на введенность полей
            if (tbName.Text == "" ||
                tbLastName.Text == "" ||
                tbSecondName.Text == "" ||
                tbLogin.Text == "")
            {
                MessageBox.Show("Не все поля были заполнены");
                return;
            }

            // Проверка на допустимые символы
            if (!StringValidation.IsValid(tbLogin.Text))
            {
                MessageBox.Show("Были введены недопустимые символы.\nРазрешены: латинские буквы, цифры _ - . @");
                return;
            }

            // Проверка на изменение логина
            if (account.Login != tbLogin.Text)
            {
                // Проверка на существование введенного логина в базе
                if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login='" + tbLogin.Text + "')") != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                    return;
                }
            }
            
            // Изменение аккаунта
            DatabaseWorker.SqlQuery("UPDATE Accounts SET " +
                "FirstName = '" + tbName.Text + "', " +
                "LastName = '" + tbLastName.Text + "', " +
                "SecondName = '" + tbSecondName.Text + "', " +
                "Login = '" + tbLogin.Text.Trim() + "', " +
                "CityId = " + cbCity.SelectedValue + ", " +
                "Phone = '" + tbPhone.Text + "', " +
                "Email = '" + tbMail.Text + "' " +
                "WHERE(id = " + account.Id + ")");

            Close();
        }

        // Заполнение гродов
        private void FillCities()
        {
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT id, City FROM Cities");
            cbCity.DataSource = cities;
            cbCity.ValueMember = "id";
            cbCity.DisplayMember = "City";
        }

        // Заполнение данных об аккаунте
        private void FillAccountData()
        {
            tbLogin.Text = account.Login;
            tbName.Text = account.FirstName;
            tbLastName.Text = account.LastName;
            tbSecondName.Text = account.SecondName;
            cbCity.Text = account.City;
            tbPhone.Text = account.Phone;
            tbMail.Text = account.Email;   
        }

        #endregion Методы



        #region События

        // Редактировать сотрудника
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            EditAccount();
        }

        // Смена пароля
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm(account);
            cpf.ShowDialog();
        }

        // Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
