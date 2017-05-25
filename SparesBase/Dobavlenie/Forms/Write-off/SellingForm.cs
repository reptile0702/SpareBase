using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellingForm : Form
    {
        int quantity, retailPrice, wholesalePrice, servicePrice;
        int id;
        
        // Конструктор
        public SellingForm(int quantity, int retailPrice, int wholesalePrice, int servicePrice, int id)
        {
            InitializeComponent();
            this.quantity = quantity;
            this.retailPrice = retailPrice;
            this.wholesalePrice = wholesalePrice;
            this.servicePrice = servicePrice;
            this.id = id;
        }


        // Заполнение количества
        private void FillQuantity()
        {
            for (int i = 0; i < quantity; i++)
                cbQuantity.Items.Add(i + 1);

            cbQuantity.SelectedIndex = 0;
        }

        // Заполнение цен
        private void FillPrices()
        {
            cbPrice.Items.Add("Розничная цена: " + retailPrice);
            cbPrice.Items.Add("Оптовая цена: " + wholesalePrice);
            cbPrice.Items.Add("Сервисная цена: " + servicePrice);
            cbPrice.SelectedIndex = 0;
        }

        // Добавление продажи в базу
        private void AddSell()
        {
            DatabaseWorker.SqlQuery("INSERT INTO Selling VALUES (''," + cbQuantity.Text + "," + cbPrice.Text.Remove(0, cbPrice.Text.IndexOf(':') + 2) + ", " + id + ")");
            DatabaseWorker.InsertAction(5, id);
        }


        // Загрузка формы
        private void SellingForm_Load(object sender, EventArgs e)
        {
            FillPrices();
            FillQuantity();
        }
  
        // Клик на ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddSell();
            Close();
        }

        // Клик на Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
