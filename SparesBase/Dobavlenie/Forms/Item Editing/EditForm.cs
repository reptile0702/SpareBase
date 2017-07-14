using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;

namespace SparesBase
{
    public partial class EditForm : Form
    {
        #region Поля
        
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

        #endregion Поля



        #region Конструкторы

        // Конструктор для добавления предмета
        public EditForm(int[] categories)
        {
            InitializeComponent();

            this.categories = categories;
            images = new Image[5];

            // Выключение кнопок: В заказ, продажа, брак
            btnInOrder.Enabled = false;
            btnDefect.Enabled = false;
            btnSell.Enabled = false;

            // Текст на форме
            Text = "Добавление предмета";
            btnEdit.Text = "Добавить предмет";

            // Заполнение элементов данными
            FillSellers();
            FillStatuses();

            btnLoadImages.Visible = false;
        }

        // Конструктор для изменения предмета
        public EditForm(Item item)
        {
            InitializeComponent();

            images = new Image[5];
            this.item = item;

            // Текст на форме
            Text = "Изменение предмета";
            btnEdit.Text = "Изменить предмет";

            // Заполнение элементов данными
            FillSellers();
            FillStatuses();
            GetItemData(item);

            if (Settings.AutoLoadItemImages)
            {
                DownloadPictures();
                btnLoadImages.Visible = false;
            }
            else
            {
                btnLoadImages.Visible = true;
                btnImg1.Enabled = false;
                btnImg2.Enabled = false;
                btnImg3.Enabled = false;
                btnImg4.Enabled = false;
                btnImg5.Enabled = false;
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
                tbQuantity.Text != "")
            {
                // Проверка на правильность введенного поставщика
                if (cbSeller.SelectedValue == null)
                {
                    MessageBox.Show("Введенный поставщик не существует");
                    return;
                }

                // Проверка выбранность поставщика
                if (cbSeller.SelectedValue.ToString() == "-2")
                {
                    MessageBox.Show("Не выбран поставщик");
                    return;
                }

                // Идентификатор поставщика
                int sellerId = int.Parse(cbSeller.SelectedValue.ToString());

                // Инвентарный номер
                int inventNumber = 0;

                // Подсчет остатка и инвентарного номера
                if (item != null)
                {
                    CalcResidue();
                    inventNumber = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT Counter FROM ItemsCounters WHERE(OrganizationId = " + EnteredUser.Organization.Id + ")").ToString());
                }
                else
                {
                    residue = int.Parse(tbQuantity.Text);
                    inventNumber = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT Counter FROM ItemsCounters WHERE(OrganizationId = " + EnteredUser.Organization.Id + ")").ToString()) + 1;
                    DatabaseWorker.SqlQuery("UPDATE ItemsCounters SET Counter = " + inventNumber + " WHERE(OrganizationId = " + EnteredUser.Organization.Id + ")");
                }

                // Формирование запроса
                string query = "";
                if (operation == "INSERT")
                    query = "INSERT INTO Items VALUES(" +
                        "'', " +
                        item.MainCategory.Id + ", " +
                        (item.SubCategory1 != null ? item.SubCategory1.Id.ToString() : "0") + ", " +
                        (item.SubCategory2 != null ? item.SubCategory2.Id.ToString() : "0") + ", " +
                        (item.SubCategory3 != null ? item.SubCategory3.Id.ToString() : "0") + ", " +
                        (item.SubCategory4 != null ? item.SubCategory4.Id.ToString() : "0") + ", " +
                        "'" + tbItemName.Text + "', " +
                        "" + sellerId + ", " +
                        "'" + tbPurchasePrice.Text + "', " +
                        "'" + tbRetailPrice.Text + "', " +
                        "'" + tbWholesalePrice.Text + "', " +
                        "'" + tbServicePrice.Text + "', " +
                        "'" + tbFirmPrice.Text + "', " +
                        "'" + tbStorage.Text + "', " +
                        "'" + tbNote.Text + "', " +
                        "" + int.Parse(tbQuantity.Text) + ", " +
                        "NOW(), " +
                        "NOW(), " +
                        "" + residue + ", " +
                        EnteredUser.Organization.Id + ", " +
                        "" + (chbSearchAllowed.Checked ? "1" : "0") + ", " +
                        "0, " +
                        "" + cbStatus.SelectedValue + "," +
                        "" + inventNumber + "," +
                        " '" + (tbSerial.Text.Trim() != "" ? tbSerial.Text : "") + "')";
                else
                    query = "UPDATE Items SET " +
                        "Main_Category_Id = " + item.MainCategory.Id + ", " +
                        "Sub_Category_1_Id = " + (item.SubCategory1 != null ? item.SubCategory1.Id.ToString() : "0") + ", " +
                        "Sub_Category_2_Id = " + (item.SubCategory2 != null ? item.SubCategory2.Id.ToString() : "0") + ", " +
                        "Sub_Category_3_Id = " + (item.SubCategory3 != null ? item.SubCategory3.Id.ToString() : "0") + ", " +
                        "Sub_Category_4_Id = " + (item.SubCategory4 != null ? item.SubCategory4.Id.ToString() : "0") + ", " +
                        "Item_Name = '" + tbItemName.Text + "', " +
                        "Seller_Id = " + sellerId + ", " +
                        "Purchase_Price = '" + tbPurchasePrice.Text + "', " +
                        "Retail_Price = '" + tbRetailPrice.Text + "', " +
                        "Wholesale_Price = '" + tbWholesalePrice.Text + "', " +
                        "Service_Price = '" + tbServicePrice.Text + "', " +
                        "FirmPrice = '" + tbFirmPrice.Text + "', " +
                        "Storage = '" + tbStorage.Text + "', " +
                        "Note = '" + tbNote.Text + "', " +
                        "Quantity = " + int.Parse(tbQuantity.Text) + ", " +
                        "Residue = " + residue + " , " +
                        "SearchAllowed = " + (chbSearchAllowed.Checked ? "1" : "0") + ", " +
                        "ChangeDate = NOW(), " +
                        "StatusId = " + cbStatus.SelectedValue + ", " +
                        "SerialNumber = '" + (tbSerial.Text.Trim() != "" ? tbSerial.Text : "") + "' " +
                        "WHERE id = " + updateId;

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

        // Заполнение данных о предмете
        private void GetItemData(Item item)
        {
            tbItemName.Text = item.Name;
            cbSeller.SelectedValue = item.Seller != null ? item.Seller.Id : -2;
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
            tbSerial.Text = item.SerialNumber.Trim() == "" ? "" : item.SerialNumber.ToString();
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
            //for (int i = 0; i < this.categories.Length; i++)
            //    if (categories[i] != null)
            //        this.categories[i] = categories[i].Id;

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
        private void FillSellers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Rows.Add("-2", "Без поставщика");

            int selectedId = 0;
            if (cbSeller.SelectedValue != null)
                selectedId = int.Parse(cbSeller.SelectedValue.ToString());

            string query =
                "SELECT " +
                "id, " +
                "name " +
                "FROM Sellers ";
            query += "WHERE(OrganizationId = " + EnteredUser.Organization.Id + " AND (Hidden <> 1";
            query += item != null ? " OR id = " + item.Seller.Id + ")) " : ")) ";
            query += "ORDER BY name";

            DataTable sellers = DatabaseWorker.SqlSelectQuery(query);

            bool flag = false;
            foreach (DataRow row in sellers.Rows)
            {
                dt.Rows.Add(row[0].ToString(), row[1].ToString());

                if (selectedId != 0 && !flag)
                {
                    if (selectedId != (int)row[0])
                        flag = false;
                    else
                        flag = true;
                }
            }

            dt.Rows.Add("-1", "Добавить нового поставщика...");

            cbSeller.DataSource = dt;
            cbSeller.DisplayMember = "name";
            cbSeller.ValueMember = "id";

            if (flag)
                cbSeller.SelectedValue = selectedId;
            else
                cbSeller.SelectedIndex = 0;
        }

        // Заполнение списка статусов предмета
        private void FillStatuses()
        {
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT id, Status FROM ItemStatus ORDER BY Status");
            cbStatus.DisplayMember = "Status";
            cbStatus.ValueMember = "id";
            cbStatus.DataSource = dt;
        }

        // Загрузка картинок предмета
        private void DownloadPictures()
        {
            // Получение списка картинок, которые есть у предмета
            string[] photos = FtpManager.GetItemImagesList(item.Id);

            counter = 0;
            imagesCount = photos.Length;
            if (imagesCount > 0)
            {
                // Изменение картинки на гифку загрузки и отключение функионала фотографий
                pbPhoto.SizeMode = PictureBoxSizeMode.CenterImage;
                pbPhoto.Image = Properties.Resources.LoadGif;
                btnImg1.Enabled = false;
                btnImg2.Enabled = false;
                btnImg3.Enabled = false;
                btnImg4.Enabled = false;
                btnImg5.Enabled = false;
                btnClearPhoto.Enabled = false;
                btnBrowsePhoto.Enabled = false;

                // Загрузка каждой фотографии
                foreach (string photo in photos)
                {
                    WebClient wcPhotos = new WebClient();
                    wcPhotos.DownloadDataCompleted += WcPhotos_DownloadDataCompleted;
                    wcPhotos.DownloadDataAsync(new Uri(FtpManager.FtpConnectString + "Photos/" + "item_" + item.Id + "/" + photo), photo);
                }
            }
            else
            {
                // Картинок у предмета нет
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
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    FillSellers();
                    cbSeller.SelectedValue = sf.sellerId;
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

        // Смена категорий
        private void btnChangeCategories_Click(object sender, EventArgs e)
        {
            ChangeCategoriesForm ccf = new ChangeCategoriesForm(this, item.Organization.Id);
            ccf.ShowDialog();
        }

        #endregion Разные события



        #region События списания предмета

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

        #endregion События списания предмета



        #region События фотографий

        // Вывается, когда фотография предмета загрузилась
        private void WcPhotos_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            // Преобразование загруженных байтов в картинку
            MemoryStream memoryStream = new MemoryStream(e.Result);
            Image img = Image.FromStream(memoryStream);

            // Получение индекса картинки и записывание её на нужное место в массиве
            string imageIndex = e.UserState.ToString()[0].ToString();
            images[int.Parse(imageIndex) - 1] = img;

            counter++;
            if (counter == imagesCount)
            {
                // При загрузке всех картинок предмета, происходит загрузка на элемент первой фотографии и включение функционала фотографий
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

        // Клик на одну из кнопок выбора фотографии
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

        // Назначение фото с компьютера
        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений| *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                string fileExtension = Path.GetExtension(ofd.FileName);
                images[selectedImage] = img;
                pbPhoto.Image = img;
                imagesEdited = true;
            }
        }

        // Очистка выделенного фото
        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
            images[selectedImage] = null;
            pbPhoto.Image = null;
            imagesEdited = true;   
        }

        // Клик на кнопку "Загрузка фотографий"
        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            btnLoadImages.Visible = false;
            DownloadPictures();
        }

        #endregion События фотографий
    }
}