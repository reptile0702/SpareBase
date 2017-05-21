using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm(this);
            reg.ShowDialog();
        }

        private void Authentification()
        {
            DataTable dr = DatabaseWorker.SqlSelectQuery("SELECT id, Login, Password, OrganizationId, Admin FROM Accounts WHERE(Login='" + tbLogIn.Text + "')");
            if (dr.Rows.Count != 0)
            {
                if (dr.Rows[0].ItemArray[1].ToString() != tbLogIn.Text)
                {
                    MessageBox.Show("Пользователь с таким логином не зарегистрирован");
                    return;
                }

            }

            if (dr.Rows[0].ItemArray[2].ToString() != tbPassword.Text)
            {
                MessageBox.Show("Не верно введён пароль");
                return;
            }
            InitializeMainForm(
                int.Parse(dr.Rows[0].ItemArray[0].ToString()),
                dr.Rows[0].ItemArray[1].ToString(),
                int.Parse(dr.Rows[0].ItemArray[3].ToString()),
                int.Parse(dr.Rows[0].ItemArray[4].ToString()) == 0 ? false : true);
            
        }
        public void InitializeMainForm(int id, string login, int organizationId, bool admin)
        {
            EnteredUser.id = id;
            EnteredUser.LogIn = login;
            EnteredUser.OrganizationId = organizationId;
            EnteredUser.Admin = admin;

            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Authentification();

        }

    }
}
