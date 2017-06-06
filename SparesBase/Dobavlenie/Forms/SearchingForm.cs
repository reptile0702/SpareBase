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
            string where = "WHERE(";//organizationId != 0 ? "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.OrganizationId = " + organizationId + ") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))" : "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))";
            string[] searchWords = searchStr.Split(' ');
            if (searchStr != "")
            {
                where += "(";
            }
            foreach (string word in searchWords)
            {
                if (word != "")
                {
                    where += "i.Item_Name LIKE \"%" + word + "%\" OR ";
                }               
            }
            if (searchStr != "")
            {
                where = where.Remove(where.Length - 3, 3) + ") AND";
            }           
            where += organizationId != 0 ? " (i.OrganizationId = " + organizationId + ") AND" : "";
            //where += searchStr != "" || organizationId != 0 ? " AND ": 
            where += " (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))";


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
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay);
#else
                dgv.Rows.Add(
                    item.Name,
                    item.RetailPrice,
                    item.ServicePrice,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay);
#endif

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;
            }
        }

        private void SearchingForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            dgv.Columns.Add("Id", "ID");
#endif
            dgv.Columns.Add("Name", "Наименование");
            dgv.Columns.Add("Retail", "Розница");
            dgv.Columns.Add("Service", "Сервисы");
            dgv.Columns.Add("Quantity", "Количество");
            dgv.Columns.Add("date", "Дата добавления");

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
            if (dgv.CurrentRow != null)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                OrganizationCardForm ocf = new OrganizationCardForm(item.Organization);
                ocf.ShowDialog();
            }            
        }
    }
}
