using System;

namespace Stack.Exceptions
{
    internal class StackIsEmptyException : Exception
    {
        public StackIsEmptyException(string message) : base(message)
        {

        }
    }
}
