namespace Exercises.Dependencies
{
    public interface IFactoriable
    {
        T Create<T>();
    }
    public class ModuleFactory : IFactoriable
    {
        public T Create<T>()
        {
            return default;
        }
    }
}
