// TODO: Abstract platform service instantiation using a factory.

namespace Exercises.Patterns
{
	using Exercises.Dependencies;

	public class E1
    {
        public void Run()
        {
            IPersistentStorage storage = null;
            IDisplay display = null;
#if XBOX
            storage = new XboxStorage();
            display = new XboxDisplay();
#elif PS4
            storage = new Ps4Storage();
            display = new Ps4Display();
#else
            storage = new DesktopStorage();
            display = new DesktopDisplay();
#endif

            storage.Write("/test/myfile.conf", new byte[] { 0, 1, 0, 0, 0, 1 });
            display.Write(new byte[] {0, 1, 0, 0, 0, 1});
        }
    }
}
