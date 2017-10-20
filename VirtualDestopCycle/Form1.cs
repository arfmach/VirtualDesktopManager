using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;
using WindowsDesktop;

namespace VirtualDesktopManager
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private IList<VirtualDesktop> _Desktops;
        private IntPtr[] _ActivePrograms;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private readonly HotKeyManager _RightHotkey;
        private readonly HotKeyManager _LeftHotkey;
        private readonly HotKeyManager _NumberHotkey;

        private bool _CloseToTray;

        private readonly bool _UseAltKeySettings;

        public Form1()
        {
            InitializeComponent();

            HandleChangedNumber();

            _CloseToTray = true;

            _RightHotkey = new HotKeyManager();
            _RightHotkey.KeyPressed += RightKeyManagerPressed;

            _LeftHotkey = new HotKeyManager();
            _LeftHotkey.KeyPressed += LeftKeyManagerPressed;

            _NumberHotkey = new HotKeyManager();
            _NumberHotkey.KeyPressed += NumberHotkeyPressed;

            VirtualDesktop.CurrentChanged += VirtualDesktop_CurrentChanged;
            VirtualDesktop.Created += VirtualDesktop_Added;
            VirtualDesktop.Destroyed += VirtualDesktop_Destroyed;

            FormClosing += Form1_FormClosing;

            _UseAltKeySettings = Properties.Settings.Default.AltHotKey;
            _CheckBox1.Checked = _UseAltKeySettings;

            _ListView1.Items.Clear();
            _ListView1.Columns.Add("File").Width = 400;
            foreach (var file in Properties.Settings.Default.DesktopBackgroundFiles)
            {
                _ListView1.Items.Add(NewListViewItem(file));
            }
        }

        private void NumberHotkeyPressed(object sender, KeyPressedEventArgs e)
        {
            var index = (int) e.HotKey.Key - (int)Key.D0 - 1;
            var currentDesktopIndex = GetCurrentDesktopIndex();

            if (index == currentDesktopIndex)
            {
                return;
            }

            if (index > _Desktops.Count - 1)
            {
                return;
            }

            _Desktops.ElementAt(index)?.Switch();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_CloseToTray)
            {
                e.Cancel = true;
                Visible = false;
                ShowInTaskbar = false;
                _NotifyIcon.BalloonTipTitle = "Still Running...";
                _NotifyIcon.BalloonTipText = "Right-click on the tray icon to exit.";
                _NotifyIcon.ShowBalloonTip(2000);
            }
        }

        private void HandleChangedNumber()
        {
            _Desktops = VirtualDesktop.GetDesktops();
            _ActivePrograms = new IntPtr[_Desktops.Count];
        }

        private void VirtualDesktop_Added(object sender, VirtualDesktop e)
        {
            HandleChangedNumber();
        }

        private void VirtualDesktop_Destroyed(object sender, VirtualDesktopDestroyEventArgs e)
        {
            HandleChangedNumber();
        }

        private void VirtualDesktop_CurrentChanged(object sender, VirtualDesktopChangedEventArgs e)
        {
            // 0 == first
            var currentDesktopIndex = GetCurrentDesktopIndex();

            var pictureFile = PickNthFile(currentDesktopIndex);
            if (pictureFile != null)
            {
                Native.SetBackground(pictureFile);
            }

            RestoreApplicationFocus(currentDesktopIndex);
            ChangeTrayIcon(currentDesktopIndex);
        }

        private static string PickNthFile(int currentDesktopIndex)
        {
            var n = Properties.Settings.Default.DesktopBackgroundFiles.Count;
            if (n == 0)
            {
                return null;
            }
            var index = currentDesktopIndex % n;
            return Properties.Settings.Default.DesktopBackgroundFiles[index];
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RightHotkey.Dispose();
            _LeftHotkey.Dispose();
            _NumberHotkey.Dispose();

            _CloseToTray = false;

            Close();
        }

        private void NormalHotkeys()
        {
            try
            {
                _RightHotkey.Register(Key.Right, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
                _LeftHotkey.Register(Key.Left, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
                RegisterNumberHotkeys(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            }
            catch (Exception)
            {
                _NotifyIcon.BalloonTipTitle = "Error setting hotkeys";
                _NotifyIcon.BalloonTipText = "Could not set hotkeys. Please open settings and try the alternate combination.";
                _NotifyIcon.ShowBalloonTip(2000);
            }
        }

        private void AlternateHotkeys()
        {
            try
            {
                _RightHotkey.Register(Key.Right, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
                _LeftHotkey.Register(Key.Left, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
                RegisterNumberHotkeys(System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
            }
            catch (Exception)
            {
                _NotifyIcon.BalloonTipTitle = "Error setting hotkeys";
                _NotifyIcon.BalloonTipText = "Could not set hotkeys. Please open settings and try the default combination.";
                _NotifyIcon.ShowBalloonTip(2000);
            }
        }

        private void RegisterNumberHotkeys(ModifierKeys modifiers)
        {
            _NumberHotkey.Register(Key.D1, modifiers);
            _NumberHotkey.Register(Key.D2, modifiers);
            _NumberHotkey.Register(Key.D3, modifiers);
            _NumberHotkey.Register(Key.D4, modifiers);
            _NumberHotkey.Register(Key.D5, modifiers);
            _NumberHotkey.Register(Key.D6, modifiers);
            _NumberHotkey.Register(Key.D7, modifiers);
            _NumberHotkey.Register(Key.D8, modifiers);
            _NumberHotkey.Register(Key.D9, modifiers);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _LabelStatus.Text = "";

            if (!_UseAltKeySettings)
            {
                NormalHotkeys();
            }
            else
            {
                AlternateHotkeys();
            }

            var desktop = InitialDesktopState();
            ChangeTrayIcon();

            Visible = false;
        }

        private int GetCurrentDesktopIndex()
        {
            return _Desktops.IndexOf(VirtualDesktop.Current);
        }

        private void SaveApplicationFocus(int currentDesktopIndex = -1)
        {
            var activeAppWindow = GetForegroundWindow();

            if (currentDesktopIndex == -1)
            {
                currentDesktopIndex = GetCurrentDesktopIndex();
            }

            _ActivePrograms[currentDesktopIndex] = activeAppWindow;
        }

        private void RestoreApplicationFocus(int currentDesktopIndex = -1)
        {
            if (currentDesktopIndex == -1)
            {
                currentDesktopIndex = GetCurrentDesktopIndex();
            }

            if (_ActivePrograms[currentDesktopIndex] != null && _ActivePrograms[currentDesktopIndex] != IntPtr.Zero)
            {
                SetForegroundWindow(_ActivePrograms[currentDesktopIndex]);
            }
        }

        private void ChangeTrayIcon(int currentDesktopIndex = -1)
        {
            if (currentDesktopIndex == -1)
            {
                currentDesktopIndex = GetCurrentDesktopIndex();
            }

            var desktopNumber = currentDesktopIndex + 1;
            var desktopNumberString = desktopNumber.ToString();

            var fontSize = 140;
            var xPlacement = 100;
            var yPlacement = 50;

            if (desktopNumber > 9 && desktopNumber < 100)
            {
                fontSize = 125;
                xPlacement = 75;
                yPlacement = 65;
            }
            else if(desktopNumber > 99)
            {
                fontSize = 80;
                xPlacement = 90;
                yPlacement = 100;
            }

            using (var newIcon = Properties.Resources.mainIcoPng)
            {
                var desktopNumberFont = new Font("Segoe UI", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                using (var gr = Graphics.FromImage(newIcon))
                {
                    gr.DrawString(desktopNumberString, desktopNumberFont, Brushes.White, xPlacement, yPlacement);

                    var numberedIcon = Icon.FromHandle(newIcon.GetHicon());
                    _NotifyIcon.Icon = numberedIcon;

                    DestroyIcon(numberedIcon.Handle);
                    desktopNumberFont.Dispose();
                }
            }
        }

        private VirtualDesktop InitialDesktopState()
        {
            var desktop = VirtualDesktop.Current;
            var desktopIndex = GetCurrentDesktopIndex();

            SaveApplicationFocus(desktopIndex);

            return desktop;
        }

        private void RightKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            var desktop = InitialDesktopState();

            if (desktop.GetRight() != null)
            {
                desktop.GetRight()?.Switch();
            }
            else
            {
                _Desktops.First()?.Switch();
            }
        }

        private void LeftKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            var desktop = InitialDesktopState();

            if (desktop.GetLeft() != null)
            {
                desktop.GetLeft()?.Switch();
            }
            else
            {
                _Desktops.Last()?.Switch();
            }
        }

        private void OpenSettings()
        {
            Visible = true;
            WindowState = System.Windows.Forms.FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ListView1.SelectedItems.Count > 0)
                {
                    var selected = _ListView1.SelectedItems[0];
                    var indx = selected.Index;
                    var totl = _ListView1.Items.Count;

                    if (indx == 0)
                    {
                        _ListView1.Items.Remove(selected);
                        _ListView1.Items.Insert(totl - 1, selected);
                    }
                    else
                    {
                        _ListView1.Items.Remove(selected);
                        _ListView1.Items.Insert(indx - 1, selected);
                    }
                }
                else
                {
                    MessageBox.Show("You can only move one item at a time. Please select only one item and try again.",
                        "Item Select", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ListView1.SelectedItems.Count > 0)
                {
                    var selected = _ListView1.SelectedItems[0];
                    var indx = selected.Index;
                    var totl = _ListView1.Items.Count;

                    if (indx == totl - 1)
                    {
                        _ListView1.Items.Remove(selected);
                        _ListView1.Items.Insert(0, selected);
                    }
                    else
                    {
                        _ListView1.Items.Remove(selected);
                        _ListView1.Items.Insert(indx + 1, selected);
                    }
                }
                else
                {
                    MessageBox.Show("You can only move one item at a time. Please select only one item and try again.",
                        "Item Select", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _RightHotkey.Unregister(Key.Right, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            _LeftHotkey.Unregister(Key.Left, System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt);
            _RightHotkey.Unregister(Key.Right, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);
            _LeftHotkey.Unregister(Key.Left, System.Windows.Input.ModifierKeys.Shift | System.Windows.Input.ModifierKeys.Alt);

            if (_CheckBox1.Checked)
            {
                AlternateHotkeys();
                Properties.Settings.Default.AltHotKey = true;
            }
            else
            {
                NormalHotkeys();
                Properties.Settings.Default.AltHotKey = false;
            }

            Properties.Settings.Default.DesktopBackgroundFiles.Clear();
            foreach (ListViewItem item in _ListView1.Items)
            {
                Properties.Settings.Default.DesktopBackgroundFiles.Add(item.Tag.ToString());
            }

            Properties.Settings.Default.Save();
            _LabelStatus.Text = "Changes were successful.";
        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            _OpenFileDialog1.CheckFileExists = true;
            _OpenFileDialog1.CheckPathExists = true;
            _OpenFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            _OpenFileDialog1.FilterIndex = 0;
            _OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            _OpenFileDialog1.Multiselect = true;
            _OpenFileDialog1.Title = "Select desktop background image";
            if (_OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string file in _OpenFileDialog1.FileNames)
                {
                    _ListView1.Items.Add(NewListViewItem(file));
                }
            }
        }

        private static ListViewItem NewListViewItem(string file)
        {
            return new ListViewItem {
                Text = Path.GetFileName(file),
                ToolTipText = file,
                Name = Path.GetFileName(file),
                Tag = file
            };
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ListView1.SelectedItems.Count > 0)
                {
                    var selected = _ListView1.SelectedItems[0];
                    _ListView1.Items.Remove(selected);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
