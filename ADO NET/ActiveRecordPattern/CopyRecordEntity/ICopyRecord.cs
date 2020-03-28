namespace ActiveRecordPattern.CopyRecordEntity
{
    internal interface ICopyRecord
    {
        // properties

        int MovieId { get; }
        int CopyId { get; }
        bool Available { get; }

        // setters

        void SetCopyId(int newId);
        void SetAvailable(bool newState);
        void SetMovieId(int newId);

    }
}
