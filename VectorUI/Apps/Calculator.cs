using VectorUI.UI.Elements;
using VectorUI.UI.Grfx;

namespace VectorUI.Apps
{
    class MainWnd: UI.Elements.Window
    {
        public MainWnd()
        {
            MoveTo(new Point(20, 20));
            Resize(new Size(100, 100));
            Add(new Box(new Rectangle(Point.Zero, new Point(100, 100)), 0xff00ee00));
        }
    }

    public class Calculator: VectorUI.UI.Elements.App
    {
        public Calculator()
        {
            Windows.Add(new MainWnd());
        }
    }
}
