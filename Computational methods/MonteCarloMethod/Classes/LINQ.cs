using System.Collections.Generic;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    internal class Linq<T>
    {
        public IEnumerable<T> NumbersFromCollection(IEnumerable<T> collection)
        {
            var Numbers = collection.Where(s => double.TryParse(s.ToString(), out _));
            return Numbers;
        }
    }
}
