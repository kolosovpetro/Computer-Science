namespace ActiveRecordPattern.DataBaseContexts
{
    internal interface IInsertable<T>
    {
        void Insert(T entity);
    }
}
