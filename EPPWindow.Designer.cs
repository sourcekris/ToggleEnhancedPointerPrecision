namespace ToggleEnhancedPointerPrecision
{
    partial class EPPWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPPWindow));
            StatusLabel = new Label();
            StatusMessageBox = new TextBox();
            HotKeyLabel = new Label();
            SystemTrayIcon = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            ModifierDropDown = new ComboBox();
            ModifierLabel = new Label();
            HotKeyDropDown = new ComboBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(9, 8);
            StatusLabel.Margin = new Padding(2, 0, 2, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(42, 15);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "Status:";
            // 
            // StatusMessageBox
            // 
            StatusMessageBox.AcceptsReturn = true;
            StatusMessageBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusMessageBox.Location = new Point(9, 45);
            StatusMessageBox.Margin = new Padding(2);
            StatusMessageBox.Multiline = true;
            StatusMessageBox.Name = "StatusMessageBox";
            StatusMessageBox.ReadOnly = true;
            StatusMessageBox.Size = new Size(544, 219);
            StatusMessageBox.TabIndex = 1;
            // 
            // HotKeyLabel
            // 
            HotKeyLabel.AutoSize = true;
            HotKeyLabel.Location = new Point(380, 9);
            HotKeyLabel.Margin = new Padding(2, 0, 2, 0);
            HotKeyLabel.Name = "HotKeyLabel";
            HotKeyLabel.Size = new Size(48, 15);
            HotKeyLabel.TabIndex = 2;
            HotKeyLabel.Text = "Hotkey:";
            HotKeyLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // SystemTrayIcon
            // 
            SystemTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
            SystemTrayIcon.BalloonTipText = "Enhanced Pointer Precision Toggler is still running";
            SystemTrayIcon.BalloonTipTitle = "EPP Toggler Still Running";
            SystemTrayIcon.ContextMenuStrip = contextMenuStrip1;
            SystemTrayIcon.Icon = (Icon)resources.GetObject("SystemTrayIcon.Icon");
            SystemTrayIcon.Text = "EPP Toggler";
            SystemTrayIcon.Visible = true;
            SystemTrayIcon.DoubleClick += WindowReopen;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.AccessibleDescription = "Exit";
            exitToolStripMenuItem.AccessibleName = "Exit";
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ContextMenuExit;
            // 
            // ModifierDropDown
            // 
            ModifierDropDown.FormattingEnabled = true;
            ModifierDropDown.Location = new Point(302, 5);
            ModifierDropDown.Name = "ModifierDropDown";
            ModifierDropDown.Size = new Size(74, 23);
            ModifierDropDown.TabIndex = 3;
            ModifierDropDown.SelectionChangeCommitted += ChangeHotkey;
            // 
            // ModifierLabel
            // 
            ModifierLabel.AutoSize = true;
            ModifierLabel.Location = new Point(241, 9);
            ModifierLabel.Name = "ModifierLabel";
            ModifierLabel.Size = new Size(55, 15);
            ModifierLabel.TabIndex = 4;
            ModifierLabel.Text = "Modifier:";
            ModifierLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // HotKeyDropDown
            // 
            HotKeyDropDown.FormattingEnabled = true;
            HotKeyDropDown.Location = new Point(433, 6);
            HotKeyDropDown.Name = "HotKeyDropDown";
            HotKeyDropDown.Size = new Size(120, 23);
            HotKeyDropDown.TabIndex = 5;
            HotKeyDropDown.SelectionChangeCommitted += ChangeHotkey;
            // 
            // EPPWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(HotKeyDropDown);
            Controls.Add(ModifierLabel);
            Controls.Add(ModifierDropDown);
            Controls.Add(HotKeyLabel);
            Controls.Add(StatusMessageBox);
            Controls.Add(StatusLabel);
            Margin = new Padding(2);
            Name = "EPPWindow";
            Text = "Enhanced Pointer Precision Toggler";
            FormClosing += WindowClosing;
            Resize += WindowResize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox StatusMessageBox;
        private Label HotKeyLabel;
        private NotifyIcon SystemTrayIcon;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ComboBox ModifierDropDown;
        private Label ModifierLabel;
        private ComboBox HotKeyDropDown;
    }
}