using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BytesRoad.Net.Ftp;
using System.IO;

namespace SparesBase
{
    public partial class PhotoEditor : Form
    {

        int timeout = 30000;
        string ftpServer = "host3.statushost.ru";
        string username = "sh61018001";
        string password = "lfybkrf";
        string remotePath = "Photos/";
        int port = 21;

        private int id;
        public PhotoEditor(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        
        private Image[] DownloadImages(int id)
        {
            string folderName = "";
            string[] names = GetFilesFromServer("");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i]=="item_" + id)
                {
                    folderName = names[i];
                }
            }
            if (folderName != "")
            {
                FtpClient client = new FtpClient();
                client.PassiveMode = true;
                client.Connect(timeout, ftpServer, port);
                client.Login(timeout, username, password);

                string[] imgName = GetFilesFromServer(folderName);
                Image[] images = new Image[imgName.Length];
                for (int i = 0; i < imgName.Length; i++)
                {
                    byte[] imageBytes = client.GetFile(timeout, remotePath + folderName + "/" + imgName[i]);
                    MemoryStream memoryStream = new MemoryStream(imageBytes);

                    images[i] = Image.FromStream(memoryStream);
                }
                client.Disconnect(timeout);
                return images;
            }
            else
            {
                return null;
            }               
        }
        // Получение папок из сервера
        private string[] GetFilesFromServer(string path)
        {
            FtpClient client = new FtpClient();
            client.PassiveMode = true;
            client.Connect(timeout, ftpServer, port);
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

        

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {

        }

        private void btnClearImg_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
