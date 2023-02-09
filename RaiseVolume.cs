// https://www.dotnetcurry.com/ShowArticle.aspx?ID=431
using System; // provides IntPtr and String
using System.Runtime.InteropServices; // provides DLLImport 

namespace RaiseVolume {
  class Program {
    const int APPCOMMAND_VOLUME_UP = 0xA0000;
    const int WM_APPCOMMAND = 0x319;
    
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    static void Main(string[] args) {
      SendMessageW(Program.Main.Handle, WM_APPCOMMAND, Program.Main.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
    }
  }
}