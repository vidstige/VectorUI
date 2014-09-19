using System.Collections.Generic;
using VectorUI.UI.Grfx;

namespace VectorUI.UI.Elements
{
    public class Window
    {
        private readonly Element _root = new Element();
        private Rectangle _position;

        public Window()
        {
            _position = new Rectangle(Point.Zero, Point.Zero);
        }

        public Rectangle Position { get { return _position; } }

        public void MoveTo(Point absolute)
        {
            _position = _position.MoveTo(absolute);
        }
        public void Resize(Size size)
        {
            _position = new Rectangle(_position.TopLeft, _position.TopLeft.Plus(size));
        }

        public void Add(Element child)
        {
            _root.Add(child);
        }

        public void Render(BitmapRenderer target)
        {
            var old = target.Target;
            target.Target = old.MoveTo(_position.TopLeft);
            _root.Render(target);
            target.Target = old;
        }
    }
}
