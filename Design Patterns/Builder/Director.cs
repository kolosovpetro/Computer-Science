using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Director
    {
        public void BuildSmallHouse(SmallHouseBuilder builder)
        {
            builder.Reset();
            builder.BuildHouseRoof(40);
            builder.BuildHouseWalls(6);
            builder.BuildHouseWindows(3);
            builder.ConnectElectricity();
            builder.ConnectInternet();
            builder.ConnectWater();
            builder.InstallHouseDoors(4);
        }
        public void BuildAverageHouse(AverageHouseBuilder builder)
        {
            builder.Reset();
            builder.BuildHouseRoof(60);
            builder.BuildHouseWalls(8);
            builder.BuildHouseWindows(5);
            builder.ConnectElectricity();
            builder.ConnectInternet();
            builder.ConnectWater();
            builder.InstallHouseDoors(6);
        }
        public void BuildBigHouse(BigHouseBuilder builder)
        {
            builder.Reset();
            builder.BuildHouseRoof(100);
            builder.BuildHouseWalls(10);
            builder.BuildHouseWindows(8);
            builder.ConnectElectricity();
            builder.ConnectInternet();
            builder.ConnectWater();
            builder.InstallHouseDoors(10);
        }
    }
}
