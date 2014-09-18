using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WriteableBitmap _screen;
        private readonly BitmapPalette _palette;

        public MainWindow()
        {
            InitializeComponent();
            _palette = BitmapPalettes.Halftone256;
            _screen = new WriteableBitmap(320, 200, 72, 72, PixelFormats.Indexed8, _palette);
        }
    }
}
