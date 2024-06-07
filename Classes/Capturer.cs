using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace rdp.Classes
{
    public static class Capturer
    {

        static IntPtr hdcScreen;
        static IntPtr hdcMemDc;
        static IntPtr hbmScreen;

        static int width = 1920;
        static int heigth = 1080;

        public static Bitmap CaptureImage()
        {

            hdcScreen = NativeMethods.GetDC(NativeMethods.GetDesktopWindow());
            // hdcWindow = NativeMethods.GetDC(hdcScreen);

            hdcMemDc = NativeMethods.CreateCompatibleDC(hdcScreen);
            hbmScreen = NativeMethods.CreateCompatibleBitmap(hdcScreen, width, heigth);

            NativeMethods.SelectObject(hdcMemDc, hbmScreen);

            NativeMethods.BitBlt(
            hdcMemDc,
            0, 0,
            width, heigth, hdcScreen, 0, 0, 0x00CC0020);

            var r = Image.FromHbitmap(hbmScreen);

            Debug.WriteLine(r.GetType());

            return ConvertToAvaloniaBitmap(r);
            
        }

        private static Bitmap ConvertToAvaloniaBitmap(Image bitmap)
        {
            if (bitmap == null)
                return null;
            System.Drawing.Bitmap bitmapTmp = new System.Drawing.Bitmap(bitmap);
            var bitmapdata = bitmapTmp.LockBits(new Rectangle(0, 0, bitmapTmp.Width, bitmapTmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap bitmap1 = new Bitmap(Avalonia.Platform.PixelFormat.Bgra8888, Avalonia.Platform.AlphaFormat.Premul,
                bitmapdata.Scan0,
                new Avalonia.PixelSize(bitmapdata.Width, bitmapdata.Height),
                new Avalonia.Vector(96, 96),
                bitmapdata.Stride);
            bitmapTmp.UnlockBits(bitmapdata);
            bitmapTmp.Dispose();
            return bitmap1;
        }
    }

}
