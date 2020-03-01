using System;

namespace MonteCarloMethod.Exceptions
{
    class IncorrectTaskFormat : Exception
    {
        public IncorrectTaskFormat()
        {

        }

        public IncorrectTaskFormat(string Message) : base(Message)
        {

        }
    }
}
