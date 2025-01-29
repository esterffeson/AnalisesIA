using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MacroRainbowSix
{
    public class KeyboardShortcutForm : Form
    {
        private const int WM_KEYDOWN = 0x0100;

        public event KeyEventHandler KeyDownEvent;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    KeyEventArgs e = new KeyEventArgs((Keys)m.WParam.ToInt32());
                    KeyDownEvent?.Invoke(this, e);
                    if (e.Handled)
                    {
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
