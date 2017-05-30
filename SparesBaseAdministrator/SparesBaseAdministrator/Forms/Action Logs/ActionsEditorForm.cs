using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBaseAdministrator
{
    public partial class ActionsEditorForm : Form
    {
        private Action SelectedAction
        {
            get { return (Action)tvActions.SelectedNode.Tag; }
            set { tvActions.SelectedNode.Tag = value; }
        }

        public ActionsEditorForm()
        {
            InitializeComponent();
            FillActions();
        }

        private void FillActions()
        {
            tvActions.Nodes.Clear();

            DataTable actions = DatabaseWorker.SqlSelectQuery("SELECT * FROM Actions");
            foreach (DataRow row in actions.Rows)
            {
                Action action = new Action(int.Parse(row.ItemArray[0].ToString()), row.ItemArray[1].ToString(), row.ItemArray[2].ToString());

                TreeNode actionNode = new TreeNode(action.Name);
                actionNode.Tag = action;
                tvActions.Nodes.Add(actionNode);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ActionEditor ae = new ActionEditor();
            ae.ShowDialog();
            FillActions();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            ActionEditor ae = new ActionEditor(SelectedAction);
            ae.ShowDialog();
            FillActions();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить действие \"" + SelectedAction.Name + "\"?", "Удаление действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseWorker.SqlQuery("DELETE FROM Actions WHERE(id = " + SelectedAction.Id + ")");
                FillActions();
            }
        }
    }
}
