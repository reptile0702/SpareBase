using System;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class DefectForm : Form
    {
        int quantity;
        int id;

        // Конструктор
        public DefectForm(int quantity, int id)
        {
            InitializeComponent();
            this.quantity = quantity;
            this.id = id;
        }


        // Заполнение ComboBox с количеством
        private void FillQuantity()
        {
            for (int i = 0; i < quantity; i++)
                cbQuantityOfDefect.Items.Add(i + 1);

            cbQuantityOfDefect.SelectedIndex = 0;
        }

        // Добавление дефекта в таблицу
        private void AddDefect()
        {
            // Проверка на введенность полей
            if (tbWhoIdentified.Text != "" &&
                tbNote.Text != "")
            {
                DatabaseWorker.SqlQuery("INSERT INTO Defect VALUES (''," + id + ", " + cbQuantityOfDefect.Text + ", '" + tbWhoIdentified.Text + "', '" + tbNote.Text + "')");
                DatabaseWorker.InsertAction(6, id);
            }
        }


        // Загрузка формы
        private void DefectForm_Load(object sender, EventArgs e)
        {
            FillQuantity();
        }

        // Клик на OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddDefect();
            Close();
        }

        // Клик на Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
