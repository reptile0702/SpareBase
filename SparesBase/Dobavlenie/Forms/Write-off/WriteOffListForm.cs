using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class WriteOffListForm : Form
    {
        Item item;

        public WriteOffListForm(Item item)
        {
            InitializeComponent();
            this.item = item;
            Text = "Списки списания предмета \"" + item.Name + "\"";

            FillOrders();
            FillSells();
            FillDefects();
        }

        #region Методы

        private void FillOrders()
        {
            dgvOrders.Rows.Clear();
            DataTable orders = DatabaseWorker.SqlSelectQuery("SELECT * FROM Purchase WHERE(ItemId = " + item.Id + ")");
            foreach (DataRow row in orders.Rows)
            {
                Order order = new Order(
                    int.Parse(row["id"].ToString()),
                    int.Parse(row["Number_Of_Order"].ToString()),
                    int.Parse(row["Quantity"].ToString()),
                    row["Firm_Price"].ToString(),
                    row["Total"].ToString(),
                    int.Parse(row["ItemId"].ToString()));

                dgvOrders.Rows.Add(
                    order.NumberOfOrder,
                    order.Quantity,
                    order.FirmPrice,
                    order.Total);

                dgvOrders.Rows[dgvOrders.Rows.Count - 1].Tag = order;
            }
        }

        private void FillSells()
        {
            dgvSells.Rows.Clear();
            DataTable sells = DatabaseWorker.SqlSelectQuery("SELECT * FROM Selling WHERE(ItemId = " + item.Id + ")");
            foreach (DataRow row in sells.Rows)
            {
                Sell sell = new Sell(
                    int.Parse(row["id"].ToString()),
                    int.Parse(row["Quantity"].ToString()),
                    int.Parse(row["Price"].ToString()),
                    int.Parse(row["ItemId"].ToString()));

                dgvSells.Rows.Add(
                    sell.Quantity,
                    sell.Price);

                dgvSells.Rows[dgvSells.Rows.Count - 1].Tag = sell;
            }
        }

        private void FillDefects()
        {
            dgvDefects.Rows.Clear();
            DataTable defects = DatabaseWorker.SqlSelectQuery("SELECT * FROM Defect WHERE(ItemId = " + item.Id + ")");
            foreach (DataRow row in defects.Rows)
            {
                Defect defect = new Defect(
                    int.Parse(row["id"].ToString()),
                    int.Parse(row["QuantityOfDefect"].ToString()),
                    row["WhoIdentified"].ToString(),
                    row["Note"].ToString(),
                    int.Parse(row["ItemId"].ToString()));

                dgvDefects.Rows.Add(
                    defect.Quantity,
                    defect.WhoIndetified);

                dgvDefects.Rows[dgvDefects.Rows.Count - 1].Tag = defect;
            }
        }

        #endregion Методы



        #region События

        private void EditOrder_Click(object sender, EventArgs e)
        {

        }

        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы уверены, что хотите удалить заказ?",
                "Удаление заказа",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("DELETE FROM Purchase WHERE(id = " + ((Order)dgvOrders.CurrentRow.Tag).Id + ")");
                FillOrders();
            }
        }

        private void EditSell_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSell_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы уверены, что хотите удалить продажу?",
                "Удаление продажи",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("DELETE FROM Selling WHERE(id = " + ((Sell)dgvSells.CurrentRow.Tag).Id + ")");
                FillSells();
            }
        }

        private void EditDefect_Click(object sender, EventArgs e)
        {

        }

        private void DeleteDefect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы уверены, что хотите удалить дефект?",
                "Удаление дефекта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("DELETE FROM Defect WHERE(id = " + ((Defect)dgvDefects.CurrentRow.Tag).Id + ")");
                FillDefects();
            }
        }

        #endregion События
    }
}
