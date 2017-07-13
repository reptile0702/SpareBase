using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class OrganizationCardForm : Form
    {
        Organization organization;
        Account admin;

        // Конструктор
        public OrganizationCardForm(Organization organization)
        {
            InitializeComponent();
            InitializeCard(organization);
            this.organization = organization;
        }


        // Инициализация карточки
        public void InitializeCard(Organization organization)
        {
            lName.Text = "Название:\n" + organization.Name;
            lSite.Text = "Сайт:";
            lSiteLink.Text = organization.Site;
            lTelephone.Text = "Телефон: " + organization.Telephone;
            lCity.Text = "Город: " + organization.City;

            DataTable queryAdmin = DatabaseWorker.SqlSelectQuery("SELECT * FROM Accounts " +
                "LEFT JOIN Cities ON CityId = Cities.id " +
                "WHERE(OrganizationId = " + organization.Id + " AND Admin = 1)");
            if (queryAdmin.Rows.Count == 0)
                admin = null;
            else
                admin = new Account(
                    int.Parse(queryAdmin.Rows[0]["id"].ToString()),
                    queryAdmin.Rows[0]["FirstName"].ToString(),
                    queryAdmin.Rows[0]["LastName"].ToString(),
                    queryAdmin.Rows[0]["SecondName"].ToString(),
                    queryAdmin.Rows[0]["Login"].ToString(),
                    organization,
                    queryAdmin.Rows[0]["City"].ToString(),
                    queryAdmin.Rows[0]["Phone"].ToString(),
                    queryAdmin.Rows[0]["Email"].ToString(),
                    queryAdmin.Rows[0]["Admin"].ToString() == "1" ? true : false);

            if (admin != null)
            {
                lAdminFirstName.Text = "Имя: " + admin.FirstName;
                lAdminLastName.Text = "Фамилия: " + admin.LastName;
                lAdminSecondName.Text = "Отчество: " + admin.SecondName;
            }
            else
            {
                lAdminFirstName.Text = "";
                lAdminLastName.Text = "Не назначен";
                lAdminSecondName.Text = "";
            }
        }


        #region События

        // Клик на "Карточка администратора"
        private void btnAdminCard_Click(object sender, System.EventArgs e)
        {
            AccountCardForm acf = new AccountCardForm(admin);
            acf.ShowDialog();
        }

        // Клик на сайт
        private void lSiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lSiteLink.Text);
        }

        #endregion События
    }
}
