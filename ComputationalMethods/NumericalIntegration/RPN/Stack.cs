namespace NumericalIntegration.RPN
{
    internal class Stack<T>
    {
        private int _count;
        private readonly T[] _elements;

        public Stack()
        {
            _count = 0;
            _elements = new T[10];
        }

        public void Push(T value)
        {
            _elements[_count] = value;
            _count++;
        }

        public T Peek()
        {
            return _elements[_count - 1];
        }

        public T Pop()
        {
            _count--;
            return _elements[_count];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}
