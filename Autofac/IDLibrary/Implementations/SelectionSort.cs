using System.Collections.Generic;
using System.Linq;
using IDLibrary.Interfaces;

namespace IDLibrary.Implementations
{
    public class SelectionSort : ISortMethod
    {
        public void Sort(IEnumerable<int> collection)
        {
            var arr = collection as int[] ?? collection.ToArray();

            for (var i = 0; i < arr.Length; i++)
            {
                var minIndex = i;

                for (var k = i + 1; k < arr.Length; k++)
                    if (arr[minIndex] > arr[k])
                        minIndex = k;

                Swap(arr, i, minIndex);
            }
        }

        private static void Swap(IList<int> arr, int i, int minIndex)
        {
            var temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}