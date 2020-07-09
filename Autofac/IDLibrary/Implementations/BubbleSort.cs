using System.Collections.Generic;
using System.Linq;
using IDLibrary.Interfaces;

namespace IDLibrary.Implementations
{
    public class BubbleSort : ISortMethod
    {
        public void Sort(IEnumerable<int> collection)
        {
            var array = collection as int[] ?? collection.ToArray();
            var swapped = true;
            while (swapped)
            {
                swapped = false;

                for (var i = 1; i < array.Length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        Swap(array, i);
                        swapped = true;
                    }
                }
            }
        }

        private static void Swap(int[] array, int i)
        {
            var temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }
}