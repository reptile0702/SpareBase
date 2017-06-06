﻿using System.Windows.Forms;

namespace SparesBase
{
    public partial class OrganizationCardForm : Form
    {
        Organization organization;

        public OrganizationCardForm(Organization organization)
        {
            InitializeComponent();
            InitializeCard(organization);
            this.organization = organization;
        }

        public void InitializeCard(Organization organization)
        {
            
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
                lAdminLastName.Text = "Не назначен";
                lAdminSecondName.Text = "";
            }
        }

        private void btnAdminCard_Click(object sender, System.EventArgs e)
        {
            AccountCardForm acf = new AccountCardForm(organization.Admin);
            acf.ShowDialog();
        }
    }
}
