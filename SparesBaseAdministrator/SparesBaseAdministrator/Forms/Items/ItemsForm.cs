using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class ItemsForm : Form
    {
        public Category SelectedCategory { get { return (Category)treeView.SelectedNode.Tag; } }
        public Item SelectedItem { get { return (Item)dgv.CurrentRow.Tag; } }

        // Конструктор
        public ItemsForm()
        {
            InitializeComponent();

            tbSearch.Text = "Поиск";
            tbSearch.ForeColor = Color.Gray;
            FillOrganizations();
            FillCategories();
            InitializeDataGridView();
        }

        #region Заполнение данных

        // Заполнение организаций
        private void FillOrganizations()
        {
            DataTable organizations = DatabaseWorker.SqlSelectQuery("SELECT id, Name FROM Organizations");

            cbOrganizations.ValueMember = "id";
            cbOrganizations.DisplayMember = "Name";
            cbOrganizations.DataSource = organizations;
        }

        // Заполнение TreeView категориями из базы
        private void FillCategories()
        {
            treeView.Nodes.Clear();
            TreeNode root = new TreeNode();

            string where = cbOrganizations.SelectedValue.ToString() != "0" ? "WHERE(OrganizationId=" + cbOrganizations.SelectedValue + ")" : "";

            DataTable mainDt = DatabaseWorker.SqlSelectQuery("SELECT id, Name, OrganizationId FROM Main_Category " + where);
            if (mainDt.Rows.Count != 0)
            {
                DataTable subCat1Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_1 " + where);
                DataTable subCat2Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_2 " + where);
                DataTable subCat3Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_3 " + where);
                DataTable subCat4Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_4 " + where);

                // Главная категория
                foreach (DataRow row in mainDt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        0,
                        int.Parse(row.ItemArray[2].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    root.Nodes.Add(newTreeNode);
                }

                // Подкатегория 1
                foreach (DataRow row in subCat1Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()), 
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int mainId = category.PreviousCategoryId;

                    foreach (TreeNode node in root.Nodes)
                    {
                        Category cat = (Category)node.Tag;
                        if (cat.Id == mainId)
                            node.Nodes.Add(newTreeNode);
                    }
                }

                // Подкатегория 2
                foreach (DataRow row in subCat2Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub1Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                        {
                            Category cat = (Category)sub1Node.Tag;
                            if (cat.Id == sub1Id)
                                sub1Node.Nodes.Add(newTreeNode);
                        }
                }

                // Подкатегория 3
                foreach (DataRow row in subCat3Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub2Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                            {
                                Category cat = (Category)sub2Node.Tag;
                                if (cat.Id == sub2Id)
                                    sub2Node.Nodes.Add(newTreeNode);
                            }
                }

                // Подкатегория 4
                foreach (DataRow row in subCat4Dt.Rows)
                {
                    Category category = new Category(
                        int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        int.Parse(row.ItemArray[2].ToString()),
                        int.Parse(row.ItemArray[3].ToString()));

                    TreeNode newTreeNode = new TreeNode(category.Name);
                    newTreeNode.Tag = category;
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    int sub3Id = category.PreviousCategoryId;

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                foreach (TreeNode sub3Node in sub2Node.Nodes)
                                {
                                    Category cat = (Category)sub3Node.Tag;
                                    if (cat.Id == sub3Id)
                                        sub3Node.Nodes.Add(newTreeNode);
                                }
                }

                // Добавление нодов в TreeView
                foreach (TreeNode node in root.Nodes)
                    treeView.Nodes.Add(node);
                
                // Сортировка по алфавиту
                treeView.Sort();

                // Выделение первого нода
                if (treeView.Nodes.Count != 0)
                    treeView.SelectedNode = treeView.Nodes[0];
            }
        }

        // Заполнение DataGridView предметами по условию
        public void FillItems(string where)
        {
            dgv.Rows.Clear();

            // Выполнение запроса
            DataTable items = DatabaseWorker.SqlSelectQuery("SELECT i.id, mc.id, mc.Name, mc.OrganizationId, sc1.id, sc1.Name, sc1.MainCatId, sc1.OrganizationId, sc2.id, sc2.Name, sc2.SubCat1Id, sc2.OrganizationId, sc3.id, sc3.Name, sc3.SubCat2Id, sc3.OrganizationId, sc4.id, sc4.Name, sc4.SubCat3Id, sc4.OrganizationId, i.Item_Name, s.id, s.name, s.site, s.telephone, s.contactFirstName, s.contactLastName, s.contactSecondName, s.OrganizationId, i.Purchase_Price, i.Retail_Price, i.Wholesale_Price, i.Service_Price, i.FirmPrice, i.Storage, i.Note, i.Quantity, i.Residue, i.Upload_Date, o.id, o.Name, o.Site, o.Telephone, oc.City, oa.id, oa.FirstName, oa.LastName, oa.SecondName, oa.Login, oac.City, oa.Phone, oa.Email, oa.Admin, i.SearchAllowed FROM Items i LEFT JOIN Main_Category mc ON mc.id = i.Main_Category_Id LEFT JOIN Sub_Category_1 sc1 ON sc1.id = i.Sub_Category_1_Id LEFT JOIN Sub_Category_2 sc2 ON sc2.id = i.Sub_Category_2_Id LEFT JOIN Sub_Category_3 sc3 ON sc3.id = i.Sub_Category_3_Id LEFT JOIN Sub_Category_4 sc4 ON sc4.id = i.Sub_Category_4_Id LEFT JOIN Sellers s ON s.id = i.Seller_Id LEFT JOIN Organizations o ON o.id = i.OrganizationId LEFT JOIN Cities oc ON oc.id = o.CityId LEFT JOIN Accounts oa ON oa.id = o.AdminAccountId LEFT JOIN Cities oac ON oac.id = oa.CityId " + where);

            foreach (DataRow row in items.Rows)
            {
                // Категории
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

            if (dgv.Rows.Count == 0)
            {
                cmsDeleteItem.Enabled = false;
                cmsEditItem.Enabled = false;
            }
            else
            {
                cmsEditItem.Enabled = true;
                cmsDeleteItem.Enabled = true;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
                if (i % 2 != 0)
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

            cmsAddItem.Enabled = true;
        }

        // Заполнение предметов по категориям
        private void FillItemsByCategory()
        {
            int[] selectedCategories = FormCategories();

            // Формирование условия WHERE
            string where = "WHERE (";
            for (int i = 0; i < treeView.SelectedNode.FullPath.Split('\\').Length; i++)
            {
                if (i == 0) where += "i.Main_Category_Id=(SELECT id FROM Main_Category WHERE(id=" + selectedCategories[i] + "))";
                if (i == 1) where += " AND i.Sub_Category_1_Id=(SELECT id FROM Sub_Category_1 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 2) where += " AND i.Sub_Category_2_Id=(SELECT id FROM Sub_Category_2 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 3) where += " AND i.Sub_Category_3_Id=(SELECT id FROM Sub_Category_3 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 4) where += " AND i.Sub_Category_4_Id=(SELECT id FROM Sub_Category_4 WHERE(id=" + selectedCategories[i] + "))";
            }
            where += ")";

            FillItems(where);
        }

        #endregion Заполнение данных



        #region Вспомогательные методы

        // Инициализация DataGridView
        private void InitializeDataGridView()
        {
            dgv.Columns.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Наименование");
            dgv.Columns.Add("seller", "Поставщик");
            dgv.Columns.Add("purchasePrice", "Закупка");
            dgv.Columns.Add("retailPrice", "Розница");
            dgv.Columns.Add("wholesalePrice", "Мелкий опт");
            dgv.Columns.Add("servicePrice", "Сервисы");
            dgv.Columns.Add("storage", "Хранение");
            dgv.Columns.Add("quantity", "Количество");
            dgv.Columns.Add("uploadDate", "Дата добавления");
            dgv.Columns.Add("residue", "Остаток");

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 120;
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 120;
            dgv.Columns[10].Width = 70;
        }

        // Поиск и выделение нода по пути
        private void Find(TreeNodeCollection nodes, string path)
        {
            foreach (TreeNode item in nodes)
            {
                if (item.FullPath == path)
                {
                    treeView.SelectedNode = item;
                    return;
                }
                Find(item.Nodes, path);
            }
        }

        // Возвращает массив категорий сформированный по полному пути выделенного нода в TreeView
        private int[] FormCategories()
        {
            int[] categories = new int[5];
            List<int> cats = new List<int>();
            TreeNode parent = treeView.SelectedNode;

            do
            {
                Category category = (Category)parent.Tag;
                cats.Add(category.Id);
                parent = parent.Parent;
            }
            while (parent != null);

            cats.Reverse();
            for (int i = 0; i < categories.Length; i++)
            {
                if (i > cats.Count - 1)
                    break;
                else
                    categories[i] = cats[i];
            }

            return categories;
        }

        // Возвращает массив категорий сформированный по полному пути нода
        private int[] FormCategories(TreeNode node)
        {
            int[] categories = new int[5];
            List<int> cats = new List<int>();
            TreeNode parent = node;

            do
            {
                Category category = (Category)parent.Tag;
                cats.Add(category.Id);
                parent = parent.Parent;
            }
            while (parent != null);

            cats.Reverse();
            for (int i = 0; i < categories.Length; i++)
            {
                if (i > cats.Count - 1)
                    break;
                else
                    categories[i] = cats[i];
            }

            return categories;
        }

        #endregion Вспомогательные методы



        #region Предметы

        // Добавить предмет
        private void AddItem()
        {
            EditForm form = new EditForm(FormCategories(), int.Parse(cbOrganizations.SelectedValue.ToString()));
            form.ShowDialog();
            FillItemsByCategory();
        }

        // Редактировать предмет
        private void EditItem()
        {
            EditForm form = new EditForm(SelectedItem, FormCategories());
            form.ShowDialog();
            FillItemsByCategory();
        }

        // Удалить предмет
        private void DeleteItem()
        {
            int selectedItemId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            DatabaseWorker.SqlQuery("DELETE FROM Items WHERE(id = " + selectedItemId + ")");
            PhotoEditor pe = new PhotoEditor(selectedItemId, true);
            pe.DeleteItemImages();
            DatabaseWorker.InsertAction(3, selectedItemId);
            FillItemsByCategory();
        }

        // Обновляет информацию о выделенном предмете в панели информации
        private void InsertInfoAboutItem()
        {
            Item selItem = SelectedItem;
            lname.Text = "Имя: " + selItem.Name;
            lseller.Text = "Поставщик: " + selItem.Seller.Name;
            lpurchase.Text = "Закупка: " + selItem.PurchasePrice;
            lretail.Text = "Розница: " + selItem.RetailPrice;
            lwhole.Text = "Мелкий опт: " + selItem.WholesalePrice;
            lservice.Text = "Сервисы: " + selItem.ServicePrice;
            lfirm.Text = "Фирменная цена: " + selItem.FirmPrice;
            lstorage.Text = "Хранение: \n" + selItem.Storage;
            lnote.Text = "Описание: \n" + selItem.Note;
            lquantity.Text = "Количество: " + selItem.Quantity;
            lresidue.Text = "Остаток: " + selItem.Residue;
        }

        // Поиск предмета
        private void SearchItems(string query, int organizationId)
        {
            string where = organizationId != 0 ? "WHERE((Item_Name LIKE \"%" + query + "%\" OR Note LIKE \"%" + query + "%\") AND (Items.OrganizationId = " + organizationId + "))" : "WHERE(Item_Name LIKE \"%" + query + "%\" OR Note LIKE \"%" + query + "%\")";
            FillItems(where);
        }

        #endregion Предметы



        #region Категории

        // Добавляет новую категорию
        public void AddCategory(int nodeCount, int selectedIdNode, string category)
        {
            string id = "";
            if (nodeCount == 0)
            {
                DatabaseWorker.SqlQuery("INSERT INTO Main_Category VALUES('', '" + category + "', " + cbOrganizations.SelectedValue + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Main_Category WHERE(id=LAST_INSERT_ID())").ToString();
                treeView.Nodes.Add(new TreeNode() { Text = category, Tag = id, ContextMenuStrip = cmsCategory });
            }
            else
            {
                DatabaseWorker.SqlQuery("INSERT INTO Sub_Category_" + nodeCount + " VALUES('', '" + category + "', " + selectedIdNode + ", " + cbOrganizations.SelectedValue + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_" + nodeCount + " WHERE(id=LAST_INSERT_ID())").ToString();
                treeView.SelectedNode.Nodes.Add(new TreeNode() { Text = category, Tag = id, ContextMenuStrip = cmsCategory });
            }
        }

        // Переименовать категорию
        public void RenameCategory(int nodeCount, int selectedIdNode, string newName)
        {
            if (nodeCount == 1)
                DatabaseWorker.SqlQuery("UPDATE Main_Category SET Name = '" + newName + "' WHERE(id = " + selectedIdNode + ")");
            else
                DatabaseWorker.SqlQuery("UPDATE Sub_Category_" + (nodeCount - 1) + " SET Name = '" + newName + "' WHERE(id = " + selectedIdNode + ")");
            treeView.SelectedNode.Text = newName;
        }

        // Удалить категорию
        public void DeleteCategory(int nodeCount, int selectedIdNode)
        {
            if (nodeCount == 1)
                DatabaseWorker.SqlQuery("DELETE FROM Main_Category WHERE(id = " + selectedIdNode + ")");
            else
                DatabaseWorker.SqlQuery("DELETE FROM Sub_Category_" + (nodeCount - 1) + " WHERE(id = " + selectedIdNode + ")");
            treeView.SelectedNode.Remove();
        }

        // Смена категории
        private void ChangeCategories(int[] categories, int itemId)
        {
            DatabaseWorker.SqlQuery("UPDATE Items Set Main_Category_Id=" + categories[0] + ",  Sub_Category_1_Id=" + categories[1] + ", Sub_Category_2_Id=" + categories[2] + ", Sub_Category_3_Id=" + categories[3] + ", Sub_Category_4_Id=" + categories[4] + " WHERE(id=" + itemId + ")");
        }

        #endregion Категории



        #region События

        #region Категории

        // Выделение нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillItemsByCategory();
        }

        // Смена организации
        private void cbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCategories();
        }

        // Клик на кнопку "Добавить главную категорию"
        private void AddMainCategory_Click(object sender, EventArgs e)
        {
            EditCategory ecf = new EditCategory(this);
            ecf.ShowDialog();
        }

        // Клик на кнопку "Добавить подкатегорию"
        private void AddSubCategory_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.FullPath.Split('\\').Length < 5)
            {
                EditCategory ecf = new EditCategory(this, SelectedCategory.Id, treeView.SelectedNode.FullPath.Split('\\').Length, false);
                ecf.ShowDialog();
            }
            else
                MessageBox.Show("Невозможно создать новую категорию", "Создание категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Клик на кнопку "Переименовать категорию"
        private void RenameCategory_Click(object sender, EventArgs e)
        {
            EditCategory ecf = new EditCategory(this, SelectedCategory.Id, treeView.SelectedNode.FullPath.Split('\\').Length, true);
            ecf.ShowDialog();
        }

        // Клик на кнопку "Удалить категорию"
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить категорию \"" + SelectedCategory.Name + "\"?", "Удаление категории", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DeleteCategory(treeView.SelectedNode.FullPath.Split('\\').Length, SelectedCategory.Id);
        }

        #endregion Категории

        #region Предметы

        // Клик на кнопку "Добавить предмет"
        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        // Клик на кнопку "Редактировать предмет"
        private void EditItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        // Клик на кнопку "Удалить предмет"
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить предмет \"" + SelectedItem.Name + "\"?", "Удаление предмета", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DeleteItem();
        }

        // Смена выделенной строчки в DataGridView
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
                InsertInfoAboutItem();
        }

        #endregion Предметы

        #region Раскрытие / Закрытие узлов TreeView

        // Раскрытие выделенного нода в TreeView
        private void cmsExpandNode_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.ExpandAll();
        }

        // Закрытие выделенного нода в TreeView
        private void cmsCollapseNode_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.Collapse();
        }

        // Раскрытие всех нодов в TreeView
        private void ExpandAllNodes_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        // Закрытие всех нодов в TreeView
        private void CollapseAllNodes_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }

        #endregion Раскрытие / Закрытие узлов TreeView

        #region Drag'n'Drop 

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = treeView.PointToClient(Cursor.Position);
            TreeNode node = treeView.GetNodeAt(pt);
            if (node != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите переместить предмет из категорий \"" + treeView.SelectedNode.FullPath.Replace("\\", " - ") + "\" в категории \"" + node.FullPath.Replace("\\", " - ") + "\"?", "Перемещение предмета", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChangeCategories(FormCategories(node), int.Parse(e.Data.GetData(DataFormats.Text).ToString()));
                    FillItemsByCategory();
                }
            }
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                dgv.DoDragDrop(dgv.CurrentRow.Cells[0].Value.ToString(), DragDropEffects.Copy);
        }

        #endregion Drag'n'Drop 

        #region Поиск

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchItems(tbSearch.Text, int.Parse(cbOrganizations.SelectedValue.ToString()));
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == "Поиск")
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                tbSearch.Text = "Поиск";
                tbSearch.ForeColor = Color.Gray;
            }
        }

        #endregion Поиск

        #endregion События
    }
}
