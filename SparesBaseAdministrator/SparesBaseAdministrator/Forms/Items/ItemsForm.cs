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
            treeView.FillCategories(int.Parse(cbOrganizations.SelectedValue.ToString()), cmsCategory);
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

        // Заполнение предметов по категориям
        private void FillItemsByCategory()
        {
            int[] selectedCategories = treeView.FormCategories();

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
            where += ") ";

            if (!tsmiZeroResidueItems.Checked)
                where += " AND (i.Residue > 0)";
            if (!tsmiDeletedItems.Checked)
                where += " AND (i.Deleted <> 1)";


            Item[] items = dgv.FillItems(where);
            foreach (Item item in items)
            {
                dgv.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Seller.Name,
                    item.PurchasePrice,
                    item.RetailPrice,
                    item.WholesalePrice,
                    item.ServicePrice,
                    item.FirmPrice,
                    item.Storage,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.ChangeDate.Date.ToShortDateString() + " " + item.ChangeDate.TimeOfDay,
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

            cmsAddItem.Enabled = true;
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
            dgv.Columns.Add("firmPrice", "Цена фирмы");
            dgv.Columns.Add("storage", "Хранение");
            dgv.Columns.Add("quantity", "Количество");
            dgv.Columns.Add("uploadDate", "Дата добавления");
            dgv.Columns.Add("changeDate", "Дата изменения");
            dgv.Columns.Add("residue", "Остаток");

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 120;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 90;
            dgv.Columns[10].Width = 120;
            dgv.Columns[11].Width = 120;
            dgv.Columns[12].Width = 70;
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

        #endregion Вспомогательные методы



        #region Предметы

        // Добавить предмет
        private void AddItem()
        {
            EditForm form = new EditForm(treeView.FormCategories(), int.Parse(cbOrganizations.SelectedValue.ToString()));
            form.ShowDialog();
            FillItemsByCategory();
        }

        // Редактировать предмет
        private void EditItem()
        {
            EditForm form = new EditForm(SelectedItem, treeView.FormCategories());
            form.ShowDialog();
            FillItemsByCategory();
        }

        // Удалить предмет
        private void DeleteItem()
        {
            int selectedItemId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            DatabaseWorker.SqlQuery("DELETE FROM Items WHERE(id = " + selectedItemId + ")");
            FtpManager.DeleteItemImages(SelectedItem.Id);
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

            lMainCategory.Text = "Главная категория: " + selItem.MainCategory.Name;
            if (selItem.SubCategory1 != null)
                lSubCategory1.Text = "Подкатегория 1: " + selItem.SubCategory1.Name;
            if (selItem.SubCategory2 != null)
                lSubCategory2.Text = "Подкатегория 2: " + selItem.SubCategory2.Name;
            if (selItem.SubCategory3 != null)
                lSubCategory3.Text = "Подкатегория 3: " + selItem.SubCategory3.Name;
            if (selItem.SubCategory4 != null)
                lSubCategory4.Text = "Подкатегория 4: " + selItem.SubCategory4.Name;
        }

        // Поиск предмета
        private void SearchItems(string query, int organizationId)
        {
            string where = "WHERE(";
            string[] searchWords = query.Split(' ');
            if (query != "")
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
            if (query != "")
            {
                where = where.Remove(where.Length - 3, 3) + ") AND";
            }
            where += organizationId != 0 ? " (i.OrganizationId = " + organizationId + ") AND" : "";
            where += " (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))";

            Item[] items = dgv.FillItems(where);

            foreach (Item item in items)
            {
                dgv.Rows.Add(
                    item.Id,
                    item.Name,
                    item.RetailPrice,
                    item.ServicePrice,
                    item.Quantity,
                    item.UploadDate.Date.ToShortDateString() + " " + item.UploadDate.TimeOfDay,
                    item.ChangeDate.Date.ToShortDateString() + " " + item.ChangeDate.TimeOfDay);

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

            cmsAddItem.Enabled = true;
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
                if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Items WHERE(Main_Category_Id = " + SelectedCategory.Id + ")").ToString()) <= 0)
                {
                    DatabaseWorker.SqlQuery("DELETE FROM Main_Category WHERE(id = " + selectedIdNode + ")");
                    treeView.SelectedNode.Remove();
                }
                else
                    MessageBox.Show("Операцию удаления категории произвести невозможно, так как к ней привязаны один или несколько предметов.", "Удаление категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Items WHERE(Sub_Category_" + (nodeCount - 1) + "_Id = " + SelectedCategory.Id + ")").ToString()) <= 0)
                {
                    DatabaseWorker.SqlQuery("DELETE FROM Sub_Category_" + (nodeCount - 1) + " WHERE(id = " + selectedIdNode + ")");
                    treeView.SelectedNode.Remove();
                }
                else
                    MessageBox.Show("Операцию удаления категории произвести невозможно, так как к ней привязаны один или несколько предметов.", "Удаление категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            treeView.FillCategories(int.Parse(cbOrganizations.SelectedValue.ToString()), cmsCategory);
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

        // Отображение предметов с остатком 0
        private void tsmiZeroResidueItems_Click(object sender, EventArgs e)
        {
            FillItemsByCategory();
        }

        // Отображение удаленных предметов
        private void tsmiDeletedItems_Click(object sender, EventArgs e)
        {
            FillItemsByCategory();
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
                    ChangeCategories(treeView.FormCategories(node), int.Parse(e.Data.GetData(DataFormats.Text).ToString()));
                    FillItemsByCategory();
                }
            }
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                dgv.DoDragDrop(SelectedItem.Id.ToString(), DragDropEffects.Copy);
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
