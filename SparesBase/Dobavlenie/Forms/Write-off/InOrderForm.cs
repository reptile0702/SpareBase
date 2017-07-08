using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class InOrder : Form
    {
        private int quantity = 0;
        private int itemId = 0;
        private int firmPrice = 0;

        // Конструктор
        public InOrder(int itemId, int quantity, int firmPrice)
        {
            InitializeComponent();

            this.itemId = itemId;
            this.quantity = quantity;
            this.firmPrice = firmPrice;

            FillQuantity();

            tbPrice.Text = firmPrice.ToString();
            tbTotal.Text = (int.Parse(cbQuantity.Text) * firmPrice).ToString();
        }


        #region Методы

        // Добавление заказа в таблицу
        private void AddInOrder()
        {
            // Проверка на введенность поля
            if (tbNumber.Text != "")
            {
                DatabaseWorker.SqlQuery("INSERT INTO Purchase VALUES(''," + tbNumber.Text + "," + cbQuantity.Text + ",'" + tbPrice.Text + "'," + tbTotal.Text + "," + itemId  + ")");
                DatabaseWorker.InsertAction(4, itemId);
            }
            else
                MessageBox.Show("Введите номер заказа");
        }

        // Заполнение ComboBox'а с количеством
        private void FillQuantity()
        {
            for (int i = 0; i < quantity; i++)
                cbQuantity.Items.Add(i + 1);
            cbQuantity.SelectedIndex = 0;
        }

        #endregion Методы



        #region События

        // Клик на OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddInOrder();
            DialogResult = DialogResult.OK;
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
                tbTotal.Text = (int.Parse(cbQuantity.Text) * firmPrice).ToString();
        }

        #endregion События
    }
}
