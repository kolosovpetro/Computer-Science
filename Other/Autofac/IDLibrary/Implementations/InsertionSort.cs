using System.Collections.Generic;
using System.Linq;
using IDLibrary.Interfaces;

namespace IDLibrary.Implementations
{
    public class InsertionSort : ISortMethod
    {
        public void Sort(IEnumerable<int> collection)
        {
            var array = collection as int[] ?? collection.ToArray();

            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(array, j);
                    j--;
                }
            }
        }

        private static void Swap(int[] array, int j)
        {
            var temp = array[j];
            array[j] = array[j - 1];
            array[j - 1] = temp;
        }
    }
}