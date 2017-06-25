using System;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace SparesBaseAdministrator
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

            // Проверка логина
            if (tbLogIn.Text != "1")
            {
                MessageBox.Show("Пользователь с таким логином не зарегистрирован");
                return;
            }

            // Проверка пароля
            if (tbPassword.Text != "1")
            {
                MessageBox.Show("Не верно введён пароль");
                return;
            }

            // Инициализация формы
            InitializeForm();
        }

        // Инициализация аккаунта
        public void InitializeForm()
        {
            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }


        // Клик на кнопку "Вход"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Authentification();
        }

        private void bwUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            File.Delete("Version.xml");

            WebClient webcl = new WebClient();
            webcl.DownloadFileCompleted += Webcl_DownloadFileCompleted;
            webcl.DownloadFileAsync(new Uri("ftp://u0183148:W5iLVaY9@server137.hosting.reg.ru/www/xn--29-nmcu.xn--p1ai/SparesBase/Admin/Versions/CurrentVersion/Version.xml"), "Version.xml");
        }

        private void Webcl_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Version.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            File.Delete("Version.xml");

            double remoteVersion = Convert.ToDouble(xRoot["Version"].InnerText.Replace(".", ""));
            double thisVersion = Convert.ToDouble(Application.ProductVersion.Replace(".", ""));
            if (thisVersion < remoteVersion)
            {
                UpdateProgramForm upf = new UpdateProgramForm(xRoot["Version"].InnerText, xRoot["Date"].InnerText, xRoot["ChangeLog"].InnerText);
                upf.ShowDialog();
            }
        }
    }
}
