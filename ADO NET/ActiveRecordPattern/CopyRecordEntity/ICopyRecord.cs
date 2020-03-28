namespace ActiveRecordPattern.CopyRecordEntity
{
    interface ICopyRecord
    {
        // properties

        int MovieId { get; }
        int CopyId { get; }
        bool Available { get; }

        // setters

        void ChangeCopyId(int newId);
        void ChangeAvailable(bool newState);
        void ChangeMovieId(int newId);

    }
}
