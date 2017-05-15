using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class EditForm : Form
    {
        int itemId;
        string[] categories;

        // Конструктор для добавления
        public EditForm(string[] categories)
        {
            InitializeComponent();

            this.categories = categories;          
            btnInOrder.Enabled = false;
            btnDefect.Enabled = false;
            btnSell.Enabled = false;
        }

        // Конструктор для изменения
        public EditForm(int itemId, string[] categories)
        {
            InitializeComponent();
            this.itemId = itemId;
            this.categories = categories;
            tbQuantity.Enabled = false;
            tbRetailPrice.Enabled = false;
            tbServicePrice.Enabled = false;
            tbPurchasePrice.Enabled = false;
            tbFirmPrice.Enabled = false;
            tbWholesalePrice.Enabled = false;
        }

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

        //Операция над предметом(INSERT/UPDATE)
        private void ItemOperation(string operation, int updateId = 0)
        {
            if (tbItemName.Text != "" &&
                cbSeller.Text != "" &&
                tbPurchasePrice.Text != "" &&
                tbRetailPrice.Text != "" &&
                tbServicePrice.Text != "" &&
                tbQuantity.Text != "")            
            {
                try
                {
                    int id = int.Parse(cbSeller.SelectedValue.ToString());
                    string query = "";

                    string mainCategoryId = "0";
                    string subCategory1Id = "0";
                    string subCategory2Id = "0";
                    string subCategory3Id = "0";
                    string subCategory4Id = "0";

                    for (int i = 0; i < categories.Length; i++)
                    {
                        if (i == 0) mainCategoryId = DatabaseWorker.SqlScalarQuery("SELECT id FROM Main_Category WHERE(Name = '" + categories[0] + "')").ToString();
                        if (i == 1) subCategory1Id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_1 WHERE(Name = '" + categories[1] + "')").ToString();
                        if (i == 2) subCategory2Id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_2 WHERE(Name = '" + categories[2] + "')").ToString();
                        if (i == 3) subCategory3Id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_3 WHERE(Name = '" + categories[3] + "')").ToString();
                        if (i == 4) subCategory4Id = DatabaseWorker.SqlScalarQuery("SELECT id FROM Sub_Category_4 WHERE(Name = '" + categories[4] + "')").ToString();
                    }

                    if (operation == "INSERT")
                        query = "INSERT INTO Items VALUES('', {0}, {1}, {2}, {3}, {4}, '{5}', {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14}, NOW(), {15})";
                    else
                        query = "UPDATE Items SET Item_Name='{5}', Seller_Id={6}, Purchase_Price='{7}', Retail_Price='{8}', Wholesale_Price='{9}', Service_Price='{10}', FirmPrice='{11}', Storage='{12}', Note='{13}', Quantity={14}, Residue={15} WHERE id = " + updateId;

                    // Подсчет остатка
                    int sold = 0;//int.Parse(cbSold.Text.Remove(0, cbSold.Text.IndexOf(':')+2));
                    int defect = 0;
                    int inOrder = 0;
                    int residue = int.Parse(tbQuantity.Text) - (defect + sold + inOrder);

                    query = string.Format(query,
                        mainCategoryId,
                        subCategory1Id,
                        subCategory2Id,
                        subCategory3Id,
                        subCategory4Id,
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

                    DatabaseWorker.SqlQuery(query);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Введены не все поля");
        }

        // Поиск предмета в базе по выделенному ID
        private void FindItemById(int itemId)
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

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, name FROM Sellers");
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

        // Очищение всех полей с информацией о предмете (УДАЛИТЬ ИЛИ НЕ УДАЛИТЬ ВОТ В ЧЕМ ВОПРОС)
        private void ClearFields()
        {
            tbItemName.Clear();
            tbPurchasePrice.Clear();
            tbQuantity.Clear();
            tbRetailPrice.Clear();
            tbWholesalePrice.Clear();
            tbServicePrice.Clear();
            tbStorage.Clear();
            tbNote.Clear();
            DataTable firstElement = (DataTable)cbSeller.DataSource;
            cbSeller.Text = firstElement.Rows[0][1].ToString();
            pbPhoto.Image = null;
        }

        // Загрузка превью-фотографии
        private void DownloadPreviewImage(int id)
        {
            PhotoEditor pe = new PhotoEditor(id, true);
            pbPhoto.Image = pe.DownloadPreviewImage();
        }

        #endregion Вспомогательные методы  



        #region Разные события

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            FillSellersComboBox();
            if (itemId == 0)
            {
                Text = "Добавление предмета";
                btnEdit.Text = "Добавить предмет";
            }
            else
            {
                Text = "Изменение предмета";
                btnEdit.Text = "Изменить предмет";
                FindItemById(itemId);
            }

            DownloadPreviewImage(itemId);
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

        #endregion Разные события

        private void btnSell_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm(int.Parse(tbQuantity.Text), int.Parse(tbRetailPrice.Text), int.Parse(tbWholesalePrice.Text), int.Parse(tbServicePrice.Text), itemId);
            selling.ShowDialog();
        }

        private void btnDefect_Click(object sender, EventArgs e)
        {
            DefectForm defect = new DefectForm(int.Parse(tbQuantity.Text), itemId);
            defect.ShowDialog();
        }

        private void btnInOrder_Click(object sender, EventArgs e)
        {
            if (tbFirmPrice.Text != "")
            {
                InOrder InOrder = new InOrder(itemId, int.Parse(tbQuantity.Text), int.Parse(tbFirmPrice.Text));
                InOrder.ShowDialog();
            }
            else
            {
                MessageBox.Show("Поле 'Собственная цена' не имеет никаких данных");    
            }
           
        }
    }
}