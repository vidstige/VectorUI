﻿namespace VectorUI.UI.Grfx
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
    }
}