namespace ActiveRecordPattern.DataBaseContexts
{
    interface IRemovable<T>
    {
        void Remove(T entity);
    }
}
