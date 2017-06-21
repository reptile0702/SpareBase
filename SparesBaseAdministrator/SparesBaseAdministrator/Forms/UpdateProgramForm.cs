using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class UpdateProgramForm : Form
    {
        public UpdateProgramForm(string version, string date, string changeLog)
        {
            InitializeComponent();
            lVersion.Text = "Доступна новая версия: " + version;
            rtbChangeLog.Text = "Дата: " + date + "\n";
            rtbChangeLog.Text += "Изменения:\n" + changeLog;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WebClient webcl = new WebClient();
            webcl.DownloadFileCompleted += Webcl_DownloadFileCompleted; ;
            webcl.DownloadFileAsync(new System.Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru//SparesBase/Admin/Versions/CurrentVersion/SparesBaseAdministrator.exe"), "SparesBaseAdministrator.update");
        }

        private void Webcl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start("Updater.exe", "SparesBaseAdministrator.exe SparesBaseAdministrator.update");
            Process.GetCurrentProcess().Kill();
        }

        private void UpdateProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
