using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UpdateToFtpServer
{
    public partial class VersionEditor : Form
    {
        ProgramVersion programVersion;
        string newFileVersionPath;
        string programType;

        public VersionEditor(ProgramVersion version, string newFileVersionPath, string programType)
        {
            InitializeComponent();
            programVersion = version;
            this.newFileVersionPath = newFileVersionPath;
            this.programType = programType;
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
            FtpManager.UploadNewVersion(programType, new ProgramVersion(tbVersion.Text, tbDate.Text, rtbChangeLog.Text, true), newFileVersionPath);            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadVersion();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
