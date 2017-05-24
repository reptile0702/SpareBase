using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class EditForm : Form
    {
        // Идентификатор текущего предмета
        int itemId;

        // Категории текущего предмета
        int[] categories;

        // Остаток
        int residue = 0;

        #region Конструкторы

        // Конструктор для добавления предмета
        public EditForm(int[] categories)
        {
            InitializeComponent();

            this.categories = categories;

            // Выключение кнопок: В заказ, продажа, брак
            btnInOrder.Enabled = false;
            btnDefect.Enabled = false;
            btnSell.Enabled = false;

            Text = "Добавление предмета";
            btnEdit.Text = "Добавить предмет";
        }

        // Конструктор для изменения предмета
        public EditForm(int itemId, int[] categories)
        {
            InitializeComponent();

            this.itemId = itemId;
            this.categories = categories;

            // Выключение полей
            tbQuantity.Enabled = false;
            tbRetailPrice.Enabled = false;
            tbServicePrice.Enabled = false;
            tbPurchasePrice.Enabled = false;
            tbFirmPrice.Enabled = false;
            tbWholesalePrice.Enabled = false;

            Text = "Изменение предмета";
            btnEdit.Text = "Изменить предмет";
            GetItemData(itemId);
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
                    query = "INSERT INTO Items VALUES('', {0}, {1}, {2}, {3}, {4}, '{5}', {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14}, NOW(), {15}, " + EnteredUser.OrganizationId + ")";
                else
                    query = "UPDATE Items SET Item_Name='{5}', Seller_Id={6}, Purchase_Price='{7}', Retail_Price='{8}', Wholesale_Price='{9}', Service_Price='{10}', FirmPrice='{11}', Storage='{12}', Note='{13}', Quantity={14}, Residue={15} WHERE id = " + updateId;

                // Подсчет остатка                    
                CalcResidue();                    

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
                    residue);

                // Выполнение запроса
                DatabaseWorker.SqlQuery(query);

                Close();
            }
            else
                MessageBox.Show("Введены не все поля");
        }

        // Поиск предмета в базе по выделенному ID и запись данных в панель информации
        private void GetItemData(int itemId)
        {
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Items WHERE id=" + itemId);
            tbItemName.Text = dt.Rows[0].ItemArray[6].ToString();
            cbSeller.Text = DatabaseWorker.SqlScalarQuery("SELECT name FROM Sellers WHERE id=" + dt.Rows[0][7]).ToString();
            tbPurchasePrice.Text = dt.Rows[0].ItemArray[8].ToString();
            tbRetailPrice.Text = dt.Rows[0].ItemArray[9].ToString();
            tbWholesalePrice.Text = dt.Rows[0].ItemArray[10].ToString();
            tbServicePrice.Text = dt.Rows[0].ItemArray[11].ToString();
            tbFirmPrice.Text = dt.Rows[0].ItemArray[12].ToString();
            tbStorage.Text = dt.Rows[0].ItemArray[13].ToString();
            tbNote.Text = dt.Rows[0].ItemArray[14].ToString();
            tbQuantity.Text = dt.Rows[0].ItemArray[15].ToString();
        }

        #endregion Предметы



        #region Заполнение элеметов данными

        // Заполнение ComboBox'а с поставщиками
        private void FillSellersComboBox()
        {
            int selectedId = 0;
            if (cbSeller.SelectedValue != null)
                selectedId = int.Parse(cbSeller.SelectedValue.ToString());

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, name FROM Sellers WHERE(OrganizationId = " + EnteredUser.OrganizationId + ")");
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

        // Вставляет в Seller ComboBox текст
        public void ChangeTextInSellerComboBox(string text)
        {
            cbSeller.Text = text;
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
            residue = int.Parse(tbQuantity.Text) - (purchase + selling + defect);

            // Занесение остатка в базу
            DatabaseWorker.SqlQuery("UPDATE Items SET Residue = " + residue + " WHERE(id = " + itemId + ")");
        }

        #endregion Вспомогательные методы  



        #region Разные события

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            FillSellersComboBox();
            DownloadPreviewImage(itemId);
            CalcResidue();
        }

        // Смена выделенного индекса поставщика
        private void cbSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeller.Text == "Добавить нового поставщика...")
            {
                SellerForm sf = new SellerForm(this);
                sf.ShowDialog();
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
            PhotoEditor pe = new PhotoEditor(itemId);
            pe.ShowDialog();
        }

        // Клик на кнопку Добавления / Изменения
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (itemId == 0)
                AddItem();
            else
                UpdateItem(itemId);
        }

        // Продажа
        private void btnSell_Click(object sender, EventArgs e)
        {
            // Проверка на остаток
            if (residue > 0)
            {
                SellingForm selling = new SellingForm(residue, int.Parse(tbRetailPrice.Text), int.Parse(tbWholesalePrice.Text), int.Parse(tbServicePrice.Text), itemId);
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
                DefectForm defect = new DefectForm(residue, itemId);
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
                InOrder InOrder = new InOrder(itemId, residue, int.Parse(tbFirmPrice.Text));
                InOrder.ShowDialog();
                CalcResidue();
            }
            else
                MessageBox.Show("Остаток данного предмета равен нулю");
        }

        #endregion Разные события
    }
}