// TODO: E2 contains a bug. Fix it.
// Write could be called from the main thread.

namespace Exercises.Concurrency
{
	using System;
	using System.Threading;
	using Exercises.Dependencies;

	public class E2
    {
        private readonly Random _random;
        private readonly DesktopDisplay _display;
        private readonly Thread _thread;
        private readonly byte[] _buffer;

        private bool _done;

        public E2(DesktopDisplay display)
        {
            _random = new Random();
            _display = display;
            _thread = new Thread(Run);
            _buffer = new byte[10];
        }

        public void Start()
        {
            _done = false;
            _thread.Start();
        }
        public void Stop()
        {
            _done = true;
        }

        public void Write()
        {
            _display.Write(_buffer);
        }

        public void Run()
        {
            while (!_done)
            {
                _random.NextBytes(_buffer);
            }
        }
    }
}
