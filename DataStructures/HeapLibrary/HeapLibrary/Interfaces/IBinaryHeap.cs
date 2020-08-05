using System.Collections.Generic;

namespace HeapLibrary.Interfaces
{
    /// <summary>
    /// Array based max binary heap interface
    /// </summary>
    public interface IBinaryHeap
    {
        /// <summary>
        /// Base of the heap
        /// </summary>
        List<int> HeapBase { get; }

        /// <summary>
        /// Returns the size of the heap
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Removes root element and restores heap property
        /// </summary>
        /// <returns></returns>
        int Pop();
        
        /// <summary>
        /// Returns root element without removing from heap
        /// </summary>
        /// <returns></returns>
        int Peek();

        /// <summary>
        /// Pushes new value to the end of heap
        /// </summary>
        /// <param name="value">Integer, value to be pushed</param>
        void Push(int value);

        /// <summary>
        /// Pushes range of integers to the heap
        /// </summary>
        /// <param name="values">Array of integers to be pushed</param>
        void PushRange(params int[] values);
    }
}