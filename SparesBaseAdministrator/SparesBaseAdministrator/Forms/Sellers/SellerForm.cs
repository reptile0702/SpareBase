using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class SellerForm : Form
    {
        DataTable listBoxSource;
        //EditForm editForm;

        // Конструктор обычный
        public SellerForm()
        {
            InitializeComponent();
        }

        // Констуктор для EditForm, чтобы выделенный поставщик вставился в ComboBox
        //public SellerForm(EditForm editForm)
        //{
        //    InitializeComponent();
        //    this.editForm = editForm;
        //}


        private void FillOrganizations()
        {
            DataTable organizations = new DataTable();
            organizations.Columns.Add("id");
            organizations.Columns.Add("Organization");
            organizations.Rows.Add("0", "Все организации");

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, Name FROM Organizations");
            foreach (DataRow row in dt.Rows)
                organizations.Rows.Add(row.ItemArray[0], row.ItemArray[1]);

            cbOrganizations.ValueMember = "id";
            cbOrganizations.DisplayMember = "Organization";
            cbOrganizations.DataSource = organizations;
        }

        // Получение данных о выделенном поставщике из базы и вывод данных во все TextBox'ы
        private void GetSellerData()
        {
            int selectedId = int.Parse(lbSellers.SelectedValue.ToString());
            DataTable sellerInfo = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sellers WHERE(id = " + selectedId + ")");
            tbName.Text = sellerInfo.Rows[0].ItemArray[1].ToString();
            tbSite.Text = sellerInfo.Rows[0].ItemArray[2].ToString();
            tbTelephone.Text = sellerInfo.Rows[0].ItemArray[3].ToString();
            tbFirstName.Text = sellerInfo.Rows[0].ItemArray[4].ToString();
            tbLastName.Text = sellerInfo.Rows[0].ItemArray[5].ToString();
            tbSecondName.Text = sellerInfo.Rows[0].ItemArray[6].ToString();
        }

        // Обновить данные о поставщиках в ListBox
        private void FillSellers(int organizationId, int sellerId = 0)
        {
            string where = organizationId != 0 ? "WHERE(OrganizationId = " + organizationId + ")" : "";
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, name FROM Sellers " + where);
            listBoxSource = new DataTable();
            listBoxSource.Columns.Add("id");
            listBoxSource.Columns.Add("name");
            foreach (DataRow row in dt.Rows)
                listBoxSource.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString());

            lbSellers.DisplayMember = "name";
            lbSellers.ValueMember = "id";
            lbSellers.DataSource = listBoxSource;

            if (sellerId != 0)
                lbSellers.SelectedValue = sellerId;
        }


        // Загрузка формы
        private void SellerForm_Load(object sender, EventArgs e)
        {
            FillOrganizations();
            FillSellers(0);
        }

        // Закрытие формы и вставка в ComboBox AddForm'ы выделенного поставщика
        private void SellerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (editForm != null)
            //{
            //    DataRowView text = (DataRowView)lbSellers.SelectedItem;
            //    editForm.ChangeTextInSellerComboBox(text[1].ToString());
            //}
        }

        // Смена выделенного поставщика
        private void lbSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSellerData();
        }

        // Добавление нового поставщика
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SellerEdit editForm = new SellerEdit();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                FillSellers(int.Parse(cbOrganizations.SelectedValue.ToString()));
                lbSellers.SelectedIndex = lbSellers.Items.Count - 1;
            }
        }

        // Редактирование поставщика
        private void btnSellerEdit_Click(object sender, EventArgs e)
        {
            SellerEdit editForm = new SellerEdit(int.Parse(lbSellers.SelectedValue.ToString()));
            if (editForm.ShowDialog() == DialogResult.OK)
                FillSellers(int.Parse(lbSellers.SelectedValue.ToString()));
        }

        // Удаление поставщика
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lbSellers.SelectedValue.ToString());
            DatabaseWorker.SqlQuery("DELETE FROM Sellers WHERE(id=" + id + ")");
            listBoxSource.Rows.RemoveAt(lbSellers.SelectedIndex);
        }

        // Клик на кнопку OK
        private void tbOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSellers(int.Parse(cbOrganizations.SelectedValue.ToString()));
        }
    }
}
