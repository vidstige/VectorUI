using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorUI.Fake.Hardware
{
    public interface IVGAScreen
    {
        byte[] Screen { get; }
        void VRetrace();

        byte[] Load(string path, out int width, out int height, out int stride);

    }
}
