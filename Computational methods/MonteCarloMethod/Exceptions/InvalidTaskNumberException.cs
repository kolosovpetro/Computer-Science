using System;

namespace MonteCarloMethod.Exceptions
{
    class InvalidTaskNumberException : Exception
    {
        public InvalidTaskNumberException()
        {

        }

        public InvalidTaskNumberException(string Message) : base(Message)
        {

        }
    }
}
