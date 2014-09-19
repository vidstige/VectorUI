namespace VectorUI.UI.Grfx
{
    public class Rectangle
    {
        private readonly Point _min;
        private readonly Point _max;

        public Rectangle(Point min, Point max)
        {
            _min = min;
            _max = max;
        }

        public Point TopLeft { get { return _min; } }
        public Point BottomRight { get { return _max; } }

        public Size Size { get { return new Size(_max.X - _min.X, _max.Y - _min.Y); } }

        public Rectangle Scale(Rectangle source, Rectangle target)
        {
            return new Rectangle(_min.Scale(source, target), _max.Scale(source, target));
        }

        public Rectangle MoveTo(Point absolute)
        {
            return new Rectangle(absolute, absolute.Plus(_max.Minus(_min)));
        }
    }
}
