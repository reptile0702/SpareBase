using System;
using System.Data;
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
            string where = organizationId != 0 ? "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.OrganizationId = " + organizationId + ") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))" : "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))";
            dgv.FillItems(where);           
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

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
