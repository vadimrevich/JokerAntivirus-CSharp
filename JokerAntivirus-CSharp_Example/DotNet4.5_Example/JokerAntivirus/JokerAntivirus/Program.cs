using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokerAntivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Downloads dn = new Downloads();
            StartProcess sp = new StartProcess();

            // Check User Downloads Path
            dn.SetUserDownloadPath();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check User Documents Path
            dn.SetUserDocumentsPath();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check User Desktop Path
            dn.SetUserDesktopPath();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check NIT .BIN Path
            dn.SetNITBINDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check NIT ELevation Path
            dn.SetNITEleveationDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check NIT SYSUPDATE Path
            dn.SetNITSysUpDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check NIT ProgData Path
            dn.SetNITProgDataDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check Pub Path
            dn.SetPubDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check NIT Pub1 Path
            dn.SetNITPub1Dir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check User Util Path
            dn.SetNITUtilDir();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

            // Check RServer30 Path
            dn.SetRServer30Path();
            dn.Download();
            sp.StartAsNotepad(dn.GetLocalPath(), 5000);

        }
    }
}
