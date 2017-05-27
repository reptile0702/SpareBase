using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class AccountEditorForm : Form
    {
        int organizationId;
        Account account;

        // Конструктор
        public AccountEditorForm(int organizationId)
        {
            InitializeComponent();
            FillComboBoxes();
            this.organizationId = organizationId;
            Text = "Регистрация аккаунта";
            btnFinishRegistration.Text = "Зарегистрировать";
        }

        public AccountEditorForm(Account account)
        {
            InitializeComponent();
            FillComboBoxes();
            FillAccountInfo(account);
            Text = "Редактирование аккаунта";
            btnFinishRegistration.Text = "Изменить данные";
            this.account = account;
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
        }

        // Редактирование
        private void Edit()
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

            // Изменение данных об аккаунте
            DatabaseWorker.SqlQuery("UPDATE Accounts SET FirstName = '" + tbName.Text + "', LastName = '" + tbLastName.Text + "', SecondName = '" + tbSecondName.Text + "', Login = '" + tbLogIn.Text + "', Password = '" + tbPassword.Text + "', OrganizationId = " + cbOrganization.SelectedValue + ", CityId = " + cbCity.SelectedIndex + ", Phone = '" + tbPhone.Text + "', Email = '" + tbMail.Text + "' WHERE(id = " + account.Id + ")");
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
            if (account == null)
                Register();
            else
                Edit();

            Close();
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
