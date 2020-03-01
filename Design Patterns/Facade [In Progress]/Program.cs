using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            MP4 mp4 = new MP4();
            OGG ogg = new OGG();
            IFormat Converted = mp4.Convert(ogg);
        }
    }
}
