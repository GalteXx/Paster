using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace Paster.HotKeyManagment
{
    [Flags]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8,
    }

    internal class HotKey
    {
        private readonly int iD;
        private readonly Key keyCode;
        private readonly KeyModifiers modifiers;
        private readonly Action hotKeyRaised;

        public HotKey(int _iD, KeyModifiers _modifiers, Key _keyCode, Action _hotKeyRaised)
        {
            iD = _iD;
            keyCode = _keyCode;
            modifiers = _modifiers;
            hotKeyRaised = _hotKeyRaised;
        }

        public int ID => iD;

        public Key KeyCode => keyCode;
        public uint VirtualKeyCode => (uint) KeyInterop.VirtualKeyFromKey(keyCode);

        public KeyModifiers Modifiers => modifiers;

        public void OnHotKeyRaised()
        {
            hotKeyRaised?.Invoke();
        }
    }
}
