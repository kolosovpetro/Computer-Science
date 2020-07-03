namespace DoubleLinkedListLibrary.Interfaces
{
    public interface ILinkedList<T>
    {
        /// <summary>
        /// Returns length of linked list
        /// </summary>
        int Count { get; }

        /// <summary>
        /// First node of linked list
        /// </summary>
        INode<T> First { get; }
        
        /// <summary>
        /// Last node of linked list
        /// </summary>
        INode<T> Last { get; }
        
        /// <summary>
        /// Checks whether linked list is empty
        /// </summary>
        bool IsEmpty { get; }
        
        /// <summary>
        /// Adds new element after particular node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        void AddAfter(INode<T> node, T data);
        
        /// <summary>
        /// Adds new element after particular node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        void AddBefore(INode<T> node, T data);
        
        /// <summary>
        /// Adds first node
        /// </summary>
        /// <param name="data"></param>
        void AddFirst(T data);
        
        /// <summary>
        /// Adds last node
        /// </summary>
        /// <param name="data"></param>
        void AddLast(T data);
        
        /// <summary>
        /// Deletes all nodes from the list
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Check whether linked list contains particular data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Copies linked list contents to array, starting from particular index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        void CopyTo(ref T[] array, int index);
        
        /// <summary>
        /// Returns node with value equals data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        INode<T> Find(T data);
        
        /// <summary>
        /// Finds the last node that contains the specified value.
        /// </summary>
        /// <returns></returns>
        INode<T> FindLast(T data);
        
        /// <summary>
        /// Removes node from linked list
        /// </summary>
        /// <param name="node"></param>
        void Remove(INode<T> node);
        
        /// <summary>
        /// Removes node which contains specified data
        /// </summary>
        /// <param name="data"></param>
        void Remove(T data);
        
        /// <summary>
        /// Removes last node from linked list
        /// </summary>
        void RemoveLast();
        
        /// <summary>
        /// Removes first item from linked list
        /// </summary>
        void RemoveFirst();
    }
}