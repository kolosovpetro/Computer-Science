using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class ImprovedLinearSearchSentinel : AbstractSearch
    {
        public ImprovedLinearSearchSentinel(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        { }

        public override bool DoSearch()
        {
            return ExecuteImprovedLinearSearchSentinel(Array, SearchValue);
        }

        private static bool ExecuteImprovedLinearSearchSentinel(IList<int> array, int searchValue)
        {
            array[array.Count - 1] = searchValue;
            var last = array[array.Count - 1];
            var step = 0;

            while (array[step] != searchValue)
                step++;

            return step < array.Count - 1 && last == searchValue;
        }

    }
}
