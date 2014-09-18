namespace VectorUI.UI.Grfx
{
    public class Size
    {
        private readonly float _width;
        private readonly float _height;

        public Size(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
    }
}
