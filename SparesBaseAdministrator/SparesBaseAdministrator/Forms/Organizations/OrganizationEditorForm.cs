using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class OrganizationEditorForm : Form
    {
        public OrganizationEditorForm()
        {
            InitializeComponent();
            FillCities();
            Text = "Регистрация организации";
            btnEdit.Text = "Зарегистрировать";
        }

        public OrganizationEditorForm(Organization organization)
        {
            InitializeComponent();
            FillCities();
            FillOrganizationData(organization);
            Text = "Редактирование организации";
            btnEdit.Text = "Изменить";
        }

        // Заполнение ComboBox'ов с городами
        private void FillCities()
        {
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT City FROM Cities");
            foreach (DataRow row in cities.Rows)
                cbCity.Items.Add(row.ItemArray[0]);

            cbCity.SelectedIndex = 0;
        }

        private void FillOrganizationData(Organization organization)
        {
            tbName.Text = organization.Name;
            tbSite.Text = organization.Site;
            tbPhone.Text = organization.Telephone;
            cbCity.Text = organization.City;
        }
    }
}
