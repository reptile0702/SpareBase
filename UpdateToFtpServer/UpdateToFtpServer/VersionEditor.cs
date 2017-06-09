using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateToFtpServer
{
    public partial class VersionEditor : Form
    {
        ProgramVersion programVersion;
        string newFileVersionPath;

        public VersionEditor(ProgramVersion version, string newFileVersionPath)
        {
            InitializeComponent();
            programVersion = version;
            this.newFileVersionPath = newFileVersionPath;
            FillData();
        }

        private void FillData()
        {
            tbVersion.Text = programVersion.Version;
            tbDate.Text = programVersion.Date;
            rtbChangeLog.Text = programVersion.ChangeLog;
        }

        private void UploadVersion()
        {
            FtpManager.UploadNewVersion("Client", new ProgramVersion(tbVersion.Text, tbDate.Text, rtbChangeLog.Text, true), newFileVersionPath);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadVersion();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
