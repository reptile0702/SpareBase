using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using BytesRoad.Net.Ftp;

namespace SparesBaseAdministrator
{
    public partial class BannerLoad : Form
    {
        public BannerLoad()
        {
            InitializeComponent();
            //  bw.RunWorkerAsync();
        }
        private Banner SelectedBanner { get { return (Banner)tvBanners.SelectedNode.Tag; } set { tvBanners.SelectedNode.Tag = value; } }


        // Данные об FTP сервере
        int timeout = 30000;
        int port = 21;
        string server = "status.nvhost.ru";
        string username = "sh61018001";
        string password = "lfybkrf";
        string remotePath = "SparesBase/";
        FtpClient client;

        // Коннект к серверу
        private void Connect()
        {
            client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, server, port);
            client.Login(timeout, username, password);
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Banner banner = new Banner(open.SafeFileName, "", Image.FromFile(open.FileName));
                TreeNode node = new TreeNode(banner.PhotoName);
                node.Tag = banner;
                tvBanners.Nodes.Add(node);
            }
        }

        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            pbBanner.Image = null;
            tbLink.Text = "";
            tvBanners.SelectedNode.Remove();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            XmlDocument banners = new XmlDocument();
            banners.Load("Banners.xml");
            XmlElement element = banners.DocumentElement;

            element.RemoveAll();
            foreach (TreeNode node in tvBanners.Nodes)
            {
                Banner ban = (Banner)node.Tag;
                XmlNode bannerNode = banners.CreateElement("Banner");
                XmlNode bannerName = banners.CreateElement("PhotoName");
                XmlAttribute nameAttr = banners.CreateAttribute("value");
                nameAttr.Value = ban.PhotoName;
                bannerName.Attributes.Append(nameAttr);
                XmlNode bannerLink = banners.CreateElement("Link");
                XmlAttribute LinkAttr = banners.CreateAttribute("value");
                LinkAttr.Value = ban.Link;
                bannerLink.Attributes.Append(LinkAttr);

                bannerNode.AppendChild(bannerName);
                bannerNode.AppendChild(bannerLink);

                element.AppendChild(bannerNode);

            }
            MemoryStream mem = new MemoryStream();
            banners.Save(mem);
            Connect();
            string[] files = GetFilesFromServer("Banners/");
            foreach (string file in files)
            {
                client.DeleteFile(timeout,remotePath + "Banners/" + file);

            }
            client.PutFile(timeout, remotePath + "Banners/Banners.xml", mem.GetBuffer());
            foreach (TreeNode item in tvBanners.Nodes)
            {
                Banner ban = (Banner)item.Tag;
                MemoryStream memory = new MemoryStream();
                ban.Image.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                client.PutFile(timeout, remotePath + "Banners/" + ban.PhotoName, memory.GetBuffer()); 
            }
            client.Disconnect(timeout);

        }


        // Получение файлов с сервера по определенному пути
        private string[] GetFilesFromServer(string path)
        {

            FtpItem[] files = client.GetDirectoryList(timeout, remotePath + path);

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {


        }

        private void BannerLoad_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            wc.DownloadFile(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Banners/Banners.xml"), "Banners.xml");
            wc.Dispose();
            XmlDocument banners = new XmlDocument();
            banners.Load("Banners.xml");
            XmlElement element = banners.DocumentElement;
            foreach (XmlNode node in element.ChildNodes)
            {
                WebClient pics = new WebClient();
                byte[] imageBytes = pics.DownloadData(new Uri("ftp://sh61018001:lfybkrf@status.nvhost.ru/SparesBase/Banners/" + node["PhotoName"].Attributes["value"].Value));
                pics.Dispose();
                MemoryStream ms = new MemoryStream(imageBytes);

                Banner ban = new Banner(node["PhotoName"].Attributes["value"].Value, node["Link"].Attributes["value"].Value, Image.FromStream(ms));
                TreeNode tn = new TreeNode(ban.PhotoName);
                tn.Tag = ban;

                tvBanners.Nodes.Add(tn);
            }
        }

        private void tvBanners_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Banner banner = (Banner)tvBanners.SelectedNode.Tag;
            tbLink.Text = banner.Link;
            pbBanner.Image = banner.Image;

        }


        private void tbLink_Leave(object sender, EventArgs e)
        {
            SelectedBanner.Link = tbLink.Text;
        }
    }
}
