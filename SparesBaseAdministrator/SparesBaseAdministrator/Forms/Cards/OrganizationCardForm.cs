﻿using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class OrganizationCardForm : Form
    {
        Organization organization;

        // Конструктор
        public OrganizationCardForm(Organization organization)
        {
            InitializeComponent();
            InitializeCard(organization);
            this.organization = organization;
        }

        // Заполнение данных о организации
        public void InitializeCard(Organization organization)
        {
            lId.Text = "Идентификатор: " + organization.Id.ToString();
            lName.Text = "Название: " + organization.Name;
            lSite.Text = "Сайт: " + organization.Site;
            lTelephone.Text = "Телефон: " + organization.Telephone;
            lCity.Text = "Город: " + organization.City;

            if (organization.Admin != null)
            {
                lAdminFirstName.Text = "Имя: " + organization.Admin.FirstName;
                lAdminLastName.Text = "Фамилия: " + organization.Admin.LastName;
                lAdminSecondName.Text = "Отчество: " + organization.Admin.SecondName;
            }
            else
            {
                lAdminFirstName.Text = "";
                lAdminLastName.Text = "Администратор не назначен";
                lAdminSecondName.Text = "";
            }
        }

        // Клик на кнопку "Карточка администратора"
        private void btnAdminCard_Click(object sender, System.EventArgs e)
        {
            AccountCardForm acf = new AccountCardForm(organization.Admin);
            acf.ShowDialog();
        }

        // Клик на кнопку "ОК"
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
