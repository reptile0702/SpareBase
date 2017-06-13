using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class UpdateProgramForm : Form
    {
        // Конструктор
        public UpdateProgramForm(string version, string date, string changeLog)
        {
            InitializeComponent();
            lVersion.Text = "Доступна новая версия: " + version;
            rtbChangeLog.Text = "Дата: " + date + "\n";
            rtbChangeLog.Text += "Изменения:\n" + changeLog;
        }

        // Ок
        private void btnOk_Click(object sender, EventArgs e)
        {
            WebClient webcl = new WebClient();
            webcl.DownloadFileCompleted += Webcl_DownloadFileCompleted; ;
            webcl.DownloadFileAsync(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Client/Versions/CurrentVersion/SparesBase.exe"), "SparesBase.update");
        }

        // Загрузка новой версии программы завершена
        private void Webcl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start("Updater.exe", "SparesBase.exe SparesBase.update");
            Process.GetCurrentProcess().Kill();
        }

        // Закрытие формы
        private void UpdateProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
