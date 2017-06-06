using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class AuthenticationForm : Form
    {
        // Конструктор
        public AuthenticationForm()
        {
            InitializeComponent();
        }
        

        // Аунтентификация
        private void Authentification()
        {
            DataTable dr = DatabaseWorker.SqlSelectQuery("SELECT id, Login, Password, OrganizationId, Admin FROM Accounts WHERE(Login='" + tbLogIn.Text + "')");

            // Проверка на существование введенного логина в базе
            if (dr.Rows.Count != 0)
            {
                if (dr.Rows[0].ItemArray[1].ToString() != tbLogIn.Text.Trim())
                {
                    MessageBox.Show("Пользователь с таким логином не зарегистрирован");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином не зарегистрирован");
                return;
            }

            // Проверка пароля
            if (dr.Rows[0].ItemArray[2].ToString() != tbPassword.Text.Trim())
            {
                MessageBox.Show("Не верно введён пароль");
                return;
            }

            // зарегистрирован ли данный аккаунт в какой-либо организации
            if (dr.Rows[0].ItemArray[3].ToString() == "0")
            {
                MessageBox.Show("Данный аккаунт не зарегистрирован ни в одной из организаций.");
                return;
            }

            // Инициализация аккаунта
            InitializeAccount(
                int.Parse(dr.Rows[0].ItemArray[0].ToString()),
                dr.Rows[0].ItemArray[1].ToString(),
                int.Parse(dr.Rows[0].ItemArray[3].ToString()),
                int.Parse(dr.Rows[0].ItemArray[4].ToString()) == 0 ? false : true);
        }

        // Инициализация аккаунта
        public void InitializeAccount(int id, string login, int organizationId, bool admin)
        {
            EnteredUser.id = id;
            EnteredUser.LogIn = login;
            EnteredUser.OrganizationId = organizationId;
            EnteredUser.Admin = admin;

            MainForm mf = new MainForm(this);
            mf.Show();
            Hide();
        }


        // Клик на кнопку "Вход"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Authentification();
        }

        // Клик на кнопку "Регистрация"
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm(this);
            reg.ShowDialog();
        }

        public void InitializeForm()
        {
            tbLogIn.Clear();
            tbPassword.Clear();
            tbLogIn.Select();

            EnteredUser.id = 0;
            EnteredUser.LogIn = "";
            EnteredUser.OrganizationId = 0;
            EnteredUser.Admin = false;

        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
          
        }
    }
}
