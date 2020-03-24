namespace SOLID.ISP.Good_Practice
{
    class SmartPhoneISPFriendly : ICallable, ICamera, IRecordable, ISerfable
    {
        public void Call()
        {
            System.Console.WriteLine("Calling ... ");
        }

        public void SerfInternet()
        {
            System.Console.WriteLine("Opening internet browser ...");
        }

        public void TakePhoto()
        {
            System.Console.WriteLine("Making picture ... ");
        }

        public void TakeVideo()
        {
            System.Console.WriteLine("Video record in progress ... ");
        }
    }
}
