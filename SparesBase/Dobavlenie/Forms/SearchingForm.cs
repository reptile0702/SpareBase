using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;

namespace SparesBase
{
    public partial class SearchingForm : Form
    {
        #region Поля
        
        List<Banner> banners;
        int bannerCounter;
        int selectedOrganization;
        Thread previewThread;

        #endregion Поля



        #region Конструкторы

        // Конструктор
        public SearchingForm()
        {
            InitializeComponent();
            banners = new List<Banner>();
            bannerCounter = 0;
            selectedOrganization = 0;

            FillCities();

            if (Settings.AutoLoadItemImages)
                btnLoadImage.Visible = false;
            else
                btnLoadImage.Visible = true;
        }

        #endregion Конструкторы



        #region Методы

        // Заполнение городов
        private void FillCities()
        {
            DataTable cities = new DataTable();
            cities.Columns.Add("id");
            cities.Columns.Add("City");
            cities.Rows.Add("0", "Все города");

            DataTable queryCities = DatabaseWorker.SqlSelectQuery("SELECT id, City FROM Cities");
            foreach (DataRow row in queryCities.Rows)
                cities.Rows.Add(row.ItemArray[0], row.ItemArray[1]);

            cbСities.ValueMember = "id";
            cbСities.DisplayMember = "City";
            cbСities.DataSource = cities;

            int userCity = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT CityId " +
                "FROM Organizations " +
                "WHERE(id = " + EnteredUser.Organization.Id + ")").ToString());

            cbСities.SelectedValue = userCity;
            Search("", 0, userCity);
        }

        // Поиск
        private void Search(string searchStr, int organizationId, int cityId)
        {
            // Формирование условия по строке поиска, организации, городу
            string where = "WHERE(";
            string[] searchWords = searchStr.Split(' ');

            if (searchStr != "")
                where += "(";

            foreach (string word in searchWords)
                if (word != "")
                    where += "i.Item_Name LIKE \"%" + word + "%\" OR "; 

            if (searchStr != "")
                where = where.Remove(where.Length - 3, 3) + ") AND";

            where += organizationId != 0 ? " (i.OrganizationId = " + organizationId + ") AND" : "";
            where += " (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1)";
            where += cityId == -1 ? ")" : " AND (o.CityId = " + cityId + "))";

            // Поиск предметов
            Item[] items = dgv.FillItems(where);
            foreach (Item item in items)
            {
                dgv.Rows.Add(
                    item.Name,
                    item.RetailPrice,
                    item.ServicePrice,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.ChangeDate.Date.ToShortDateString() + " " + item.ChangeDate.TimeOfDay);

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;
            }
        }

        // Загрузка рекламных баннеров
        private void LoadBanners()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Banners/Banners.xml");
            XmlElement element = doc.DocumentElement;

            foreach (XmlNode node in element.ChildNodes)
                if (File.Exists("Banners/" + node["PhotoName"].Attributes["value"].Value))
                banners.Add(new Banner(
                    node["Link"].Attributes["value"].Value, 
                    Image.FromFile("Banners/" + node["PhotoName"].Attributes["value"].Value)));
        }

        // Загрузка превью-фотографии
        private void DownloadPreview()
        {
            pbPreview.Image = null;

            if (previewThread != null)
                previewThread.Abort();

            // Загрузка превью-фотографии в отдельном потоке
            previewThread = new Thread(() =>
            {
                Item item = (Item)dgv.CurrentRow.Tag;

                pbPreview.SizeMode = PictureBoxSizeMode.CenterImage;
                pbPreview.Image = Properties.Resources.LoadGif;

                // Проверка на существование превью-фотографии
                if (FtpManager.PreviewExists(item.Id))
                {
                    // Загрузка превью-фотографии
                    WebClient wcPreview = new WebClient();
                    wcPreview.DownloadDataCompleted += WcPreview_DownloadDataCompleted; ;
                    byte[] imageBytes = wcPreview.DownloadData(new Uri(FtpManager.FtpConnectString + "Photos/item_" + item.Id + "/preview.jpg"));
                    MemoryStream ms = new MemoryStream(imageBytes);
                    pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    pbPreview.Image = Image.FromStream(ms);
                }
                else
                    pbPreview.Image = null;
            });
            previewThread.Start();
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void SearchingForm_Load(object sender, EventArgs e)
        {
            // Задержка перед загрузкой баннеров
            loadBannersDelay.Start();
        }

        // Нажатие на Enter на TextBox
        private void tbSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(tbSearching.Text, selectedOrganization, int.Parse(cbСities.SelectedValue.ToString()));
        }

        // Смена организации
        private void cbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSearchByOrganization.Checked = false;
            tbSearching.Text = "";  
        }

        // Двойной клик на предмет
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                OrganizationCardForm ocf = new OrganizationCardForm(item.Organization);
                ocf.ShowDialog();
            }            
        }
        
        // Смена баннеров по таймеру
        private void timer_Tick(object sender, EventArgs e)
        {
            pbBanner.Image = banners[bannerCounter].Image;
            pbBanner.Tag = banners[bannerCounter].Link;
            bannerCounter++;
            if (bannerCounter == banners.Count)
                bannerCounter = 0;
        }

        // Загрузка баннеров после задержки
        private void loadBannersDelay_Tick(object sender, EventArgs e)
        {
            LoadBanners();            
            timer.Interval = 5000;
            timer.Start();
            loadBannersDelay.Stop();
        }

        // Клик на баннер и переход на ссылку
        private void pbBanner_Click(object sender, EventArgs e)
        {
            if (pbBanner.Tag != null)
                Process.Start(pbBanner.Tag.ToString());
        }

        // Клик на ячейку
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                lNameSC.Text = "Название СЦ:\n" + item.Organization.Name;
                lPhoneSC.Text = "Телефон СЦ: " + item.Organization.Telephone;

                if (Settings.AutoLoadItemImages)
                    DownloadPreview();
                else
                    btnLoadImage.Visible = true;
            }
        }

        // Клик на "Поиск по организации"
        private void cbSearchByOrganization_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchByOrganization.Checked)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                selectedOrganization = item.Organization.Id;
                Search(tbSearching.Text, selectedOrganization, -1);
            }
            else
            {
                selectedOrganization = 0;
                Search(tbSearching.Text, selectedOrganization, int.Parse(cbСities.SelectedValue.ToString()));
            }
        }

        // Загрузить фотографию
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            btnLoadImage.Visible = false;
            DownloadPreview();
        }

        // Превью-фото загружено
        private void WcPreview_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {

        }

        #endregion События
    }
}
