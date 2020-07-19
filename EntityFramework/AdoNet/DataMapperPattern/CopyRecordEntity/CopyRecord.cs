namespace DataMapperPattern.CopyRecordEntity
{
    internal class CopyRecord : ICopyRecord
    {
        public int CopyId { get; private set; }

        public bool Available { get; private set; }

        public int MovieId { get; private set; }

        public CopyRecord() { }

        public CopyRecord(int copyId, bool available, int movieId)
        {
            CopyId = copyId;
            Available = available;
            MovieId = movieId;
        }

        public override string ToString()
        {
            return $"Copy id: {CopyId}, Availability: {Available}, Movie Id: {MovieId}";
        }

        public void SetCopyId(int newId)
        {
            CopyId = newId;
        }

        public void SetAvailable(bool newState)
        {
            Available = newState;
        }

        public void SetMovieId(int newId)
        {
            MovieId = newId;
        }
    }
}
