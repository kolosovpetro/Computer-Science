namespace StackLibrary.Interfaces
{
    public interface IStack<T>
    {
        /// <summary>
        /// Returns capacity of the stack
        /// </summary>
        int Capacity { get; }
        
        /// <summary>
        /// Returns number of elements in the stack
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns top element without removing it
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Checks whether stack is empty
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Checks whether stack is full
        /// </summary>
        /// <returns></returns>
        bool IsFull();

        /// <summary>
        /// Clears all stack data
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks if stack contains specified element
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Copies contents of stack to array, starting from index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        void CopyTo(ref T[] array, int index);

        /// <summary>
        /// Removes and returns element from the top of the stack
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Inserts new element to the top of the stack
        /// </summary>
        /// <param name="data"></param>
        void Push(T data);

        /// <summary>
        /// Copies stack contents to the new array of type T
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
    }
}