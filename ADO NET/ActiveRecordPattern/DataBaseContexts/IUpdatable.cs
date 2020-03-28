namespace ActiveRecordPattern.DataBaseContexts
{
    internal interface IUpdatable<T>
    {
        void Update(T entity);
    }
}
