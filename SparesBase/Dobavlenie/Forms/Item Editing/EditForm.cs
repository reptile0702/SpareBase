using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Threading;

namespace SparesBase
{
    public partial class EditForm : Form
    {
        
        // Предмет
        Item item;

        // Категории текущего предмета
        int[] categories;

        // Фотографии предмета
        Image[] images;
        bool imagesEdited;
        int counter = 1;
        int imagesCount = 0;
        int selectedImage = 0;
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
            FillSellersComboBox();
            FillStatuses();
        }

        // Конструктор для изменения предмета
        public EditForm(Item item, int[] categories)
        {
            InitializeComponent();

            images = new Image[5];
            this.item = item;
            this.categories = categories;

            Text = "Изменение предмета";
            btnEdit.Text = "Изменить предмет";
            FillSellersComboBox();
            FillStatuses();
            GetItemData(item);
            DownloadPictures();

            //pbPhoto.Image = FtpManager.DownloadPreviewImage(item.Id);
            //if (FtpManager.PreviewExists(item.Id))
            //{
            //    pbPhoto.SizeMode = PictureBoxSizeMode.CenterImage;
            //    pbPhoto.Image = Properties.Resources.LoadGif;
            //    WebClient webclient = new WebClient();
            //    webclient.DownloadDataCompleted += Webclient_DownloadDataCompleted;
            //    webclient.DownloadDataAsync(new Uri("ftp://u0183148:W5iLVaY9@server137.hosting.reg.ru/www/xn--29-nmcu.xn--p1ai/SparesBase/Photos/item_" + item.Id + "/preview.jpg"));

            //}
        }
        private void DownloadPictures()
        {
            string[] photos = FtpManager.DownloadImages(item.Id);

            counter = 0;
            imagesCount = photos.Length;
            if (imagesCount > 0)
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.CenterImage;
                pbPhoto.Image = Properties.Resources.LoadGif;
                btnImg1.Enabled = false;
                btnImg2.Enabled = false;
                btnImg3.Enabled = false;
                btnImg4.Enabled = false;
                btnImg5.Enabled = false;
                btnClearPhoto.Enabled = false;
                btnBrowsePhoto.Enabled = false;

            }

            foreach (string photo in photos)
            {
                WebClient webclient = new WebClient();
                webclient.DownloadDataCompleted += Webclient_DownloadDataCompleted;
                webclient.DownloadDataAsync(new Uri("ftp://u0183148:W5iLVaY9@server137.hosting.reg.ru/www/xn--29-nmcu.xn--p1ai/SparesBase/Photos/" + "item_" + item.Id + "/" + photo), photo);
            }
        }

        private void Webclient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream(e.Result);
            Image img = Image.FromStream(memoryStream);
            string imageIndex = e.UserState.ToString()[0].ToString();
            img.Tag = "SparesBase/Photos/" + "item_" + item.Id + "/" + e.UserState.ToString();
            images[int.Parse(imageIndex) - 1] = img;
            counter++;
            if (counter == imagesCount)
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                btnImg1.Enabled = true;
                btnImg2.Enabled = true;
                btnImg3.Enabled = true;
                btnImg4.Enabled = true;
                btnImg5.Enabled = true;
                btnClearPhoto.Enabled = true;
                btnBrowsePhoto.Enabled = true;

                pbPhoto.Image = images[0];
                btnImg1.BackColor = Color.Green;
            }

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
                tbQuantity.Text != "" &&
                cbSeller.SelectedValue != null)
            {

                // Идентификатор поставщика
                int id = int.Parse(cbSeller.SelectedValue.ToString());

                // Формирование запроса
                string query = "";
                if (operation == "INSERT")
                    query = "INSERT INTO Items VALUES(" +
                        "'', " +
                        "{0}, " +
                        "{1}, " +
                        "{2}, " +
                        "{3}, " +
                        "{4}, " +
                        "'{5}', " +
                        "{6}, " +
                        "'{7}', " +
                        "'{8}', " +
                        "'{9}', " +
                        "'{10}', " +
                        "'{11}', " +
                        "'{12}', " +
                        "'{13}', " +
                        "{14}, " +
                        "NOW(), NOW(), " +
                        "{15}, " +
                        EnteredUser.OrganizationId + ", " +
                        "{16}, " +
                        "0, " +
                        "{17}," +
                        "{18}," +
                        " {19})";
                else
                    query = "UPDATE Items SET " +
                        "Main_Category_Id = {0}, " +
                        "Sub_Category_1_Id = {1}, " +
                        "Sub_Category_2_Id = {2}, " +
                        "Sub_Category_3_Id = {3}, " +
                        "Sub_Category_4_Id = {4}, " +
                        "Item_Name='{5}', " +
                        "Seller_Id={6}, " +
                        "Purchase_Price='{7}', " +
                        "Retail_Price='{8}', " +
                        "Wholesale_Price='{9}', " +
                        "Service_Price='{10}', " +
                        "FirmPrice='{11}', " +
                        "Storage='{12}', " +
                        "Note='{13}', " +
                        "Quantity={14}, " +
                        "Residue={15} , " +
                        "SearchAllowed={16}, " +
                        "ChangeDate = NOW(), " +
                        "StatusId = {17}, " +
                        "SerialNumber = {19} " +
                        "WHERE id = " + updateId;

                int inventNumber = 0;

                // Подсчет остатка 
                if (item != null)
                {
                    CalcResidue();
                    inventNumber = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT Counter FROM ItemsCounters WHERE(OrganizationId = " + EnteredUser.OrganizationId + ")").ToString());
                }
                else
                {
                    residue = int.Parse(tbQuantity.Text);
                    inventNumber = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT Counter FROM ItemsCounters WHERE(OrganizationId = " + EnteredUser.OrganizationId + ")").ToString()) + 1;
                    DatabaseWorker.SqlQuery("UPDATE ItemsCounters SET Counter = " + inventNumber + " WHERE(OrganizationId = " + EnteredUser.OrganizationId + ")");
                }



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
                    chbSearchAllowed.Checked ? "1" : "0",
                    cbStatus.SelectedValue,
                    inventNumber,
                    tbSerial.Text != "" ? tbSerial.Text : " 0");

                // Выполнение запроса
                DatabaseWorker.SqlQuery(query);

                // Добавление фотографий на FTP сервер если они были редактированы
                if (updateId == 0)
                {
                    if (imagesEdited)
                    {
                        int itemId = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT id FROM Items WHERE(id = LAST_INSERT_ID())").ToString());
                        FtpManager.UploadImages(images, itemId);
                    }

                    DatabaseWorker.InsertAction(1, int.Parse(DatabaseWorker.SqlScalarQuery("SELECT LAST_INSERT_ID() FROM Items").ToString()));
                }
                else
                {
                    if (imagesEdited)
                        FtpManager.UploadImages(images, item.Id);

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
            cbStatus.Text = item.Status;
            lInventNumber.Text = "Инвентарный номер: " + item.InventNumber.ToString();
            tbSerial.Text = item.SerialNumber <= 0 ? "" : item.SerialNumber.ToString();
            FillCategoriesInfo();
        }

        // Заполнение строки категорий
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

        // Смена категорий
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

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, name FROM Sellers WHERE(OrganizationId=" + EnteredUser.OrganizationId + ") ORDER BY name");
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

        private void FillStatuses()
        {
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, Status FROM ItemStatus ORDER BY Status");
            cbStatus.DataSource = dt;
            cbStatus.DisplayMember = "Status";
            cbStatus.ValueMember = "id";
        }

        #endregion Заполнение элеметов данными



        #region Вспомогательные методы

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

        // Получение остатка из базы
        private void GetResidue()
        {
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT Residue FROM Items WHERE(id = " + item.Id + ")");
            residue = int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

        #endregion Вспомогательные методы  



        #region Разные события

        // Загрузка формы
        private void EditForm_Load(object sender, EventArgs e)
        {
            if (item != null)
                GetResidue();
        }

        // Смена выделенного индекса поставщика
        private void cbSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeller.Text == "Добавить нового поставщика...")
            {
                SellerEdit sf = new SellerEdit();
                if (sf.ShowForm() == SellerState.Insert)
                {
                    FillSellersComboBox();
                    cbSeller.SelectedValue = sf.sellerId;
                }
            }
        }

        // Открытие ComboBox'а с поставщиками
        private void cbSeller_DropDown(object sender, EventArgs e)
        {
            FillSellersComboBox();
        }

        // Просмотр фотографий предмета
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            PhotoEditor pe = null;
            if (item == null)
                pe = new PhotoEditor();
            else
                pe = new PhotoEditor(item.Id);

            if (pe.ShowDialog() == DialogResult.OK)
            {
                imagesEdited = true;
                images = pe.Images;
                pbPhoto.Image = null;
                foreach (Image image in images)
                {
                    if (image != null)
                    {
                        pbPhoto.Image = image;
                        break;
                    }
                }
            }
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

        // Смена категорий
        private void btnChangeCategories_Click(object sender, EventArgs e)
        {
            ChangeCategoriesForm ccf = new ChangeCategoriesForm(this, item.Organization.Id);
            ccf.ShowDialog();
        }


        #endregion Разные события

        private void btnImg_Click(object sender, EventArgs e)
        {
           

            btnImg1.BackColor = SystemColors.Control;
            btnImg2.BackColor = SystemColors.Control;
            btnImg3.BackColor = SystemColors.Control;
            btnImg4.BackColor = SystemColors.Control;
            btnImg5.BackColor = SystemColors.Control;

            Button but = (Button)sender;
            but.BackColor = Color.Green;

            pbPhoto.Image = images[int.Parse(but.Text) - 1];

            selectedImage = int.Parse(but.Text) - 1;
            
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений| *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                Image img = Image.FromFile(ofd.FileName);
                string fileExtension = Path.GetExtension(ofd.FileName);
                img.Tag = "Photos/item_" + item.Id + "/" + selectedImage + fileExtension;
                images[selectedImage] = img;
                pbPhoto.Image = img;
                imagesEdited = true;
              
            }
        }

        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
           
            images[selectedImage] = null;
            pbPhoto.Image = null;
            imagesEdited = true;
            
        }
    }
}