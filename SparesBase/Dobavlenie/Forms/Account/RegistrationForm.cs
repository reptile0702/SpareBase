using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class RegistrationForm : Form
    {
        AuthenticationForm af;
        
        // Конструктор
        public RegistrationForm(AuthenticationForm af)
        {
            InitializeComponent();
            this.af = af;
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
            DatabaseWorker.SqlQuery("INSERT INTO Accounts VALUES('','" + tbName.Text + "', '" + tbLastName.Text + "', '" + tbSecondName.Text + "', '" + tbLogIn.Text + "', '" + tbPassword.Text + "', " + cbOrganization.SelectedValue + ", " + (cbCity.SelectedIndex + 1) + ", '" + tbPhone.Text + "', '" + tbMail.Text + "', 0)");

            // Инициализация аккаунта в программе
            DataTable dr = DatabaseWorker.SqlSelectQuery("SELECT id, Login, Password, OrganizationId, Admin FROM Accounts WHERE(id = LAST_INSERT_ID())");
            af.InitializeAccount(
                int.Parse(dr.Rows[0].ItemArray[0].ToString()),
                dr.Rows[0].ItemArray[1].ToString(),
                int.Parse(dr.Rows[0].ItemArray[3].ToString()),
                int.Parse(dr.Rows[0].ItemArray[4].ToString()) == 0 ? false : true);

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


        // Загрузка формы
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
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
