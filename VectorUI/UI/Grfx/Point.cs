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

        public float X { get { return _x; } }
        public float Y { get { return _y; } }
    }
}
