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
    public partial class ActionLogsForm : Form
    {
        public ActionLogsForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FindLogs(int actionId, int accountId)
        {
            // TODO: Находить логи только по текущей организации
            lbLogs.Items.Clear();
            string where = "";
            if (actionId != 0 || accountId != 0)
            {
                where = " WHERE ";
                where += actionId != 0 ? "ActionLogs.ActionId= " + actionId + " " : "";
                where += actionId != 0 && accountId != 0 ? " AND " : "";
                where += accountId != 0 ? "ActionLogs.AccountId=" + accountId : "";
            }
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT ActionLogs.ActionId, Accounts.LastName, Accounts.FirstName, Accounts.SecondName FROM ActionLogs LEFT JOIN Accounts ON ActionLogs.AccountId=Accounts.id " + where);
            foreach (DataRow row in dt.Rows)
            {
                lbLogs.Items.Add(row.ItemArray[0] + " " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
            }
        }

        private void FillComboboxes()
        {
            DataTable actions = new DataTable();
            actions.Columns.Add("id");
            actions.Columns.Add("Action");
            actions.Rows.Add("0", "Все действия");

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Actions");
            foreach (DataRow row in dt.Rows)
            {
                actions.Rows.Add(row.ItemArray[0], row.ItemArray[1]);
            }

            DataTable accounts = new DataTable();
            accounts.Columns.Add("id");
            accounts.Columns.Add("FIO");
            accounts.Rows.Add("0", "Все аккаунты");

            // TODO: Аккаунты только по текущей организации
            dt = DatabaseWorker.SqlSelectQuery("SELECT id, LastName, FirstName, SecondName FROM Accounts");
            foreach (DataRow row in dt.Rows)
            {
                accounts.Rows.Add(row.ItemArray[0], row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
            }
            cbAction.ValueMember = "id";
            cbAction.DisplayMember = "Action";
            cbAccount.ValueMember = "id";
            cbAccount.DisplayMember = "FIO";

            cbAction.DataSource = actions;
            cbAccount.DataSource = accounts;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;
            cbAccount.SelectedIndexChanged += CbAccount_SelectedIndexChanged;
        }

        private void CbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }

        private void ActionLogsForm_Load(object sender, EventArgs e)
        {
            FillComboboxes();
            FindLogs(0, 0);
        }
    }
}
