namespace DataMapperPattern.DataBaseContexts
{
    internal interface ISelectable<T>
    {
        T Select(int movieId);
    }
}
