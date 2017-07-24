using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SparesBase.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace SparesBase
{
    public partial class MainForm : Form
    {
        // TODO: Добавть журнал поисков  ???

        // TODO: Придумать систему обновления через загрузку всех файлов программы с сервера и установку их на компьютер
        // TODO: Сделать проверку хеш суммы файлов для закачки на компьютер. Хеш суммы хранить в базе данных. Хранить там хеши баннеров и файлов обновления

        #region Поля

        AuthenticationForm au;
        Thread previewThread;

        #endregion Поля



        #region Свойства

        // Выбранная категория в TreeView
        public Category SelectedCategory { get { return (Category)treeView.SelectedNode.Tag; } }

        // Выбранный предмет в DataGridView
        public Item SelectedItem
        {
            get
            {
                if (dgv.CurrentRow != null)
                    return (Item)dgv.CurrentRow.Tag;
                else
                    return null;
            }
        }

        #endregion Свойства



        #region Конструкторы

        // Конструктор
        public MainForm(AuthenticationForm au)
        {
            InitializeComponent();
            this.au = au;

            // Заполнение заголовка формы именем пользовалеля и названием организации
            Text = "База запчастей - " +
                EnteredUser.LastName +
                " " + EnteredUser.FirstName +
                " " + EnteredUser.SecondName +
                " - " + EnteredUser.Organization.Name;

            if (!EnteredUser.Admin)
                tsmiLogs.Visible = false;

            if (!EnteredUser.Admin)
            {
                tsmiLogs.Visible = false;
                tsmiEmployees.Visible = false;
            }

            if (Settings.AutoLoadItemImages)
                btnLoadImage.Visible = false;

            tbSearch.Text = "Поиск";
            tbSearch.ForeColor = Color.Gray;

            treeView.FillCategories(EnteredUser.Organization.Id, cmsCategory);
            ClearInfoAboutItem();
        }

        #endregion Конструкторы



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

            // Запоминание выбранной строки, если она есть
            Item selectedItem = null;
            if (dgv.CurrentRow != null)
                selectedItem = (Item)dgv.CurrentRow.Tag;

            // Получение предметов из базы
            Item[] items = dgv.FillItems(where);
            FillRows(items);
        }

        #endregion Заполнение данных



        #region Вспомогательные методы

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

            while (parent != null)
            {
                Category category = (Category)parent.Tag;
                cats.Add(category.Id);
                parent = parent.Parent;
            }


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

        // Подсчет остатка
        private void CalcResidue(int quantity, int itemId)
        {
            int purchase = 0;
            int selling = 0;
            int defect = 0;

            // Подсчет всех строк
            // В заказ
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT Quantity FROM Purchase WHERE(ItemId=" + itemId + ")");
            foreach (DataRow row in dt.Rows)
                purchase += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

            // Продажа
            dt = DatabaseWorker.SqlSelectQuery("SELECT Quantity FROM Selling WHERE(ItemId=" + itemId + ")");
            foreach (DataRow row in dt.Rows)
                selling += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

            // Брак
            dt = DatabaseWorker.SqlSelectQuery("SELECT QuantityOfDefect FROM Defect WHERE(ItemId=" + itemId + ")");
            foreach (DataRow row in dt.Rows)
                defect += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

            // Остаток                            
            int residue = quantity - (purchase + selling + defect);

            // Занесение остатка в базу
            DatabaseWorker.SqlQuery("UPDATE Items SET Residue = " + residue + " WHERE(id = " + itemId + ")");
        }

        // Заполнение строчек предметов
        private void FillRows(Item[] items)
        {
            // Запоминание выбранной строки, если она есть
            Item selectedItem = null;
            if (dgv.CurrentRow != null)
                selectedItem = (Item)dgv.CurrentRow.Tag;

            foreach (Item item in items)
            {
                dgv.Rows.Add(
                item.InventNumber,
                item.Name,
                item.Seller.Name,
                item.PurchasePrice,
                item.RetailPrice,
                item.WholesalePrice,
                item.ServicePrice,
                item.FirmPrice,
                item.Storage,
                item.Quantity,
                item.UploadDate.Date.ToShortDateString(),
                item.ChangeDate.Date.ToShortDateString(),
                item.Residue,
                item.Status);

                dgv.Rows[dgv.Rows.Count - 1].Tag = item;

                // Выделение ранее выделенного предмета, если таковой существует
                if (selectedItem != null)
                    if (item.Id == selectedItem.Id)
                        dgv.Rows[dgv.Rows.Count - 1].Selected = true;
            }

            // Очистка информации о предыдущем предмете
            if (dgv.Rows.Count > 0)
            {
                ClearInfoAboutItem();
                InsertInfoAboutItem((Item)dgv.Rows[0].Tag);
            }
            else
                ClearInfoAboutItem();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                // Определение цвета статуса предмета
                if (dgv["status", i].Value.ToString() == "В наличии")
                    dgv["status", i].Style.BackColor = Color.Aqua;
                else if (dgv["status", i].Value.ToString() == "Доставка")
                    dgv["status", i].Style.BackColor = Color.Bisque;
                else if (dgv["status", i].Value.ToString() == "Транзит")
                    dgv["status", i].Style.BackColor = Color.CadetBlue;

                // Назначение контекстного меню списания на все соответствующие ячейки
                dgv["residue", i].ContextMenuStrip = cmsWriteOff;
            }
        }

        // Загрузка превью-фотографии
        private void DownloadPreview()
        {
            if (SelectedItem == null)
                return;

            pbPreview.Image = null;

            if (previewThread != null)
                previewThread.Abort();

            // Загрузка превью-фотографии в отдельном потоке
            previewThread = new Thread(() =>
            {
                pbPreview.SizeMode = PictureBoxSizeMode.CenterImage;
                pbPreview.Image = Properties.Resources.LoadGif;

                Thread.Sleep(400);

                // Проверка на существование превью-фотографии
                if (FtpManager.PreviewExists(SelectedItem.Id))
                {
                    // Загрузка превью-фотографии
                    WebClient wcPreview = new WebClient();
                    wcPreview.DownloadDataCompleted += WcPreview_DownloadDataCompleted;
                    byte[] imageBytes = wcPreview.DownloadData(new Uri(FtpManager.FtpConnectString + "Photos/item_" + SelectedItem.Id + "/preview.jpg"));
                    MemoryStream ms = new MemoryStream(imageBytes);
                    pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    pbPreview.Image = Image.FromStream(ms);
                }
                else
                    pbPreview.Image = null;
            });
            previewThread.Start();
        }

        #endregion Вспомогательные методы



        #region Предметы

        // Добавить предмет
        private void AddItem()
        {
            EditForm form = new EditForm(FormCategories());
            form.ShowDialog();
            if (tbSearch.Text == "Поиск" || tbSearch.Text.Trim() == "")
                FillItemsByCategory();
            else
                SearchItems(tbSearch.Text);
        }

        // Редактировать предмет
        private void EditItem()
        {
            EditForm form = new EditForm(SelectedItem);
            form.ShowDialog();
            if (tbSearch.Text == "Поиск" || tbSearch.Text.Trim() == "")
                FillItemsByCategory();
            else
                SearchItems(tbSearch.Text);
        }

        // Удалить предмет
        private void DeleteItem()
        {
            DatabaseWorker.SqlQuery("UPDATE Items SET Deleted = 1 WHERE(id = " + SelectedItem.Id + ")");
            FtpManager.DeleteItemImages(SelectedItem.Id);
            DatabaseWorker.InsertAction(3, SelectedItem.Id);
            if (tbSearch.Text == "Поиск" || tbSearch.Text.Trim() == "")
                FillItemsByCategory();
            else
                SearchItems(tbSearch.Text);
        }

        // Обновляет информацию о выделенном предмете в панели информации
        private void InsertInfoAboutItem(Item selItem)
        {
            lname.Text = "Имя: " + selItem.Name;
            lseller.Text = "Поставщик: " + (selItem.Seller != null ? selItem.Seller.Name : "Без поставщика");
            lpurchase.Text = "Закупка: " + selItem.PurchasePrice;
            lretail.Text = "Розница: " + selItem.RetailPrice;
            lwhole.Text = "Мелкий опт: " + selItem.WholesalePrice;
            lservice.Text = "Сервисы: " + selItem.ServicePrice;
            lfirm.Text = "Фирменная цена: " + selItem.FirmPrice;
            lstorage.Text = "Хранение: \n" + selItem.Storage;
            lnote.Text = "Описание: \n" + selItem.Note;
            lquantity.Text = "Количество: " + selItem.Quantity;
            lresidue.Text = "Остаток: " + selItem.Residue;

            lCategories.Text = "Категории: " + selItem.MainCategory.Name;
            if (selItem.SubCategory1 != null)
                lCategories.Text += " => " + selItem.SubCategory1.Name;
            if (selItem.SubCategory2 != null)
                lCategories.Text += " => " + selItem.SubCategory2.Name;
            if (selItem.SubCategory3 != null)
                lCategories.Text += " => : " + selItem.SubCategory3.Name;
            if (selItem.SubCategory4 != null)
                lCategories.Text += " => : " + selItem.SubCategory4.Name;
        }

        // Очищение информации о предмете
        private void ClearInfoAboutItem()
        {
            lname.Text = "Имя: ";
            lseller.Text = "Поставщик: ";
            lpurchase.Text = "Закупка: ";
            lretail.Text = "Розница: ";
            lwhole.Text = "Мелкий опт: ";
            lservice.Text = "Сервисы: ";
            lfirm.Text = "Фирменная цена: ";
            lstorage.Text = "Хранение: \n";
            lnote.Text = "Описание: \n";
            lquantity.Text = "Количество: ";
            lresidue.Text = "Остаток: ";
            lCategories.Text = "Категория: ";
        }

        // Поиск предмета
        private void SearchItems(string query)
        {
            Item[] items;
            string where = "WHERE(";
            if (cbSerial.Checked)
            {
                // Поиск предмета по серийному номеру
                where += "i.SerialNumber LIKE'%" + tbSearch.Text + "%' AND i.OrganizationId = " + EnteredUser.Organization.Id + ")";
                items = dgv.FillItems(where);
            }
            else
            {
                // Поиск предмета по словам
                string[] searchWords = tbSearch.Text.Split(' ');
                if (tbSearch.Text != "")
                    where += "(";

                foreach (string word in searchWords)
                    if (word != "")
                        where += "i.Item_Name LIKE \"%" + word + "%\" OR ";

                if (tbSearch.Text != "")
                    where = where.Remove(where.Length - 3, 3) + ") AND";

                where += " (i.OrganizationId = " + EnteredUser.Organization.Id + ") AND";
                where += " (i.Residue > 0) AND (i.Deleted <> 1))";
                items = dgv.FillItems(where);
            }

            FillRows(items);
        }

        #endregion Предметы



        #region Категории

        // Добавляет новую категорию
        public void AddCategory(int nodeCount, int selectedIdNode, string category)
        {
            string id = "";
            if (nodeCount == 0)
            {
                // Главная категория
                DatabaseWorker.SqlQuery("INSERT INTO Main_Category VALUES('', '" + category + "', " + EnteredUser.Organization.Id + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Main_Category WHERE(id=LAST_INSERT_ID())").ToString();

                Category cat = new Category(
                    int.Parse(id),
                    category,
                    selectedIdNode,
                    EnteredUser.Organization.Id);

                treeView.Nodes.Add(new TreeNode() { Text = category, Tag = cat, ContextMenuStrip = cmsCategory });
            }
            else
            {
                // Подкатегория
                DatabaseWorker.SqlQuery("INSERT INTO Sub_Category_" + nodeCount + " VALUES('', '" + category + "', " + selectedIdNode + ", " + EnteredUser.Organization.Id + ")");
                id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_" + nodeCount + " WHERE(id=LAST_INSERT_ID())").ToString();

                Category cat = new Category(
                    int.Parse(id),
                    category,
                    selectedIdNode,
                    EnteredUser.Organization.Id);

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
            DatabaseWorker.SqlQuery("UPDATE Items Set " +
                "Main_Category_Id = " + categories[0] + ", " +
                "Sub_Category_1_Id = " + categories[1] + ", " +
                "Sub_Category_2_Id = " + categories[2] + ", " +
                "Sub_Category_3_Id = " + categories[3] + ", " +
                "Sub_Category_4_Id = " + categories[4] + " " +
                "WHERE(id = " + itemId + ")");
        }

        #endregion Категории



        #region События

        #region Разные

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            //treeView.FillCategories(EnteredUser.Organization.Id, cmsCategory);
        }

        // Закрытие формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!au.Visible)
                Application.Exit();
        }

        // Выделение нода в TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillItemsByCategory();
        }

        // Журнал действий
        private void tsmiActionLogs_Click(object sender, EventArgs e)
        {
            ActionLogsForm alf = new ActionLogsForm();
            alf.ShowDialog();
        }

        // Смена аккаунта
        private void tsmiChangeAccount_Click(object sender, EventArgs e)
        {
            au.AccountExit();
            au.Show();
            Close();
        }

        // Выход из программы
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сотрудники
        private void tsmiEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm employees = new EmployeesForm();
            employees.ShowDialog();
        }

        // Поставщики
        private void tsmiSellers_Click(object sender, EventArgs e)
        {
            SellerForm sf = new SellerForm();
            sf.ShowDialog();
        }

        // Информация об аккаунте
        private void tsmiAccountInfo_Click(object sender, EventArgs e)
        {
            Account account = new Account(
                    EnteredUser.Id,
                    EnteredUser.FirstName,
                    EnteredUser.LastName,
                    EnteredUser.SecondName,
                    EnteredUser.Login,
                    EnteredUser.Organization,
                    EnteredUser.City,
                    EnteredUser.Phone,
                    EnteredUser.Email,
                    EnteredUser.Admin);

            AccountEditor ae = new AccountEditor(account);
            ae.ShowDialog();
        }

        // О программе
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        // Настройки
        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        #endregion Разные

        #region Категории

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
            DeleteItem();
        }

        // Загрузить превью-фотографию
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            btnLoadImage.Visible = false;
            DownloadPreview();
        }

        // Нажатие на Enter
        private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SelectedItem != null)
                EditItem();
        }

        // Предотвращение перехода на новую строчку при нажатии Enter
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }

        // Смена выделенного предмета
        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                InsertInfoAboutItem(SelectedItem);

                // Загрузка превью-фотографии
                if (Settings.AutoLoadItemImages)
                {
                    btnLoadImage.Visible = false;
                    DownloadPreview();
                }
                else
                {
                    pbPreview.Image = null;
                    btnLoadImage.Visible = true;
                }
            }
        }

        // Окончание загрузки превью-фотографии
        private void WcPreview_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MemoryStream ms = new MemoryStream(e.Result);
                pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                pbPreview.Image = Image.FromStream(ms);
            }
            else
                pbPreview.Image = null;
        }

        #endregion Предметы

        #region TreeView

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

        #endregion TreeView

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
                if (MessageBox.Show("Вы уверены, что хотите переместить предмет из категорий \"" + treeView.SelectedNode.FullPath.Replace("\\", " - ") + "\" в категории \"" + node.FullPath.Replace("\\", " - ") + "\"?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ChangeCategories(FormCategories(node), int.Parse(e.Data.GetData(DataFormats.Text).ToString()));
                    FillItemsByCategory();
                }
            }
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                dgv.CurrentRow != null &&
                dgv.HitTest(e.X, e.Y).RowIndex != -1)
            {
                Item item = (Item)dgv.CurrentRow.Tag;
                dgv.DoDragDrop(item.Id.ToString(), DragDropEffects.Copy);
            }
        }

        #endregion Drag'n'Drop

        #region Списания

        // Продажа
        private void cmsSelling_Click(object sender, EventArgs e)
        {
            Item item = SelectedItem;
            SellingForm sel = new SellingForm(item.Quantity, int.Parse(item.RetailPrice), int.Parse(item.WholesalePrice), int.Parse(item.ServicePrice), item.Id);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                CalcResidue(item.Quantity, item.Id);
                FillItemsByCategory();
            }
        }

        // Дефект
        private void cmsDefect_Click(object sender, EventArgs e)
        {
            Item item = SelectedItem;
            DefectForm defect = new DefectForm(item.Quantity, item.Id);
            if (defect.ShowDialog() == DialogResult.OK)
            {
                CalcResidue(item.Quantity, item.Id);
                FillItemsByCategory();
            }
        }

        // В заказ
        private void cmsInOrder_Click(object sender, EventArgs e)
        {
            Item item = SelectedItem;
            InOrder inorder = new InOrder(item.Id, item.Quantity, int.Parse(item.FirmPrice));
            if (inorder.ShowDialog() == DialogResult.OK)
            {
                CalcResidue(item.Quantity, item.Id);
                FillItemsByCategory();
            }
        }

        // В резерв ???
        private void cmsReserve_Click(object sender, EventArgs e)
        {

        }

        #endregion Списания

        #region Поиск

        // Нажатие Enter при поиске
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchItems(tbSearch.Text);
        }

        // Поиск по организациям
        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            SearchingForm sf = new SearchingForm();
            sf.ShowDialog();
        }

        // Выделение поля для поиска
        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == "Поиск")
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        // Снятие выделения поля для поиска
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
