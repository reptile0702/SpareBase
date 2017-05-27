using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            int orgCount = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Organizations").ToString());
            int accCount = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Accounts").ToString());
            int itemsCount = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Items").ToString());
            int actionsCount = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM ActionLogs").ToString());
            int sellersCount = int.Parse(DatabaseWorker.SqlScalarQuery("SELECT COUNT(1) FROM Sellers").ToString());

            lOrgCount.Text = "Количество зарегистрированных организаций: " + orgCount;
            lAccCount.Text = "Количество зарегистрированных аккаунтов: " + accCount;
            lItemsCount.Text = "Количество предметов в базе: " + itemsCount;
            lActionsCount.Text = "Количество совершенных действий: " + actionsCount;
            lSellersCount.Text = "Количество поставщиков в базе: " + sellersCount;
        }

        private void btnAccounts_Click(object sender, System.EventArgs e)
        {
            AccountsForm af = new AccountsForm();
            af.ShowDialog();
        }

        private void btnActionLogs_Click(object sender, System.EventArgs e)
        {
            ActionLogsForm alf = new ActionLogsForm();
            alf.ShowDialog();
        }

        private void btnCities_Click(object sender, System.EventArgs e)
        {
            CitiesForm cf = new CitiesForm();
            cf.ShowDialog();
        }

        private void btnSellers_Click(object sender, System.EventArgs e)
        {
            SellerForm sf = new SellerForm();
            sf.ShowDialog();
        }
    }
}
