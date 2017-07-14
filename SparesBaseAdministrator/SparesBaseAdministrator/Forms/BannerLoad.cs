using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace SparesBaseAdministrator
{
    public partial class BannerLoad : Form
    {
        private Banner SelectedBanner { get { return (Banner)tvBanners.SelectedNode.Tag; } set { tvBanners.SelectedNode.Tag = value; } }

        // Конструктор
        public BannerLoad()
        {
            InitializeComponent();
        }


        #region Методы

        // Добавление баннера из файла картинки
        private void AddBanner()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Banner banner = new Banner(open.SafeFileName, "", Image.FromFile(open.FileName), MD5hash.GetMD5FileChecksum(open.FileName));
                TreeNode node = new TreeNode(banner.PhotoName);
                node.Tag = banner;
                tvBanners.Nodes.Add(node);
            }
        }

        // Удаление баннера
        private void RemoveBanner()
        {
            pbBanner.Image = null;
            tbLink.Text = "";
            tvBanners.SelectedNode.Remove();
        }

        // Загрузка баннеров с сервера
        private void DownloadBanners()
        {
            FtpManager.DownloadBannersFile();

            XmlDocument banners = new XmlDocument();
            banners.Load("Banners.xml");
            XmlElement element = banners.DocumentElement;
            foreach (XmlNode node in element.ChildNodes)
            {
                Banner ban = new Banner(node["PhotoName"].Attributes["value"].Value, node["Link"].Attributes["value"].Value, FtpManager.DownloadBannerImage(node["PhotoName"].Attributes["value"].Value), node["Checksum"].Attributes["value"].Value);
                TreeNode tn = new TreeNode(ban.PhotoName);
                tn.Tag = ban;
                tvBanners.Nodes.Add(tn);
            }
        }

        // Загрузка баннеров на сервер
        private void UploadBannersToServer()
        {
            List<Banner> banners = new List<Banner>();
            foreach (TreeNode node in tvBanners.Nodes)
                banners.Add((Banner)node.Tag);

            FtpManager.UploadBanners(banners.ToArray());

            MessageBox.Show("Баннеры были успешно загружены на сервер");
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void BannerLoad_Load(object sender, EventArgs e)
        {
            DownloadBanners();
        }

        // Добавление баннера
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            AddBanner();
        }

        // Удаление баннера
        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            RemoveBanner();
        }

        // Выбор баннера в TreeView
        private void tvBanners_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tbLink.Text = SelectedBanner.Link;
            pbBanner.Image = SelectedBanner.Image;
        }

        // Выход из фокуса TextBox'а
        private void tbLink_Leave(object sender, EventArgs e)
        {
            SelectedBanner.Link = tbLink.Text;
        }

        // ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                UploadBannersToServer();
                Close();
            }
            catch (Exception) {}
        }

        // Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
