using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace UpdateToFtpServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetVersionsOfPrograms()
        {
            ProgramVersion[] clientVersions = FtpManager.GetVersions("Client");
            foreach (ProgramVersion version in clientVersions)
            {
                TreeNode versionNode = new TreeNode(version.CurrentVersion ? version.Version + " (Текущая версия)" : version.Version);
                versionNode.Tag = version;
                tvSparesBase.Nodes.Add(versionNode);
            }

            ProgramVersion[] adminVersions = FtpManager.GetVersions("Admin");
            foreach (ProgramVersion version in adminVersions)
            {
                TreeNode versionNode = new TreeNode(version.CurrentVersion ? version.Version + " (Текущая версия)" : version.Version);
                versionNode.Tag = version;
                tvAdmin.Nodes.Add(versionNode);
            }
        }

        private void UploadNewVersion()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы программ *.exe | *.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                VersionEditor ve = new VersionEditor(new ProgramVersion(
                    FileVersionInfo.GetVersionInfo(ofd.FileName).FileVersion,
                    DateTime.Now.ToShortDateString(),
                    "",
                    true),
                    ofd.FileName);
                ve.ShowDialog();
            }
        }

        private void EditVersion()
        {
            VersionEditor ve = new VersionEditor((ProgramVersion)tvSparesBase.SelectedNode.Tag, "");
            ve.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetVersionsOfPrograms();
        }

        private void tvSparesBase_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            EditVersion();
        }

        private void btnSparesBaseAddVersion_Click(object sender, EventArgs e)
        {
            UploadNewVersion();
        }
    }
}
