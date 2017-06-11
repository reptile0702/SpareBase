using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class InOrder : Form
    {
        private int quant = 0;
        private int itemId = 0;
        private int price = 0;

        // Конструктор
        public InOrder(int itemId, int quant, int price)
        {
            InitializeComponent();

            this.itemId = itemId;
            this.quant = quant;
            this.price = price;
        }


        // Добавление заказа в таблицу
        private void AddInOrder()
        {
            // Проверка на введенность поля
            if (tbNumber.Text != "")
            {
                DatabaseWorker.SqlQuery("INSERT INTO Purchase VALUES(''," + tbNumber.Text + "," + cbQuantity.Text + ",'" + tbPrice.Text + "'," + tbTotal.Text + "," + itemId + ")");
                DatabaseWorker.InsertAction(4, itemId);
            }
            else
                MessageBox.Show("Введите номер заказа");
        }


        // Загрузка формы
        private void InOrder_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox'а с количеством
            for (int i = 0; i < quant; i++)         
                cbQuantity.Items.Add(i+1);
            cbQuantity.SelectedIndex = 0;

            tbPrice.Text = price.ToString();
            tbTotal.Text = (int.Parse(cbQuantity.Text) * price).ToString();      
        }

        // Клик на OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddInOrder();
            Close();
        }

        // Клик на Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Изменение количества
        private void cbQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuantity.Text != "")          
                tbTotal.Text = (int.Parse(cbQuantity.Text) * price).ToString();
        }
    }
}
