using GlobalHotKeys.Native.Types;

namespace ToggleEnhancedPointerPrecision
{
    public partial class EPPWindow : Form
    {
        public EPPWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            // Setup Icon and System Tray icons.
            this.Icon = Properties.Resources.Icon1;
            this.SystemTrayIcon.Visible = true;
            SetBalloonTip();
        }

        public void AppendText(string text) =>
          this.StatusMessageBox.AppendText(text);

        public void AddHotkey(string text) =>
          this.HotKeyDropDown.Items.Add(text);

        public void AddModifier(string text) =>
          this.ModifierDropDown.Items.Add(text);

        public void SelectHotkey(string text) =>
            this.HotKeyDropDown.SelectedItem = text;

        public void SelectModifier(string text) =>
            this.ModifierDropDown.SelectedItem = text;

        public VirtualKeyCode GetHotkey()
        {
            return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), this.HotKeyDropDown.SelectedItem.ToString());
        }
        public Modifiers GetModifier()
        {
            return (Modifiers)Enum.Parse(typeof(Modifiers), this.ModifierDropDown.SelectedItem.ToString());
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            this.SystemTrayIcon.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private void SetBalloonTip()
        {
            SystemTrayIcon.BalloonTipTitle = "EPP Toggler Still Running";
            SystemTrayIcon.BalloonTipText = "Right click the system tray icon to exit.";
            SystemTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
        }

        private void WindowResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.SystemTrayIcon.ShowBalloonTip(30000);
                this.Hide();
            }
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {

            this.SystemTrayIcon.ShowBalloonTip(30000);
            e.Cancel = true;
            this.Hide();
        }

        private void WindowReopen(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void ChangeHotkey(object sender, EventArgs e)
        {
            EPPTogglerMain.ReplaceHotkey(this, this.GetHotkey(), this.GetModifier());
        }
    }
}
