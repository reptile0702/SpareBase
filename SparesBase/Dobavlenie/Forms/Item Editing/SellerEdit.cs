using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellerEdit : Form
    {
        // Поставщик
        Seller seller;

        #region Конструкторы

        // Конструктор для добавления нового поставщика
        public SellerEdit()
        {
            InitializeComponent();
            Text = "Новый поставщик";
            
        }

        // Конструктор для редактирования поставщика
        public SellerEdit(Seller seller)
        {
            InitializeComponent();
            this.seller = seller;
            
            FillSellerData(seller);
            Text = "Редактирование поставщика";
        }

        #endregion Конструкторы
        


        #region Заполнение данных

       
      
        // Заполнение данных о поставщике
        private void FillSellerData(Seller seller)
        {
            tbName.Text = seller.Name;
            tbSite.Text = seller.Site;
            tbTelephone.Text = seller.Telephone;
            tbFirstName.Text = seller.ContactFirstName;
            tbLastName.Text = seller.ContactLastName;
            tbSecondName.Text = seller.ContactSecondName;
           
        }

        #endregion Заполнение данных



        #region Методы

        // Операция над поставщиком
        private void SellerOperation(string query)
        {
            // Проверка на введенность обязательных полей
            if (tbName.Text != "" &&
                tbTelephone.Text != "" && 
                tbFirstName.Text != "" && 
                tbSecondName.Text != "" && 
                tbLastName.Text != "")
            {
                DatabaseWorker.SqlQuery(query);
                Close();
            }
            else
                MessageBox.Show("Заполнены не все поля");
        }

        #endregion Методы



        #region События

        // Добавление / изменение данных о поставщике
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (seller == null)
                SellerOperation("INSERT INTO Sellers VALUES(NULL, '" + tbName.Text + "', '" + tbSite.Text + "', '" + tbTelephone.Text + "', '" + tbFirstName.Text + "', '" + tbLastName.Text + "', '" + tbSecondName.Text + "', " + EnteredUser.OrganizationId + ")");
            else
                SellerOperation("UPDATE Sellers SET name='" + tbName.Text + "', site='" + tbSite.Text + "', telephone='" + tbTelephone.Text + "', contactFirstName='" + tbFirstName.Text + "', contactLastName='" + tbLastName.Text + "', contactSecondName='" + tbSecondName.Text + "', OrganizationId = " + EnteredUser.OrganizationId + " WHERE(id = " + seller.Id + ")");

            DialogResult = DialogResult.OK;
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
