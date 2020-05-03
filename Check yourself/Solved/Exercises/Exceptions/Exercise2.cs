// TODO: InvalidOperationException is catched by SetSensitivity consumer but
// exception data is not forwarded. Fix it.

namespace Exercises.Exceptions
{
	using System;
	using System.Collections.Generic;
	using Exercises.Dependencies;

	public class E2
    {
        private readonly IEnumerable<Sensor> _sensors;
        private List<string> exceptionData;

        public E2(IEnumerable<Sensor> sensors)
        {
            _sensors = sensors;
            exceptionData = new List<string>();
        }

        public void SetSensitivy(int i)
        {
            try
            {
                foreach(var s in _sensors)
                    s.SetSensitivity(i);
            }
            catch (SensorFailedException ex)
            {
                exceptionData.Add(ex.Message);
                throw new InvalidOperationException("Could not set value");
            }
        }
    }
}
