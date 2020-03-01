using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class MP4 : IFormat
    {
        public IFormat Convert(IFormat ToBeConverted)
        {
            return ToBeConverted;
        }
    }
}
