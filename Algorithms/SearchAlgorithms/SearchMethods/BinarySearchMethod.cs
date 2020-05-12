using System.Collections.Generic;

namespace SearchAlgorithms.SearchMethods
{
    internal class BinarySearchMethod : AbstractSearch
    {
        public BinarySearchMethod(IEnumerable<int> collection, int searchValue) : 
            base(collection, searchValue)
        { }

        public override bool DoSearch()
        {
            return BinarySearch(Array, SearchValue);
        }

        private bool BinarySearch(int[] array, int searchValue)
        {
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (searchValue == array[mid]) return true;

                if (searchValue < array[mid]) max = mid - 1;

                else min = mid + 1;
            }

            return false;
        }
    }
}
