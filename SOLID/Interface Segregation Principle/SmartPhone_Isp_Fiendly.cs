using System;

namespace SOLID.ISP
{
    /// <summary>
    /// Separated interface providing only method Call
    /// </summary>
    public interface ICallable
    {
        void Call();
    }

    /// <summary>
    /// Separate interface providing only method MakePhoto
    /// </summary>
    public interface ICamerable
    {
        void MakePhoto();
    }

    /// <summary>
    /// Separated interface providing only method ListenMusic
    /// </summary>
    public interface IMusicable
    {
        void ListenMusic();
    }

    /// <summary>
    /// Class Smartphone implements all interfaces
    /// </summary>
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

    /// <summary>
    /// Class Phone inplements interface Callable, eg may be used for Call only
    /// </summary>
    public class Phone : ICallable
    {
        public void Call()
        {
            Console.WriteLine("Calling ...");
        }
    }
}
