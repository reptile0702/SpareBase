using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BytesRoad.Net.Ftp;
using System.IO;

namespace SparesBaseAdministrator
{
    public partial class PhotoEditor : Form
    {
        // Данные об FTP сервере
        int timeout = 30000;
        int port = 21;
        string server = "status.nvhost.ru";
        string username = "sh61018001";
        string password = "lfybkrf";
        string remotePath = "Photos/";

        // Фотографии
        Image[] images;

        // ID предмета
        private int id;

        #region Конструкторы


        public PhotoEditor(int id, bool preview)
        {
            InitializeComponent();
            this.id = id;
        }

        public PhotoEditor(int id)
        {
            InitializeComponent();
            this.id = id;
            images = DownloadImages(id);
        }

        #endregion Конструкторы


        #region Методы

        // Загрузка превью-фото
        public Image DownloadPreviewImage()
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);

            string[] folders = GetFilesFromServer("");
            string folder = "";
            for (int i = 0; i < folders.Length; i++)
                if (folders[i] == "item_" + id)
                {
                    folder = folders[i];
                    break;
                }

            if (folder != "")
            {
                string[] files = GetFilesFromServer(folder);
                string file = "";
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] == "preview.jpg")
                    {
                        file = files[i];
                        break;
                    }
                }

                if (file != "")
                {
                    byte[] imageBytes = client.GetFile(timeout, remotePath + folder + "/" + file);
                    MemoryStream memoryStream = new MemoryStream(imageBytes);
                    return Image.FromStream(memoryStream);
                }
            }

            return null;
        }

        // Удаление картинок предмета и его папки
        public void DeleteItemImages()
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);

            string[] folders = GetFilesFromServer("");
            string folder = "";
            for (int i = 0; i < folders.Length; i++)
                if (folders[i] == "item_" + id)
                {
                    folder = folders[i];
                    break;
                }

            if (folder != "")
            {
                string[] files = GetFilesFromServer(folder);
                for (int i = 0; i < files.Length; i++)
                    if (files[i] != "." && files[i] != "..")
                        client.DeleteFile(timeout, remotePath + "item_" + id + "/" + files[i]);

                client.DeleteDirectory(timeout, remotePath + "item_" + id);
            }
        }

        // Загрузка фото на сервер
        private void UploadImages()
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);

            // Проверка на количество загружаемых фоток
            byte imagesCounter = 0;
            for (int i = 0; i < images.Length; i++)
                if (images[i] != null)
                    imagesCounter++;

            if (imagesCounter != 0)
            {
                // Поиск папки с предметом, если ее нет, то создать
                string[] folders = GetFilesFromServer("");
                string createFolder = "";
                for (int i = 0; i < folders.Length; i++)
                    if (folders[i] == "item_" + id)
                        createFolder = folders[i];

                if (createFolder == "")
                    client.CreateDirectory(timeout, remotePath + "item_" + id);
                else
                {
                    // Удаление всех фоток до загрузки новых
                    string[] photos = GetFilesFromServer("item_" + id);
                    for (int i = 0; i < photos.Length; i++)
                        client.DeleteFile(timeout, remotePath + "item_" + id + "/" + photos[i]);
                }

                // Cоздание временной папки 
                Directory.CreateDirectory(Application.StartupPath + "/Temp/");

                Image previewImage;

                // Загрузка фото
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i] != null)
                    {
                        if (i == 0)
                        {
                            previewImage = ResizeImage(images[i], 200, 200);
                            previewImage.Tag = remotePath + "item_" + id + "/preview.jpg";
                            previewImage.Save(Application.StartupPath + "/Temp/" + Path.GetFileName(previewImage.Tag.ToString()));
                            byte[] previewBytes = File.ReadAllBytes(Application.StartupPath + "/Temp/" + Path.GetFileName(previewImage.Tag.ToString()));
                            client.PutFile(timeout, previewImage.Tag.ToString(), previewBytes, 0, previewBytes.Length);
                        }

                        Image resizedImage = ResizeImage(images[i], 400, 400);
                        resizedImage.Tag = images[i].Tag;
                        resizedImage.Save(Application.StartupPath + "/Temp/" + Path.GetFileName(resizedImage.Tag.ToString()));
                        byte[] bytes = File.ReadAllBytes(Application.StartupPath + "/Temp/" + Path.GetFileName(resizedImage.Tag.ToString()));
                        client.PutFile(timeout, resizedImage.Tag.ToString(), bytes, 0, bytes.Length);
                    }
                }

                client.Disconnect(timeout);

                // Удаление временных файлов
                string[] files = Directory.GetFiles(Application.StartupPath + "/Temp/");
                for (int i = 0; i < files.Length; i++)
                    File.Delete(files[i]);

                // Удаление временной папки
                Directory.Delete(Application.StartupPath + "/Temp/");
            }
            else
            {
                // Удаление всех фоток из папки
                string[] photos = GetFilesFromServer("item_" + id);
                for (int i = 0; i < photos.Length; i++)
                    client.DeleteFile(timeout, remotePath + "item_" + id + "/" + photos[i]);

                // Удаление директории предмета
                client.DeleteDirectory(timeout, remotePath + "item_" + id);
            }
        }

        // Загрузка фото с сервера
        private Image[] DownloadImages(int id)
        {
            string folderName = "";
            Image[] images = new Image[5];
            string[] names = GetFilesFromServer("");
            for (int i = 0; i < names.Length; i++)
                if (names[i] == "item_" + id)
                    folderName = names[i];

            if (folderName != "")
            {
                FtpClient client = new FtpClient();
                client.PassiveMode = true;
                client.Connect(timeout, server, port);
                client.Login(timeout, username, password);

                string[] imgName = GetFilesFromServer(folderName);

                for (int i = 0; i < imgName.Length; i++)
                {
                    if (imgName[i] == "preview.jpg")
                    {
                        byte[] imageBytes = client.GetFile(timeout, remotePath + folderName + "/" + imgName[i]);
                        MemoryStream memoryStream = new MemoryStream(imageBytes);
                        Image img = Image.FromStream(memoryStream);
                        string imageIndex = imgName[i][0].ToString();
                        img.Tag = remotePath + folderName + "/" + imgName[i];
                        images[int.Parse(imageIndex) - 1] = img;
                    }
                }
                client.Disconnect(timeout);
                return images;
            }
            else
                return images;
        }

        // Обновление PictureBox
        private void UpdatePicture()
        {
            int selectedImage = int.Parse(lbImages.SelectedItem.ToString()[12].ToString());
            if (images[selectedImage - 1] != null)
            {
                pbPreview.Image = images[selectedImage - 1];
                btnClearImg.Enabled = true;
            }
            else
            {
                pbPreview.Image = null;
                btnClearImg.Enabled = false;
            }
        }

        // Получение файлов с сервера по определенному пути
        private string[] GetFilesFromServer(string path)
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);

            FtpItem[] files = client.GetDirectoryList(timeout, remotePath + path);
            client.Disconnect(timeout);
            string[] names = new string[files.Length];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = files[i].Name;
            }
            return names;
        }

        // Смена размера изображения
        public Image ResizeImage(Image image, int nWidth, int nHeight)
        {
            int newWidth, newHeight;
            var coefH = (double)nHeight / (double)image.Height;
            var coefW = (double)nWidth / (double)image.Width;
            if (coefW >= coefH)
            {
                newHeight = (int)(image.Height * coefH);
                newWidth = (int)(image.Width * coefH);
            }
            else
            {
                newHeight = (int)(image.Height * coefW);
                newWidth = (int)(image.Width * coefW);
            }

            Image result = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(image, 0, 0, newWidth, newHeight);
                g.Dispose();
            }
            return result;
        }

        #endregion Методы


        #region События

        // Назначить
        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений| *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int selectedImage = int.Parse(lbImages.SelectedItem.ToString()[12].ToString());
                Image img = Image.FromFile(ofd.FileName);
                string fileExtension = Path.GetExtension(ofd.FileName);
                img.Tag = remotePath + "item_" + id + "/" + selectedImage + fileExtension;
                images[selectedImage - 1] = img;
                UpdatePicture();
            }
        }

        // Очистить
        private void btnClearImg_Click(object sender, EventArgs e)
        {
            int selectedImage = int.Parse(lbImages.SelectedItem.ToString()[12].ToString());
            images[selectedImage - 1] = null;
            UpdatePicture();
        }

        // ОК
        private void btnOk_Click(object sender, EventArgs e)
        {
            UploadImages();
            Close();
        }

        // Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Смена изображения в ListBox
        private void lbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePicture();
        }

        #endregion События
    }
}
