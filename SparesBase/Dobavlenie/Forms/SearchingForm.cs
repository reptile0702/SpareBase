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
            dgv.Rows.Clear();
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Items WHERE(SearchAllowed=1)");
            foreach (DataRow row in dt.Rows)
            {
                Item item = new Item(row.ItemArray);
                dgv.Rows.Add(
                    item.Id,
                    item.ItemName,
                    item.SellerID,
                    item.PurchasePrice,
                    item.RetailPrice,
                    item.WholesalePrice,
                    item.ServicePrice,
                    item.Storage,
                    item.Quantuty,
                    item.Residue);

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;

            }
            

        }

        private void SearchingForm_Load(object sender, EventArgs e)
        {
            dgv.Columns.Add("Id","ID");
            dgv.Columns.Add("Name","Наименование");
            dgv.Columns.Add("Seller","Поставщик");
            dgv.Columns.Add("Purchase","Закупка");
            dgv.Columns.Add("Retail","Розница");
            dgv.Columns.Add("Wholesale","Мелкий опт");
            dgv.Columns.Add("Service", "Сервисы");
            dgv.Columns.Add("Storage","Хранение");
            dgv.Columns.Add("Quantity","Количество");            
            dgv.Columns.Add("Residue","Остаток");

            FillOrganizations();
            Search("", 0);
        }
    }
}
