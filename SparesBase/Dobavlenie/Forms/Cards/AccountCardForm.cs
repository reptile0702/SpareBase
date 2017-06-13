using System.Windows.Forms;

namespace SparesBase
{
    public partial class AccountCardForm : Form
    {
        // Конструктор
        public AccountCardForm(Account account)
        {
            InitializeComponent();
            InitializeCard(account);
        }

        // Инициализация карточки
        private void InitializeCard(Account account)
        {
            lFirstName.Text = "Имя: " + account.FirstName;
            lLastName.Text = "Фамилия: " + account.LastName;
            lSecondName.Text = "Отчество: " + account.SecondName;
            lCity.Text = "Город: " + account.City;
            lPhone.Text = "Телефон: " + account.Phone;
            lEmail.Text = "Email: " + account.Email;
            lAdmin.Text = account.Admin ? "Администратор оргацизации" : "Не администратор";
        }
    }
}
