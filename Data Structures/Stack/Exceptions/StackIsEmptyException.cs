using System;

namespace Stack.Exceptions
{
    class StackIsEmptyException : Exception
    {
        public StackIsEmptyException()
        {

        }

        public StackIsEmptyException(string message) : base(message)
        {

        }
    }
}
