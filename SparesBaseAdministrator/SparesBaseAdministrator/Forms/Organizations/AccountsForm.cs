using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class AccountsForm : Form
    {
        // Выделенная организация в TreeView
        private Organization SelectedOrganization
        {
            get { return (Organization)tvOrganizations.SelectedNode.Tag; }
            set { tvOrganizations.SelectedNode.Tag = value; }
        }

        // Выделенный аккаунт в DataGridView
        private Account SelectedAccount
        {
            get { return (Account)dgvAccounts.CurrentRow.Tag; }
            set { dgvAccounts.CurrentRow.Tag = value; }
        }


        // Конструктор
        public AccountsForm()
        {
            InitializeComponent();
        }

        #region Методы

        // Заполнение TreeView организациями
        private void FillOrganizations()
        {
            // Выделенный нод
            TreeNode selectedNode = tvOrganizations.SelectedNode;

            tvOrganizations.Nodes.Clear();
            tvOrganizations.Nodes.Add("Без организации");

            DataTable organizations = DatabaseWorker.SqlSelectQuery("SELECT o.id, o.Name, o.Site, o.Telephone, c.City, o.AdminAccountId, a.FirstName, a.LastName, a.SecondName, a.Login, ac.City, a.Phone, a.Email, a.Admin FROM Organizations o LEFT JOIN Cities c ON c.id = o.CityId LEFT JOIN Accounts a ON a.id = o.AdminAccountId LEFT JOIN Cities ac ON ac.id = a.CityId");
            foreach (DataRow row in organizations.Rows)
            {
                Account adminAccount = null;
                if (row.ItemArray[5].ToString() != "0")
                    adminAccount = new Account(
                        int.Parse(row.ItemArray[5].ToString()),
                        row.ItemArray[6].ToString(),
                        row.ItemArray[7].ToString(),
                        row.ItemArray[8].ToString(),
                        row.ItemArray[9].ToString(),
                        row.ItemArray[10].ToString(),
                        row.ItemArray[11].ToString(),
                        row.ItemArray[12].ToString(),
                        row.ItemArray[13].ToString() == "0" ? false : true,
                        null);

                Organization organization = new Organization(
                    int.Parse(row.ItemArray[0].ToString()),
                    row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString(),
                    row.ItemArray[3].ToString(),
                    row.ItemArray[4].ToString(),
                    adminAccount);

                if (adminAccount != null)
                    organization.Admin.Organization = organization;

                TreeNode organizationNode = new TreeNode(organization.Name);
                organizationNode.Tag = organization;
                organizationNode.ContextMenuStrip = cmsOrganization;
                tvOrganizations.Nodes.Add(organizationNode);
            }

            // Выделение последнего выделенного нода
            if (selectedNode != null)
                tvOrganizations.SelectedNode = tvOrganizations.Nodes[selectedNode.Index];
            else
                tvOrganizations.SelectedNode = tvOrganizations.Nodes[0];
        }

        // Заполнение DataGridView аккаунтами (Без организации)
        private void FillAccounts()
        {
            dgvAccounts.Rows.Clear();
            DataTable accounts = DatabaseWorker.SqlSelectQuery("SELECT a.id, a.FirstName, a.LastName, a.SecondName, a.Login, c.City, a.Phone, a.Email, a.Admin FROM Accounts a LEFT JOIN Cities c ON c.id = a.CityId WHERE(a.OrganizationId = 0)");
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
                        row.ItemArray[8].ToString() == "0" ? false : true,
                        null);

                dgvAccounts.Rows.Add(
                    account.Id,
                    account.FirstName,
                    account.LastName,
                    account.SecondName,
                    account.Login,
                    account.Admin);

                dgvAccounts.Rows[dgvAccounts.Rows.Count - 1].Tag = account;
            }

            if (dgvAccounts.Rows.Count == 0)
            {
                tsmiEditAccount.Enabled = false;
                cmsEditAccount.Enabled = false;

                tsmiDeleteAccount.Enabled = false;
                cmsDeleteAccount.Enabled = false;

                tsmiDesignateAnAdministrator.Enabled = false;
                cmsDesignateAnAdministrator.Enabled = false;
            }
            else
            {
                tsmiEditAccount.Enabled = true;
                cmsEditAccount.Enabled = true;

                tsmiDeleteAccount.Enabled = true;
                cmsDeleteAccount.Enabled = true;

                tsmiDesignateAnAdministrator.Enabled = true;
                cmsDesignateAnAdministrator.Enabled = true;
            }
        }

        // Заполнение DataGridView аккаунтами (С организацией)
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
                        row.ItemArray[8].ToString() == "0" ? false : true,
                        SelectedOrganization);

                dgvAccounts.Rows.Add(
                    account.Id,
                    account.FirstName,
                    account.LastName,
                    account.SecondName,
                    account.Login,
                    account.Admin);

                dgvAccounts.Rows[dgvAccounts.Rows.Count - 1].Tag = account;
            }

            if (dgvAccounts.Rows.Count == 0)
            {
                tsmiEditAccount.Enabled = false;
                cmsEditAccount.Enabled = false;

                tsmiDeleteAccount.Enabled = false;
                cmsDeleteAccount.Enabled = false;

                tsmiDesignateAnAdministrator.Enabled = false;
                cmsDesignateAnAdministrator.Enabled = false;
            }
            else
            {
                tsmiEditAccount.Enabled = true;
                cmsEditAccount.Enabled = true;

                tsmiDeleteAccount.Enabled = true;
                cmsDeleteAccount.Enabled = true;

                tsmiDesignateAnAdministrator.Enabled = true;
                cmsDesignateAnAdministrator.Enabled = true;
            }
        }

        #endregion Методы



        #region События


        #region Главные

        // Загрузка формы
        private void AccountsForm_Load(object sender, EventArgs e)
        {
            FillOrganizations();
        }

        // Выделение нода в TreeView
        private void tvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvOrganizations.SelectedNode.Tag != null)
            {
                FillAccounts((Organization)tvOrganizations.SelectedNode.Tag);

                tsmiDesignateAnAdministrator.Enabled = true;
                cmsDesignateAnAdministrator.Enabled = true;

                tsmiEditOrganization.Enabled = true;
                cmsEditOrganization.Enabled = true;

                tsmiDeleteOrganization.Enabled = true;
                cmsDeleteOrganization.Enabled = true;
            }
            else
            {
                FillAccounts();

                tsmiDesignateAnAdministrator.Enabled = false;
                cmsDesignateAnAdministrator.Enabled = false;

                tsmiEditOrganization.Enabled = false;
                cmsEditOrganization.Enabled = false;

                tsmiDeleteOrganization.Enabled = false;
                cmsDeleteOrganization.Enabled = false;
            }
        }

        // Двойной клик на ноде в TreeView
        private void tvOrganizations_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                OrganizationCardForm ocf = new OrganizationCardForm((Organization)e.Node.Tag);
                ocf.ShowDialog();
            }
        }

        // Двойной клик на ячейку в DataGridView
        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                AccountCardForm acf = new AccountCardForm((Account)dgvAccounts.Rows[e.RowIndex].Tag);
                acf.ShowDialog();
            }
        }

        #endregion Главные


        #region Организация

        // Регистрация организации
        private void RegisterOrganization_Click(object sender, EventArgs e)
        {
            OrganizationEditorForm oe = new OrganizationEditorForm();
            oe.ShowDialog();
            FillOrganizations();
        }

        // Редактирование организации
        private void EditOrganization_Click(object sender, EventArgs e)
        {
            OrganizationEditorForm oe = new OrganizationEditorForm((Organization)tvOrganizations.SelectedNode.Tag);
            oe.ShowDialog();
            FillOrganizations();
        }

        // Удаление организации
        private void DeleteOrganization_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Вы уверены, что хотите удалить эту организацию?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("UPDATE Accounts SET OrganizationId = 0, Admin = 0 WHERE(OrganizationId = " + SelectedOrganization.Id + ")");
                DatabaseWorker.SqlQuery("DELETE FROM Organizations WHERE(id = " + SelectedOrganization.Id + ")");
                tvOrganizations.Nodes.Remove(tvOrganizations.SelectedNode);
            }
        }

        #endregion Организация


        #region Аккаунт

        // Регистрация аккаунта
        private void RegisterAccount_Click(object sender, EventArgs e)
        {
            if (SelectedOrganization != null)
            {
                AccountRegistrationForm aef = new AccountRegistrationForm(SelectedOrganization.Id);
                aef.ShowDialog();
            }
            else
            {
                AccountRegistrationForm aef = new AccountRegistrationForm(0);
                aef.ShowDialog();
            }

            if (SelectedOrganization != null)
                FillAccounts(SelectedOrganization);
            else
                FillAccounts();
        }

        // Редактирование аккаунта
        private void EditAccount_Click(object sender, EventArgs e)
        {
            AccountEditForm aef = new AccountEditForm(SelectedAccount);
            aef.ShowDialog();
            if (SelectedOrganization != null)
                FillAccounts(SelectedOrganization);
            else
                FillAccounts();
        }

        // Удаление аккаунта
        private void DeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Вы уверены, что хотите удалить этот аккаунт?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("DELETE FROM Accounts WHERE(id = " + SelectedAccount.Id + ")");

                // Если происходит удаление админа организации, то меняется поле админа в таблице Organizations
                if (SelectedAccount.Admin)
                {
                    DatabaseWorker.SqlQuery("UPDATE Organizations SET AdminAccountId = 0 WHERE(id = " + SelectedOrganization.Id + ");");
                    SelectedOrganization.Admin = null;
                    tvOrganizations.SelectedNode.Tag = SelectedOrganization;
                }

                FillAccounts(SelectedOrganization);
            }
        }

        // Смена администратора
        private void DesignateAnAdministrator_Click(object sender, EventArgs e)
        {
            if (!SelectedAccount.Admin)
            {
                if (MessageBox.Show(
                    "Вы уверены, что хотите поменять администратора в этой организации?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = "";
                    if (SelectedOrganization.Admin != null)
                        query += "UPDATE Accounts SET Admin = 0 WHERE(id = " + SelectedOrganization.Admin.Id + "); ";
                    query += "UPDATE Accounts SET Admin = 1 WHERE(id = " + SelectedAccount.Id + "); ";
                    query += "UPDATE Organizations SET AdminAccountId = " + SelectedAccount.Id + " WHERE(id = " + SelectedOrganization.Id + ");";

                    DatabaseWorker.SqlQuery(query);

                    SelectedAccount.Admin = true;
                    SelectedOrganization.Admin = SelectedAccount;

                    FillAccounts(SelectedOrganization);
                }
            }
            else
                MessageBox.Show("Данный аккаунт уже является администратором данной организации.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Аккаунт


        #endregion События
    }
}
