namespace ToggleEnhancedPointerPrecision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon1;
            this.notifyIcon1.Visible = true;
            SetBalloonTip();
        }

        public void AppendText(string text) =>
          this.textBox1.AppendText(text);

        private void ContextMenuExit(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private void SetBalloonTip()
        {
            notifyIcon1.BalloonTipTitle = "EPP Toggler Still Running";
            notifyIcon1.BalloonTipText = "Right click the system tray icon to exit.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
        }

        private void WindowResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.ShowBalloonTip(30000);
                this.Hide();
            }
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {

            this.notifyIcon1.ShowBalloonTip(30000);
            e.Cancel = true;
            this.Hide();
        }

        private void WindowReopen(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
