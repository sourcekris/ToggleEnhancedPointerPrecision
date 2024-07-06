
using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;
using GlobalHotKeys.Native.Types;
using GlobalHotKeys;

namespace ToggleEnhancedPointerPrecision
{
    internal static class Program
    {
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
            using var subscription = hotKeyManager.HotKeyPressed
              .ObserveOn(SynchronizationContext.Current)
              .Subscribe(hotKey =>
                form.AppendText($"HotKey: Id = {hotKey.Id}, Key = {hotKey.Key}, Modifiers = {hotKey.Modifiers}{Environment.NewLine}")
              );

            Application.Run(form);
        }
    }
}