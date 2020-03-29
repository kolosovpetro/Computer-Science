namespace Trees.Trees
{
    internal class Node<T>
    {
        public T Data { get; private set; }
        public int ParentIndex { get; private set; }
        public int Weight { get; private set; }

        public void SetParentIndex(int index)
        {
            ParentIndex = index;
        }

        public void SetData(T data)
        {
            Data = data;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }
    }
}
