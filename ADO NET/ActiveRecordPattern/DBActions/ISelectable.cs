namespace ActiveRecordPattern.DBActions
{
    interface ISelectable
    {
        IMovieEntity Select(int id);
    }
}
