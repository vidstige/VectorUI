using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VectorUI.Fake.Hardware;

namespace VectorUI
{
    class MainViewModel : ISVGAScreen, IPower
    {
        private const int _stride = 800 * 4;
        private readonly byte[] _screen = new byte[_stride * 600];
        private readonly WriteableBitmap _screenBitmap;
        private static readonly Int32Rect _rect = new Int32Rect(0, 0, 800, 600);

        private readonly AutoResetEvent _verticalRetrace = new AutoResetEvent(false);

        public MainViewModel()
        {
            On = true;
            _screenBitmap = new WriteableBitmap(_rect.Width, _rect.Height, 96, 96, PixelFormats.Bgra32, null);
        }

        public WriteableBitmap ScreenBitmap { get { return _screenBitmap; } }

        public void Draw()
        {
            _screenBitmap.WritePixels(_rect, _screen, _stride, 0);
            _verticalRetrace.Set();
        }

        public byte[] Screen { get { return _screen; } }

        public void VRetrace()
        {
            _verticalRetrace.WaitOne();
        }

        public void Quit()
        {
            On = false;
            _verticalRetrace.Set();
        }

        public byte[] Load(string path, out int width, out int height, out int stride)
        {
            var source = new BitmapImage(new Uri("pack://application:,,,/" + path));
            width = source.PixelWidth;
            height = source.PixelHeight;

            stride = 500;
            var bytes = new byte[stride * height];
            source.CopyPixels(bytes, stride, 0);

            return bytes;
        }

        public bool On
        {
            get;
            private set;
        }
    }
}
