
using System;
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
        
        public unsafe void Draw(Bitmap bitmap, Point p)
        {
            fixed (byte* source = bitmap.Pixels)
            fixed (byte* target = _bitmap.Pixels)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var source_row = (uint*)(source + bitmap.Index(0, y));
                    var target_row = (uint*)(target + _bitmap.Index((int)p.X, (int)(p.Y + y)));
                    int c = 0;
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        target_row[c] = source_row[c];
                        c++;
                    }
                }
            }
        }

        public unsafe void Draw(Rectangle rectangle, uint color)
        {
            var r = rectangle.Scale(Source, Target);
            fixed (byte* raw = _bitmap.Pixels)
            {
                for (int y = (int)r.TopLeft.Y; y < (int)r.BottomRight.Y; y++)
                {
                    int start = (int)r.TopLeft.X;
                    int end = (int)r.BottomRight.X;
                    int begin = _bitmap.Index(start, y);
                    var pixels = (uint*)(raw + begin);
                    int cnt = 0;
                    for (int x = start; x < end; x++)
                    {
                        pixels[cnt++] = color;
                    }
                }
            }
        }
    }
}
