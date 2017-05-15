using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class InOrder : Form
    {
        private int quant = 0;
        private int itemId = 0;
        private int price = 0;

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
            DatabaseWorker.SqlQuery("INSERT INTO Purchase VALUES(''," + tbNumber.Text + "," + cbQuantity.Text + ",'" + tbPrice.Text + "'," + tbTotal.Text + "," + itemId + ")");
        }


        // Загрузка формы
        private void InOrder_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < quant; i++)         
                cbQuantity.Items.Add(i+1);

            tbPrice.Text = price.ToString();

            tbTotal.Text = (quant * price).ToString();      
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
    }
}
