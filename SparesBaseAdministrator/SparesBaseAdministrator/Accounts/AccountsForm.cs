using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class AccountsForm : Form
    {
        public AccountsForm()
        {
            InitializeComponent();
        }

        private void FillOrganizations()
        {
            DataTable organizations = DatabaseWorker.SqlSelectQuery("SELECT o.id, o.Name, o.Site, o.Telephone, c.City, o.AdminAccountId, a.FirstName, a.LastName, a.SecondName, a.Login, ac.City, a.Phone, a.Email, a.Admin FROM Organizations o LEFT JOIN Cities c ON c.id = o.CityId LEFT JOIN Accounts a ON a.id = o.AdminAccountId LEFT JOIN Cities ac ON ac.id = a.CityId");
            foreach (DataRow row in organizations.Rows)
            {
                Organization organization = new Organization(
                    int.Parse(row.ItemArray[0].ToString()),
                    row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(),
                    row.ItemArray[3].ToString(),
                    row.ItemArray[4].ToString(),
                    new Account(
                        int.Parse(row.ItemArray[5].ToString()),
                        row.ItemArray[6].ToString(),
                        row.ItemArray[7].ToString(),
                        row.ItemArray[8].ToString(),
                        row.ItemArray[9].ToString(),
                        row.ItemArray[10].ToString(),
                        row.ItemArray[11].ToString(),
                        row.ItemArray[12].ToString(),
                        row.ItemArray[13].ToString() == "0" ? false : true));
                TreeNode organizationNode = new TreeNode(organization.Name);
                organizationNode.Tag = organization;
                tvOrganizations.Nodes.Add(organizationNode);
            }
        }

        private void FillAccounts(Organization organization)
        {
            dgvAccounts.Rows.Clear();
            DataTable accounts = DatabaseWorker.SqlSelectQuery("SELECT a.id, a.FirstName, a.LastName, a.SecondName, a.Login, c.City, a.Phone, a.Email, a.Admin FROM Accounts a LEFT JOIN Cities c ON c.id = a.CityId WHERE(a.OrganizationId = " + organization.Id + ")");
            foreach (DataRow row in accounts.Rows)
            {
                Account account = new Account(
                    int.Parse(row.ItemArray[0].ToString()),
                        row.ItemArray[1].ToString(),
                        row.ItemArray[2].ToString(),
                        row.ItemArray[3].ToString(),
                        row.ItemArray[4].ToString(),
                        row.ItemArray[5].ToString(),
                        row.ItemArray[6].ToString(),
                        row.ItemArray[7].ToString(),
                        row.ItemArray[8].ToString() == "0" ? false : true);

                dgvAccounts.Rows.Add(
                    account.Id,
                    account.FirstName,
                    account.LastName,
                    account.SecondName,
                    account.Login);

                dgvAccounts.Rows[dgvAccounts.Rows.Count - 1].Tag = account;
            }
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            FillOrganizations();
        }

        private void tvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillAccounts((Organization)tvOrganizations.SelectedNode.Tag);
        }

        private void tvOrganizations_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OrganizationCardForm ocf = new OrganizationCardForm((Organization)e.Node.Tag);
            ocf.ShowDialog();
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AccountCardForm acf = new AccountCardForm((Account)dgvAccounts.Rows[e.RowIndex].Tag);
            acf.ShowDialog();
        }
    }
}
