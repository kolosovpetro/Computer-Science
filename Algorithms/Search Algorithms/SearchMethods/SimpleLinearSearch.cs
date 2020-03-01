using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    class SimpleLinearSearch : AbstractSearch
    {
        public SimpleLinearSearch(IEnumerable<int> newCollection, int newSearchValue) :
            base(newCollection, newSearchValue)
        { }

        public override bool DoSearch()
        {
            return SimpLinearSearch(Array, SearchValue);
        }

        private bool SimpLinearSearch(int[] Array, int SearchValue)
        {
            bool result = false;
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] == SearchValue)
                    result = true;

            return result;
        }
    }
}
