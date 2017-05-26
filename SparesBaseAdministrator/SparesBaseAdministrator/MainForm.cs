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

            lOrgCount.Text = "Количество зарегистрированных организаций: " + orgCount;
            lAccCount.Text = "Количество зарегистрированных аккаунтов: " + accCount;
            lItemsCount.Text = "Количество предметов в базе: " + itemsCount;
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
    }
}
