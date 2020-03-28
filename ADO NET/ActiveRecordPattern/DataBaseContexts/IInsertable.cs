namespace ActiveRecordPattern.DataBaseContexts
{
    interface IInsertable<T>
    {
        void Insert(T entity);
    }
}
