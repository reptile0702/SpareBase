using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class EditForm : Form
    {
        // Предмет
        Item item;

        // Категории текущего предмета
        int[] categories;

        // Идентификатор организации
        int organizationId;

        // Остаток
        int residue = 0;

        #region Конструкторы

        // Конструктор для добавления предмета
        public EditForm(int[] categories, int organizationId)
        {
            InitializeComponent();

            this.categories = categories;
            this.organizationId = organizationId;

            // Выключение кнопок: В заказ, продажа, брак
            btnInOrder.Enabled = false;
            btnDefect.Enabled = false;
            btnSell.Enabled = false;

            Text = "Добавление предмета";
            btnEdit.Text = "Добавить предмет";
            FillSellersComboBox();
        }

        // Конструктор для изменения предмета
        public EditForm(Item item, int[] categories)
        {
            InitializeComponent();

            this.item = item;
            this.categories = categories;

            Text = "Изменение предмета";
            btnEdit.Text = "Изменить предмет";
            FillSellersComboBox();
            GetItemData(item);
        }

        #endregion Конструкторы



        #region Предметы

        // Добавление предмета в базу
        private void AddItem()
        {
            ItemOperation("INSERT");
        }

        // Обновление предмета в базе
        private void UpdateItem(int updateId)
        {
            ItemOperation("UPDATE", updateId);
        }

        //Операция над предметом (INSERT/UPDATE)
        private void ItemOperation(string operation, int updateId = 0)
        {
            // Проверка на введенность всех обязательных полей
            if (tbItemName.Text != "" &&
                cbSeller.Text != "" &&
                tbPurchasePrice.Text != "" &&
                tbRetailPrice.Text != "" &&
                tbServicePrice.Text != "" &&
                tbQuantity.Text != "")
            {
                // Идентификатор поставщика
                int id = int.Parse(cbSeller.SelectedValue.ToString());

                // Формирование запроса
                string query = "";
                if (operation == "INSERT")
                    query = "INSERT INTO Items VALUES('', {0}, {1}, {2}, {3}, {4}, '{5}', {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14}, NOW(), {15}, " + organizationId + ", {16}, 0)";
                else
                    query = "UPDATE Items SET Main_Category_Id = {0}, Sub_Category_1_Id = {1}, Sub_Category_2_Id = {2}, Sub_Category_3_Id = {3}, Sub_Category_4_Id = {4}, Item_Name='{5}', Seller_Id={6}, Purchase_Price='{7}', Retail_Price='{8}', Wholesale_Price='{9}', Service_Price='{10}', FirmPrice='{11}', Storage='{12}', Note='{13}', Quantity={14}, Residue={15} , SearchAllowed={16} WHERE id = " + updateId;

                // Подсчет остатка 
                if (item != null)
                    CalcResidue();
                else
                    residue = int.Parse(tbQuantity.Text);

                // Вставка данных о предмете в стороку запроса
                query = string.Format(query,
                    categories[0],
                    categories[1],
                    categories[2],
                    categories[3],
                    categories[4],
                    tbItemName.Text,
                    DatabaseWorker.SqlScalarQuery("SELECT id FROM Sellers WHERE(id=" + id + ")"),
                    tbPurchasePrice.Text,
                    tbRetailPrice.Text,
                    tbWholesalePrice.Text,
                    tbServicePrice.Text,
                    tbFirmPrice.Text,
                    tbStorage.Text,
                    tbNote.Text,
                    int.Parse(tbQuantity.Text),
                    residue,
                    chbSearchAllowed.Checked ? "1" : "0");

                // Выполнение запроса
                DatabaseWorker.SqlQuery(query);
                if (updateId == 0)
                {
                    DatabaseWorker.InsertAction(1, int.Parse(DatabaseWorker.SqlScalarQuery("SELECT LAST_INSERT_ID() FROM Items").ToString()));
                }
                else
                {
                    DatabaseWorker.InsertAction(2, updateId);
                }

                Close();
            }
            else
                MessageBox.Show("Введены не все поля");
        }

        // Поиск предмета в базе по выделенному ID и запись данных в панель информации
        private void GetItemData(Item item)
        {
            tbItemName.Text = item.Name;
            cbSeller.SelectedValue = item.Seller.Id;
            tbPurchasePrice.Text = item.PurchasePrice;
            tbRetailPrice.Text = item.RetailPrice;
            tbWholesalePrice.Text = item.WholesalePrice;
            tbServicePrice.Text = item.ServicePrice;
            tbFirmPrice.Text = item.FirmPrice;
            tbStorage.Text = item.Storage;
            tbNote.Text = item.Note;
            tbQuantity.Text = item.Quantity.ToString();
            chbSearchAllowed.Checked = item.SearchAllowed;
            FillCategoriesInfo();
        }

        private void FillCategoriesInfo()
        {
            lMainCategory.Text = "Категории: ";
            lMainCategory.Text += item.MainCategory.Name;
            if (item.SubCategory1 != null)
                lMainCategory.Text += " - " + item.SubCategory1.Name;
            if (item.SubCategory2 != null)
                lMainCategory.Text += " - " + item.SubCategory2.Name;
            if (item.SubCategory3 != null)
                lMainCategory.Text += " - " + item.SubCategory3.Name;
            if (item.SubCategory4 != null)
                lMainCategory.Text += " - " + item.SubCategory4.Name;
        }

        public void ChangeCategories(Category[] categories)
        {
            for (int i = 0; i < this.categories.Length; i++)
                if (categories[i] != null)
                    this.categories[i] = categories[i].Id;

            item.MainCategory = categories[0];
            item.SubCategory1 = categories[1];
            item.SubCategory2 = categories[2];
            item.SubCategory3 = categories[3];
            item.SubCategory4 = categories[4];

            FillCategoriesInfo();
        }

        #endregion Предметы



        #region Заполнение элеметов данными

        // Заполнение ComboBox'а с поставщиками
        private void FillSellersComboBox()
        {
            int selectedId = 0;
            if (cbSeller.SelectedValue != null)
                selectedId = int.Parse(cbSeller.SelectedValue.ToString());

            string where = organizationId != 0 ? "WHERE(OrganizationId = " + organizationId + ")" : "WHERE(OrganizationId = " + item.Organization.Id + ")";
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, name FROM Sellers " + where);
            DataTable source = new DataTable();
            source.Columns.Add("id");
            source.Columns.Add("name");

            bool flag = false;
            foreach (DataRow row in dt.Rows)
            {
                source.Rows.Add(row[0].ToString(), row[1].ToString());

                if (selectedId != 0 && !flag)
                {
                    if (selectedId != (int)row[0])
                        flag = false;
                    else
                        flag = true;
                }
            }

            source.Rows.Add("-1", "Добавить нового поставщика...");

            cbSeller.DataSource = source;
            cbSeller.DisplayMember = "name";
            cbSeller.ValueMember = "id";

            if (flag)
                cbSeller.SelectedValue = selectedId;
            else
                cbSeller.SelectedIndex = 0;
        }

        #endregion Заполнение элеметов данными



        #region Вспомогательные методы

        // Загрузка превью-фотографии
        private void DownloadPreviewImage(int id)
        {
            PhotoEditor pe = new PhotoEditor(id, true);
            pbPhoto.Image = pe.DownloadPreviewImage();
        }

        // Подсчет остатка
        private void CalcResidue()
        {
            if (tbQuantity.Text != "")
            {
                int purchase = 0;
                int selling = 0;
                int defect = 0;

                // Подсчет всех строк

                // В заказ
                DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT Quantity FROM Purchase WHERE(ItemId=" + item.Id + ")");
                foreach (DataRow row in dt.Rows)
                    purchase += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

                // Продажа
                dt = DatabaseWorker.SqlSelectQuery("SELECT Quantity FROM Selling WHERE(ItemId=" + item.Id + ")");
                foreach (DataRow row in dt.Rows)
                    selling += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

                // Брак
                dt = DatabaseWorker.SqlSelectQuery("SELECT QuantityOfDefect FROM Defect WHERE(ItemId=" + item.Id + ")");
                foreach (DataRow row in dt.Rows)
                    defect += row.ItemArray[0].ToString() != "" ? int.Parse(row.ItemArray[0].ToString()) : 0;

                // Остаток            
                residue = int.Parse(tbQuantity.Text) - (purchase + selling + defect);

                // Занесение остатка в базу
                DatabaseWorker.SqlQuery("UPDATE Items SET Residue = " + residue + " WHERE(id = " + item.Id + ")");
            }

        }

        #endregion Вспомогательные методы  



        #region Разные события

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {

            //DownloadPreviewImage(item.Id);
            CalcResidue();
        }

        // Смена выделенного индекса поставщика
        private void cbSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeller.Text == "Добавить нового поставщика...")
            {
                SellerEdit sf = new SellerEdit();
                if (sf.ShowDialog() == DialogResult.OK)
                    cbSeller.SelectedIndex = cbSeller.Items.Count - 2;
            }
        }

        // Открывание ComboBox'а с поставщиками
        private void cbSeller_DropDown(object sender, EventArgs e)
        {
            FillSellersComboBox();
        }

        // Просмотр фотографий предмета
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            PhotoEditor pe = new PhotoEditor(item.Id);
            pe.ShowDialog();
        }

        // Клик на кнопку Добавления / Изменения
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (item == null)
                AddItem();
            else
                UpdateItem(item.Id);
        }

        // Продажа
        private void btnSell_Click(object sender, EventArgs e)
        {
            // Проверка на остаток
            if (residue > 0)
            {
                SellingForm selling = new SellingForm(residue, int.Parse(tbRetailPrice.Text), int.Parse(tbWholesalePrice.Text), int.Parse(tbServicePrice.Text), item.Id);
                selling.ShowDialog();
                CalcResidue();
            }
            else
                MessageBox.Show("Остаток данного предмета равен нулю");
        }

        // Брак
        private void btnDefect_Click(object sender, EventArgs e)
        {
            // Проверка на остаток
            if (residue > 0)
            {
                DefectForm defect = new DefectForm(residue, item.Id);
                defect.ShowDialog();
                CalcResidue();
            }
            else
                MessageBox.Show("Остаток данного предмета равен нулю");
        }

        // В заказ
        private void btnInOrder_Click(object sender, EventArgs e)
        {
            // Проверка на остаток
            if (residue > 0)
            {
                InOrder InOrder = new InOrder(item.Id, residue, int.Parse(tbFirmPrice.Text));
                InOrder.ShowDialog();
                CalcResidue();
            }
            else
                MessageBox.Show("Остаток данного предмета равен нулю");
        }


        #endregion Разные события

        private void btnChangeCategories_Click(object sender, EventArgs e)
        {
            ChangeCategoriesForm ccf = new ChangeCategoriesForm(this, item.Organization.Id);
            ccf.ShowDialog();
        }
    }
}