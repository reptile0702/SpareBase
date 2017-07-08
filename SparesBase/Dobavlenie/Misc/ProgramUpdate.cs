namespace SparesBase
{
    public class ProgramUpdate
    {
        public string Version { get; set; }
        public string ChangeLog { get; set; }

        public ProgramUpdate(string version, string changeLog)
        {
            Version = version;
            ChangeLog = changeLog;
        }
    }
}
