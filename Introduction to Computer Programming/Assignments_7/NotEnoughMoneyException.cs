using System;

namespace Assignments_7
{
    internal class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string message) : base(message)
        {

        }
    }
}
