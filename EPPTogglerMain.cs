
using System.Reactive.Linq;
using GlobalHotKeys.Native.Types;
using GlobalHotKeys;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;

namespace ToggleEnhancedPointerPrecision
{
    internal class EPPTogglerMain
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, int[] pvParam, uint fWinIni);

        // Consts from: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfow

        // Get and setting Mouse settings including acceleration (EPP).
        private const uint SPI_GETMOUSE = 0x0003;
        private const uint SPI_SETMOUSE = 0x0004;

        // Get and setting Mouse acceleration value. Not Currently Implemented.
        private const uint SPI_GETMOUSESPEED = 0x0070;
        private const uint SPI_SETMOUSESPEED = 0x0071;

        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDWININICHANGE = 0x02;

        private const VirtualKeyCode DEFAULT_HOTKEY = VirtualKeyCode.VK_F12;
        private const Modifiers DEFAULT_MODIFIER = Modifiers.Control;

        public static HotKeyManager hkm;
        public static IRegistration hotkey;
        public static IObservable<HotKey> sub;
        // public static IRegistration hotkey;
    

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new EPPWindow();

            SetupConfigurator(form);
            ShowAccelState(form);

            // Initialize the default hotkey.
            ReplaceHotkey(form, DEFAULT_HOTKEY, DEFAULT_MODIFIER);

            // public static EPPWindow form1 = new EPPWindow(); // Place this var out of the constructor
            Application.Run(form);
        }

        static void ToggleEPP(EPPWindow f, HotKey h)
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

        static void ShowAccelState(EPPWindow f)
        {
            int[] mouse = new int[3];
            var res = SystemParametersInfo(SPI_GETMOUSE, 0, mouse, 0);
            f.AppendText($"Status of EPP at startup: {mouse[2] == 1}{Environment.NewLine}");
        }

        static void SetupConfigurator(EPPWindow f)
        {
            foreach (var vk in Enum.GetValues<VirtualKeyCode>())
            {
                f.AddHotkey(vk.ToString());
            }
            f.SelectHotkey(DEFAULT_HOTKEY.ToString());
            foreach (var m in Enum.GetValues<Modifiers>())
            {
                f.AddModifier(m.ToString());
            }
            f.SelectModifier(DEFAULT_MODIFIER.ToString());

            f.AppendText($"Hotkey is: {f.GetModifier().ToString()}-{f.GetHotkey().ToString().Replace("VK_", "")}{Environment.NewLine}");
        }

        public static void ReplaceHotkey(EPPWindow f, VirtualKeyCode vk, Modifiers m)
        {
            if (EPPTogglerMain.hkm != null)
            {
                EPPTogglerMain.hkm.Dispose();
                EPPTogglerMain.hkm = null;
            }
            EPPTogglerMain.hkm = new HotKeyManager();
            EPPTogglerMain.hotkey = EPPTogglerMain.hkm.Register(vk, m);
            EPPTogglerMain.sub = EPPTogglerMain.hkm.HotKeyPressed.Subscribe(hotKey => ToggleEPP(f, hotKey)) as IObservable<HotKey>;
            f.AppendText($"Current hotkey to: {m.ToString()}-{vk.ToString().Replace("VK_","")}{Environment.NewLine}");
        }
    }
}