// TODO: Abstract platform service instantiation using a factory.

namespace Exercises.Patterns
{
    using Exercises.Dependencies;
    using System;

    public class E1
    {
        public void Run()
        {
            IPersistentStorage storage = null;
            IDisplay display = null;
            ICreator c = null;

            string choose = "xbox";
            switch (choose)
            {
                case "xbox":
                    c = new XboxCreator();
                    break;
                case "ps4":
                    c = new Ps4Creator();
                    break;
                case "pc":
                    c = new DesktopCreator();
                    break;
                default:
                    throw new InvalidOperationException("There is no such platform");
            }

            display = c.Display();
            storage = c.Storage();
            storage.Write("/test/myfile.conf", new byte[] { 0, 1, 0, 0, 0, 1 });
            display.Write(new byte[] { 0, 1, 0, 0, 0, 1 });
        }
        // xbox, ps4, desktop
    }

    interface ICreator
    {
        IDisplay Display();
        IPersistentStorage Storage();
    }

    class XboxCreator : ICreator
    {
        public IDisplay Display()
        {
            return new XboxDisplay();
        }

        public IPersistentStorage Storage()
        {
            return new XboxStorage();
        }
    }

    class Ps4Creator : ICreator
    {
        public IDisplay Display()
        {
            return new Ps4Display();
        }

        public IPersistentStorage Storage()
        {
            return new Ps4Storage();
        }
    }

    class DesktopCreator : ICreator
    {
        public IDisplay Display()
        {
            return new DesktopDisplay();
        }

        public IPersistentStorage Storage()
        {
            return new DesktopStorage();
        }
    }
}
