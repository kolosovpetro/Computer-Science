// TODO: DisplayMessageQueue contains a bug. Fix it.
// Add and Reset could come from the main thread.

namespace Exercises.Concurrency
{
	using System.Collections.Generic;
	using System.Timers;
	using Exercises.Dependencies;

	public class DisplayMessageQueue
    {
        private readonly Display _display;
        private readonly Timer _timer;
        private readonly Queue<string> _messages;

        public DisplayMessageQueue(Display display)
        {
            _display = display;
            _timer = new Timer(1000);
            _messages = new Queue<string>();

            _timer.AutoReset = true;
            _timer.Elapsed += (o, a) => OnElapsed();
            _timer.Start();
        }

        public void Add(string message)
        {
            _messages.Enqueue(message);
        }
        public void Reset()
        {
            _messages.Clear();
        }

        private void OnElapsed()
        {
            if (_messages.Count == 0)
                return;

            var message = _messages.Dequeue();
            _display.ThreadSafePrint(message);
        }
    }
}
