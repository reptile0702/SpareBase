﻿using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace SparesBase.Forms
{
    public partial class AuthenticationForm : Form
    {
        // Конструктор
        public AuthenticationForm()
        {
            InitializeComponent();
            bwUpdater.RunWorkerAsync();
        }
        

        // Аунтентификация
        private void Authentification()
        {
            // Проверка на допустимые символы
            if (!StringValidation.IsValid(tbLogIn.Text))
            {
                MessageBox.Show("Были введены недопустимые символы.\nРазрешены: латинские буквы, цифры _ - . @");
                return;
            }

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

        private void bwUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            //Connect();
            //client.GetFile(timeout, "SparesBase/Versions/CurrentVersion/Version.xml", Application.StartupPath);
            //client.Disconnect(timeout);
            WebClient webcl = new WebClient();
            webcl.DownloadFile(new System.Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Versions/CurrentVersion/Version.xml"), "Version.xml");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Version.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            double version = Convert.ToDouble(xRoot["Version"].InnerText.Replace(".", ""));
            double thisVersion = Convert.ToDouble(Application.ProductVersion.Replace(".", ""));
            if (thisVersion < version )
            {
                e.Result = new ProgramUpdate(xRoot["Version"].InnerText, xRoot["ChangeLog"].InnerText);
               // e.Cancel = true;
            }
           

        }

        private void bwUpdater_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bwUpdater_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            ProgramUpdate pu = (ProgramUpdate)e.Result;
            if (pu != null)
            {
                UpdateProgramForm upf = new UpdateProgramForm(pu.Version, pu.ChangeLog);
                upf.ShowDialog();
            }
            
        }
    }
}
