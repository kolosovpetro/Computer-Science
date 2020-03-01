namespace Dictionary
{
    class Node<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        public Node(TKey newTKey, TValue newTValue)
        {
            Key = newTKey;
            Value = newTValue;
        }
        public void SetKey(TKey newKey)
        {
            Key = newKey;
        }

        public void SetValue(TValue newValue)
        {
            Value = newValue;
        }
    }
}
