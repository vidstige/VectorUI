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
        private readonly IVGAScreen _screen;
        private readonly IMouse _mouse;
        private readonly IPower _power;

        public UI(IVGAScreen screen, IMouse mouse, IPower power)
        {
            _screen = screen;
            _mouse = mouse;
            _power = power;
        }

        public void Run()
        {
            var screen = new Bitmap(_screen.Screen, 320, 200, 320);
            var target = new BitmapRenderer(screen);
            var root = new Element();
            root.Add(new Box(screen.Area, 128));
            while (_power.On)
            {
                //_screen.Screen[_mouse.X + _mouse.Y * 320] = 255;

                _screen.VRetrace();
                root.Render(target);
            }
        }
    }
}
