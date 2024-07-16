using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace JokerAntivirus
{
    public static class UserDirectories
    {
        /* Private Methods */
        private static void MakeKMSDirs()
        {
            String strDir;
            strDir = GetSystemRootPath();
            if (strDir.Length > 0)
            {
                strDir = GetSystemRootPath() + "\\AAct_Tools";
                if (!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }

                strDir = GetSystemRootPath() + "\\AAct_Tools\\AAct_files";
                if (!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }
                strDir = GetSystemRootPath() + "\\KMS";
                if (!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }
                strDir = GetSystemRootPath() + "\\KMSAutoS";
                if (!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }
            }

        }

        private static void MakePub1Dir()
        {
            String strDir;
            strDir = "C:\\pub1";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\pub1\\Distrib";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\pub1\\Distrib\\Zlovred";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\pub1\\Util";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
        }

        private static void MakeNITUtilDir()
        {
            String strDir;
            strDir = "C:\\.BIN";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\Elevation";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\NIT.SYSUPDATE";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\ProgramData\\NIT";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\pub";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = "C:\\Util";
            if (!Directory.Exists(strDir))
            {
                try
                {
                    Directory.CreateDirectory(strDir);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                }
            }
            strDir = GetPathCmd();
            if(Directory.Exists(strDir))
            {
                strDir = strDir + "\\rserver30";
                if(!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }
            }
            strDir = GetPathWOWCmd();
            if (Directory.Exists(strDir))
            {
                strDir = strDir + "\\rserver30";
                if (!Directory.Exists(strDir))
                {
                    try
                    {
                        Directory.CreateDirectory(strDir);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Can\'t Create a Directory {0}.\n{1}", strDir, e.Message);
                    }
                }
            }
        }

        /* Public Methods */

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

        public static bool Is64Bit()
        {
            bool retVal;
            IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);
            return retVal;
        }
        public static String GetUserDownloadPath()
        {
            String strRes = "";
            if (Environment.OSVersion.Version.Major < 6) return GetUserDocumentsPath();
            strRes = cGetEnvVarsWinExp.GetDownloadPath();
            if( strRes.Length == 0)
            {
                return GetUserTempPath();
            }
            else
            {
                return strRes;
            }
        }

        public static String GetUserDocumentsPath()
        {
            String strRes = "";
            strRes = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(Directory.Exists(strRes))
            {
                return strRes;
            }
            else
            {
                return GetUserTempPath();
            }
        }

        public static String GetUserDesktopPath()
        {
            String strRes = "";
            strRes = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (Directory.Exists(strRes))
            {
                return strRes;
            }
            else
            {
                return GetUserTempPath();
            }
        }

        public static String GetUserTempPath()
        {
            String strRes = "";
            strRes = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Process);
            if (Directory.Exists(strRes))
            {
                return strRes;
            }
            else
            {
                strRes = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine);
                if (Directory.Exists(strRes))
                {
                    return strRes;
                }
                else
                {
                    Console.Error.WriteLine("Check Integrity Error! System Variable %Temp% is not Found.");
                    return String.Empty;
                }
            }
        }

        public static String GetUserProfilePath()
        {
            String strRes = String.Empty;
            strRes = Environment.GetEnvironmentVariable("USERPROFILE", EnvironmentVariableTarget.Process);
            if (Directory.Exists(strRes))
            {
                return strRes;
            }
            else
            {
                strRes = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine);
                if (Directory.Exists(strRes))
                {
                    return strRes;
                }
                else
                {
                    return GetSystemRootPath();
                }
            }
        }

        public static String GetSystemRootPath()
        {
            String strRes = String.Empty;
            strRes = Environment.GetEnvironmentVariable("SystemRoot", EnvironmentVariableTarget.Process);
            if (Directory.Exists(strRes))
            {
                return strRes;
            }
            else
            {
                Console.Error.WriteLine("Check Integrity Error! %SystemRoot% Folder is not Found.");
                return String.Empty;
            }
        }

        public static String GetPathCmd()
        {
            String strRes = GetSystemRootPath();
            if (strRes.Length > 0)
            {
                strRes = strRes + "\\System32";
                if (Directory.Exists(strRes))
                {
                    return strRes;
                }
            }
            Console.Error.WriteLine("Check Integrity Error! pathCmd Folder is not Found.");
            return String.Empty;
        }

        public static String GetPathWOWCmd()
        {
            String strRes = GetSystemRootPath();
            if (!Is64Bit()) return String.Empty;
            if( strRes.Length > 0)
            {
                strRes = strRes + "\\SysWOW64";
                if (Directory.Exists(strRes))
                {
                    return strRes;
                }
            }
            Console.Error.WriteLine("Check Integrity Error! pathWOWCmd Folder is not Found.");
            return String.Empty;
        }

        public static String GetSystemAActDir()
        {
            String strRes = GetSystemRootPath();
            if (strRes.Length == 0)
            {
                return String.Empty;
            }
            else
            {
                MakeKMSDirs();
                strRes = strRes + "\\AAct_Tools";
                if (!Directory.Exists(strRes)) return String.Empty;
                return strRes;
            }
        }
        public static String GetSystemKMSDir()
        {
            String strRes = GetSystemRootPath();
            if (strRes.Length == 0)
            {
                return String.Empty;
            }
            else
            {
                MakeKMSDirs();
                strRes = strRes + "\\KMS";
                if (!Directory.Exists(strRes)) return String.Empty;
                return strRes;
            }
        }
        public static String GetSystemKMSAutoSDir()
        {
            String strRes = GetSystemRootPath();
            if (strRes.Length == 0)
            {
                return String.Empty;
            }
            else
            {
                MakeKMSDirs();
                strRes = strRes + "\\KMSAutoS";
                if (!Directory.Exists(strRes)) return String.Empty;
                return strRes;
            }
        }
        public static String GetNITBinPath()
        {
            String strRes = "C:\\.BIN";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetNITElevationPath()
        {
            String strRes = "C:\\Elevation";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetNITSYSUPPath()
        {
            String strRes = "C:\\NIT.SYSUPDATE";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetNITProgDataPath()
        {
            String strRes = "C:\\ProgramData\\NIT";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetPubPath()
        {
            String strRes = "C:\\pub";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetNITUtilPath()
        {
            String strRes = "C:\\Util";
            MakeNITUtilDir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetNITPub1Path()
        {
            String strRes = "C:\\pub1";
            MakePub1Dir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetZlovredPath()
        {
            String strRes = "C:\\pub1\\Zlovred";
            MakePub1Dir();
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
        public static String GetRServer30Path()
        {
            String strRes = GetPathWOWCmd();
            if(strRes.Length == 0)
            {
                strRes = GetPathCmd();
            }
            if (strRes.Length == 0) return String.Empty;
            MakeNITUtilDir();
            strRes = strRes + "\\rserver30";
            if (!Directory.Exists(strRes))
            {
                return String.Empty;
            }
            else
            {
                return strRes;
            }
        }
    }
}
