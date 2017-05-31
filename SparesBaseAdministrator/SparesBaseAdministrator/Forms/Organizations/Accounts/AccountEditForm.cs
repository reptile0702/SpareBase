using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class AccountEditForm : Form
    {
        Account account;

        // Конструктор
        public AccountEditForm(Account account)
        {
            InitializeComponent();
            FillComboBoxes();
            FillAccountInfo(account);
            Text = "Редактирование аккаунта";
            btnFinishRegistration.Text = "Изменить данные";
            this.account = account;
        }

       
        // Редактирование аккаунта
        private void Edit()
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


            // Изменение данных об аккаунте
            string query = "";
            if (account.Organization != null)
                if (account.Admin && int.Parse(cbOrganization.SelectedValue.ToString()) != account.Organization.Id)
                    query += "UPDATE Accounts SET Admin = 0 WHERE(id = " + account.Id + "); ";

            query += "UPDATE Accounts SET FirstName = '" + tbName.Text + "', LastName = '" + tbLastName.Text + "', SecondName = '" + tbSecondName.Text + "', Login = '" + tbLogIn.Text + "', OrganizationId = " + cbOrganization.SelectedValue + ", CityId = " + (cbCity.SelectedIndex + 1) + ", Phone = '" + tbPhone.Text + "', Email = '" + tbMail.Text + "' WHERE(id = " + account.Id + ")";
            
            DatabaseWorker.SqlQuery(query);

            Close();
        }

        // Заполнение ComboBox'ов с организациями и городами
        private void FillComboBoxes()
        {
            // Организации
            DataTable organizations = new DataTable();
            organizations.Columns.Add("id");
            organizations.Columns.Add("Name");
            organizations.Rows.Add("0", "Без организации");
            DataRowCollection drc = DatabaseWorker.SqlSelectQuery("SELECT id, Name From Organizations").Rows;
            foreach (DataRow row in drc)
                organizations.Rows.Add(row.ItemArray[0], row.ItemArray[1]);

            cbOrganization.DataSource = organizations;
            cbOrganization.ValueMember = "id";
            cbOrganization.DisplayMember = "Name";

            // Города
            DataTable cities = DatabaseWorker.SqlSelectQuery("SELECT City FROM Cities");
            foreach (DataRow row in cities.Rows)
                cbCity.Items.Add(row.ItemArray[0]);

            cbCity.SelectedIndex = 0;
        }

        // Заполнение информации об аккаунте
        private void FillAccountInfo(Account account)
        {
            tbLogIn.Text = account.Login;
            tbName.Text = account.FirstName;
            tbLastName.Text = account.LastName;
            tbSecondName.Text = account.SecondName;
            if (account.Organization != null)
                cbOrganization.SelectedValue = account.Organization.Id;
            cbCity.Text = account.City;
            tbPhone.Text = account.Phone;
            tbMail.Text = account.Email;
        }


        // Клик на кнопку "Зарегистрироваться"
        private void btnFinishRegistration_Click(object sender, EventArgs e)
        {
            Edit();
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Клик на кнопку "Сменить пароль"
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm(account.Id);
            cpf.ShowDialog();
        }
    }
}
