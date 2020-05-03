namespace Exercises.Dependencies
{
    public class DesktopStorage : IPersistentStorage
    {
        public void Write(string path, byte[] bytes)
        {

        }
        public byte[] Read(string path)
        {
            return null;
        }
    }
}
