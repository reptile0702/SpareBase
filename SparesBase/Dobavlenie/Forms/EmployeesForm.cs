using System.Data;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class EmployeesForm : Form
    {
        // Конструктор
        public EmployeesForm()
        {
            InitializeComponent();
            FillEmployees();
        }


        // Заполнение сотрудников
        private void FillEmployees()
        {
            dgv.Rows.Clear();
            DataTable employees = DatabaseWorker.SqlSelectQuery("SELECT a.id, a.FirstName, a.LastName, a.SecondName, a.Login, c.City, a.Phone, a.Email, a.Admin, o.id, o.Name, o.Site, o.Telephone, oc.City  FROM Accounts a LEFT JOIN Cities c ON c.id=a.CityId LEFT JOIN Organizations o ON o.id=a.OrganizationId LEFT JOIN Cities oc ON oc.id=o.CityId WHERE(OrganizationId=" + EnteredUser.OrganizationId + ")");
            foreach (DataRow row in employees.Rows)
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
                     row.ItemArray[8].ToString() == "1" ? true : false,
                     null);

                Organization org = new Organization(
                    int.Parse(row.ItemArray[9].ToString()),
                    row.ItemArray[10].ToString(),
                    row.ItemArray[11].ToString(),
                    row.ItemArray[12].ToString(),
                    row.ItemArray[13].ToString(),                                    
                    account);
                account.Organization = org;

                dgv.Rows.Add(account.LastName, account.FirstName, account.SecondName);
                dgv.Rows[dgv.Rows.Count - 1].Tag = account;
            }
        }


        // Двойной клик на сотруднике
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AccountCardForm acf = new AccountCardForm((Account)dgv.Rows[e.RowIndex].Tag);
            acf.ShowDialog();
        }

        // Добавление сотрудника
        private void tsmiAdd_Click(object sender, System.EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
            FillEmployees();
        }

        // Редактирование сотрудника
        private void tsmiEdit_Click(object sender, System.EventArgs e)
        {
            AccountEditor ae = new AccountEditor((Account)dgv.CurrentRow.Tag);
            ae.ShowDialog();
            FillEmployees();
        }

        // Удаление сотрудника
        private void tsmiDelete_Click(object sender, System.EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Account account = (Account)dgv.CurrentRow.Tag;
                if (!account.Admin)
                {
                    DatabaseWorker.SqlQuery("DELETE FROM Accounts WHERE(id=" + account.Id + ")");
                    FillEmployees();
                }
                else
                    MessageBox.Show("Удаление админа произвести невозможно");   
            }
        }
    }
}
