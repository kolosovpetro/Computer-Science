using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class SingleLeaf : ITreeRoot
    {
        int Weight;
        public SingleLeaf(int newWeight)
        {
            this.Weight = newWeight;
        }

        public void Add(ITreeRoot t)
        {
            throw new NotImplementedException();
        }

        public int GetWeight()
        {
            return this.Weight;
        }

        public int GetWholeWeight()
        {
            throw new NotImplementedException();
        }

        public void Remove(ITreeRoot t)
        {
            throw new NotImplementedException();
        }
    }
}
