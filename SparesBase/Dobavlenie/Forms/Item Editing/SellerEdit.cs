﻿using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellerEdit : Form
    {
        public int sellerId;
    
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

            Text = "Редактирование поставщика";

            FillSellerData(seller);
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
                DialogResult = DialogResult.OK;
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
            {
                SellerOperation("INSERT INTO Sellers VALUES(NULL, " +
                    "'" + tbName.Text + "', " +
                    "'" + tbSite.Text + "', " +
                    "'" + tbTelephone.Text + "', " +
                    "'" + tbFirstName.Text + "', " +
                    "'" + tbLastName.Text + "', " +
                    "'" + tbSecondName.Text + "', " +
                    "" + EnteredUser.Organization.Id + ", " +
                    "0)");

                sellerId = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT id FROM Sellers WHERE(id = LAST_INSERT_ID())").ToString());
            }
            else
            {
                SellerOperation("UPDATE Sellers SET " +
                    "name = '" + tbName.Text + "', " +
                    "site = '" + tbSite.Text + "', " +
                    "telephone = '" + tbTelephone.Text + "', " +
                    "contactFirstName = '" + tbFirstName.Text + "', " +
                    "contactLastName = '" + tbLastName.Text + "', " +
                    "contactSecondName = '" + tbSecondName.Text + "', " +
                    "OrganizationId = " + EnteredUser.Organization.Id + " " +
                    "WHERE(id = " + seller.Id + ")");

                sellerId = seller.Id;
            }
        }

        // Клик на кнопку "Отмена"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
