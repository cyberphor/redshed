using System; // provides IntPtr and String
using System.Runtime.InteropServices; // provides DLLImport 

namespace Beep {
  class Program {
    [DllImport("Kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool Beep(uint dwFreq, uint dwDuration);
    
    static void Main(string[] args) {
      for (uint i = 100; i <= 20000; i++) { 
        Beep(i, 5); 
      }
    }
  }
}