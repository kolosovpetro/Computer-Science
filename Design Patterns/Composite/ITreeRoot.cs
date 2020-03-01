using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    interface ITreeRoot
    {
        int GetWeight();
        int GetWholeWeight();
        void Add(ITreeRoot t);
        void Remove(ITreeRoot t);
    }
}
