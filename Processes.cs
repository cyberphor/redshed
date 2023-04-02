
using System; // provides Console
using System.Collections.Generic; // provides Dictionary
using System.ComponentModel; // provides Win32Exception
using System.Diagnostics; // provides Process
using System.Runtime.InteropServices; // provides DllImport
using System.Text; // provides Encoding

namespace RedShed {
    class Processes {      
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref IntPtr lpNumberOfBytesRead);

        static void PrintBytes(byte[] bytes) {
            Console.WriteLine(BitConverter.ToString(bytes));
        }

        static void GetProcessMemory(Process p) {
            IntPtr bytesRead = IntPtr.Zero;
            byte[] buffer = new byte[p.MainModule.ModuleMemorySize];
            ReadProcessMemory(p.Handle, p.MainModule.BaseAddress, buffer, buffer.Length, ref bytesRead);
            PrintBytes(buffer);
        }

        static void Main() { 
            foreach (Process p in Process.GetProcesses()) {
                try {
                    if (p.ProcessName == "Notepad") { 
                        GetProcessMemory(p);
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
    ReadProcessMemory example
    https://codingvision.net/c-read-write-another-process-memory

    Print Byte Array example
    https://gist.github.com/aal89/150c2af2f9dfd38dafaba4ac55317366

    Windows API - ProcessModule
    https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processmodule?view=net-7.0
*/