using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    class ImprovedLimearSearch : AbstractSearch
    {
        public ImprovedLimearSearch(IEnumerable<int> newCollection, int newSearchValue) :
            base(newCollection, newSearchValue)
        { }

        public override bool DoSearch()
        {
            return ImpLinearSearch(Array, SearchValue);
        }

        private bool ImpLinearSearch(int[] Array, int SearchValue)
        {
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] == SearchValue)
                    return true;

            return false;
        }
    }
}
