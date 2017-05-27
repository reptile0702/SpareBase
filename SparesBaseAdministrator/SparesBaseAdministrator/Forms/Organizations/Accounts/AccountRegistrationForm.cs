using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class AccountRegistrationForm : Form
    {
        int organizationId;
        
        // Конструктор
        public AccountRegistrationForm(int organizationId)
        {
            InitializeComponent();
            FillComboBoxes();
            this.organizationId = organizationId;
            Text = "Регистрация аккаунта";
            btnFinishRegistration.Text = "Зарегистрировать";
        }

        // Регистрация аккаунта
        private void Register()
        {
            // Проверка на введенность полей
            if (tbName.Text == "" ||
                tbLastName.Text == "" ||
                tbSecondName.Text == "" ||
                tbLogIn.Text == "" ||
                tbPassword.Text == "" ||
                tbSecondPassword.Text == "")
            {
                MessageBox.Show("Не все поля были заполнены");
                return;
            }

            // Проверка на совпадение двух паролей
            if (tbPassword.Text != tbSecondPassword.Text)
            {
                MessageBox.Show("Не совпадают введенные пароли");
                return;
            }

            // Проверка на существование введенного логина в базе
            if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login='" + tbLogIn.Text + "')") != null)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                return;
            }

            // Добавление аккаунта в базу
            DatabaseWorker.SqlQuery("INSERT INTO Accounts VALUES('','" + tbName.Text + "', '" + tbLastName.Text + "', '" + tbSecondName.Text + "', '" + tbLogIn.Text + "', '" + tbPassword.Text + "', " + organizationId + ", " + (cbCity.SelectedIndex + 1) + ", '" + tbPhone.Text + "', '" + tbMail.Text + "', 0)");

            Close();
        }
      
        // Заполнение ComboBox'ов с организациями и городами
        private void FillComboBoxes()
        {
            // Города
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT City FROM Cities");
            foreach (DataRow row in cities.Rows)
                cbCity.Items.Add(row.ItemArray[0]);

            cbCity.SelectedIndex = 0;
        }


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
    }
}
