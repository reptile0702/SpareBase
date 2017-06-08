using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SparesBase.Forms;

namespace SparesBase
{
    public partial class MainForm : Form
    {
        // TODO: Добавть журнал поисков 

        // TODO: в "поиске по организациям", буду его Глобальным дальше называть, поле ID уменьшить, за счёт него расширить наименование
        // TODO: надо.. разместить модуль проверки версии..сейчас версия 0.0001A и будем повышать циферку с каждым исправлением) Должна совершать запрос к сайту, проверять актуальную версию, если версия программы ниже актуальной, то не давать запуск, а требовать обновить.
        // TODO: На карточке переход на сайт тогда тоже нужен


        // Выбранная категория в TreeView
        public Category SelectedCategory { get { return (Category)treeView.SelectedNode.Tag; } }

        // Выбранный предмет в DataGridView
        public Item SelectedItem { get { return (Item)dgv.CurrentRow.Tag; } }

        AuthenticationForm au;

        // Конструктор
        public MainForm(AuthenticationForm au)
        {
            InitializeComponent();
            this.au = au;

            // Заполнение заголовка формы именем пользовалеля и названием организации
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT Accounts.LastName, Accounts.FirstName, Accounts.SecondName, Organizations.Name, Accounts.Admin FROM Accounts LEFT JOIN Organizations ON Organizations.id = Accounts.OrganizationId WHERE(Accounts.id=" + EnteredUser.id + ")");
            Text = "База запчастей - " + dt.Rows[0].ItemArray[0] + " " + dt.Rows[0].ItemArray[1] + " " + dt.Rows[0].ItemArray[2] + " - " + dt.Rows[0].ItemArray[3];
            if (dt.Rows[0].ItemArray[4].ToString() != "1")
                tsmiLogs.Visible = false;

            tbSearch.Text = "Поиск";
            tbSearch.ForeColor = Color.Gray;

            treeView.FillCategories(EnteredUser.OrganizationId, cmsCategory);
            InitializeDataGridView();
        }


        #region Заполнение данных

        // Заполнение предметов по категориям
        private void FillItemsByCategory()
        {
            int[] selectedCategories = FormCategories();

            // Формирование условия WHERE
            string where = "WHERE (";
            for (int i = 0; i < treeView.SelectedNode.FullPath.Split('\\').Length; i++)
            {
                if (i == 0) where += "(i.Main_Category_Id=(SELECT id FROM Main_Category WHERE(id=" + selectedCategories[i] + "))";
                if (i == 1) where += " AND i.Sub_Category_1_Id=(SELECT id FROM Sub_Category_1 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 2) where += " AND i.Sub_Category_2_Id=(SELECT id FROM Sub_Category_2 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 3) where += " AND i.Sub_Category_3_Id=(SELECT id FROM Sub_Category_3 WHERE(id=" + selectedCategories[i] + "))";
                if (i == 4) where += " AND i.Sub_Category_4_Id=(SELECT id FROM Sub_Category_4 WHERE(id=" + selectedCategories[i] + "))";
            }
            where += ") AND (i.Residue > 0) AND (i.Deleted <> 1))";

            Item[] items = dgv.FillItems(where);
            foreach (Item item in items)
            {
#if DEBUG
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

#else
                dgv.Rows.Add(                    
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
#endif

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;
            }
        }

        #endregion Заполнение данных



        #region Вспомогательные методы

        // Инициализация DataGridView
        private void InitializeDataGridView()
        {
            dgv.Columns.Clear();

#if DEBUG
            dgv.Columns.Add("id", "ID");
#endif
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

#if DEBUG
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
#else
            
            dgv.Columns[0].Width = 150;
            dgv.Columns[1].Width = 120;
            dgv.Columns[2].Width = 90;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 90;
            dgv.Columns[5].Width = 90;
            dgv.Columns[6].Width = 90;
            dgv.Columns[7].Width = 90;
            dgv.Columns[8].Width = 90;
            dgv.Columns[9].Width = 120;
            dgv.Columns[10].Width = 120;
            dgv.Columns[11].Width = 70;
#endif
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
            EditForm form = new EditForm(FormCategories());
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

            DatabaseWorker.SqlQuery("UPDATE Items SET Deleted = 1 WHERE(id = " + SelectedItem.Id + ")");
            FtpManager.DeleteItemImages(SelectedItem.Id);
            DatabaseWorker.InsertAction(3, SelectedItem.Id);
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

            lMainCat.Text = "Главная категория: " + selItem.MainCategory.Name;
            if (selItem.SubCategory1 != null)
                lSub1.Text = "Подкатегория 1: " + selItem.SubCategory1.Name;
            if (selItem.SubCategory2 != null)
                lSub2.Text = "Подкатегория 2: " + selItem.SubCategory2.Name;
            if (selItem.SubCategory3 != null)
                lSub3.Text = "Подкатегория 3: " + selItem.SubCategory3.Name;
            if (selItem.SubCategory4 != null)
                lSub4.Text = "Подкатегория 4: " + selItem.SubCategory4.Name;
        }

        // Поиск предмета
        private void SearchItems(string query)
        {
            string where = "WHERE(";//organizationId != 0 ? "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.OrganizationId = " + organizationId + ") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))" : "WHERE((i.Item_Name LIKE \"%" + searchStr + "%\" OR i.Note LIKE \"%" + searchStr + "%\") AND (i.SearchAllowed = 1) AND (i.Residue > 0) AND (i.Deleted <> 1))";
            string[] searchWords = tbSearch.Text.Split(' ');
            if (tbSearch.Text != "")
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
            if (tbSearch.Text != "")
            {
                where = where.Remove(where.Length - 3, 3) + ") AND";
            }
            where += " (i.OrganizationId = " + EnteredUser.OrganizationId + ") AND";
            //where += searchStr != "" || organizationId != 0 ? " AND ": 
            where += " (i.Residue > 0) AND (i.Deleted <> 1))";
            Item[] items = dgv.FillItems(where);
            foreach (Item item in items)
            {
#if DEBUG
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
                    item.Residue);

#else
                dgv.Rows.Add(                    
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
                    item.Residue);
#endif

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;
            }
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

                Category cat = new Category(
                    int.Parse(id),
                    category,
                    selectedIdNode,
                    EnteredUser.OrganizationId);

                treeView.Nodes.Add(new TreeNode() { Text = category, Tag = cat, ContextMenuStrip = cmsCategory });
            }
            else
            {
                DatabaseWorker.SqlQuery("INSERT INTO Sub_Category_" + nodeCount + " VALUES('', '" + category + "', " + selectedIdNode + ", " + EnteredUser.OrganizationId + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_" + nodeCount + " WHERE(id=LAST_INSERT_ID())").ToString();

                Category cat = new Category(
                    int.Parse(id),
                    category,
                    selectedIdNode,
                    EnteredUser.OrganizationId);

                treeView.SelectedNode.Nodes.Add(new TreeNode() { Text = category, Tag = cat, ContextMenuStrip = cmsCategory });
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

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            treeView.FillCategories(EnteredUser.OrganizationId, cmsCategory);
        }

        // Выделение нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillItemsByCategory();
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
                EditCategory ecf = new EditCategory(this, SelectedCategory.Id, treeView.SelectedNode.FullPath.Split('\\').Length, false, "");
                ecf.ShowDialog();
            }
            else
                MessageBox.Show("Невозможно создать новую категорию", "Создание категории", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Клик на кнопку "Переименовать категорию"
        private void RenameCategory_Click(object sender, EventArgs e)
        {
            EditCategory ecf = new EditCategory(this, SelectedCategory.Id, treeView.SelectedNode.FullPath.Split('\\').Length, true, SelectedCategory.Name);
            ecf.ShowDialog();
        }

        // Клик на кнопку "Удалить категорию"
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить категорию \"" + SelectedCategory.Name + "\"?", "Удаление категории", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DeleteCategory(treeView.SelectedNode.FullPath.Split('\\').Length, SelectedCategory.Id);
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




        // Закрытие формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!au.Visible)
            {
                Application.Exit();
            }

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
            {
                //MessageBox.Show(e.Data.GetData(DataFormats.Text).ToString() + " " + node.Text);
                if (MessageBox.Show("Вы уверены, что хотите переместить предмет из категорий \"" + treeView.SelectedNode.FullPath.Replace("\\", " - ") + "\" в категории \"" + node.FullPath.Replace("\\", " - ") + "\"?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ChangeCategories(FormCategories(node), int.Parse(e.Data.GetData(DataFormats.Text).ToString()));
                    FillItemsByCategory();

                }

            }
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgv.CurrentRow != null)
                {
                    dgv.DoDragDrop(dgv.CurrentRow.Cells[0].Value.ToString(), DragDropEffects.Copy);
                }

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
                SearchItems(tbSearch.Text);
            }
        }

        private void tsmiChangeAccount_Click(object sender, EventArgs e)
        {
            au.InitializeForm();
            au.Show();
            Close();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            EmployeesForm employees = new EmployeesForm();
            employees.ShowDialog();
        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            SearchingForm sf = new SearchingForm();
            sf.ShowDialog();
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

        private void tsmiSellers_Click(object sender, EventArgs e)
        {
            SellerForm sf = new SellerForm();
            sf.ShowDialog();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                InsertInfoAboutItem();
            }
        }

       
    }
}
