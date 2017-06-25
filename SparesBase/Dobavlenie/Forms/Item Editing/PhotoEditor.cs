using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SparesBase
{
    public partial class PhotoEditor : Form
    {
        // Фотографии
        Image[] images;

        // ID предмета
        private int id;


        private int counter;
        private int imagesCount;

        public Image[] Images { get { return images; } }


        #region Конструкторы

        // Конструктор для добавления предмета
        public PhotoEditor()
        {
            InitializeComponent();
            images = new Image[5];
        }

        // Конструктор для редактирования предмета
        public PhotoEditor(int id)
        {
            InitializeComponent();
            this.id = id;
            images = new Image[5];
            
            string[] photos = FtpManager.DownloadImages(id);

            counter = 0;
            imagesCount = photos.Length;
            if (imagesCount > 0)
            {
                pbPreview.SizeMode = PictureBoxSizeMode.CenterImage;
                pbPreview.Image = Properties.Resources.LoadGif;
                btnBrowseImg.Enabled = false;
                btnClearImg.Enabled = false;
                btnOk.Enabled = false;
                lbImages.Enabled = false;
            }

            foreach (string photo in photos)
            {
                WebClient webclient = new WebClient();
                webclient.DownloadDataCompleted += Webclient_DownloadDataCompleted;
                webclient.DownloadDataAsync(new Uri("ftp://u0183148:W5iLVaY9@server137.hosting.reg.ru/www/xn--29-nmcu.xn--p1ai/SparesBase/Photos/" + "item_" + id + "/" + photo), photo);
            }
        }

        private void Webclient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            
            MemoryStream memoryStream = new MemoryStream(e.Result);
            Image img = Image.FromStream(memoryStream);
            string imageIndex = e.UserState.ToString()[0].ToString();
            img.Tag = "SparesBase/Photos/" + "item_" + id + "/" + e.UserState.ToString();
            images[int.Parse(imageIndex) - 1] = img;
            counter++;
            if (counter == imagesCount)
            {
                pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                lbImages.SelectedIndex = 0;
                btnBrowseImg.Enabled = true;
                btnClearImg.Enabled = true;
                btnOk.Enabled = true;
                lbImages.Enabled = true;
            }
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
                img.Tag = "Photos/item_" + id + "/" + selectedImage + fileExtension;
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
