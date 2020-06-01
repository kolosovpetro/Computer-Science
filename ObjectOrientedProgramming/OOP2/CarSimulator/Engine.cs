using System;
using System.Globalization;
using System.Windows.Forms;

namespace CarSimulator
{
    internal class Engine
    {
        private const double Mile = 1.609344;         // per km
        private const double Gallon = 3.785411784;    // per ltr
        private readonly double _displacement;         
        private const double DefaultFuelTankCapacity = 50;
        private readonly double _fuelTankCapacity;
        private double _amountOfFuel;

        public Engine(double newDisplacement, double newAmountOfFuel)
        {
            _displacement = newDisplacement;
            _amountOfFuel = newAmountOfFuel;
            _fuelTankCapacity = DefaultFuelTankCapacity;
        }

        public Engine(double newDisplacement, double newAmountOfFuel, double newFuelTankCapacity) :
            this(newDisplacement, newAmountOfFuel)
        {
            _fuelTankCapacity = newFuelTankCapacity;
        }


        public static double Mpg2Lp100Km(double mpg) => 100 * Gallon / (Mile * mpg);

        public static double Lp100Km2Mpg(double lp100Km) => 100 * Gallon / (Mile * lp100Km);

        public void Work(Label label)
        {
            _amountOfFuel -= 4 * _displacement / 100;
            if (_amountOfFuel <= 0)
            {

                var errorMessage = MessageBox.Show("I'm out of fuel! CLick OK to refuel, Cancel to quit",
                    "Out of fuel error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                
                if (errorMessage == DialogResult.OK) 
                    Refuel(_fuelTankCapacity);
                
                if (errorMessage == DialogResult.Cancel) 
                    Environment.Exit(0);
            }

            label.Text = Convert.ToString(_amountOfFuel.ToString(CultureInfo.InvariantCulture));
            label.Update();

        }

        public void Refuel(double fuelAmount)
        {
            if (_amountOfFuel + fuelAmount > _fuelTankCapacity)
                throw new InvalidOperationException("Fuel on the shoes");
            _amountOfFuel += fuelAmount;
        }
    }
}
