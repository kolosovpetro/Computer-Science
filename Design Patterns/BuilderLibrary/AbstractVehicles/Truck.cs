namespace BuilderLibrary
{
    abstract class Truck : ITransprot
    {
        public ITransprot transport { get; private set; }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public string Engine { get; private set; }

        public double EngineVolume { get; private set; }

        public int WheelsNumber { get; private set; }

        public int CylindersNumber { get; private set; }

        public double FuelTankCapacity { get; private set; }

        public double MaxSpeed { get; private set; }

        protected Truck() { }

        public virtual void Reset() { }

        public void SetCylinderNumber(int newNumber)
        {
            CylindersNumber = newNumber;
        }

        public void SetEngine(string newEngine)
        {
            Engine = newEngine;
        }

        public void SetEngineVolume(double newVolume)
        {
            EngineVolume = newVolume;
        }

        public void SetManufacturer(string newManufacturer)
        {
            Manufacturer = newManufacturer;
        }

        public void SetMaxSpeed(double newSpeed)
        {
            MaxSpeed = newSpeed;
        }

        public void SetModel(string newModel)
        {
            Model = newModel;
        }

        public void SetTankCapacity(double newCapacity)
        {
            FuelTankCapacity = newCapacity;
        }

        public void SetWheelsNumber(int newNumber)
        {
            WheelsNumber = newNumber;
        }
    }
}
