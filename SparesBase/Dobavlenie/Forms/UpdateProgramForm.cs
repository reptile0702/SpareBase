using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparesBase
{
    public partial class UpdateProgramForm : Form
    {
        public UpdateProgramForm(string version, string changeLog)
        {
            InitializeComponent();
            lVersion.Text = "Доступна новая версия: " + version;
            rtbChangeLog.Text = changeLog;
            
        }

        private void UpdateProgramForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void UpdateProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
