using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BytesRoad.Net.Ftp;
using System.IO;

namespace SparesBase
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

        public Image[] Images { get { return images; } }
        #region Конструкторы


        public PhotoEditor()
        {
            InitializeComponent();
            images = new Image[5];
        }

        public PhotoEditor(int id)
        {
            InitializeComponent();
            this.id = id;
            images = FtpManager.DownloadImages(id);
        }

        #endregion Конструкторы


        #region Методы

      
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
            //int selectedImage = int.Parse(lbImages.SelectedItem.ToString()[12].ToString());
            //FtpManager.UploadImages(images, id);
            DialogResult = DialogResult.OK;
            
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
