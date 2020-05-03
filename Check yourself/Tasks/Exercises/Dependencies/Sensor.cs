namespace Exercises.Dependencies
{
	using System;

	public class Sensor
    {
        public event Action<int> ValueChanged;

        public void SetSensitivity(int sensitivity)
        {
            if(sensitivity == 0)
                throw new SensorFailedException();
        }
    }
}
