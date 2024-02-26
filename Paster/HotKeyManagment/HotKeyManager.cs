using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;

namespace Paster.HotKeyManagment
{
    /// <summary>
    /// Manages hotkey regestring/unregestring etc.
    /// </summary>
    //God bless COM
    //It's quite an overkill, but I like the way it turned out to be
    internal class HotKeyManager
    {
        private const int windowsMessageHotkey = 0x0312;
        private readonly MainWindow window;

        private readonly List<HotKey> hotKeys;
        
        
        public IEnumerable<HotKey> HotKeys => hotKeys;

        public HotKeyManager(MainWindow _window)
        {
            window = _window;
            hotKeys = new();

            var hwnd = new WindowInteropHelper(window).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(WndProc);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);



        /// <summary>
        /// Registers a Hotkey with specified modifier and Key
        /// </summary>
        /// <param name="modifiers"></param>
        /// <param name="key"></param>
        /// <returns>Returns false if hotkey registration failed</returns>
        public bool RequestRegisterHotKey(KeyModifiers modifiers, Key key, Action action)
        {
            hotKeys.Add(new HotKey(hotKeys.Count > 0 ? hotKeys.Last().ID + 1 : 0, modifiers, key, action));
            return RegisterHotKey(new WindowInteropHelper(window).Handle, hotKeys.Last().ID, modifiers, hotKeys.Last().VirtualKeyCode);
        }

        /// <summary>
        /// Unregisters All hotkeys
        /// </summary>
        /// <returns>Retruns false if hotkey unregistration failed</returns>
        public bool RequestUnregisterHotKeys()
        {
            foreach (HotKey hotKey in hotKeys)
                if (!UnregisterHotKey(new WindowInteropHelper(window).Handle, hotKey.ID))
                    return false;
            return true;
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == windowsMessageHotkey)
            {
                var hk = hotKeys.Find(hk => hk.ID == wParam.ToInt32());
                if (hk != null)
                {
                    hk.OnHotKeyRaised();
                    handled = true;
                }
                else
                    handled = false;
            }
            return IntPtr.Zero;
        }
    }
}
