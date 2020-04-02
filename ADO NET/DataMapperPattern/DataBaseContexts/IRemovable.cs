namespace DataMapperPattern.DataBaseContexts
{
    interface IRemovable<T>
    {
        void Remove(T entity);
    }
}
