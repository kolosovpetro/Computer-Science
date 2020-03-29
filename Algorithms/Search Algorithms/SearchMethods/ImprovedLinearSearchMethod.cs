using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class ImprovedLinearSearchMethod : AbstractSearch
    {
        public ImprovedLinearSearchMethod(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        { }

        public override bool DoSearch()
        {
            return ImprovedLinearSearch(Array, SearchValue);
        }

        private bool ImprovedLinearSearch(int[] array, int searchValue)
        {
            foreach (var term in array)
            {
                if (term == searchValue) return true;
            }

            return false;
        }
    }
}
