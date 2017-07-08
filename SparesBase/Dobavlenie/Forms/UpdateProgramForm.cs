using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class UpdateProgramForm : Form
    {
        #region Конструкторы
        
        // Конструктор
        public UpdateProgramForm(string version, string date, string changeLog)
        {
            InitializeComponent();
            lVersion.Text = "Доступна новая версия: " + version;
            rtbChangeLog.Text = "Дата: " + date + "\n";
            rtbChangeLog.Text += "Изменения:\n" + changeLog;
        }

        #endregion Конструкторы



        #region События

        // Клик на кнопку ОК
        private void btnOk_Click(object sender, EventArgs e)
        {
            WebClient webcl = new WebClient();
            webcl.DownloadFileCompleted += Webcl_DownloadFileCompleted;

            // Загрузка файла Updater.exe если его нет на компьютере
            if (!File.Exists("Updater.exe"))
                webcl.DownloadFile(new Uri(FtpManager.FtpConnectString + "Updater.exe"), "Updater.exe");
           
            // Загрузка новой версии программы
            webcl.DownloadFileAsync(new Uri(FtpManager.FtpConnectString + "Client/Versions/CurrentVersion/SparesBase.exe"), "SparesBase.update");
        }

        // Загрузка новой версии программы завершена
        private void Webcl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Запуск программы обновления
            Process.Start("Updater.exe", "SparesBase.exe SparesBase.update");

            // Закрытие текущего процесса
            Process.GetCurrentProcess().Kill();
        }

        // Закрытие формы
        private void UpdateProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Обновление обязательно, так что при закрытии данной формы закроется и вся программа
            Application.Exit();
        }

        #endregion События
    }
}
