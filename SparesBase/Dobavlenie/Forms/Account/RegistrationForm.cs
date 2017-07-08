using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class RegistrationForm : Form
    {
        // Конструктор
        public RegistrationForm()
        {
            InitializeComponent();
            FillCities();
        }


        #region Методы
        
        // Регистрация
        private void Register()
        {
            // Проверка на введенность полей
            if (tbName.Text == "" ||
                tbLastName.Text == "" ||
                tbSecondName.Text == "" ||
                tbLogin.Text == "" ||
                tbPassword.Text == "" ||
                tbSecondPassword.Text == "")
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

            // Проверка на совпадение двух паролей
            if (tbPassword.Text.Trim() != tbSecondPassword.Text.Trim())
            {
                MessageBox.Show("Не совпадают введенные пароли");
                return;
            }
            
            // Проверка на существование введенного логина в базе
            if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login = '" + tbLogin.Text + "')") != null)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                return;
            }

            // Добавление аккаунта в базу
            DatabaseWorker.SqlQuery("INSERT INTO Accounts VALUES('', " +
                "'" + tbName.Text + "', " +
                "'" + tbLastName.Text + "', " +
                "'" + tbSecondName.Text + "', " +
                "'" + tbLogin.Text.Trim() + "', " +
                "'" + MD5hash.GetMD5Hash(tbPassword.Text.Trim()) + "', " +
                "" + EnteredUser.Organization.Id + ", " +
                "" + cbCity.SelectedValue + ", " +
                "'" + tbPhone.Text + "', " +
                "'" + tbMail.Text + "', " +
                "0)");

            Close();
        }

        // Заполнение ComboBox'а с городами
        private void FillCities()
        {
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT id, City FROM Cities");

            cbCity.ValueMember = "id";
            cbCity.DisplayMember = "City";
            cbCity.DataSource = cities;

            cbCity.SelectedIndex = 0;
        }

        #endregion Методы



        #region События

        // Клик на кнопку "Зарегистрироваться"
        private void btnFinishRegistration_Click(object sender, EventArgs e)
        {
            Register();
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
