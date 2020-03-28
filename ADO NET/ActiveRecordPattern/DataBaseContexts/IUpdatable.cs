namespace ActiveRecordPattern.DataBaseContexts
{
    interface IUpdatable<T>
    {
        void Update(T entity);
    }
}
