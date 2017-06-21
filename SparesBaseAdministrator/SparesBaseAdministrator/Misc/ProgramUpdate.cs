using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
