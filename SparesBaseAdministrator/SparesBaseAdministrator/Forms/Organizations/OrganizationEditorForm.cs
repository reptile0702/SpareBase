using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class OrganizationEditorForm : Form
    {
        Organization organization;

        // Конструктор для регистрации организации
        public OrganizationEditorForm()
        {
            InitializeComponent();
            FillCities();
            Text = "Регистрация организации";
            btnEdit.Text = "Зарегистрировать";
        }

        // Конструктор для редактирования организации
        public OrganizationEditorForm(Organization organization)
        {
            InitializeComponent();
            FillCities();
            FillOrganizationData(organization);
            Text = "Редактирование организации";
            btnEdit.Text = "Изменить";
            this.organization = organization;
        }


        // Заполнение ComboBox'ов с городами
        private void FillCities()
        {
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT City FROM Cities");
            foreach (DataRow row in cities.Rows)
                cbCity.Items.Add(row.ItemArray[0]);

            cbCity.SelectedIndex = 0;
        }

        // Заполнение данных об организации
        private void FillOrganizationData(Organization organization)
        {
            tbName.Text = organization.Name;
            tbSite.Text = organization.Site;
            tbPhone.Text = organization.Telephone;
            cbCity.Text = organization.City;
        }

        // Регистрация организации
        private void RegisterOrganization()
        {
            if (tbName.Text != "" ||
                tbPhone.Text != "" ||
                tbSite.Text != "")
            {
                DatabaseWorker.SqlQuery("INSERT INTO Organizations VALUES('', '" + tbName.Text + "', '" + tbSite.Text + "', '" + tbPhone.Text + "', " + (cbCity.SelectedIndex + 1) + ", 0)");
                Close();
            }
            else
                MessageBox.Show("Введены не все поля.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Редактирование организации
        private void EditOrganization()
        {
            if (tbName.Text != "" ||
                tbPhone.Text != "" ||
                tbSite.Text != "")
            {
                DatabaseWorker.SqlQuery("UPDATE Organizations SET Name = '" + tbName.Text + "', Site = '" + tbSite.Text + "', Telephone = '" + tbPhone.Text + "', CityId = " + (cbCity.SelectedIndex + 1) + " WHERE(id = " + organization.Id + ")");
                Close();
            }
            else
                MessageBox.Show("Введены не все поля.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // Клик на кнопку Зарегистрировать / Изменить
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (organization == null)
                RegisterOrganization();
            else
                EditOrganization();
        }

        // Клик на кнопку Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
