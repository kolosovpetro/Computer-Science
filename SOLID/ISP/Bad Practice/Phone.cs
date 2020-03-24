using System;

namespace SOLID.ISP.Bad_Practice
{
    class Phone : IPhone
    {
        public void BrowseInternet()
        {
            throw new NotImplementedException();        // here is unsuspported feature
        }

        public void Call()
        {
            Console.WriteLine("We are calling now ...");
        }

        public void MakeVideo()
        {
            throw new NotImplementedException();        // here is unsuspported feature
        }

        public void TakePhoto()
        {
            throw new NotImplementedException();        // here is unsuspported feature
        }

        // here class depends on the functionalities it doesn't use, in order not to repeat code
        // let's follow Interface Segregation Principle
    }
}
