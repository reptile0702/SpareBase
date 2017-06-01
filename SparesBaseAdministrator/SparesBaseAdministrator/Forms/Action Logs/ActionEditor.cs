using System;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class ActionEditor : Form
    {
        Action action;

        public ActionEditor()
        {
            InitializeComponent();
            Text = "Добавление действия";
            btnEdit.Text = "Добавить";
        }

        public ActionEditor(Action action)
        {
            InitializeComponent();
            this.action = action;
            FillActionData();

            Text = "Редактирование действия";
            btnEdit.Text = "Изменить";
        }

        private void FillActionData()
        {
            tbActionName.Text = action.Name;
            tbActionText.Text = action.TemplateText;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (action == null)
                DatabaseWorker.SqlQuery("INSERT INTO Actions VALUES('', '" + tbActionName.Text + "', '" + tbActionText.Text + "')");
            else
                DatabaseWorker.SqlQuery("UPDATE Actions SET Action = '" + tbActionName.Text + "', TemplateText = '" + tbActionText.Text + "' WHERE(id = " + action.Id + ")");

            Close();
        }
    }
}
