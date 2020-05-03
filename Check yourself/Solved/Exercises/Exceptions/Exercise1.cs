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

            try
            {
                _valueProvider = valueProvider;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Object initiazliation has been failed.");
            }
        }

        public async Task<int> ReadAndDivide(int i)
        {
            // since that _valueProvider is readonly, it follows that we have to work with exception over constructor
            return await _valueProvider.Read() / i;
        }
    }
}
