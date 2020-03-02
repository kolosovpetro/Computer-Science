using System;
using System.Windows.Forms;

namespace CarSimulator
{
    class Engine
    {
        private const double Mile = 1.609344;         // per km
        private const double Gallon = 3.785411784;    // per ltr
        private readonly double Displacement;         
        private const double DefaultFuelTankCapasity = 50;
        private readonly double FuelTankCapasity;
        private double amountOfFuel;

        public Engine(double newDisplacement, double newAmountOfFuel)
        {
            this.Displacement = newDisplacement;
            this.amountOfFuel = newAmountOfFuel;
            this.FuelTankCapasity = DefaultFuelTankCapasity;
        }

        public Engine(double newDisplacement, double newAmountOfFuel, double newFuelTankCapacity) :
            this(newDisplacement, newAmountOfFuel)
        {
            this.FuelTankCapasity = newFuelTankCapacity;
        }


        public static double MPG2Lp100Km(double MPG) { return 100 * Gallon / (Mile * MPG); }

        public static double Lp100Km2MPG(double Lp100Km) { return 100 * Gallon / (Mile * Lp100Km); }

        public void Work(Label label)
        {
            this.amountOfFuel -= 4 * Displacement / 100;
            if (this.amountOfFuel <= 0)
            {

                var ErrorMessage = MessageBox.Show("I'm out of fuel! CLick OK to refuel, Cancel to quit",
                    "Out of fuel error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (ErrorMessage == DialogResult.OK) Refuel(this.FuelTankCapasity);
                if (ErrorMessage == DialogResult.Cancel) Environment.Exit(0);
            }

            label.Text = Convert.ToString(amountOfFuel.ToString());
            label.Update();

        }

        public void Refuel(double fuelAmount)
        {
            if (this.amountOfFuel + fuelAmount > this.FuelTankCapasity)
                throw new InvalidOperationException("Fuel on the shoes");
            this.amountOfFuel += fuelAmount;
        }
    }
}
