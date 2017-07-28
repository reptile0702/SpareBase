using System;
using System.Data;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class ActionLogsForm : Form
    {
        #region Конструкторы
        
        // Конструктор
        public ActionLogsForm()
        {
            InitializeComponent();
        }

        #endregion Конструкторы



        #region Методы

        // Получение логов из базы по фильтрам
        private void GetLogs(int actionId, int accountId)
        {           
            lbLogs.Items.Clear();

            // Даты
            string dateFrom = dtpFrom.Value.Date.ToString("yyyy-MM-dd 23:59:59");
            string dateTo = dtpTo.Value.Date.ToString("yyyy-MM-dd 23:59:59");

            // Формирование условия по фильтрам
            string where = "";
            where = " WHERE(((al.OrganizationId=" + EnteredUser.Organization.Id + ") AND (al.Date BETWEEN '" + dateFrom + "' AND '" + dateTo + "')) AND";
            if (actionId != 0 || accountId != 0)
            {
                where += actionId != 0 ? " al.ActionId= " + actionId + " AND " : "";               
                where += accountId != 0 ? " al.AccountId=" + accountId + " AND " : "";  
            }
            where = where.Remove(where.Length - 4, 4) + ") ORDER BY al.Date";

            // Получение логов
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT " +
                "al.ActionId, " +
                "a.LastName, " +
                "a.FirstName, " +
                "a.SecondName, " +
                "i.Item_Name, " +
                "al.Date " +
                "FROM ActionLogs al " +
                "LEFT JOIN Accounts a ON al.AccountId = a.id " +
                "LEFT JOIN Items i ON al.ItemId = i.id " + where + " DESC");

            // Запись в ListBox
            foreach (DataRow row in dt.Rows)
            {
                DateTime date = DateTime.Parse(row.ItemArray[5].ToString());
                switch (row.ItemArray[0].ToString())
                {
                    case "1":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Добавлен предмет \"" + row.ItemArray[4] + "\" пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                    case "2":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Изменен предмет \"" + row.ItemArray[4] + "\" пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                    case "3":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Удалён предмет \"" + row.ItemArray[4] + "\" пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                    case "4":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Предмет \"" + row.ItemArray[4] + "\" поступил в заказ пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                    case "5":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Предмет \"" + row.ItemArray[4] + "\" поступил в продажу пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                    case "6":
                        lbLogs.Items.Add("[" + date.Date.ToShortDateString() + " " + date.TimeOfDay + "] Обнаружен брак в предмете \"" + row.ItemArray[4] + "\" пользователем " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
                        break;
                }
            }
        }

        // Заполнение действий
        private void FillActions()
        {
            // Действия
            DataTable actions = new DataTable();
            actions.Columns.Add("id");
            actions.Columns.Add("Action");
            actions.Rows.Add("0", "Все действия");

            DataTable queryActions = DatabaseWorker.SqlSelectQuery("SELECT * FROM Actions");
            foreach (DataRow row in queryActions.Rows)
                actions.Rows.Add(row.ItemArray[0], row.ItemArray[1]);

            cbAction.ValueMember = "id";
            cbAction.DisplayMember = "Action";
            cbAction.DataSource = actions;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;
        }

        // Заполнение аккаунтов
        private void FillAccounts()
        {
            // Аккаунты
            DataTable accounts = new DataTable();
            accounts.Columns.Add("id");
            accounts.Columns.Add("FIO");
            accounts.Rows.Add("0", "Все аккаунты");

            DataTable queryAccounts = DatabaseWorker.SqlSelectQuery("SELECT " +
                "id, " +
                "LastName, " +
                "FirstName, " +
                "SecondName " +
                "FROM Accounts " +
                "WHERE(OrganizationId = " + EnteredUser.Organization.Id + ")");
            foreach (DataRow row in queryAccounts.Rows)
                accounts.Rows.Add(
                    row.ItemArray[0], 
                    row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
            
            cbAccount.ValueMember = "id";
            cbAccount.DisplayMember = "FIO";
            cbAccount.DataSource = accounts;
            cbAccount.SelectedIndexChanged += CbAccount_SelectedIndexChanged;
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void ActionLogsForm_Load(object sender, EventArgs e)
        {
            FillAccounts();
            FillActions();
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

        // Изменение даты "C"
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            GetLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }

        // Изменение даты "По"
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            GetLogs(int.Parse(cbAction.SelectedValue.ToString()), int.Parse(cbAccount.SelectedValue.ToString()));
        }

        #endregion События
    }
}
