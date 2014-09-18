using System.Collections.Generic;

namespace VectorUI.UI.Grfx
{
    public class Element
    {
        private readonly List<Element> _childs = new List<Element>();

        public void Add(Element element)
        {
            _childs.Add(element);
        }

        public virtual void Render(BitmapRenderer target)
        {
            foreach (var e in _childs) e.Render(target);
        }
    }
}
