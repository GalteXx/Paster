using Paster.HotKeyManagment;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Forms = System.Windows.Forms;

namespace Paster
{
    //Sorry, potential recruiters, no MVVM here.
    public partial class MainWindow : Window
    {
        private HotKeyManager hotkeyManager;   
        public MainWindow()
        {
            InitializeComponent();
            

            Forms.NotifyIcon trayIcon = new()
            {
                Icon = new($"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/Resources/trayIcon.ico"),
                Visible = true
            };
            trayIcon.DoubleClick +=
                delegate (object? sender, EventArgs args)
                {
                    Show();
                };
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            hotkeyManager = new(this);
            hotkeyManager.RequestRegisterHotKey(KeyModifiers.Control | KeyModifiers.Shift, Key.A, HotKeyRaised);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            hotkeyManager.RequestUnregisterHotKeys();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            //base.OnStateChanged(e);
            Hide();
        }

        private void HotKeyRaised()
        {
            MessageBox.Show("Hotkey Raised!!!");
        }
    }
}