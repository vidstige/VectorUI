namespace VectorUI.UI.Grfx
{
    public class Bitmap
    {
        private readonly byte[] _pixels;
        private readonly int _width;
        private readonly int _height;
        private readonly int _stride;

        public Bitmap(int width, int height, int stride)
        {
            _width = width;
            _height = height;
            _stride = stride;
            _pixels = new byte[height * stride];
        }
        public Bitmap(byte[] pixels, int width, int height, int stride)
        {
            _width = width;
            _height = height;
            _stride = stride;
            _pixels = pixels;
        }

        public byte[] Pixels { get { return _pixels; } }
        public int Index(int x, int y)
        {
            return x + y * _stride;
        }

        public Rectangle Area { get { return new Rectangle(Point.Zero, new Point(_width, _height)); } }
    }
}
