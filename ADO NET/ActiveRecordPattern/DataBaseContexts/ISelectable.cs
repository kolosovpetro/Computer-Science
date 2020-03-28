namespace ActiveRecordPattern.DataBaseContexts
{
    interface ISelectable<T>
    {
        T Select(int id);
    }
}
