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
        List<int> HeapBase { get; set; }

        /// <summary>
        /// Returns the size of the heap
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Checks whenever heap is empty
        /// </summary>
        bool IsEmpty { get; }
        
        /// <summary>
        /// Return root of the heap
        /// </summary>
        int Root { get; }
        
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
        
        /// <summary>
        /// Increases value at index and restores heap property
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void IncreaseKey(int index, int value);
        
        /// <summary>
        /// Decreases value at index and restores heap property
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        void DecreaseKey(int index, int value);
    }
}