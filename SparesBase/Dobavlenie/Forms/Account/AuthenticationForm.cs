using System;
using System.Data;
using System.IO;
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
            tf1 = new TestForm();
            tf2 = new TestForm();
        }

        #region Методы

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

        // Выход из аккаунта
        public void AccountExit()
        {
            tbLogIn.Clear();
            tbPassword.Clear();
            tbLogIn.Select();

            EnteredUser.id = 0;
            EnteredUser.LogIn = "";
            EnteredUser.OrganizationId = 0;
            EnteredUser.Admin = false;
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
            //tf2.Show();
            bwUpdater.RunWorkerAsync();
            tf1.Show();
            
        }

        // Клик на кнопку "Вход"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Authentification();
        }

        TestForm tf1;
        TestForm tf2;

        // Отдельный поток
        private void bwUpdater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            File.Delete("Version.xml");

            // Загрузка Version.xml
            WebClient wcVersion = new WebClient();
            wcVersion.DownloadFileCompleted += WcVersion_DownloadFileCompleted;
            wcVersion.DownloadProgressChanged += WcVersion_DownloadProgressChanged;
            wcVersion.DownloadFileAsync(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Client/Versions/CurrentVersion/Version.xml"), "Version.xml");
            
            

            // Загрузка Banners.xml
            WebClient wcBanners = new WebClient();
            wcBanners.DownloadFileCompleted += WcBanners_DownloadFileCompleted;
            wcBanners.DownloadFileAsync(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Banners/Banners.xml"), "Banners/Banners.xml");
        }

        private void WcVersion_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }

        // Вызывается, когда загрузится файл Banners.xml
        private void WcBanners_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Создание папки Banners если ее нет
            if (!Directory.Exists("Banners"))
                Directory.CreateDirectory("Banners");
            
            // Загрузка баннеров, которых нет на компьютере
            string[] images = FtpManager.GetFilesFromServer("Banners");
            foreach (string img in images)
            {
                if (!FolderBannerCheck(img))
                {
                    WebClient webclient = new WebClient();
                    webclient.DownloadProgressChanged += Webclient_DownloadProgressChanged;
                    webclient.DownloadFileAsync(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Banners/" + img), "Banners/" + img);
                }                
            }

            // Удаление всех старых баннеров
            DirectoryInfo di = new DirectoryInfo("Banners");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
                if (file.Name != "Banners.xml")
                    if (!FileChecking(file.Name))
                        file.Delete();
        }

        private void Webclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (tf1.IsHandleCreated)
            {
                tf1.Invoke(new Action(() =>
                {

                    tf1.progressBar.Maximum = 1;
                    tf1.progressBar.Value = 1 / (int)e.BytesReceived;
                    tf1.label1.Text = (e.BytesReceived / 1000).ToString();
                }));
            }
        }

        void AddProgress(string text)
        {
            tf1.label1.Text = text;
        }

        // Вызывается, когда загрузится файл Version.xml
        private void WcVersion_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
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

        #endregion События
    }
}
