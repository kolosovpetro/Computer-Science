using System;

namespace MonteCarloMethod.Exceptions
{
    class InvalidTaskCaseException : Exception
    {
        public InvalidTaskCaseException()
        {

        }

        public InvalidTaskCaseException(string Message) : base(Message)
        {

        }
    }
}
