using System.Runtime.InteropServices;

namespace VolumeController {
  class Program {
    [DllImport("user32.dll")]
    public static extern int SendMessageW(int hWnd, int Msg, int wParam, int lParam);

    static void Main(string[] args) {
      const int APPCOMMAND_VOLUME_UP = 0xA0000;
      const int WM_APPCOMMAND = 0x319;
      SendMessageW(-1, WM_APPCOMMAND, 0, APPCOMMAND_VOLUME_UP);
    }
  }
}