namespace NumericalIntegration
{
    class Stack<T>
    {
        int count;
        T[] elements;

        public Stack()
        {
            count = 0;
            elements = new T[10];
        }

        public void Push(T value)
        {
            elements[count] = value;
            count++;
        }

        public T Peek()
        {
            return elements[count - 1];
        }

        public T Pop()
        {
            count--;
            return elements[count];
        }

        public bool IsEmpty()
        {
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
