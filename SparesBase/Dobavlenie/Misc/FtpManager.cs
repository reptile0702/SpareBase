using System.Collections.Generic;
using BytesRoad.Net.Ftp;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SparesBase
{
    class FtpManager
    {
        // Данные об FTP сервере
        static int timeout = 30000;
        static int port = 21;
        static string server = "status.nvhost.ru";
        static string username = "sh61018001";
        static string password = "lfybkrf";
        static string photosPath = "SparesBase/Photos/";
        static string remotePath = "SparesBase/";
        static FtpClient client;
        static string photosString = "Photos/";

        // Коннект к серверу
        private static void Connect()
        {
            client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);
        }


        #region Методы

        // Загрузка фото на сервер
        public static void UploadImages(Image[] images, int id)
        {
            Connect();

            // Проверка на количество загружаемых фоток
            byte imagesCounter = 0;
            for (int i = 0; i < images.Length; i++)
                if (images[i] != null)
                    imagesCounter++;

            if (imagesCounter != 0)
            {
                // Поиск папки с предметом, если ее нет, то создать
                string[] folders = GetFilesFromServer(photosString);
                string createFolder = "";
                for (int i = 0; i < folders.Length; i++)
                    if (folders[i] == "item_" + id)
                        createFolder = folders[i];

                if (createFolder == "")
                    client.CreateDirectory(timeout, photosPath + "item_" + id);
                else
                {
                    // Удаление всех фоток до загрузки новых
                    string[] photos = GetFilesFromServer(photosString + "item_" + id);
                    for (int i = 0; i < photos.Length; i++)
                        client.DeleteFile(timeout, photosPath + "item_" + id + "/" + photos[i]);
                }

                // Cоздание временной папки 
                Directory.CreateDirectory(Application.StartupPath + "/Temp/");

                Image previewImage;

                bool pCreated = false;

                // Загрузка фото
                for (int i = 0; i < images.Length; i++)
                {
                    if (images[i] != null)
                    {
                        if (!pCreated)
                        {
                            previewImage = ResizeImage(images[i], 200, 200);
                            previewImage.Tag = photosPath + "item_" + id + "/preview.jpg";
                            previewImage.Save(Application.StartupPath + "/Temp/" + Path.GetFileName(previewImage.Tag.ToString()));
                            byte[] previewBytes = File.ReadAllBytes(Application.StartupPath + "/Temp/" + Path.GetFileName(previewImage.Tag.ToString()));
                            client.PutFile(timeout, previewImage.Tag.ToString(), previewBytes, 0, previewBytes.Length);
                            pCreated = true;
                        }

                        Image resizedImage = ResizeImage(images[i], 400, 400);
                        resizedImage.Tag = photosPath + "item_" + id + "/" + (i + 1) + ".jpg";
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
                string[] photos = GetFilesFromServer(photosString + "item_" + id);
                for (int i = 0; i < photos.Length; i++)
                    client.DeleteFile(timeout, photosPath + "item_" + id + "/" + photos[i]);

                // Удаление директории предмета
                client.DeleteDirectory(timeout, photosPath + "item_" + id);
            }
        }

        // Загрузка фото с сервера
        public static Image[] DownloadImages(int id)
        {
            string folderName = "";
            Image[] images = new Image[5];

            // Проверка на существование папки предмета.
            string[] names = GetFilesFromServer(photosString);
            for (int i = 0; i < names.Length; i++)
                if (names[i] == "item_" + id)
                    folderName = names[i];

            if (folderName != "")
            {
                Connect();

                string[] imgName = GetFilesFromServer(photosString + folderName); 

                for (int i = 0; i < imgName.Length; i++)
                {
                    if (imgName[i] != "preview.jpg")
                    {
                        byte[] imageBytes = client.GetFile(timeout, photosPath + folderName + "/" + imgName[i]);
                        MemoryStream memoryStream = new MemoryStream(imageBytes);
                        Image img = Image.FromStream(memoryStream);
                        string imageIndex = imgName[i][0].ToString();
                        img.Tag = photosPath + folderName + "/" + imgName[i];
                        images[int.Parse(imageIndex) - 1] = img;
                    }
                }
                client.Disconnect(timeout);
                return images;
            }
            else
                return images;
        }

        // Загрузка превью-фото
        public static Image DownloadPreviewImage(int id)
        {
            Connect();

            // поиск папки предмета
            string[] folders = GetFilesFromServer(photosString);
            string folder = "";
            for (int i = 0; i < folders.Length; i++)
                if (folders[i] == "item_" + id)
                {
                    folder = folders[i];
                    break;
                }

            if (folder != "")
            {
                string[] files = GetFilesFromServer(photosString + folder);
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
                    byte[] imageBytes = client.GetFile(timeout, photosPath + folder + "/" + file);
                    MemoryStream memoryStream = new MemoryStream(imageBytes);
                    return Image.FromStream(memoryStream);
                }
            }

            return null;
        }

        public static bool PreviewExists(int itemid)
        {
            string[] folders = GetFilesFromServer("Photos/");
            foreach (string folder in folders)           
                if (folder == "item_" + itemid)               
                    return true;
                          
            return false;
        }

        // Удаление картинок предмета и его папки
        public static void DeleteItemImages(int id)
        {
            Connect();

            // Поиск папки предмета 
            string[] folders = GetFilesFromServer(photosString);
            string folder = "";
            for (int i = 0; i < folders.Length; i++)
                if (folders[i] == "item_" + id)
                {
                    folder = folders[i];
                    break;
                }

            if (folder != "")
            {
                // Удаление всех фото 
                string[] files = GetFilesFromServer(photosString + folder);
                for (int i = 0; i < files.Length; i++)
                    if (files[i] != "." && files[i] != "..")
                        client.DeleteFile(timeout, photosPath + "item_" + id + "/" + files[i]);

                // удаление папки предмета
                client.DeleteDirectory(timeout, photosPath + "item_" + id);
            }
        }

        #endregion Методы


        #region Вспомогательные методы

        // Получение файлов с сервера по определенному пути
        public static string[] GetFilesFromServer(string path)
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);

            FtpItem[] files = client.GetDirectoryList(timeout, remotePath + path);
            client.Disconnect(timeout);
            List<string> names = new List<string>();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name != "." && files[i].Name != "..")
                {
                    names.Add(files[i].Name);
                }

            }
            return names.ToArray();
        }

        // Смена размера изображения
        private static Image ResizeImage(Image image, int nWidth, int nHeight)
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

        #endregion Вспомогательные методы
    }
}
