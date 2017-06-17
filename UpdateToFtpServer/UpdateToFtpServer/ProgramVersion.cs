namespace UpdateToFtpServer
{
    public class ProgramVersion
    {
        public ProgramVersion(string version, string date, string changeLog, bool currentVersion)
        {
            Version = version;
            Date = date;
            ChangeLog = changeLog;
            CurrentVersion = currentVersion;
        }

        public string Version { get; set; }
        public string Date { get; set; }
        public string ChangeLog { get; set; }
        public bool CurrentVersion { get; set; }
    }
}
