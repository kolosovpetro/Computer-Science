namespace Queue
{
    public interface IQueue<T>
    {
        bool IsEmpty();
        bool IsFull();
        T Peek();
        void Enqueue(T entry);
        void Dequeue();

    }
}
