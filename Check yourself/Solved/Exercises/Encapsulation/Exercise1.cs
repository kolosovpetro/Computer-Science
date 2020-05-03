// TODO: Improve encapsulation of SensorFilter.

namespace Exercises.Encapsulation
{
	using System.Collections.Generic;
	using System.Linq;
	using Exercises.Dependencies;

	public class SensorFilter
    {
        private const int maxBufferSize = 10;
        private int index = 0;
        private Sensor sensor;
        private int value;
        private IList<int> buffer;

        public Sensor Sensor
        {
            get
            {
                return this.sensor;
            }

            set
            {
                this.sensor = value;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public IList<int> Buffer
        {
            get
            {
                return this.buffer;
            }

            set
            {
                this.buffer = value;
            }
        }

        public SensorFilter(Sensor sensor)
        {
            Sensor = sensor;
            Buffer = new List<int>(Enumerable.Repeat(0, maxBufferSize));
            Sensor.ValueChanged += OnValueChanged;
        }

        public void OnValueChanged(int value)
        {
            Buffer[index] = value;
            index = (index + 1) % maxBufferSize;

            Value = (int)Buffer.Average();
        }
    }
}
