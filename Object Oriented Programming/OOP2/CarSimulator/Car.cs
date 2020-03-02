using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace CarSimulator
{
    class Car
    {
        private string make;
        private string model;
        private Engine engine;

        public Car(string newMake, string newModel, double newDisplacement, 
            double newAmountOfFuel, double newFuelTankCapacity) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel, newFuelTankCapacity))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, double newDisplacement, double newAmountOfFuel) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, Engine newEngine) // main constructor
        {
            this.make = newMake;
            this.model = newModel;
            this.engine = newEngine;
        }

        public void Go(double howManyKm, PictureBox pb1, Label RangePassed, Label FuelAvailable)
        {
            int tempRange = (int)howManyKm;
            int t = 0;
            while (true)
            {
                this.engine.Work(FuelAvailable);
                Thread.Sleep(100);
                t++;
                howManyKm--;
                if (howManyKm == 0) break;
                WinFormsAuxiliry.Animation(pb1);
                WinFormsAuxiliry.ChangeLabelText(RangePassed, $"{t} km out of {tempRange}");
            }

            WinFormsAuxiliry.ChangeLabelText(RangePassed, "Here I am");
        }

        public void Refuel(double fuelAmount)
        {
            this.engine.Refuel(fuelAmount);
        }
    }
}
