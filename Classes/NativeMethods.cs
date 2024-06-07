using Avalonia;
using System;
using System.Runtime.InteropServices;

namespace rdp.Classes
{
    public class NativeMethods
    {
        [DllImport("User32.dll")]
        public extern static IntPtr GetDesktopWindow();
        //gdi32
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int cx, int cy);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

        [DllImport("gdi32.dll")]
        public static extern int GetObject(IntPtr h, int c, out IntPtr pv);
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr ho);


        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(
            IntPtr hdc,
            int x,
            int y,
            int cx,
            int cy,
            IntPtr hdcSrc,
            int x1,
            int x2,
            int rop
        );
    }
}
