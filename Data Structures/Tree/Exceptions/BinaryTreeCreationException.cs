using System;

namespace Trees.Exceptions
{
    class BinaryTreeCreationException : Exception
    {
        public BinaryTreeCreationException()
        {

        }

        public BinaryTreeCreationException(string message) : base(message)
        {

        }
    }
}
