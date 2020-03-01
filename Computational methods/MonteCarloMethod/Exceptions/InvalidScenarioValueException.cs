using System;

namespace MonteCarloMethod.Exceptions
{
    class InvalidScenarioValueException : Exception
    {
        public InvalidScenarioValueException()
        {

        }

        public InvalidScenarioValueException(string Message) : base(Message)
        {

        }
    }
}
