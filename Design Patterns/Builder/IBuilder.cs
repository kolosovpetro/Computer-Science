using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    interface IBuilder
    {
        void Reset();  // initializes complete object of IBuilder (in our Example is House)
        void BuildHouseWalls(int NumberOfWalls);
        void BuildHouseRoof(int RoofSquare);
        void BuildHouseWindows(int WindowsNumber);
        void InstallHouseDoors(int DoorsNumber);
        void ConnectWater(bool IsConnected = true);
        void ConnectElectricity(bool IsConnected = true);
        void ConnectInternet(bool IsConnected = true);
    }
}
