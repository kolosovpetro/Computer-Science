using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class SimpleLinearSearchMethod : AbstractSearch
    {
        public SimpleLinearSearchMethod(IEnumerable<int> collection, int searchValue) :
            base(collection, searchValue)
        { }

        public override bool DoSearch()
        {
            return SimpleLinearSearch(Array, SearchValue);
        }

        private bool SimpleLinearSearch(int[] array, int searchValue)
        {
            bool result = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchValue) result = true;
            }

            return result;
        }
    }
}
