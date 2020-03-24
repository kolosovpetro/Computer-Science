using System;

namespace SOLID.ISP.Good_Practice
{
    class PhoneISPFriendly : ICallable, ICamera
    {
        public void Call()
        {
            Console.WriteLine("Calling ... ");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Making picture ... ");
        }
    }
}
