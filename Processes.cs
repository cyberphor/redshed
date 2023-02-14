
using System; // provides Console
using System.ComponentModel; // provides Win32Exception
using System.Diagnostics; // provides Process
using System.Runtime.InteropServices; // provides DllImport
using System.Text; // provides Encoding

namespace RedShed {
    class Processes {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        
        static void Main() {  
            Process[] processCollection = Process.GetProcesses();  
            foreach (Process p in processCollection) {
                try {
                    if (p.ProcessName == "Notepad") {
                        Console.WriteLine(p.Id + " " + p.ProcessName + " " + p.Handle);
                        ProcessModuleCollection modules = p.Modules;
                        foreach (ProcessModule module in modules) {
                            int bytesRead = 0;
                            byte[] buffer = new byte[module.ModuleMemorySize];
                            ReadProcessMemory((int) p.Handle, (int) module.BaseAddress, buffer, buffer.Length, ref bytesRead);
                            Console.WriteLine(Encoding.Unicode.GetString(buffer));
                        }
                    }
                } catch {
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