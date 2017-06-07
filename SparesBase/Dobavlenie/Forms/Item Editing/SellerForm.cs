using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class SellerForm : Form
    {
        // Выделенный поставщик
        private Seller SelectedSeller
        {
            get { return (Seller)tvSellers.SelectedNode.Tag; }
            set { tvSellers.SelectedNode.Tag = value; }
        }


        // Конструктор
        public SellerForm()
        {
            InitializeComponent();

           
            FillSellers();
        }


        #region Заполнение данных

      
       

        // Получение данных о выделенном поставщике из базы и вывод данных во все TextBox'ы
        private void FillSellerData()
        {
            Seller selectedSeller = (Seller)tvSellers.SelectedNode.Tag;
            tbName.Text = selectedSeller.Name;
            tbSite.Text = selectedSeller.Site;
            tbTelephone.Text = selectedSeller.Telephone;
            tbFirstName.Text = selectedSeller.ContactFirstName;
            tbLastName.Text = selectedSeller.ContactLastName;
            tbSecondName.Text = selectedSeller.ContactSecondName;
        }

        // Обновить данные о поставщиках в ListBox
        private void FillSellers()
        {
            tvSellers.Nodes.Clear();

            string where = "WHERE(OrganizationId = " + EnteredUser.OrganizationId + ")";
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Sellers " + where);

            Seller seller = null;
            foreach (DataRow row in dt.Rows)
            {
                seller = new Seller(
                    int.Parse(row.ItemArray[0].ToString()),
                    row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(),
                    row.ItemArray[3].ToString(),
                    row.ItemArray[4].ToString(),
                    row.ItemArray[5].ToString(),
                    row.ItemArray[6].ToString(),
                    int.Parse(row.ItemArray[7].ToString()));

                TreeNode sellerNode = new TreeNode(seller.Name);
                sellerNode.Tag = seller;

                tvSellers.Nodes.Add(sellerNode);
            }

            if (tvSellers.Nodes.Count != 0)
                tvSellers.SelectedNode = tvSellers.Nodes[0];
        }

        #endregion Заполнение данных



        #region Работа с поставщиком

        // Добавление нового поставщика
        private void AddSeller()
        {
            SellerEdit editForm = new SellerEdit();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                FillSellers();
                tvSellers.SelectedNode = tvSellers.Nodes[tvSellers.Nodes.Count - 1];
            }
        }

        // Редактирование поставщика
        private void EditSeller()
        {
            SellerEdit editForm = new SellerEdit(SelectedSeller);
            if (editForm.ShowDialog() == DialogResult.OK)
                FillSellers();
        }

        // Удаление поставщика
        private void DeleteSeller()
        {
            DatabaseWorker.SqlQuery("DELETE FROM Sellers WHERE(id=" + SelectedSeller.Id + ")");
            tvSellers.Nodes.Remove(tvSellers.SelectedNode);
        }

        #endregion Работа с поставщиком



        #region События

        // Добавление нового поставщика
        private void Add_Click(object sender, EventArgs e)
        {
            AddSeller();
        }

        // Редактирование поставщика
        private void SellerEdit_Click(object sender, EventArgs e)
        {
            EditSeller();
        }

        // Редактирование поставщика при двойном клике на нод
        private void tvSellers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            EditSeller();
        }

        // Удаление поставщика
        private void Delete_Click(object sender, EventArgs e)
        {
            if (int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Items WHERE(Seller_Id = " + SelectedSeller.Id + ")").ToString()) <= 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить поставщика \"" + SelectedSeller.Name + "\"?", "Удаление поставщика", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    DeleteSeller();
            }
            else
                MessageBox.Show("Операцию удаления поставщика произвести невозможно, так как к нему привязаны один или несколько предметов.", "Удаление поставщика", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Смена выделенного поставщика
        private void tvSellers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillSellerData();
        }

        #endregion События
    }
}
