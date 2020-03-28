namespace ActiveRecordPattern.DataBaseContexts
{
    interface IUpdateable<T>
    {
        void Update(T entity);
    }
}
