namespace Exercises.Dependencies
{
    public class ModuleFactory
    {
        public T Create<T>()
        {
            return default(T);
        }
    }
}
