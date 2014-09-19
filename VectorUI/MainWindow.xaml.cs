using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VectorUI.Apps;
using VectorUI.Fake.Hardware;

namespace VectorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMouse
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly Thread _demoThread;
        private readonly MainViewModel _viewModel;
        private Point _mousePosition;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _demoThread = new Thread(RunDemo);
            _demoThread.IsBackground = false;
            _demoThread.Name = "Demo Runner";

            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += _timer_Tick;
        }

        private void RunDemo(object state)
        {
            var ui = new UI.UI(_viewModel, this, _viewModel);
            ui.Start(new Calculator());
            ui.Run();
        }

        private void _timer_Tick(object sender, System.EventArgs e)
        {
            _viewModel.Draw();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _demoThread.Start();
            _timer.Start();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            _viewModel.Quit();
            _timer.Stop();
        }

        public int X
        {
            get { return (int)_mousePosition.X; }
        }

        public int Y
        {
            get { return (int)_mousePosition.Y; }
        }

        private Point Scale(Point p, Size origin, Size target)
        {
            return new Point(p.X * target.Width / origin.Width, p.Y * target.Height / origin.Height);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            var element = (UIElement)sender;
            var point = e.GetPosition(element);
            _mousePosition = Scale(point, element.RenderSize, new Size(800, 600));
        }
    }
}
