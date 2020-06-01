namespace Heaps.Interfaces
{
    internal interface IHeap
    {
        int Root();
        int GetNode(int index);
        int GetParentOf(int Child);
        int GetLeftChildOf(int Parent);
        int GetRightChildOf(int Parent);
        void SiftUp(int index);
        int Pop();
        void SiftDown(int index);
        int GetLeftChildIndex(int Parent);
        int GetRightChildIndex(int Parent);

    }
}
