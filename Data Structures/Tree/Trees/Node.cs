using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Node<T>
    {
        public T Data { get; private set; }
        public int ParentIndex { get; private set; }
        public int Weight { get; private set; }

        public void SetParantIndex(int newIndex)
        {
            this.ParentIndex = newIndex;
        }

        public void SetData(T newData)
        {
            this.Data = newData;
        }

        public void SetWeight(int newWeight)
        {
            this.Weight = newWeight;
        }
    }
}
