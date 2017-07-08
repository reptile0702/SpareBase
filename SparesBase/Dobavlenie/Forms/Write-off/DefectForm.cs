using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class DefectForm : Form
    {
        int itemId;
        int quantity;

        // Конструктор
        public DefectForm(int quantity, int itemId)
        {
            InitializeComponent();
            this.quantity = quantity;
            this.itemId = itemId;
        }

        #region Методы
        
        // Заполнение ComboBox с количеством
        private void FillQuantity()
        {
            for (int i = 0; i < quantity; i++)
                cbQuantityOfDefect.Items.Add(i + 1);

            cbQuantityOfDefect.SelectedIndex = 0;
        }

        // Добавление дефекта в базу
        private void AddDefect()
        {
            // Проверка на введенность полей
            if (tbWhoIdentified.Text != "" &&
                tbNote.Text != "")
            {
                DatabaseWorker.SqlQuery("INSERT INTO Defect VALUES ('', " +
                    "" + itemId + ", " +
                    "" + cbQuantityOfDefect.Text + ", " +
                    "'" + tbWhoIdentified.Text + "', " +
                    "'" + tbNote.Text + "')");

                DatabaseWorker.InsertAction(6, itemId);
            }
        }

        #endregion Методы



        #region События

        // Загрузка формы
        private void DefectForm_Load(object sender, EventArgs e)
        {
            FillQuantity();
        }

        // Клик на OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddDefect();
            DialogResult = DialogResult.OK;
            Close();
        }

        // Клик на Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
