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

        public UI(ISVGAScreen screen, IMouse mouse, IPower power)
        {
            _screen = screen;
            _mouse = mouse;
            _power = power;
        }

        public void Run()
        {
            var screenBitmap = new Bitmap(_screen.Screen, 800, 600, 800);
            var screen = new BitmapRenderer(screenBitmap);
            var root = new Element();
            root.Add(new Box(screenBitmap.Area, 0xff404040));
            screen.Target = new Rectangle(new Point(10, 10), new Point(200, 100));
            while (_power.On)
            {
                //_screen.Screen[_mouse.X + _mouse.Y * 320] = 255;

                _screen.VRetrace();
                root.Render(screen);
            }
        }
    }
}
