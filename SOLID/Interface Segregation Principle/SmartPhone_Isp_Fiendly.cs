using System;

namespace SOLID.ISP
{
    interface ICallable
    {
        void Call();
    }

    interface ICamerable
    {
        void MakePhoto();
    }

    interface IMusicable
    {
        void ListenMusic();
    }

    public class SmartPhone : ICallable, ICamerable, IMusicable
    {
        public void Call()
        {
            Console.WriteLine("Calling ... ");
        }

        public void ListenMusic()
        {
            Console.WriteLine("Play current song ... ");
        }

        public void MakePhoto()
        {
            Console.WriteLine("Making picure of ...");
        }
    }

    public class Phone : ICallable
    {
        public void Call()
        {
            Console.WriteLine("Calling ...");
        }
    }
}
