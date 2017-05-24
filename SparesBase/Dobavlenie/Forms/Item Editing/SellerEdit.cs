using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellerEdit : Form
    {
        int sellerId;

        // Конструктор для добавления нового поставщика
        public SellerEdit()
        {
            InitializeComponent();
            sellerId = 0;
            Text = "Новый поставщик";
        }

        // Конструктор для редактирования поставщика
        public SellerEdit(int sellerId)
        {
            InitializeComponent();
            this.sellerId = sellerId;
            Text = "Редактирование поставщика";
        }

        // Загрузка формы
        private void SellerEdit_Load(object sender, EventArgs e)
        {
            if (sellerId != 0)
            {
                DataTable sellerInfo = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sellers WHERE(id = " + sellerId + " AND OrganizationId=" + EnteredUser.OrganizationId + ")");
                tbName.Text = sellerInfo.Rows[0].ItemArray[1].ToString();
                tbSite.Text = sellerInfo.Rows[0].ItemArray[2].ToString();
                tbTelephone.Text = sellerInfo.Rows[0].ItemArray[3].ToString();
                tbFirstName.Text = sellerInfo.Rows[0].ItemArray[4].ToString();
                tbLastName.Text = sellerInfo.Rows[0].ItemArray[5].ToString();
                tbSecondName.Text = sellerInfo.Rows[0].ItemArray[6].ToString();
            }
        }

        // Добавление / изменение данных о поставщике
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (sellerId == 0)
                SellerOperation("INSERT INTO Sellers VALUES(NULL, '" + tbName.Text + "', '" + tbSite.Text + "', '" + tbTelephone.Text + "', '" + tbFirstName.Text + "', '" + tbLastName.Text + "', '" + tbSecondName.Text + "', OrganizationId=" + EnteredUser.OrganizationId + ")");
            else
                SellerOperation("UPDATE Sellers SET name='" + tbName.Text + "', site='" + tbSite.Text + "', telephone='" + tbTelephone.Text + "', contactFirstName='" + tbFirstName.Text + "', contactLastName='" + tbLastName.Text + "', contactSecondName='" + tbSecondName.Text + "' WHERE(id = " + sellerId + ")");

            DialogResult = DialogResult.OK;
        }

        // Операция над поставщиком
        private void SellerOperation(string query)
        {
            if ((tbName.Text != "") && (tbTelephone.Text != "") && (tbFirstName.Text != "") && (tbSecondName.Text != "") && (tbLastName.Text != ""))
            {
                DatabaseWorker.SqlQuery(query);
                Close();
            }
            else
                MessageBox.Show("Заполнены не все поля");
        }
    }
}
