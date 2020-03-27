namespace ActiveRecordPattern.CopyRecordEntity
{
    interface ICopy
    {
        // properties

        int CopyId { get; }
        bool Available { get; }
        int MovieId { get; }

        // setters

        void ChangeCopyId(int newId);
        void ChangeAvailable(bool newState);
        void ChangeMovieId(int newId);

        // methods

        void Rent();
        void Insert();
        void Update();
    }
}
