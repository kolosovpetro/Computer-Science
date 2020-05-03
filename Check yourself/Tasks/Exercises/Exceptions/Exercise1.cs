// TODO: Wrong usage of exceptions. We want to preserve the callstack.

namespace Exercises.Exceptions
{
	using System;
	using System.Threading.Tasks;
	using Exercises.Dependencies;

	public class E1
    {
        private readonly Logger _logger;
        private readonly ValueProvider _valueProvider;

        public E1(Logger logger, ValueProvider valueProvider)
        {
            _logger = logger;
            _valueProvider = valueProvider;
        }

        public async Task<int> ReadAndDivide(int i)
        {
            try
            {
                return await _valueProvider.Read() / i;
            }
            catch (InvalidOperationException exception)
            {
                _logger.Log(exception.Message);
                throw exception;
            }
        }
    }
}
