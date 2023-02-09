using System; // provides IntPtr and String
using System.Runtime.InteropServices; // provides DLLImport 

namespace HelloWorld {
  class Program {
    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, String message, String title, uint type);
  
    static void Main(string[] args) {
      MessageBox(IntPtr.Zero, "Hello World!", "Foo Bar", 0);
    }
  }
}