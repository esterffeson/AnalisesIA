using MacroRainbowSix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroMouse
{
    public class KeyboardShortcutManager
    {
        private TrackBar _trackBar;
        private Button _button;
        private Form _overlayForm;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int MOD_CTRL = 0x0002;
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID_UP = 1;
        private const int HOTKEY_ID_DOWN = 2;
        private const int HOTKEY_ID_ENTER = 3;

        public KeyboardShortcutManager(TrackBar trackBar, Button button, Form overlayForm)
        {
            _trackBar = trackBar ?? throw new ArgumentNullException(nameof(trackBar));
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _overlayForm = overlayForm ?? throw new ArgumentNullException(nameof(overlayForm));

            _overlayForm.Load += OverlayForm_Load;
            _overlayForm.FormClosing += OverlayForm_FormClosing;
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            // Configura o Form como um overlay
            _overlayForm.TopMost = true;
            //_overlayForm.FormBorderStyle = FormBorderStyle.None;
            _overlayForm.ShowInTaskbar = true;

            RegisterHotKey(_overlayForm.Handle, HOTKEY_ID_UP, MOD_CTRL, (int)Keys.Up);
            RegisterHotKey(_overlayForm.Handle, HOTKEY_ID_DOWN, MOD_CTRL, (int)Keys.Down);
            RegisterHotKey(_overlayForm.Handle, HOTKEY_ID_ENTER, MOD_CTRL, (int)Keys.Enter);
        }
        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            UnregisterHotKey(_overlayForm.Handle, HOTKEY_ID_UP);
            UnregisterHotKey(_overlayForm.Handle, HOTKEY_ID_DOWN);
            UnregisterHotKey(_overlayForm.Handle, HOTKEY_ID_ENTER);
        }

        public void HandleHotKey(Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case HOTKEY_ID_UP:
                        IncreaseTrackBarValue();
                        break;
                    case HOTKEY_ID_DOWN:
                        DecreaseTrackBarValue();
                        break;
                    case HOTKEY_ID_ENTER:
                        _button.PerformClick();
                        break;
                }
            }
        }

        private void IncreaseTrackBarValue()
        {
            if (_trackBar.Value < _trackBar.Maximum)
            {
                _trackBar.Value += 1;
            }
        }

        private void DecreaseTrackBarValue()
        {
            if (_trackBar.Value > _trackBar.Minimum)
            {
                _trackBar.Value -= 1;
            }
        }
    }
}
