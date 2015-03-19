using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace detector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport(@"imagepp-wrap.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int add(int x, int y);
        //private static extern int Image_LoadFromFile(String filename);
        public MainWindow()
        {
            InitializeComponent();
            func();
        }

        public void func()
        {
            try
            {
                //add(1, 2);
                ImageRGBByte image = new ImageRGBByte(@"E:\My\Desktop\LotteryScan\rgby.png");
                BitmapSource source = image.ToBitmapSource();
                image1.Width=source.Width;
                image1.Height=source.Height;
                image1.Source = source;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
