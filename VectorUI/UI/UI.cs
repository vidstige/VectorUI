using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorUI.Fake.Hardware;

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
            while (_power.On)
            {
                var x = _mouse.X;
                var y = _mouse.Y;
                _screen.Screen[x + y * 320] = 255;

                _screen.VRetrace();
            }
        }
    }
}
