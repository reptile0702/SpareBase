﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class UpdateProgramForm : Form
    {
        private string newVersionChecksum;
        private WebClient webClient;

        #region Конструкторы

        // Конструктор
        public UpdateProgramForm(string version, string date, string changeLog, string newVersionChecksum)
        {
            InitializeComponent();
            this.newVersionChecksum = newVersionChecksum;

            webClient = new WebClient();
            webClient.DownloadFileCompleted += Webcl_DownloadFileCompleted;

            lVersion.Text = "Доступна новая версия: " + version;
            rtbChangeLog.Text = "Дата: " + date + "\n";
            rtbChangeLog.Text += "Изменения:\n" + changeLog;
        }

        #endregion Конструкторы



        #region Методы

        private void DownloadFile()
        {
            // Загрузка новой версии программы
            webClient.DownloadFileAsync(new Uri(FtpManager.FtpConnectString + "Client/Versions/CurrentVersion/SparesBase.exe"), "SparesBase.update");
        }

        #endregion Методы



        #region События

        // Клик на кнопку ОК
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Загрузка файла Updater.exe если его нет на компьютере
            if (!File.Exists("Updater.exe"))
                webClient.DownloadFile(new Uri(FtpManager.FtpConnectString + "Updater.exe"), "Updater.exe");

            DownloadFile();
        }

        // Загрузка новой версии программы завершена
        private void Webcl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Проверка целостности файла обновления
            if (!MD5hash.VerifyMD5FileChecksum("SparesBase.update", newVersionChecksum))
            {
                DownloadFile();
                return;
            }

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
