using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class CompoudLeaf : ITreeRoot
    {
        int Weight;
        List<ITreeRoot> Children = new List<ITreeRoot>();
        public CompoudLeaf(int newWeight)
        {
            this.Weight = newWeight;
        }
        public void Add(ITreeRoot Child)
        {
            Children.Add(Child);
        }
        public void Remove(ITreeRoot Child)
        {
            Children.Remove(Child);
        }
        public List<ITreeRoot> GetChildern()
        {
            return Children;
        }
        public int GetWeight()
        {
            return this.Weight;
        }
        public int GetWholeWeight()
        {
            int Weight = this.Weight;
            foreach (ITreeRoot Child in Children)
            {
                Weight += Child.GetWeight();
            }
            return Weight;
        }
    }
}
