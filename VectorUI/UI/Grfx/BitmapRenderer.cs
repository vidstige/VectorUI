
namespace VectorUI.UI.Grfx
{
    public class BitmapRenderer
    {
        private readonly Bitmap _bitmap;
        private Rectangle _target;

        public BitmapRenderer(Bitmap target)
        {
            _bitmap = target;
            _target = Source;
        }

        public Rectangle Source
        {
            get { return new Rectangle(Point.Zero, new Point(_bitmap.Width, _bitmap.Height)); }
        }

        public Rectangle Target
        {
            get { return _target; }
            set { _target = value; }
        }
        
        public void Draw(Rectangle rectangle, byte color)
        {
            var r = rectangle.Scale(Source, Target);

            var pixels = _bitmap.Pixels;
            for (int y = (int)r.TopLeft.Y; y < (int)r.BottomRight.Y; y++)
            {
                int start = (int)r.TopLeft.X;
                int end = (int)r.BottomRight.X;
                int begin = _bitmap.Index(start, y);
                for (int x = start; x < end; x++)
                {
                    pixels[begin++] = color;
                }                
            }
        }
    }
}
