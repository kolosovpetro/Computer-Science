using System;

namespace Assignments_7
{
    internal class NegativeAmountException : Exception
    {
        public NegativeAmountException(string message) : base(message)
        {

        }
    }
}
