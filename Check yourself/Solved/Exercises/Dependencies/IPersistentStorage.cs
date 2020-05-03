namespace Exercises.Dependencies
{
    public interface IPersistentStorage
    {
        void Write(string path, byte[] bytes);
        byte[] Read(string path);
    }
}
