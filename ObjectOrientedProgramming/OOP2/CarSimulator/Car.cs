using System.Threading;
using System.Windows.Forms;

namespace CarSimulator
{
    internal class Car
    {
        private string _make;
        private string _model;
        private readonly Engine _engine;

        public Car(string newMake, string newModel, double newDisplacement, 
            double newAmountOfFuel, double newFuelTankCapacity) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel, newFuelTankCapacity))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, double newDisplacement, double newAmountOfFuel) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, Engine newEngine) // main constructor
        {
            _make = newMake;
            _model = newModel;
            _engine = newEngine;
        }

        public void Go(double howManyKm, PictureBox pb1, Label rangePassed, Label fuelAvailable)
        {
            int tempRange = (int)howManyKm;
            int t = 0;
            while (true)
            {
                _engine.Work(fuelAvailable);
                Thread.Sleep(100);
                t++;
                howManyKm--;
                if (howManyKm == 0) break;
                WinFormsAuxiliary.Animation(pb1);
                WinFormsAuxiliary.ChangeLabelText(rangePassed, $"{t} km out of {tempRange}");
            }

            WinFormsAuxiliary.ChangeLabelText(rangePassed, "Here I am");
        }

        public void Refuel(double fuelAmount)
        {
            _engine.Refuel(fuelAmount);
        }
    }
}
