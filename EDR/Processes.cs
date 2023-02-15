
using System; // provides Console
using System.Collections.Generic; // provides Dictionary
using System.ComponentModel; // provides Win32Exception
using System.Diagnostics; // provides Process
using System.Runtime.InteropServices; // provides DllImport
using System.Text; // provides Encoding

namespace RedShed {
    class ProcessInfo {
        public int Id;
        public string Name;
        public IntPtr Handle;
        public int ModuleCount;
    }

    class Processes {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        static ProcessInfo GetProcessInfo(Process p) {
            ProcessInfo pinfo = new ProcessInfo();
            pinfo.Id = p.Id;
            pinfo.Name = p.ProcessName;
            pinfo.Handle = p.Handle;
            pinfo.ModuleCount = p.Modules.Count;
            return pinfo;
        }

        static void GetProcessModuleMemory(Process p, ProcessModule m) {
            int bytesRead = 0;
            byte[] buffer = new byte[m.ModuleMemorySize];
            ReadProcessMemory((int) p.Handle, (int) m.BaseAddress, buffer, buffer.Length, ref bytesRead);
            Console.WriteLine(Encoding.Unicode.GetString(buffer));
        }

        static void Main() { 
            foreach (Process p in Process.GetProcesses()) {
                try {
                    if (p.ProcessName == "notepad") {
                        Console.WriteLine(GetProcessInfo(p.GetType().GetProperties()));
                        foreach (ProcessModule m in p.Modules) {
                            //Console.WriteLine(m);
                            //GetProcessModuleMemory(p, m);
                        }
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    continue;
                } 
            }  
        }
    }
}

/* 
    https://codingvision.net/c-read-write-another-process-memory
    var sb = new StringBuilder();
    foreach (var b in buffer) {
        sb.Append(b + " ");
    }
    Console.WriteLine(sb.ToString());
    https://gist.github.com/aal89/150c2af2f9dfd38dafaba4ac55317366
    https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processmodule?view=net-7.0
*/