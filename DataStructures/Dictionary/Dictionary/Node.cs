namespace Dictionary.Dictionary
{
    internal class Node<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public void SetKey(TKey key)
        {
            Key = key;
        }

        public void SetValue(TValue value)
        {
            Value = value;
        }
    }
}
