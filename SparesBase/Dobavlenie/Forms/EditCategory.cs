using System;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class EditCategory : Form
    {
        MainForm mf;
        int id;
        int nodeCount;
        bool rename;
        string oldName;

        // Конструктор для добавления главной категории
        public EditCategory(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        // Конструктор для добавления подкатегории и переименования
        public EditCategory(MainForm mf, int id, int nodeCount, bool rename, string oldName)
        {
            InitializeComponent();
            this.mf = mf;
            this.id = id;
            this.nodeCount = nodeCount;
            this.rename = rename;
            this.oldName = oldName;
        }


        // Загрузка формы
        private void EditCategory_Load(object sender, EventArgs e)
        {
            if (rename)
            {
                Text = "Переименовывание категории";
                btnAdd.Text = "Переименовать";
                tbCategory.Text = oldName;
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
