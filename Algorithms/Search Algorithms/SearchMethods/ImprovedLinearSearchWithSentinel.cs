using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    class ImprovedLinearSearchWithSentinel : AbstractSearch
    {
        public ImprovedLinearSearchWithSentinel(IEnumerable<int> newCollection, int newSearchValue) :
            base(newCollection, newSearchValue)
        { }

        public override bool DoSearch()
        {
            return ImpLinearSearchWithSentinel(this.Array, SearchValue);
        }

        private bool ImpLinearSearchWithSentinel(int[] Array, int SearchValue)
        {
            Array[Array.Length - 1] = SearchValue;
            int last = Array[Array.Length - 1];
            int step = 0;

            while (Array[step] != SearchValue)
                step++;

            if (step < Array.Length - 1 && last == SearchValue)
                return true;

            return false;
        }

    }
}
