using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class BigHouse : BigHouseBuilder
    {
        public int ShowRoofSquare
        {
            get
            {
                return this.RoofSquare;
            }
        }
        public int ShowDoorsNumber
        {
            get
            {
                return this.DoorsNumber;
            }
        }
        public int ShowWallsNumber
        {
            get
            {
                return this.WallsNumber;
            }
        }
        public int ShowWindowsNumber
        {
            get
            {
                return this.WindowsNumber;
            }
        }
        public bool CheckElectricity
        {
            get
            {
                return this.IsElectricityConnected;
            }
        }
        public bool CheckWater
        {
            get
            {
                return this.IsWaterConnected;
            }
        }
        public bool CheckInternet
        {
            get
            {
                return this.IsInternetConnected;
            }
        }
    }
}
