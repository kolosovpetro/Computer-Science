using System;

namespace MonteCarloMethod.Exceptions
{
    internal class IncorrectTaskFormat : Exception
    {
        public IncorrectTaskFormat(string message) : base(message)
        {

        }
    }
}
