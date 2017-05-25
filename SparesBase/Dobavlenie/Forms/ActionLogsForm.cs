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
            lbLogs.Items.Clear();

            // Формирование условия по фильтрам
            string where = "";
            where = " WHERE((ActionLogs.OrganizationId=" + EnteredUser.OrganizationId + ") ";
            if (actionId != 0 || accountId != 0)
            {
               
                where += actionId != 0 ? " AND ActionLogs.ActionId= " + actionId + " " : "";               
                where += accountId != 0 ? " AND ActionLogs.AccountId=" + accountId : "";
               
            }
            where += ")";

            // Получение логов
            DataTable dt = DatabaseWorker.SqlSelectQuery("SELECT ActionLogs.ActionId, Accounts.LastName, Accounts.FirstName, Accounts.SecondName, Items.Item_Name, ActionLogs.Date FROM ActionLogs LEFT JOIN Accounts ON ActionLogs.AccountId=Accounts.id LEFT JOIN Items ON ActionLogs.ItemId=Items.id " + where);

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
                

                //lbLogs.Items.Add(row.ItemArray[0] + " " + row.ItemArray[1] + " " + row.ItemArray[2] + " " + row.ItemArray[3]);
            }
               
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

            
            dt = DatabaseWorker.SqlSelectQuery("SELECT id, LastName, FirstName, SecondName FROM Accounts WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
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
