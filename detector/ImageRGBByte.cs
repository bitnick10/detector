using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace detector
{
    class ImageRGBByte
    {
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UIntPtr ImageRGBByte_LoadFromFile(String s);
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 ImageRGBByte_Height(UIntPtr handle);
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 ImageRGBByte_Width(UIntPtr handle);
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UIntPtr ImageRGBByte_DataPtr(UIntPtr handle);
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 ImageRGBByte_GetPixel(UIntPtr handle, UInt32 x, UInt32 y);
        private UIntPtr handle;
        public UInt32 Width
        {
            get
            {
                return ImageRGBByte_Width(handle);
            }
        }
        public UInt32 Height
        {
            get
            {
                return ImageRGBByte_Height(handle);
            }
        }
        public UIntPtr DataPtr
        {
            get
            {
                return ImageRGBByte_DataPtr(handle);
            }
        }
        private Int32 GetPixel(UInt32 x, UInt32 y)
        {
            return ImageRGBByte_GetPixel(handle, x, y);
        }
        public ImageRGBByte(string filename)
        {
            handle = ImageRGBByte_LoadFromFile(filename);
        }
        public BitmapSource ToBitmapSource()
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                (int)Width,
                (int)Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (UInt32 y = 0; y < Height; y++)
            {
                for (UInt32 x = 0; x < Width; x++)
                {
                    int baseOffset = (int)(y * Width + x);
                    byte r = Marshal.ReadByte(DataPtr, baseOffset + 0);
                    byte g = Marshal.ReadByte(DataPtr, baseOffset + 1);
                    byte b = Marshal.ReadByte(DataPtr, baseOffset + 2);
                    Color color = Color.FromArgb(r, g, b);
                    //UInt32 a = 0xffff0000;
                    color = Color.FromArgb(GetPixel(x, y));
                    // color = Color.Red;
                    bitmap.SetPixel((int)x, (int)(Height - y - 1), color);
                }
            }
            BitmapSource source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                   bitmap.GetHbitmap(),
                                   IntPtr.Zero,
                                   Int32Rect.Empty,
                                   BitmapSizeOptions.FromEmptyOptions());
            return source;
        }
    }
}
