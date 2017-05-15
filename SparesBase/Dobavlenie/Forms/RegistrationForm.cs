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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        
        private void ToRegister()
        {
            

            if (tbName.Text == "" ||
                tbSecondName.Text == "" ||
                tbLastName.Text == "" ||
                tbLogIn.Text == "" ||
                tbPassword.Text == "" ||
                tbSecondPassword.Text == "")                
            {
                MessageBox.Show("Не все поля были заполнены");
                return;
            }

            if (tbPassword.Text != tbSecondPassword.Text)
            {
                MessageBox.Show("Не совпадают введенные пароли");
                return;
            }

           
            if (DatabaseWorker.SqlScalarQuery("SELECT Login FROM Accounts WHERE(Login='" + tbLogIn.Text + "')") != null)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                return;
            }

            DatabaseWorker.SqlQuery("INSERT INTO Accounts VALUES('','" + tbName.Text + "', '" + tbSecondName.Text + "', '" + tbLastName.Text + "', '" + tbLogIn.Text + "', '" + tbPassword.Text + "', 0)");
        }



        private void btnFinishRegistration_Click(object sender, EventArgs e)
        {
            ToRegister();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
