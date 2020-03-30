using System;

namespace SOLID.ISP.Bad_Practice
{
    internal class Phone : IPhone
    {
        public void BrowseInternet()
        {
            throw new NotImplementedException();        // here is unsupported feature
        }

        public void Call()
        {
            Console.WriteLine("We are calling now ...");
        }

        public void MakeVideo()
        {
            throw new NotImplementedException();        // here is unsupported feature
        }

        public void TakePhoto()
        {
            throw new NotImplementedException();        // here is unsupported feature
        }

        // here class depends on the functionality it doesn't use, in order not to repeat code
        // let's follow Interface Segregation Principle
    }
}
