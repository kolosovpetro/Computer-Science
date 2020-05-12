using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class ImprovedLinearSearchWithSentinelMethod : AbstractSearch
    {
        public ImprovedLinearSearchWithSentinelMethod(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        { }

        public override bool DoSearch()
        {
            return ImprovedLinearSearchWithSentinel(Array, SearchValue);
        }

        private bool ImprovedLinearSearchWithSentinel(int[] array, int searchValue)
        {
            array[array.Length - 1] = searchValue;
            int last = array[array.Length - 1];
            int step = 0;

            while (array[step] != searchValue)
                step++;

            if (step < array.Length - 1 && last == searchValue)
                return true;

            return false;
        }

    }
}
