using System;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class EditCategory : Form
    {
        ItemsForm mf;
        int id;
        int nodeCount;
        bool rename;

        // Конструктор для добавления главной категории
        public EditCategory(ItemsForm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        // Конструктор для добавления подкатегории и переименования
        public EditCategory(ItemsForm mf, int id, int nodeCount, bool rename)
        {
            InitializeComponent();
            this.mf = mf;
            this.id = id;
            this.nodeCount = nodeCount;
            this.rename = rename;
        }


        // Загрузка формы
        private void EditCategory_Load(object sender, EventArgs e)
        {
            if (rename)
            {
                Text = "Переименовывание категории";
                btnAdd.Text = "Переименовать";
            }
            else
            {
                btnAdd.Text = "Создать";

                if (id == 0)
                    Text = "Добавление главной категории";
                else
                    Text = "Добавление подкатегории";
            }
        }

        // Редактирование категории
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (rename)
            {
                if (id == 0)
                    mf.RenameCategory(0, id, tbCategory.Text);
                else
                    mf.RenameCategory(nodeCount, id, tbCategory.Text);
            }
            else
            {
                if (id == 0)
                    mf.AddCategory(0, id, tbCategory.Text);
                else
                    mf.AddCategory(nodeCount, id, tbCategory.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        // Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
