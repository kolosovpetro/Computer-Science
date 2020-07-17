using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class ImprovedLinearSearch : AbstractSearch
    {
        public ImprovedLinearSearch(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        {
        }

        public override bool DoSearch()
        {
            return ExecuteImprovedLinearSearch(Array, SearchValue);
        }

        private static bool ExecuteImprovedLinearSearch(IEnumerable<int> array, int searchValue)
        {
            foreach (var term in array)
                if (term == searchValue)
                    return true;

            return false;
        }
    }
}