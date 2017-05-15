﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class MainForm : Form
    {
        // TODO: При обновлении TreeView записывать новый, выделенный ранее нод, и после обновления, его выделять
        // TODO: Когда удаляются все фотографии из предмета, то превьюшка не удаляется         
        // TODO: отобразть превью после назначения фотографии
        // TODO: Сделать вход в программу
        // TODO: Сделать регистрацию организации
        // TODO: Создать ID организации в Items

        public MainForm()
        {
            InitializeComponent();
        }
        
        #region Вспомогательные методы

        // Заполнение TreeView категориями из базы
        private void FillTreeView()
        {
             string path = "";
            TreeNode selectedNode = null;
            if (treeView.SelectedNode != null)
                path = treeView.SelectedNode.FullPath.ToUpper();
                //selectedNode = treeView.SelectedNode;

            treeView.Nodes.Clear();
            TreeNode root = new TreeNode();

            DataTable mainDt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Main_Category");
            if (mainDt.Rows.Count != 0)
            {
                DataTable subCat1Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_1");
                DataTable subCat2Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_2");
                DataTable subCat3Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_3");
                DataTable subCat4Dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sub_Category_4");

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

                Find(treeView.Nodes, path);
                //if (selectedNode != null)               
                   // treeView.SelectedNode = treeView.Nodes[selectedNode.Name];

                
                
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
            for (int i = 0; i < selectedCategories.Length; i++)
            {
                if (i == 0) where += "Main_Category_Id=(SELECT id FROM Main_Category WHERE(id=" + selectedCategories[i] + "))";
                if (i == 1) where += " AND Sub_Category_1_Id=(SELECT id FROM Sub_Category_1 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 2) where += " AND Sub_Category_2_Id=(SELECT id FROM Sub_Category_2 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 3) where += " AND Sub_Category_3_Id=(SELECT id FROM Sub_Category_3 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 4) where += " AND Sub_Category_4_Id=(SELECT id FROM Sub_Category_4 WHERE(id=" + selectedCategories[i] + "))";
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
            //dt.Columns.Add("Примечание");
            dt.Columns.Add("Количество");
            dt.Columns.Add("Дата добавления");           
            dt.Columns.Add("Остаток");

            for (int i = 0; i < items.Rows.Count; i++)
                dt.Rows.Add().ItemArray = items.Rows[i].ItemArray;

            dgv.DataSource = dt;
        }

        // Возвращает массив категорий сформированный по полному пути выделенного нода в TreeView
        private int[] FormCategories()
        {
            int[] categories = new int[5];
            TreeNode parent = treeView.SelectedNode;

            int counter = 0;
            do
            {
                categories[counter++] = int.Parse(parent.Tag.ToString());
                parent = parent.Parent;
            }
            while (parent != null);

            Array.Reverse(categories);
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
            FillDataGridView();
        }


        // Обновляет информацию о выделенном предмете в панели информации
        private void InsertInfoAboutItem(int itemId)
        {
            string query = "SELECT i.*, p.*, s.*, d.* FROM Items i LEFT JOIN Purchase p ON i.id = p.Item_Id LEFT JOIN Selling s ON i.id = s.ItemId LEFT JOIN Defect d ON i.id = d.ItemId WHERE i.id =" + itemId;

            DataTable dt = DatabaseWorker.SqlSelectQuery(query);
            lMain.Text = "Главная категория: " + DatabaseWorker.SqlScalarQuery("SELECT Name FROM Main_Category WHERE(id=" + dt.Rows[0].ItemArray[1].ToString() + ")");
            lsub1.Text = "1-ая подкатегория: " + DatabaseWorker.SqlScalarQuery("SELECT Name FROM Sub_Category_1 WHERE(id=" + dt.Rows[0].ItemArray[2].ToString() + ")");
            lsub2.Text = "2-ая подкатегория: " + DatabaseWorker.SqlScalarQuery("SELECT Name FROM Sub_Category_2 WHERE(id=" + dt.Rows[0].ItemArray[3].ToString() + ")");
            lsub3.Text = "3-ая подкатегория: " + DatabaseWorker.SqlScalarQuery("SELECT Name FROM Sub_Category_3 WHERE(id=" + dt.Rows[0].ItemArray[4].ToString() + ")");
            lsub4.Text = "4-ая подкатегория: " + DatabaseWorker.SqlScalarQuery("SELECT Name FROM Sub_Category_4 WHERE(id=" + dt.Rows[0].ItemArray[5].ToString() + ")");

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
                DatabaseWorker.SqlQuery("INSERT INTO Main_Category VALUES('', '" + category + "')");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Main_Category WHERE(id=LAST_INSERT_ID())").ToString();
                treeView.Nodes.Add(new TreeNode() { Text = category, Tag = id, ContextMenuStrip = cmsCategory });
                
            }
            else
            {
                DatabaseWorker.SqlQuery("INSERT INTO Sub_Category_" + nodeCount + " VALUES('', '" + category + "', " + selectedIdNode + ")");
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
            //if (ecf.ShowDialog() == DialogResult.OK)
                ecf.ShowDialog();
               // FillTreeView();
        }

        // Клик на кнопку "Добавить подкатегорию"
        private void AddSubCategory_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.FullPath.Split('\\').Length < 5)
            {
                EditCategory ecf = new EditCategory(this, int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.FullPath.Split('\\').Length, false);
                // if (ecf.ShowDialog() == DialogResult.OK)
                    ecf.ShowDialog();
                    //FillTreeView();
            }
            else
                MessageBox.Show("Невозможно создать новую категорию");
        }

        // Клик на кнопку "Переименовать категорию"
        private void RenameCategory_Click(object sender, EventArgs e)
        {
            EditCategory ecf = new EditCategory(this, int.Parse(treeView.SelectedNode.Tag.ToString()), treeView.SelectedNode.FullPath.Split('\\').Length, true);
            //if (ecf.ShowDialog() == DialogResult.OK)
            ecf.ShowDialog();
            //    FillTreeView();
        }

        // Клик на кнопку "Удалить категорию"
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory(treeView.SelectedNode.FullPath.Split('\\').Length, int.Parse(treeView.SelectedNode.Tag.ToString()));
           // FillTreeView();
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

        #endregion События
    }
}
