namespace ActiveRecordPattern.CopyRecordEntity
{
    class CopyRecord : ICopyRecord
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

        public void ChangeCopyId(int newId)
        {
            CopyId = newId;
        }

        public void ChangeAvailable(bool newState)
        {
            Available = newState;
        }

        public void ChangeMovieId(int newId)
        {
            MovieId = newId;
        }

        public void Rent()
        {
            Available = false;
        }

    }
}
