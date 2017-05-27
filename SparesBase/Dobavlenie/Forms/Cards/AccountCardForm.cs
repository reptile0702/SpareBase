﻿using System.Windows.Forms;

namespace SparesBase
{
    public partial class AccountCardForm : Form
    {
        public AccountCardForm(Account account)
        {
            InitializeComponent();
            InitializeCard(account);
        }

        private void InitializeCard(Account account)
        {
            lId.Text = "Идентификатор: " + account.Id.ToString();
            lFirstName.Text = "Имя: " + account.FirstName;
            lLastName.Text = "Фамилия: " + account.LastName;
            lSecondName.Text = "Отчество: " + account.SecondName;
            lLogin.Text = "Логин: " + account.Login;
            lCity.Text = "Город: " + account.City;
            lPhone.Text = "Телефон: " + account.Phone;
            lEmail.Text = "Email: " + account.Email;
            lAdmin.Text = account.Admin ? "Администратор оргацизации" : "Не администратор";
        }
    }
}
