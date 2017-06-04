using System.Windows.Forms;

namespace SparesBase
{
    public partial class ChangeCategoriesForm : Form
    {
        EditForm ef;
        public ChangeCategoriesForm(EditForm ef, int organizationId)
        {
            InitializeComponent();
            this.ef = ef;
            tvCategories.FillCategories(organizationId, null);
            tvCategories.ExpandAll();
        }

        private void tvCategories_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ef.ChangeCategories(tvCategories.GetCategories());
            Close();
        }
    }
}
