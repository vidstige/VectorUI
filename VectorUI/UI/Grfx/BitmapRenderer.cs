
namespace VectorUI.UI.Grfx
{
    public class BitmapRenderer
    {
        private readonly Bitmap _target;

        public BitmapRenderer(Bitmap target)
        {
            _target = target;
        }
        
        public void Draw(Rectangle rectangle, byte color)
        {
            for (int y = (int)rectangle.TopLeft.Y; y < (int)rectangle.BottomRight.Y; y++)
            {
                int start = (int)rectangle.TopLeft.X;
                int end = (int)rectangle.BottomRight.X;
                int begin = _target.Index(start, y);
                for (int x = start; x < end; x++)
                {
                    _target.Pixels[begin] = color;
                    begin++;
                }                
            }
        }
    }
}
