namespace DataMapperPattern.DataBaseContexts
{
    internal interface IInsertable<T>
    {
        void Insert(T entity);
    }
}
