using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellingForm : Form
    {
        int quantity, retailPrice, wholesalePrice, servicePrice;
        int id;
        
        public SellingForm(int quantity, int retailPrice, int wholesalePrice, int servicePrice, int id)
        {
            InitializeComponent();
            this.quantity = quantity;
            this.retailPrice = retailPrice;
            this.wholesalePrice = wholesalePrice;
            this.servicePrice = servicePrice;
            this.id = id;
            

        }

        private void FillQuantity()
        {
            for (int i = 0; i < quantity; i++)
            {
                cbQuantity.Items.Add(i + 1);
                
            }
            cbQuantity.SelectedIndex = 0;
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {

            FillPrices();
            FillQuantity();

        }

        private void FillPrices()
        {
            cbPrice.Items.Add("Розничная цена: " + retailPrice);
            cbPrice.Items.Add("Оптовая цена: " + wholesalePrice);
            cbPrice.Items.Add("Сервисная цена: " + servicePrice);
            cbPrice.SelectedIndex = 0;
        }

        private void AddSell()
        {
            DatabaseWorker.SqlQuery("INSERT INTO Selling VALUES (''," + cbQuantity.Text + "," + cbPrice.Text.Remove(0, cbPrice.Text.IndexOf(':') + 2) + ", " + id + ")");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AddSell();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
