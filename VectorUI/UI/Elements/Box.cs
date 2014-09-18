using VectorUI.UI.Grfx;

namespace VectorUI.UI.Elements
{
    class Box: Element
    {
        private readonly Rectangle _rectangle;
        private readonly uint _color;

        public Box(Rectangle rectangle, uint color)
        {
            _rectangle = rectangle;
            _color = color;
        }

        public override void Render(BitmapRenderer target)
        {
            target.Draw(_rectangle, _color);
        }
    }
}
