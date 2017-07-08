using System;
using System.Windows.Forms;

namespace SparesBase.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lVersion.Text = "Версия: " + Application.ProductVersion;
        }

        #region События
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion События
    }
}
