﻿using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class AccountEditor : Form
    {
        private Account account;

        // Конструктор
        public AccountEditor(Account account)
        {
            InitializeComponent();
            this.account = account;
            FillComboBoxes();
            FillData();
        }

        #region Методы

        // Редактирование аккаунта
        private void EditAccount()
        {
            // Проверка на введенность полей
            if (tbName.Text == "" ||
                tbLastName.Text == "" ||
                tbSecondName.Text == "" ||
                tbLogIn.Text == "")
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

            if (account.Login != tbLogIn.Text)
            {
                // Проверка на существование введенного логина в базе
                if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login='" + tbLogIn.Text + "')") != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                    return;
                }
            }
            
            // Изменение аккаунта
            DatabaseWorker.SqlQuery("UPDATE Accounts SET FirstName='" + tbName.Text + "', LastName='" + tbLastName.Text + "', SecondName='" + tbSecondName.Text + "', Login='" + tbLogIn.Text.Trim() + "', CityId=" + (cbCity.SelectedIndex + 1) + ", Phone='" + tbPhone.Text + "', Email='" + tbMail.Text + "' WHERE(id=" + account.Id + ")");

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

        // Заполнение данных об аккаунте
        private void FillData()
        {
            tbLogIn.Text = account.Login;
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