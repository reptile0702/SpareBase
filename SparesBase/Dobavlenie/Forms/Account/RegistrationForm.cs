using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class RegistrationForm : Form
    {
       
        
        // Конструктор
        public RegistrationForm()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        // Регистрация
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

            // Проверка на допустимые символы
            if (!StringValidation.IsValid(tbLogIn.Text))
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
            if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login='" + tbLogIn.Text + "')") != null)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                return;
            }

            // Добавление аккаунта в базу
            DatabaseWorker.SqlQuery("INSERT INTO Accounts VALUES('','" + tbName.Text + "', '" + tbLastName.Text + "', '" + tbSecondName.Text + "', '" + tbLogIn.Text.Trim() + "', '" + tbPassword.Text.Trim() + "', " + EnteredUser.OrganizationId + ", " + (cbCity.SelectedIndex + 1) + ", '" + tbPhone.Text + "', '" + tbMail.Text + "', 0)");

           
            Close();
        }


        // Заполнение ComboBox'а с городами
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
