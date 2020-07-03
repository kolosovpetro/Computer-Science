namespace QueueLibrary.Interfaces
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Returns number of elements in the queue
        /// </summary>
        int Count { get; }
        
        /// <summary>
        /// Returns capacity of the queue
        /// </summary>
        int Capacity { get; }
        
        /// <summary>
        /// Returns first element of the queue without removing it
        /// </summary>
        /// <returns></returns>
        T Peek();
        
        /// <summary>
        /// Checks whether queue is empty
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        
        /// <summary>
        /// Checks whether queue is full
        /// </summary>
        /// <returns></returns>
        bool IsFull();
        
        /// <summary>
        /// Removes all elements from the queue
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Checks whether queue contains specified element
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);
        
        /// <summary>
        /// Copies contents of the queue to the array from particular index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        void CopyTo(ref T[] array, int startIndex);
        
        /// <summary>
        /// Removes and returns first element from the queue
        /// </summary>
        /// <returns></returns>
        T Dequeue();
        
        /// <summary>
        /// Inserts element to the queue
        /// </summary>
        /// <param name="data"></param>
        void Enqueue(T data);
        
        /// <summary>
        /// Returns an array of queue's elements
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
    }
}