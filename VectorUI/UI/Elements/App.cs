using System.Collections;
using System.Collections.Generic;

namespace VectorUI.UI.Elements
{
    public class App
    {
        private readonly List<Window> _windows = new List<Window>();

        public List<Window> Windows
        {
            get { return _windows; }
        }
    }
}
