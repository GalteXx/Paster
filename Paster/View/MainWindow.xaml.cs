﻿using Paster.HotKeyManagment;
using Paster.ViewModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Forms = System.Windows.Forms;

namespace Paster.View
{
    //Nevermind...
    public partial class MainWindow : Window
    {
        private HotKeyManager hotkeyManager;   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            Forms.NotifyIcon trayIcon = new()
            {
                Icon = new($"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/Resources/trayIcon.ico"),
                Visible = true
            };
            trayIcon.DoubleClick += delegate (object? sender, EventArgs args)
                {
                    Maximize();
                };
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            hotkeyManager = new(new WindowInteropHelper(this).Handle);
            hotkeyManager.RequestRegisterHotKey(KeyModifiers.Control | KeyModifiers.Shift, Key.A, Maximize);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (hotkeyManager.RequestUnregisterHotKeys())
                base.OnClosing(e);
            else
                MessageBox.Show("Failed to unregister Hotkey... Closing anyway :D");
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            base.OnStateChanged(e);
        }

        private void Maximize()
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}