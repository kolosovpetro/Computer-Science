using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class SimpleLinearSearch : AbstractSearch
    {
        public SimpleLinearSearch(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        {
        }

        public override bool DoSearch()
        {
            return ExecuteSimpleLinearSearch(Array, SearchValue);
        }

        private static bool ExecuteSimpleLinearSearch(IEnumerable<int> array, int searchValue)
        {
            var result = false;

            foreach (var term in array)
                if (term == searchValue)
                    result = true;

            return result;
        }
    }
}