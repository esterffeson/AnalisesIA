using System;
using System.Runtime.InteropServices;

public static class getControls
{
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int vKey);

    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int vKey);

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
    private const uint MOUSEEVENTF_LEFTUP = 0x04;
    private const uint MOUSEEVENTF_MOVE = 0x0001;
	

    public static bool IsCapsLockOn()
    {
        return Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock) || (GetKeyState(0x14) & 0xffff) != 0;
    }

    public static bool isLeftMouseButtonDown()
    {
        return (GetAsyncKeyState(0x01) & 0x8000) != 0;
    }

    public static void verticalMouseAtivo(int dx, int dy)
    {
        mouse_event(MOUSEEVENTF_MOVE, (uint)dx, (uint)dy, 0, UIntPtr.Zero); // Move o mouse
    }
}
