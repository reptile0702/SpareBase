using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace SparesBase
{
    public partial class SearchingForm : Form
    {
        List<Banner> banners;
        int bannerCounter;
        int selectedOrganization;

        // Конструктор
        public SearchingForm()
        {
            InitializeComponent();
            banners = new List<Banner>();
            bannerCounter = 0;
            selectedOrganization = 0;
        }

        #region Методы
        
        // Заполнение организаций
        private void FillCities()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("City");
            dt.Rows.Add("0", "Все города");

            DataTable dt2 = DatabaseWorker.SqlSelectQuery("SELECT id, City FROM Cities");
            foreach (DataRow row in dt2.Rows)
            {
                dt.Rows.Add(row.ItemArray[0], row.ItemArray[1]);
            }

            cbСities.ValueMember = "id";
            cbСities.DisplayMember = "City";
            cbСities.DataSource = dt;
        }

        // Поиск
        private void Search(string searchStr, int organizationId, int cityId)
        {
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

            Item[] items = dgv.FillItems(where);
            foreach (Item item in items)
            {
#if DEBUG
                dgv.Rows.Add(
                    item.Id,
                    item.Name,
                    item.RetailPrice,
                    item.ServicePrice,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.ChangeDate.Date.ToShortDateString() + " " + item.ChangeDate.TimeOfDay);
#else
                dgv.Rows.Add(
                    item.Name,
                    item.RetailPrice,
                    item.ServicePrice,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.ChangeDate.Date.ToShortDateString() + " " + item.ChangeDate.TimeOfDay);
#endif

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
                banners.Add(new Banner(node["Link"].Attributes["value"].Value, Image.FromFile("Banners/" + node["PhotoName"].Attributes["value"].Value)));
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void SearchingForm_Load(object sender, EventArgs e)
        {
            // Задержка перед загрузкой баннеров
            loadBannersDelay.Start();

#if DEBUG
            dgv.Columns.Add("Id", "ID");
#endif
            dgv.Columns.Add("Name", "Наименование");
            dgv.Columns.Add("Retail", "Розница");
            dgv.Columns.Add("Service", "Сервисы");
            dgv.Columns.Add("Quantity", "Количество");
            dgv.Columns.Add("date", "Дата добавления");
            dgv.Columns.Add("changeDate", "Дата изменения");

#if DEBUG

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 80;
            dgv.Columns[3].Width = 80;
            dgv.Columns[4].Width = 80;
            dgv.Columns[5].Width = 130;
            dgv.Columns[6].Width = 130;
#else
            dgv.Columns[0].Width = 150;
            dgv.Columns[1].Width = 80;
            dgv.Columns[2].Width = 80;
            dgv.Columns[3].Width = 80;
            dgv.Columns[4].Width = 130;
            dgv.Columns[5].Width = 130;
#endif

            FillCities();
            Search("", 0, -1);   
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

        #endregion События

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                lNameSC.Text = "Название СЦ:\n" + item.Organization.Name;
                lPhoneSC.Text = "Телефон СЦ: " + item.Organization.Telephone;

            }
        }

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
    }
}
