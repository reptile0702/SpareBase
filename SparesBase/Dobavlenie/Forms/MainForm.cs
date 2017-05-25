using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class MainForm : Form
    {
        // TODO: Когда удаляются все фотографии из предмета, то превьюшка не удаляется     
        // TODO: отобразть превью после назначения фотографии
        // TODO: Загружать фотки предмета только при его добавлении или изменении

        // TODO: Возможность переносить предметы в другие категории


        // TODO: При нажатии на кнопку "Добавить нового поставщика", открывать форму добавления поставщика, а не список их

        // TODO: Доработать Drug`n`Drop(раскрытие нода при удержание мыши над ним)

        // TODO: Галочка: разршён ли поиск.
        // TODO: Привилегия для Админов.
        // TODO: Поиск по дате в логах.


        // Конструктор
        public MainForm()
        {
            InitializeComponent();

            // Заполнение заголовка формы именем пользовалеля и названием организации
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT Accounts.LastName, Accounts.FirstName, Accounts.SecondName, Organizations.Name FROM Accounts LEFT JOIN Organizations ON Organizations.id = Accounts.OrganizationId WHERE(Accounts.id=" + EnteredUser.id + ")");
            Text = "База запчастей - " + dt.Rows[0].ItemArray[0] + " " + dt.Rows[0].ItemArray[1] + " " + dt.Rows[0].ItemArray[2] + " - " + dt.Rows[0].ItemArray[3];
        }

        private void Search(string query)
        {
            DataTable items = DatabaseWorker.SqlSelectQuery("SELECT Items.id, Item_Name, Sellers.name, Purchase_Price, Retail_Price, Wholesale_Price, Service_Price, Storage, Quantity, Upload_Date, Residue FROM Items INNER JOIN Sellers ON Items.Seller_Id = Sellers.id WHERE(Item_Name LIKE \"%" + query + "%\" OR Note LIKE \"%" + query + "%\")");

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Поставщик");
            dt.Columns.Add("Закупка");
            dt.Columns.Add("Розница");
            dt.Columns.Add("Мелкий опт");
            dt.Columns.Add("Сервисы");
            dt.Columns.Add("Хранение");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Дата добавления");
            dt.Columns.Add("Остаток");

            for (int i = 0; i < items.Rows.Count; i++)
                dt.Rows.Add().ItemArray = items.Rows[i].ItemArray;

            if (dt.Rows.Count == 0)
            {
                cmsDeleteItem.Enabled = false;
                cmsEditItem.Enabled = false;
            }
            else
            {
                cmsEditItem.Enabled = true;
                cmsDeleteItem.Enabled = true;
            }

            dgv.DataSource = dt;
            dgv.Columns[0].Width = 90;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 90;

            for (int i = 0; i < dgv.Rows.Count; i++)
                if (i % 2 != 0)
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

            cmsAddItem.Enabled = false;
        }

        #region Вспомогательные методы

        // Заполнение TreeView категориями из базы
        private void FillTreeView()
        {
            treeView.Nodes.Clear();
            TreeNode root = new TreeNode();

            DataTable mainDt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Main_Category WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
            if (mainDt.Rows.Count != 0)
            {
                DataTable subCat1Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_1 WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
                DataTable subCat2Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_2 WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
                DataTable subCat3Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_3 WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
                DataTable subCat4Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_4 WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");

                // MainCat
                foreach (DataRow row in mainDt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    root.Nodes.Add(newTreeNode);
                }

                // SubCat1
                foreach (DataRow row in subCat1Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    string mainId = row.ItemArray[2].ToString();

                    foreach (TreeNode node in root.Nodes)
                        if (node.Tag.ToString() == mainId)
                            node.Nodes.Add(newTreeNode);
                }

                // SubCat2
                foreach (DataRow row in subCat2Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    string sub1Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            if (sub1Node.Tag.ToString() == sub1Id)
                                sub1Node.Nodes.Add(newTreeNode);
                }

                // SubCat3
                foreach (DataRow row in subCat3Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    string sub2Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                if (sub2Node.Tag.ToString() == sub2Id)
                                    sub2Node.Nodes.Add(newTreeNode);
                }

                // SubCat4
                foreach (DataRow row in subCat4Dt.Rows)
                {
                    TreeNode newTreeNode = new TreeNode(row.ItemArray[1].ToString());
                    newTreeNode.Tag = row.ItemArray[0];
                    newTreeNode.ContextMenuStrip = cmsCategory;
                    string sub3Id = row.ItemArray[2].ToString();

                    foreach (TreeNode rootNode in root.Nodes)
                        foreach (TreeNode sub1Node in rootNode.Nodes)
                            foreach (TreeNode sub2Node in sub1Node.Nodes)
                                foreach (TreeNode sub3Node in sub2Node.Nodes)
                                    if (sub3Node.Tag.ToString() == sub3Id)
                                        sub3Node.Nodes.Add(newTreeNode);
                }

                // Добавление нодов в TreeView
                foreach (TreeNode node in root.Nodes)
                    treeView.Nodes.Add(node);
            }
        }

        // Поиск нода по пути
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

        // Заполнение DataGridView предметами по выделенным категориям в TreeView
        public void FillDataGridView()
        {
            int[] selectedCategories = FormCategories();

            // Формирование условия WHERE
            string where = "WHERE (";
            for (int i = 0; i < treeView.SelectedNode.FullPath.Split('\\').Length; i++)
            {
                if (i == 0) where += "Main_Category_Id=(SELECT id FROM Main_Category WHERE(id=" + selectedCategories[i] + " AND OrganizationId=" + EnteredUser.OrganizationId + "))";
                if (i == 1) where += " AND Sub_Category_1_Id=(SELECT id FROM Sub_Category_1 WHERE(id=" + selectedCategories[i] + " AND OrganizationId=" + EnteredUser.OrganizationId + "))";
                if (i == 2) where += " AND Sub_Category_2_Id=(SELECT id FROM Sub_Category_2 WHERE(id=" + selectedCategories[i] + " AND OrganizationId=" + EnteredUser.OrganizationId + "))";
                if (i == 3) where += " AND Sub_Category_3_Id=(SELECT id FROM Sub_Category_3 WHERE(id=" + selectedCategories[i] + " AND OrganizationId=" + EnteredUser.OrganizationId + "))";
                if (i == 4) where += " AND Sub_Category_4_Id=(SELECT id FROM Sub_Category_4 WHERE(id=" + selectedCategories[i] + " AND OrganizationId=" + EnteredUser.OrganizationId + "))";
            }
            where += ")";

            // Выполнение запроса
            DataTable items = DatabaseWorker.SqlSelectQuery("SELECT Items.id, Item_Name, Sellers.name, Purchase_Price, Retail_Price, Wholesale_Price, Service_Price, Storage, Quantity, Upload_Date, Residue FROM Items INNER JOIN Sellers ON Items.Seller_Id = Sellers.id " + where);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Поставщик");
            dt.Columns.Add("Закупка");
            dt.Columns.Add("Розница");
            dt.Columns.Add("Мелкий опт");
            dt.Columns.Add("Сервисы");
            dt.Columns.Add("Хранение");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Дата добавления");
            dt.Columns.Add("Остаток");

            for (int i = 0; i < items.Rows.Count; i++)
                dt.Rows.Add().ItemArray = items.Rows[i].ItemArray;

            if (dt.Rows.Count == 0)
            {
                cmsDeleteItem.Enabled = false;
                cmsEditItem.Enabled = false;
            }
            else
            {
                cmsEditItem.Enabled = true;
                cmsDeleteItem.Enabled = true;
            }

            dgv.DataSource = dt;
            dgv.Columns[0].Width = 90;
            dgv.Columns[1].Width = 90;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 90;

            for (int i = 0; i < dgv.Rows.Count; i++)
                if (i % 2 != 0)
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

            cmsAddItem.Enabled = true;
        }

        // Возвращает массив категорий сформированный по полному пути выделенного нода в TreeView
        private int[] FormCategories()
        {
            int[] categories = new int[5];
            List<int> cats = new List<int>();
            TreeNode parent = treeView.SelectedNode;

            do
            {
                cats.Add(int.Parse(parent.Tag.ToString()));
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
            EditForm form = new EditForm(FormCategories());
            form.ShowDialog();
            FillDataGridView();
        }

        // Редактировать предмет
        private void EditItem()
        {
            EditForm form = new EditForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()), FormCategories());
            form.ShowDialog();
            FillDataGridView();
        }

        // Удалить предмет
        private void DeleteItem()
        {
            int selectedItemId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            DatabaseWorker.SqlQuery("DELETE FROM Items WHERE(id = " + selectedItemId + ")");
            PhotoEditor pe = new PhotoEditor(selectedItemId, true);
            pe.DeleteItemImages();
            DatabaseWorker.InsertAction(3, selectedItemId);
            FillDataGridView();
        }


        // Обновляет информацию о выделенном предмете в панели информации
        private void InsertInfoAboutItem(int itemId)
        {
            string query = "SELECT i.*, p.*, s.*, d.* FROM Items i LEFT JOIN Purchase p ON i.id = p.ItemId LEFT JOIN Selling s ON i.id = s.ItemId LEFT JOIN Defect d ON i.id = d.ItemId WHERE i.id =" + itemId;

            DataTable dt = DatabaseWorker.SqlSelectQuery(query);


            lname.Text = "Имя: " + dt.Rows[0].ItemArray[6].ToString();
            lseller.Text = "Поставщик: " + DatabaseWorker.SqlScalarQuery("SELECT name FROM Sellers WHERE(id=" + dt.Rows[0].ItemArray[7].ToString() + ")");
            lpurchase.Text = "Закупка: " + dt.Rows[0].ItemArray[8].ToString();
            lretail.Text = "Розница: " + dt.Rows[0].ItemArray[9].ToString();
            lwhole.Text = "Мелкий опт: " + dt.Rows[0].ItemArray[10].ToString();
            lservice.Text = "Сервисы: " + dt.Rows[0].ItemArray[11].ToString();
            lfirm.Text = "Фирменная цена: " + dt.Rows[0].ItemArray[12].ToString();
            lstorage.Text = "Хранение: \n" + dt.Rows[0].ItemArray[13].ToString();
            lnote.Text = "Описание: \n" + dt.Rows[0].ItemArray[14].ToString();
            lquantity.Text = "Количество: " + dt.Rows[0].ItemArray[15].ToString();
            lresidue.Text = "Остаток: " + dt.Rows[0].ItemArray[17].ToString();

            lnumber.Text = "Номер заказа: " + dt.Rows[0].ItemArray[19].ToString();
            lpurquant.Text = "Количество: " + dt.Rows[0].ItemArray[20].ToString();
            lfirmprice.Text = "Фирменная цена: " + dt.Rows[0].ItemArray[21].ToString();
            ltotal.Text = "Итоговая цена: " + dt.Rows[0].ItemArray[22].ToString();

            lsellquantity.Text = "Количество: " + dt.Rows[0].ItemArray[25].ToString();
            lsellprice.Text = "Цена: " + dt.Rows[0].ItemArray[26].ToString();

            ldefectquantity.Text = "Количество: " + dt.Rows[0].ItemArray[30].ToString();
            lwhoidentified.Text = "Кто выявил: " + dt.Rows[0].ItemArray[31].ToString();
            ldefectnote.Text = "Описание: \n" + dt.Rows[0].ItemArray[32].ToString();
        }

        #endregion Предметы



        #region Категории

        // Добавляет новую категорию
        public void AddCategory(int nodeCount, int selectedIdNode, string category)
        {
            string id = "";
            if (nodeCount == 0)
            {
                DatabaseWorker.SqlQuery("INSERT INTO Main_Category VALUES('', '" + category + "', " + EnteredUser.OrganizationId + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Main_Category WHERE(id=LAST_INSERT_ID())").ToString();
                treeView.Nodes.Add(new TreeNode() { Text = category, Tag = id, ContextMenuStrip = cmsCategory });
            }
            else
            {
                DatabaseWorker.SqlQuery("INSERT INTO Sub_Category_" + nodeCount + " VALUES('', '" + category + "', " + selectedIdNode + ", " + EnteredUser.OrganizationId + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_" + nodeCount + " WHERE(id=LAST_INSERT_ID())").ToString();
                treeView.SelectedNode.Nodes.Add(new TreeNode() { Text = category, Tag = id, ContextMenuStrip = cmsCategory });
            }
        }

        // Переименовать категорию
        public void RenameCategory(int nodeCount, int selectedIdNode, string newName)
        {
            if (nodeCount == 1) DatabaseWorker.SqlQuery("UPDATE Main_Category SET Name = '" + newName + "' WHERE(id = " + selectedIdNode + ")");
            else DatabaseWorker.SqlQuery("UPDATE Sub_Category_" + (nodeCount - 1) + " SET Name = '" + newName + "' WHERE(id = " + selectedIdNode + ")");
            treeView.SelectedNode.Text = newName;
        }

        // Удалить категорию
        public void DeleteCategory(int nodeCount, int selectedIdNode)
        {
            if (nodeCount == 1) DatabaseWorker.SqlQuery("DELETE FROM Main_Category WHERE(id = " + selectedIdNode + ")");
            else DatabaseWorker.SqlQuery("DELETE FROM Sub_Category_" + (nodeCount - 1) + " WHERE(id = " + selectedIdNode + ")");
            treeView.SelectedNode.Remove();
        }

        #endregion Категории



        #region События

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            FillTreeView();
        }

        // Выделение нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillDataGridView();
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
                EditCategory ecf = new EditCategory(this, int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.FullPath.Split('\\').Length, false);
                ecf.ShowDialog();
            }
            else
                MessageBox.Show("Невозможно создать новую категорию");
        }

        // Клик на кнопку "Переименовать категорию"
        private void RenameCategory_Click(object sender, EventArgs e)
        {
            EditCategory ecf = new EditCategory(this, int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.FullPath.Split('\\').Length, true);
            ecf.ShowDialog();
        }

        // Клик на кнопку "Удалить категорию"
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory(treeView.SelectedNode.FullPath.Split('\\').Length, int.Parse(treeView.SelectedNode.Tag.ToString()));
        }


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
            DeleteItem();
        }

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


        // Клик на ячейку предмета в DataGridView
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InsertInfoAboutItem(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
        }

        // Закрытие формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Журнал действий
        private void tsmiActionLogs_Click(object sender, EventArgs e)
        {
            ActionLogsForm alf = new ActionLogsForm();
            alf.ShowDialog();
        }

        #endregion События


        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = treeView.PointToClient(Cursor.Position);
            TreeNode node = treeView.GetNodeAt(pt);
            if (node != null)
                MessageBox.Show(e.Data.GetData(DataFormats.Text).ToString() + " " + node.Text);
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgv.DoDragDrop(dgv.CurrentRow.Cells[0].Value.ToString(), DragDropEffects.Copy);
            }
        }

        private void treeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(tbSearch.Text);
            }
        }
    }
}
