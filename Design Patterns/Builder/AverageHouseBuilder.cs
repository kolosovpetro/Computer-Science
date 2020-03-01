using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class AverageHouseBuilder : IBuilder
    {
        protected int RoofSquare;
        protected int WallsNumber;
        protected int WindowsNumber;
        protected bool IsElectricityConnected;
        protected bool IsInternetConnected;
        protected bool IsWaterConnected;
        protected int DoorsNumber;
        protected AverageHouse result;

        public void BuildHouseRoof(int RoofSquare)
        {
            this.RoofSquare = RoofSquare;
        }

        public void BuildHouseWalls(int NumberOfWalls)
        {
            this.WallsNumber = NumberOfWalls;
        }

        public void BuildHouseWindows(int WindowsNumber)
        {
            result.WindowsNumber = WindowsNumber;
        }

        public void ConnectElectricity(bool IsConnected = true)
        {
            result.IsElectricityConnected = IsConnected;
        }

        public void ConnectInternet(bool IsConnected = true)
        {
            result.IsInternetConnected = IsConnected;
        }

        public void ConnectWater(bool IsConnected = true)
        {
            result.IsWaterConnected = IsConnected;
        }

        public void InstallHouseDoors(int DoorsNumber)
        {
            result.DoorsNumber = DoorsNumber;
        }

        public void Reset()
        {
            this.result = new AverageHouse();
        }
        public AverageHouse GetResult()
        {
            return result;
        }
    }
}
