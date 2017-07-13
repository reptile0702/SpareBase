using System;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace SparesBase.Forms
{
    public partial class AuthenticationForm : Form
    {
        // Конструктор
        public AuthenticationForm()
        {
            InitializeComponent();

            // Настройки
            Settings.CreateConfigsFile();
            Settings.LoadSettings();

            // Записывание последнего логина из реестра
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey lastUserKey = currentUserKey.OpenSubKey("SparesBase");
            if (lastUserKey != null)
            {
                tbLogin.Text = lastUserKey.GetValue("Login").ToString();
                lastUserKey.Close();
                tbPassword.Select();
            }
        }

        #region Методы

        // Аунтентификация
        private void Authentification()
        {
            // Проверка на допустимые символы
            if (!StringValidation.IsValid(tbLogin.Text))
            {
                MessageBox.Show("Были введены недопустимые символы.\nРазрешены: латинские буквы, цифры _ - . @");
                return;
            }

            DataTable account = DatabaseWorker.SqlSelectQuery("SELECT " +
                "a.id, " +
                "a.FirstName, " +
                "a.LastName, " +
                "a.SecondName, " +
                "a.Login, " +
                "a.Password, " +
                "o.id, " +
                "o.Name, " +
                "o.Site, " +
                "o.Telephone, " +
                "oc.City, " +
                "ac.City, " +
                "a.Phone, " +
                "a.Email, " +
                "a.Admin " +
                "FROM Accounts a " +
                "LEFT JOIN Organizations o ON o.id = a.OrganizationId " +
                "LEFT JOIN Cities ac ON ac.id = a.CityId " +
                "LEFT JOIN Cities oc ON oc.id = o.CityId " +
                "WHERE(Login = '" + tbLogin.Text + "')");

            // Проверка на существование введенного логина в базе
            if (account.Rows.Count != 0)
            {
                if (account.Rows[0].ItemArray[4].ToString() != tbLogin.Text.Trim())
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
            if (!MD5hash.VerifyMD5Hash(tbPassword.Text.Trim(), account.Rows[0].ItemArray[5].ToString()))
            {
                MessageBox.Show("Неверно введён пароль");
                return;
            }

            // Проверка на привязку аккаунта к какой либо организации
            if (account.Rows[0].ItemArray[3].ToString() == "0")
            {
                MessageBox.Show("Данный аккаунт не зарегистрирован ни в одной из организаций.");
                return;
            }

            // Инициализация аккаунта
            InitializeAccount(
                new Account(
                    int.Parse(account.Rows[0].ItemArray[0].ToString()),
                    account.Rows[0].ItemArray[1].ToString(),
                    account.Rows[0].ItemArray[2].ToString(),
                    account.Rows[0].ItemArray[3].ToString(),
                    account.Rows[0].ItemArray[4].ToString(),
                    new Organization(
                        int.Parse(account.Rows[0].ItemArray[6].ToString()),
                        account.Rows[0].ItemArray[7].ToString(),
                        account.Rows[0].ItemArray[8].ToString(),
                        account.Rows[0].ItemArray[9].ToString(),
                        account.Rows[0].ItemArray[10].ToString()),
                    account.Rows[0].ItemArray[11].ToString(),
                    account.Rows[0].ItemArray[12].ToString(),
                    account.Rows[0].ItemArray[13].ToString(),
                    account.Rows[0].ItemArray[14].ToString() == "1" ? true : false));  
        }

        // Инициализация аккаунта
        public void InitializeAccount(Account account)
        {
            // Инициализация полей для статического класса
            EnteredUser.Id = account.Id;

            EnteredUser.FirstName = account.FirstName;
            EnteredUser.LastName = account.LastName;
            EnteredUser.SecondName = account.SecondName;

            EnteredUser.Login = account.Login;
            EnteredUser.Organization = account.Organization;

            EnteredUser.City = account.City;
            EnteredUser.Phone = account.Phone;
            EnteredUser.Email = account.Email;

            EnteredUser.Admin = account.Admin;

            // Записывание введенного логина в реестр
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey lastUserKey = currentUserKey.CreateSubKey("SparesBase");
            lastUserKey.SetValue("Login", EnteredUser.Login);
            lastUserKey.Close();

            // Открытие главной формы
            MainForm mf = new MainForm(this);
            mf.Show();
            Hide();
        }

        // Выход из аккаунта
        public void AccountExit()
        {
            tbLogin.Clear();
            tbPassword.Clear();
            tbLogin.Select();

            EnteredUser.Id = 0;

            EnteredUser.FirstName = "";
            EnteredUser.LastName = "";
            EnteredUser.SecondName = "";

            EnteredUser.Login = "";
            EnteredUser.Organization = null;

            EnteredUser.City = "";
            EnteredUser.Phone = "";
            EnteredUser.Email = "";

            EnteredUser.Admin = false;
        }

        // Загрузка файлов XML для проверки версий и баннеров
        private void LoadXml()
        {
            // Загрузка Version.xml
            WebClient wcVersion = new WebClient();
            wcVersion.DownloadFileCompleted += WcVersion_DownloadFileCompleted;
            wcVersion.DownloadFileAsync(new Uri(FtpManager.FtpConnectString + "Client/Versions/CurrentVersion/Version.xml"), "Version.xml");

            // Загрузка Banners.xml
            WebClient wcBanners = new WebClient();
            wcBanners.DownloadFileCompleted += WcBanners_DownloadFileCompleted;
            wcBanners.DownloadFileAsync(new Uri(FtpManager.FtpConnectString + "Banners/Banners.xml"), "Banners/Banners.xml");
        }

        #endregion Методы



        #region Вспомогательные методы

        // Проверка: есть ли фото с данным именем в папке Banners
        private bool FolderBannerCheck(string fileName)
        {
            DirectoryInfo di = new DirectoryInfo("Banners");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
                if (file.Name == fileName)
                    return true;

            return false;
        }

        // Проверка: есть ли фото с данным именем в файле Banners.xml
        private bool FileChecking(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Banners/Banners.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode node in xRoot.ChildNodes)
                if (node["PhotoName"].Attributes["value"].Value == fileName)
                    return true;

            return false;
        }

        #endregion Вспомогательные методы



        #region События

        // Загрузка формы
        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            // Удаление файла версии
            File.Delete("Version.xml");

            LoadXml();
        }

        // Клик на кнопку "Вход"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Authentification();
        }

        // Вызывается, когда загрузится файл Banners.xml
        private void WcBanners_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Создание папки Banners если ее нет
            if (!Directory.Exists("Banners"))
                Directory.CreateDirectory("Banners");

            // Удаление всех старых баннеров
            DirectoryInfo di = new DirectoryInfo("Banners");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
                if (file.Name != "Banners.xml")
                    if (!FileChecking(file.Name) || file.Length <= 0)
                        file.Delete();

            // Загрузка баннеров, которых нет на компьютере
            string[] images = FtpManager.GetFilesFromServer("Banners");
            foreach (string img in images)
            {
                if (!FolderBannerCheck(img))
                {
                    WebClient wcBanner = new WebClient();
                    wcBanner.DownloadFileAsync(new Uri(FtpManager.FtpConnectString + "Banners/" + img), "Banners/" + img);
                }                
            }
        }

        // Вызывается, когда загрузится файл Version.xml
        private void WcVersion_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Чтение файла Version.xml
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Version.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // Удаление файла Version.xml
            File.Delete("Version.xml");

            // Сравнение версий
            Version remoteVersion = new Version(xRoot["Version"].InnerText);
            Version localVersion = new Version(Application.ProductVersion);
            if (localVersion < remoteVersion)
            {
                UpdateProgramForm upf = new UpdateProgramForm(xRoot["Version"].InnerText, xRoot["Date"].InnerText, xRoot["ChangeLog"].InnerText);
                upf.ShowDialog();
            }
            else if (File.Exists("Updater.exe"))
                File.Delete("Updater.exe");
        }

        #endregion События
    }
}
