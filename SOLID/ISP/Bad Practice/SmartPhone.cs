using System;

namespace SOLID.ISP.Bad_Practice
{
    internal class SmartPhone : IPhone
    {
        public void BrowseInternet()
        {
            Console.WriteLine("Opening internet ... ");
        }

        public void Call()
        {
            Console.WriteLine("We are calling.. ");
        }

        public void MakeVideo()
        {
            Console.WriteLine("Start recording ... ");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Make picture");
        }
    }
}
