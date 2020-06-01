using System;

namespace MonteCarloMethod.Exceptions
{
    internal class InvalidTaskCaseException : Exception
    {
        public InvalidTaskCaseException(string message) : base(message)
        {

        }
    }
}
