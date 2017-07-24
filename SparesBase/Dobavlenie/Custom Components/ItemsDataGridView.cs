using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SparesBase
{
    class ItemsDataGridView : DataGridView
    {
        #region Конструкторы
        
        // Конструктор
        public ItemsDataGridView()
        {
            Sorted += ItemsDataGridView_Sorted;
            RowsAdded += ItemsDataGridView_RowsAdded;
            RowsRemoved += ItemsDataGridView_RowsRemoved;
        }

        #endregion Конструкторы



        #region Методы

        // Заполнение предметов
        public Item[] FillItems(string where)
        {
            Rows.Clear();

            List<Item> resItems = new List<Item>();
            DataTable items;
           
            // Выполнение запроса
            items = DatabaseWorker.SqlSelectQuery("SELECT " +
                "i.id AS ItemId, " +

                "mc.id AS MainCategoryId, " +
                "mc.Name AS MainCategoryName, " +
                "mc.OrganizationId AS MainCategoryOrgId, " +

                "sc1.id AS SubCategory1Id, " +
                "sc1.Name AS SubCategory1Name, " +
                "sc1.MainCatId, " +
                "sc1.OrganizationId AS SubCategory1OrgId, " +

                "sc2.id AS SubCategory2Id, " +
                "sc2.Name AS SubCategory2Name, " +
                "sc2.SubCat1Id, " +
                "sc2.OrganizationId AS SubCategory2OrgId, " +

                "sc3.id AS SubCategory3Id, " +
                "sc3.Name AS SubCategory3Name, " +
                "sc3.SubCat2Id, " +
                "sc3.OrganizationId AS SubCategory3OrgId, " +

                "sc4.id AS SubCategory4Id, " +
                "sc4.Name AS SubCategory4Name, " +
                "sc4.SubCat3Id, " +
                "sc4.OrganizationId AS SubCategory4OrgId, " +

                "s.id AS SellerId, " +
                "s.name AS SellerName, " +
                "s.site AS SellerSite, " +
                "s.telephone AS SellerTelephone, " +
                "s.contactFirstName AS SellerContactFN, " +
                "s.contactLastName AS SellerContactLN, " +
                "s.contactSecondName AS SellerContactSN, " +
                "s.OrganizationId AS SellerOrganizationId," +
                "s.Hidden AS SellerHidden, " +

                "i.Item_Name, " +
                "i.Purchase_Price, " +
                "i.Retail_Price, " +
                "i.Wholesale_Price, " +
                "i.Service_Price, " +
                "i.FirmPrice, " +
                "i.Storage, " +
                "i.Note, " +
                "i.Quantity, " +
                "i.Residue, " +
                "i.Upload_Date, " +

                "o.id AS OrgId, " +
                "o.Name AS OrgName, " +
                "o.Site AS OrgSite, " +
                "o.Telephone AS OrgTelephone, " +
                "oc.City, " +

                "i.SearchAllowed, " +
                "i.ChangeDate, " +
                "status.Status," +
                "i.InventNumber, " +
                "i.SerialNumber " +

                "FROM Items i " +
                "LEFT JOIN Main_Category mc ON mc.id = i.Main_Category_Id " +
                "LEFT JOIN Sub_Category_1 sc1 ON sc1.id = i.Sub_Category_1_Id " +
                "LEFT JOIN Sub_Category_2 sc2 ON sc2.id = i.Sub_Category_2_Id " +
                "LEFT JOIN Sub_Category_3 sc3 ON sc3.id = i.Sub_Category_3_Id " +
                "LEFT JOIN Sub_Category_4 sc4 ON sc4.id = i.Sub_Category_4_Id " +
                "LEFT JOIN Sellers s ON s.id = i.Seller_Id " +
                "LEFT JOIN Organizations o ON o.id = i.OrganizationId " +
                "LEFT JOIN Cities oc ON oc.id = o.CityId " +
                "LEFT JOIN ItemStatus status ON status.id = i.StatusId " + where);

            foreach (DataRow row in items.Rows)
            {
                // Категории
                Category mainCat = new Category(
                        int.Parse(row["MainCategoryId"].ToString()),
                        row["MainCategoryName"].ToString(),
                        0,
                        int.Parse(row["MainCategoryOrgId"].ToString()));

                Category subCat1 = null;
                if (row["SubCategory1Id"].ToString() != "")
                {
                    subCat1 = new Category(
                        int.Parse(row["SubCategory1Id"].ToString()),
                        row["SubCategory1Name"].ToString(),
                        int.Parse(row["MainCatId"].ToString()),
                        int.Parse(row["SubCategory1OrgId"].ToString()));
                }

                Category subCat2 = null;
                if (row["SubCategory2Id"].ToString() != "")
                {
                    subCat2 = new Category(
                        int.Parse(row["SubCategory2Id"].ToString()),
                        row["SubCategory2Name"].ToString(),
                        int.Parse(row["SubCat1Id"].ToString()),
                        int.Parse(row["SubCategory2OrgId"].ToString()));
                }

                Category subCat3 = null;
                if (row["SubCategory3Id"].ToString() != "")
                {
                    subCat3 = new Category(
                        int.Parse(row["SubCategory3Id"].ToString()),
                        row["SubCategory3Name"].ToString(),
                        int.Parse(row["SubCat2Id"].ToString()),
                        int.Parse(row["SubCategory3OrgId"].ToString()));
                }

                Category subCat4 = null;
                if (row["SubCategory4Id"].ToString() != "")
                {
                    subCat4 = new Category(
                        int.Parse(row["SubCategory4Id"].ToString()),
                        row["SubCategory4Name"].ToString(),
                        int.Parse(row["SubCat3Id"].ToString()),
                        int.Parse(row["SubCategory4OrgId"].ToString()));
                }

                Seller seller = new Seller(
                    int.Parse(row["SellerId"].ToString()),
                    row["SellerName"].ToString(),
                    row["SellerSite"].ToString(),
                    row["SellerTelephone"].ToString(),
                    row["SellerContactFN"].ToString(),
                    row["SellerContactLN"].ToString(),
                    row["SellerContactSN"].ToString(),
                    int.Parse(row["SellerOrganizationId"].ToString()),
                    row["SellerHidden"].ToString() == "1" ? true : false);

                // Организация
                Organization organization = new Organization(
                    int.Parse(row["OrgId"].ToString()),
                    row["OrgName"].ToString(),
                    row["OrgSite"].ToString(),
                    row["OrgTelephone"].ToString(),
                    row["City"].ToString());

                Item item = new Item(
                    int.Parse(row["ItemId"].ToString()),
                    mainCat,
                    subCat1,
                    subCat2,
                    subCat3,
                    subCat4,
                    row["Item_Name"].ToString(),
                    seller,
                    row["Purchase_Price"].ToString(),
                    row["Retail_Price"].ToString(),
                    row["Wholesale_Price"].ToString(),
                    row["Service_Price"].ToString(),
                    row["FirmPrice"].ToString(),
                    row["Storage"].ToString(),
                    row["Note"].ToString(),
                    int.Parse(row["Quantity"].ToString()),
                    int.Parse(row["Residue"].ToString()),
                    DateTime.Parse(row["Upload_Date"].ToString()),
                    DateTime.Parse(row["ChangeDate"].ToString()),
                    organization,
                    row["SearchAllowed"].ToString() == "1" ? true : false,
                    row["Status"].ToString(),
                    int.Parse(row["InventNumber"].ToString()),
                    row["SerialNumber"].ToString());

                resItems.Add(item);
            }

            return resItems.ToArray();
        }

        #endregion Методы



        #region События
        
        // Строки удалены
        private void ItemsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < Rows.Count; i++)
                if (i % 2 != 0)
                    Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
        }

        // Строки добавлены
        private void ItemsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < Rows.Count; i++)
                if (i % 2 != 0)
                    Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
        }

        // Строки отсортированы
        private void ItemsDataGridView_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < Rows.Count; i++)
                if (i % 2 != 0)
                    Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                else
                    Rows[i].DefaultCellStyle.BackColor = Color.White;
        }

        #endregion События
    }
}
