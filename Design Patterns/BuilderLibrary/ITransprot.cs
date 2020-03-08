namespace BuilderLibrary
{
    /// <summary>
    /// Common interface for all vehicles. Furthur to be implemented by abstract vihicles types.
    /// </summary>
    interface ITransprot
    {
        ITransprot transport { get; }
        string Manufacturer { get; }
        string Model { get; }
        string Engine { get; }
        double EngineVolume { get; }
        int WheelsNumber { get; }
        int CylindersNumber { get; }
        double FuelTankCapacity { get; }
        double MaxSpeed { get; }
        void Reset();
        void SetManufacturer(string newManufacturer);
        void SetModel(string newModel);
        void SetEngine(string newEngine);
        void SetEngineVolume(double newVolume);
        void SetWheelsNumber(int newNumber);
        void SetCylinderNumber(int newNumber);
        void SetTankCapacity(double newCapacity);
        void SetMaxSpeed(double newSpeed);
    }
}
