using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorUI.Fake.Hardware;
using VectorUI.UI.Elements;
using VectorUI.UI.Grfx;

namespace VectorUI.UI
{
    public class UI
    {
        private readonly ISVGAScreen _screen;
        private readonly IMouse _mouse;
        private readonly IPower _power;
        private readonly List<Elements.App> _apps = new List<Elements.App>();
        private Bitmap _cursor;

        public UI(ISVGAScreen screen, IMouse mouse, IPower power)
        {
            _screen = screen;
            _mouse = mouse;
            _power = power;
        }

        private Bitmap Cursor
        {
            get
            {
                if (_cursor == null)
                {
                    _cursor = new Bitmap(16, 16, 16*4);
                    var tmp = new BitmapRenderer(_cursor);
                    tmp.Draw(new Rectangle(new Point(0, 0), new Point(16, 16)), 0xffff0000);
                }
                return _cursor;
            }
        }

        public void Start(Elements.App app)
        {
            _apps.Add(app);
        }

        public void Run()
        {
            var screenBitmap = new Bitmap(_screen.Screen, 800, 600, 800*4);
            var desktop = new BitmapRenderer(screenBitmap);
            var screen = new BitmapRenderer(screenBitmap);
            var root = new Element();
            root.Add(new Box(screenBitmap.Area, 0xff404040));
            
            while (_power.On)
            {
                screen.Draw(Cursor, new Point(_mouse.X, _mouse.Y));
                //_screen.Screen[_mouse.X + _mouse.Y * 320] = 255;

                _screen.VRetrace();
                root.Render(desktop);

                foreach (Elements.App app in _apps)
                {
                    foreach (Window window in app.Windows)
                    {
                        window.Render(desktop);
                    }
                }
            }
        }
    }
}
