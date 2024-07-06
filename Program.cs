
using System.Reactive.Linq;
using GlobalHotKeys.Native.Types;
using GlobalHotKeys;
using System.Runtime.InteropServices;

namespace ToggleEnhancedPointerPrecision
{
    internal static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, int[] pvParam, uint fWinIni);

        // Consts from: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfow

        // Get and setting Mouse settings including acceleration (EPP).
        private const uint SPI_GETMOUSE = 0x0003;
        private const uint SPI_SETMOUSE = 0x0004;

        // Get and setting Mouse acceleration value.
        private const uint SPI_GETMOUSESPEED = 0x0070;
        private const uint SPI_SETMOUSESPEED = 0x0071;

        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDWININICHANGE = 0x02;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var hotKeyManager = new HotKeyManager();
            using var shift1 = hotKeyManager.Register(VirtualKeyCode.VK_F12, Modifiers.Control);

            var form = new Form1();
            ShowAccelState(form);

            using var subscription = hotKeyManager.HotKeyPressed
              .ObserveOn(SynchronizationContext.Current)
              .Subscribe(hotKey => ToggleEPP(form, hotKey)
              );

            Application.Run(form);
        }

        static void ToggleEPP(Form1 f, HotKey h)
        {
            int[] mouse = new int[3];
            SystemParametersInfo(SPI_GETMOUSE, 0, mouse, 0);

            if (mouse[2] == 1)
            {
                mouse[2] = 0;
                f.AppendText($"Disabling EPP.{Environment.NewLine}");
                SystemParametersInfo(SPI_SETMOUSE, 0, mouse, 0);
            }
            else
            {
                mouse[2] = 1;
                f.AppendText($"Enabling EPP.{Environment.NewLine}");
                SystemParametersInfo(SPI_SETMOUSE, 0, mouse, 0);
            }
            SystemParametersInfo(SPI_GETMOUSE, 0, mouse, 0);
            f.AppendText($"Status of EPP now: {mouse[2] == 1}{Environment.NewLine}");
        }

        static void ShowAccelState(Form1 f)
        {
            int[] mouse = new int[3];
            var res = SystemParametersInfo(SPI_GETMOUSE, 0, mouse, 0);
            f.AppendText($"Status of EPP at startup: {mouse[2] == 1}{Environment.NewLine}");
        }
    }
}