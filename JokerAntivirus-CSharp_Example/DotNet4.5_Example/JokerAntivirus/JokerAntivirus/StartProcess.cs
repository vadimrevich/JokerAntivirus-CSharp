using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokerAntivirus
{
    public class StartProcess
    {
        // Set a Private Members
        private String strCmdPath;
        private String strCmd32Path;
        private String strCScriptPath;
        private String strWScriptPath;
        private String strWPoshPath;
        private String strNotepadPath;

        // Private Methods
        private void SetPaths()
        {
            strCmdPath = UserDirectories.GetPathCmd() + "\\cmd.exe";
            if(!File.Exists(strCmdPath))
            {
                Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strCmdPath);
                strCmdPath = String.Empty;
            }
            strCmd32Path = UserDirectories.GetPathWOWCmd() + "\\cmd.exe";
            if (!File.Exists(strCmd32Path))
            {
                if(UserDirectories.Is64Bit())
                    Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strCmd32Path);
                strCmd32Path = String.Empty;
            }
            strCScriptPath = UserDirectories.GetPathCmd() + "\\cscript.exe";
            if (!File.Exists(strCScriptPath))
            {
                Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strCScriptPath);
                strCScriptPath = String.Empty;
            }
            strWScriptPath = UserDirectories.GetPathCmd() + "\\wscript.exe";
            if (!File.Exists(strWScriptPath))
            {
                Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strWScriptPath);
                strWScriptPath = String.Empty;
            }
            strWPoshPath = UserDirectories.GetPathCmd() + "\\WindowsPowerShell\\v1.0\\powershell.exe";
            if (!File.Exists(strWPoshPath))
            {
                Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strWPoshPath);
                strWPoshPath = String.Empty;
            }
            strNotepadPath = UserDirectories.GetSystemRootPath() + "\\notepad.exe";
            if (!File.Exists(strNotepadPath))
            {
                Console.Error.WriteLine("Check Integrity Error. The File {0} is not found.", strNotepadPath);
                strNotepadPath = String.Empty;
            }
        }

        // Constructor

        public StartProcess()
        {
            SetPaths();
        }

        // Public Methods

        public int StartAsFile(String strFile, int iTimeOut)
        {
            if (strFile.Length == 0)
            {
                Console.Error.WriteLine("Process Error! Can\'t Run Empty File.");
                return 1;
            }
            ProcessStartInfo pri = new ProcessStartInfo();
            Process firstProc = new Process();
            pri.FileName = strFile;
            firstProc.EnableRaisingEvents = true;
            firstProc.StartInfo = pri;

            try
            {
                firstProc.Start();
                if (iTimeOut <= 0)
                {
                    firstProc.WaitForExit();
                    Console.Out.WriteLine("Process {0} is terminated Successfully!");
                    return 0;
                }
                else
                {
                    if (!firstProc.WaitForExit(iTimeOut))
                    {
                        firstProc.Kill();
                    }
                    Console.Out.WriteLine("Process {0} is terminated after {1} milliseconds.", strFile, iTimeOut);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Process Error. Can\'t Run a File {0}.\n{1}", strFile, e.Message);
                return 2;
            }
        }

        public int StartAsNotepad(String strFile, int iTimeOut)
        {
            if (strFile.Length == 0)
            {
                Console.Error.WriteLine("Process Error! Can\'t Run Empty File.");
                return 1;
            }
            if (strNotepadPath.Length == 0)
            {
                Console.Error.WriteLine("Check Integrity Error! The Notepad Path {0} does not Exists!", strNotepadPath);
                return 1;
            }
            ProcessStartInfo pri = new ProcessStartInfo();
            Process firstProc = new Process();
            pri.FileName = strNotepadPath;
            pri.Arguments = strFile;
            pri.RedirectStandardOutput = false;
            pri.UseShellExecute = true;
            pri.CreateNoWindow = false;
            firstProc.EnableRaisingEvents = true;
            firstProc.StartInfo = pri;

            try
            {
                firstProc.Start();
                if (iTimeOut <= 0)
                {
                    firstProc.WaitForExit();
                    Console.Out.WriteLine("Process {0} is terminated Successfully!");
                    return 0;
                }
                else
                {
                    if (!firstProc.WaitForExit(iTimeOut))
                    {
                        firstProc.Kill();
                    }
                    Console.Out.WriteLine("Process {0} is terminated after {1} milliseconds.", strFile, iTimeOut);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Process Error. Can\'t Run a File {0}.\n{1}", strFile, e.Message);
                return 2;
            }
        }
    }

}
