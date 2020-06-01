namespace Queue.Interfaces
{
    public interface IQueue<T>
    {
        int Count { get; }
        int Capacity { get; }
        bool IsEmpty();
        bool IsFull();
        T Peek();
        void Enqueue(T entry);
        void Dequeue();

    }
}
