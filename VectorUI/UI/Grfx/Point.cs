namespace VectorUI.UI.Grfx
{
    public class Point
    {
        private readonly float _x;
        private readonly float _y;

        public static readonly Point Zero = new Point(0, 0);

        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Point Minus(Point p)
        {
            return new Point(_x - p._x, _y - p._y);
        }

        public Point Plus(Point p)
        {
            return new Point(_x + p._x, _y + p._y);
        }

        public Point Plus(Size size)
        {
            return new Point(_x + size.Width, _y + size.Height);
        }

        public Point Multiply(Size s)
        {
            return new Point(_x * s.Width, _y * s.Height);
        }

        public Point Divide(Size s)
        {
            return new Point(_x / s.Width, _y / s.Height);
        }

        public Point Scale(Rectangle source, Rectangle target)
        {
            return target.TopLeft.Minus(source.TopLeft).Plus(this.Multiply(target.Size).Divide(source.Size));
        }

        public float X { get { return _x; } }
        public float Y { get { return _y; } }

    }
}
