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
                "i.id, " +
                "mc.id, " +
                "mc.Name, " +
                "mc.OrganizationId, " +
                "sc1.id, " +
                "sc1.Name, " +
                "sc1.MainCatId, " +
                "sc1.OrganizationId, " +
                "sc2.id, " +
                "sc2.Name, " +
                "sc2.SubCat1Id, " +
                "sc2.OrganizationId, " +
                "sc3.id, " +
                "sc3.Name, " +
                "sc3.SubCat2Id, " +
                "sc3.OrganizationId, " +
                "sc4.id, " +
                "sc4.Name, " +
                "sc4.SubCat3Id, " +
                "sc4.OrganizationId, " +
                "s.id, " +
                "s.name, " +
                "s.site, " +
                "s.telephone, " +
                "s.contactFirstName, " +
                "s.contactLastName, " +
                "s.contactSecondName, " +
                "s.OrganizationId," +
                "s.Hidden, " +
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
                "o.id, " +
                "o.Name, " +
                "o.Site, " +
                "o.Telephone, " +
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
                        int.Parse(row["id1"].ToString()),
                        row["Name"].ToString(),
                        0,
                        int.Parse(row["OrganizationId"].ToString()));

                Category subCat1 = null;
                if (row["id2"].ToString() != "")
                {
                    subCat1 = new Category(
                        int.Parse(row["id2"].ToString()),
                        row["Name1"].ToString(),
                        int.Parse(row["MainCatId"].ToString()),
                        int.Parse(row["OrganizationId1"].ToString()));
                }

                Category subCat2 = null;
                if (row["id3"].ToString() != "")
                {
                    subCat2 = new Category(
                        int.Parse(row["id3"].ToString()),
                        row["Name2"].ToString(),
                        int.Parse(row["SubCat1Id"].ToString()),
                        int.Parse(row["OrganizationId2"].ToString()));
                }

                Category subCat3 = null;
                if (row["id4"].ToString() != "")
                {
                    subCat3 = new Category(
                        int.Parse(row["id4"].ToString()),
                        row["Name3"].ToString(),
                        int.Parse(row["SubCat2Id"].ToString()),
                        int.Parse(row["OrganizationId3"].ToString()));
                }

                Category subCat4 = null;
                if (row["id5"].ToString() != "")
                {
                    subCat4 = new Category(
                        int.Parse(row["id5"].ToString()),
                        row["Name4"].ToString(),
                        int.Parse(row["SubCat3Id"].ToString()),
                        int.Parse(row["OrganizationId4"].ToString()));
                }

                Seller seller = new Seller(
                    int.Parse(row["id6"].ToString()),
                    row["name5"].ToString(),
                    row["site"].ToString(),
                    row["telephone"].ToString(),
                    row["contactFirstName"].ToString(),
                    row["contactLastName"].ToString(),
                    row["contactSecondName"].ToString(),
                    int.Parse(row["OrganizationId5"].ToString()),
                    row["Hidden"].ToString() == "1" ? true : false);

                // Организация
                Organization organization = new Organization(
                    int.Parse(row["id7"].ToString()),
                    row["Name6"].ToString(),
                    row["Site"].ToString(),
                    row["Telephone"].ToString(),
                    row["City"].ToString());

                Item item = new Item(
                    int.Parse(row["id"].ToString()),
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
