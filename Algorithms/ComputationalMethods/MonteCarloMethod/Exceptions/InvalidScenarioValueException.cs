using System;

namespace MonteCarloMethod.Exceptions
{
    internal class InvalidScenarioValueException : Exception
    {
        public InvalidScenarioValueException(string message) : base(message)
        {

        }
    }
}
