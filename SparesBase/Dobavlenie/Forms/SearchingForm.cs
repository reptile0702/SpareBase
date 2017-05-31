using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SearchingForm : Form
    {
        public SearchingForm()
        {
            InitializeComponent();
        }

        private void FillOrganizations()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "Все организации");

            DataTable dt2 = DatabaseWorker.SqlSelectQuery("SELECT id, Name FROM Organizations");
            foreach (DataRow row in dt2.Rows)
            {
                dt.Rows.Add(row.ItemArray[0], row.ItemArray[1]);
            }

            cbOrganizations.ValueMember = "id";
            cbOrganizations.DisplayMember = "Name";

            cbOrganizations.DataSource = dt;


        }

        private void Search(string searchStr, int organizationId)
        {
            string where = organizationId != 0 ? "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.OrganizationId = " + organizationId + ") AND (i.SearchAllowed = 1) AND (i.Deleted <> 1))" : "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.SearchAllowed = 1) AND (i.Deleted <> 1))";
            dgv.Rows.Clear();
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT i.id, mc.id, mc.Name, mc.OrganizationId, sc1.id, sc1.Name, sc1.MainCatId, sc1.OrganizationId, sc2.id, sc2.Name, sc2.SubCat1Id, sc2.OrganizationId, sc3.id, sc3.Name, sc3.SubCat2Id, sc3.OrganizationId, sc4.id, sc4.Name, sc4.SubCat3Id, sc4.OrganizationId, i.Item_Name, s.id, s.name, s.site, s.telephone, s.contactFirstName, s.contactLastName, s.contactSecondName, s.OrganizationId, i.Purchase_Price, i.Retail_Price, i.Wholesale_Price, i.Service_Price, i.FirmPrice, i.Storage, i.Note, i.Quantity, i.Residue, i.Upload_Date, o.id, o.Name, o.Site, o.Telephone, oc.City, oa.id, oa.FirstName, oa.LastName, oa.SecondName, oa.Login, oac.City, oa.Phone, oa.Email, oa.Admin, i.SearchAllowed FROM Items i LEFT JOIN Main_Category mc ON mc.id = i.Main_Category_Id LEFT JOIN Sub_Category_1 sc1 ON sc1.id = i.Sub_Category_1_Id LEFT JOIN Sub_Category_2 sc2 ON sc2.id = i.Sub_Category_2_Id LEFT JOIN Sub_Category_3 sc3 ON sc3.id = i.Sub_Category_3_Id LEFT JOIN Sub_Category_4 sc4 ON sc4.id = i.Sub_Category_4_Id LEFT JOIN Sellers s ON s.id = i.Seller_Id LEFT JOIN Organizations o ON o.id = i.OrganizationId LEFT JOIN Cities oc ON oc.id = o.CityId LEFT JOIN Accounts oa ON oa.id = o.AdminAccountId LEFT JOIN Cities oac ON oac.id = oa.CityId " + where);

            foreach (DataRow row in dt.Rows)
            {
                Category mainCat = new Category(
                       int.Parse(row.ItemArray[1].ToString()),
                       row.ItemArray[2].ToString(),
                       0,
                       int.Parse(row.ItemArray[3].ToString()));

                Category subCat1 = null;
                if (row.ItemArray[4].ToString() != "")
                {
                    subCat1 = new Category(
                        int.Parse(row.ItemArray[4].ToString()),
                        row.ItemArray[5].ToString(),
                        int.Parse(row.ItemArray[6].ToString()),
                        int.Parse(row.ItemArray[7].ToString()));
                }

                Category subCat2 = null;
                if (row.ItemArray[8].ToString() != "")
                {
                    subCat2 = new Category(
                        int.Parse(row.ItemArray[8].ToString()),
                        row.ItemArray[9].ToString(),
                        int.Parse(row.ItemArray[10].ToString()),
                        int.Parse(row.ItemArray[11].ToString()));
                }

                Category subCat3 = null;
                if (row.ItemArray[12].ToString() != "")
                {
                    subCat3 = new Category(
                        int.Parse(row.ItemArray[12].ToString()),
                        row.ItemArray[13].ToString(),
                        int.Parse(row.ItemArray[14].ToString()),
                        int.Parse(row.ItemArray[15].ToString()));
                }

                Category subCat4 = null;
                if (row.ItemArray[16].ToString() != "")
                {
                    subCat4 = new Category(
                        int.Parse(row.ItemArray[16].ToString()),
                        row.ItemArray[17].ToString(),
                        int.Parse(row.ItemArray[18].ToString()),
                        int.Parse(row.ItemArray[19].ToString()));
                }


                // Поставщик
                Seller seller = new Seller(
                        int.Parse(row.ItemArray[21].ToString()),
                        row.ItemArray[22].ToString(),
                        row.ItemArray[23].ToString(),
                        row.ItemArray[24].ToString(),
                        row.ItemArray[25].ToString(),
                        row.ItemArray[26].ToString(),
                        row.ItemArray[27].ToString(),
                        int.Parse(row.ItemArray[28].ToString()));

                // Организация
                Organization organization = new Organization(
                        int.Parse(row.ItemArray[39].ToString()),
                        row.ItemArray[40].ToString(),
                        row.ItemArray[41].ToString(),
                        row.ItemArray[42].ToString(),
                        row.ItemArray[43].ToString(),
                        null);

                // Аккаунт админа
                Account adminAccount = new Account(
                    int.Parse(row.ItemArray[44].ToString()),
                    row.ItemArray[45].ToString(),
                    row.ItemArray[46].ToString(),
                    row.ItemArray[47].ToString(),
                    row.ItemArray[48].ToString(),
                    row.ItemArray[49].ToString(),
                    row.ItemArray[50].ToString(),
                    row.ItemArray[51].ToString(),
                    row.ItemArray[52].ToString() == "1" ? true : false,
                    organization);

                organization.Admin = adminAccount;

                Item item = new Item(
                    int.Parse(row.ItemArray[0].ToString()),
                    mainCat,
                    subCat1,
                    subCat2,
                    subCat3,
                    subCat4,
                    row.ItemArray[20].ToString(),
                    seller,
                    row.ItemArray[29].ToString(),
                    row.ItemArray[30].ToString(),
                    row.ItemArray[31].ToString(),
                    row.ItemArray[32].ToString(),
                    row.ItemArray[33].ToString(),
                    row.ItemArray[34].ToString(),
                    row.ItemArray[35].ToString(),
                    int.Parse(row.ItemArray[36].ToString()),
                    int.Parse(row.ItemArray[37].ToString()),
                    DateTime.Parse(row.ItemArray[38].ToString()),
                    organization,
                    row.ItemArray[53].ToString() == "1" ? true : false);

                dgv.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Seller.Name,
                    item.PurchasePrice,
                    item.RetailPrice,
                    item.WholesalePrice,
                    item.ServicePrice,
                    item.Storage,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.Residue);

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;

            }


        }

        private void SearchingForm_Load(object sender, EventArgs e)
        {
            dgv.Columns.Add("Id", "ID");
            dgv.Columns.Add("Name", "Наименование");
            dgv.Columns.Add("Seller", "Поставщик");
            dgv.Columns.Add("Purchase", "Закупка");
            dgv.Columns.Add("Retail", "Розница");
            dgv.Columns.Add("Wholesale", "Мелкий опт");
            dgv.Columns.Add("Service", "Сервисы");
            dgv.Columns.Add("Storage", "Хранение");
            dgv.Columns.Add("Quantity", "Количество");
            dgv.Columns.Add("Residue", "Остаток");

            FillOrganizations();
            Search("", 0);
        }

        private void tbSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(tbSearching.Text, int.Parse(cbOrganizations.SelectedValue.ToString()));
            }
        }

        private void cbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearching.Text = "";
            Search(tbSearching.Text, int.Parse(cbOrganizations.SelectedValue.ToString()));
        }
    }
}
