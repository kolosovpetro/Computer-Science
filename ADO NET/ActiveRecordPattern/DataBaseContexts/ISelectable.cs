namespace ActiveRecordPattern.DataBaseContexts
{
    internal interface ISelectable<T>
    {
        T Select(int id);
    }
}
