using System;

namespace Stack.Exceptions
{
    class StackIsFullException : Exception
    {
        public StackIsFullException()
        {

        }

        public StackIsFullException(string message) : base(message)
        {

        }
    }
}
