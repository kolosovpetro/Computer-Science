namespace DoubleLinkedListLibrary.Interfaces
{
    public interface INode<T>
    {
        /// <summary>
        /// Returns linked list node belongs to
        /// </summary>
        ILinkedList<T> List { get; set; }
        
        /// <summary>
        /// Returns next node
        /// </summary>
        INode<T> Next { get; set; }
        
        /// <summary>
        /// Returns previous node
        /// </summary>
        INode<T> Previous { get; set; }
        
        /// <summary>
        /// Returns value of the node
        /// </summary>
        T Value { get; }
    }
}