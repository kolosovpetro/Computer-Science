// TODO: Improve encapsulation of SensorFilter.

namespace Exercises.Encapsulation
{
	using System.Collections.Generic;
	using System.Linq;
	using Exercises.Dependencies;

	public class SensorFilter
    {
        private const int MaxBufferSize = 10;

        private int _index = 0;

        public Sensor Sensor { get; private set; }
        public int Value { get; private set; }
        public IList<int> Buffer { get; private set; }

        public SensorFilter(Sensor sensor)
        {
            Sensor = sensor;
            Buffer = new List<int>(Enumerable.Repeat(0, MaxBufferSize));
            Sensor.ValueChanged += OnValueChanged;
        }

        public void OnValueChanged(int value)
        {
            Buffer[_index] = value;
            _index = (_index + 1) % MaxBufferSize;

            Value = (int)Buffer.Average();
        }
    }
}
