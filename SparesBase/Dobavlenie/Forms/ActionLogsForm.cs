using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class ActionLogsForm : Form
    {
        // Конструктор
        public ActionLogsForm()
        {
            InitializeComponent();
        }


        // Получение логов из базы по фильтрам
        private void GetLogs(int actionId, int accountId)
        {
            // TODO: Находить логи только по текущей организации
            lbLogs.Items.Clear();

            // Формирование условия по фильтрам
            string where = "";
            if (actionId != 0 || accountId != 0)
            {
                where = " WHERE ";
                where += actionId != 0 ? "ActionLogs.ActionId= " + actionId + " " : "";
                where += actionId != 0 && accountId != 0 ? " AND " : "";
                where += accountId != 0 ? "ActionLogs.AccountId=" + accountId : "";
            }

            // Получение логов
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT ActionLogs.ActionId, Accounts.LastName, Accounts.FirstName, Accounts.SecondName FROM ActionLogs LEFT JOIN Accounts ON ActionLogs.AccountId=Accounts.id " + where);

            // Запись в ListBox
            foreach (DataRow row in dt.Rows)
                lbLogs.Items.Add(row.ItemArray[0] + " " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
        }

        // Заполнение ComboBox'ов действий и аккаунтов
        private void FillComboboxes()
        {
            // Действия
            DataTable actions = new DataTable();
            actions.Columns.Add("id");
            actions.Columns.Add("Action");
            actions.Rows.Add("0", "Все действия");

            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT * FROM Actions");
            foreach (DataRow row in dt.Rows)
                actions.Rows.Add(row.ItemArray[0], row.ItemArray[1]);

            cbAction.ValueMember = "id";
            cbAction.DisplayMember = "Action";
            cbAction.DataSource = actions;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;

            // Аккаунты
            DataTable accounts = new DataTable();
            accounts.Columns.Add("id");
            accounts.Columns.Add("FIO");
            accounts.Rows.Add("0", "Все аккаунты");

            // TODO: Аккаунты только по текущей организации
            dt = DatabaseWorker.SqlSelectQuery("SELECT id, LastName, FirstName, SecondName FROM Accounts");
            foreach (DataRow row in dt.Rows)
                accounts.Rows.Add(row.ItemArray[0], row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
            
            cbAccount.ValueMember = "id";
            cbAccount.DisplayMember = "FIO";
            cbAccount.DataSource = accounts;
            cbAccount.SelectedIndexChanged += CbAccount_SelectedIndexChanged;
        }

        
        // Загрузка формы
        private void ActionLogsForm_Load(object sender, EventArgs e)
        {
            FillComboboxes();
            GetLogs(0, 0);
        }

        // Изменение выделенного действия
        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }

        // Изменение выделенного аккаунта
        private void CbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }
    }
}
