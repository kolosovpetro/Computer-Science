// TODO: E3 contains a bug. Fix it.

namespace Exercises.Concurrency
{
	using System.IO;
	using System.Threading.Tasks;
	using Exercises.Dependencies;

	public class E3
    {
        private readonly ValueProvider _valueProvider;

        public E3(ValueProvider valueProvider)
        {
            _valueProvider = valueProvider;
        }

        public async Task Run()
        {
            using (var s = new FileStream("./dump.txt", FileMode.OpenOrCreate))
            {
                var buffer = new byte[] {0, 1, 0, 1, 0, 1};
                s.Write(buffer, 0, buffer.Length);

                var value = await _valueProvider.Read();
                buffer[0] = (byte)(value % 255);
                s.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
