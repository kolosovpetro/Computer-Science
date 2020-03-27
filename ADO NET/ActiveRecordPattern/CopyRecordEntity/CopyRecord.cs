using ActiveRecordPattern.DBActions;
using System;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class CopyRecord : ICopyRecord, IEntity
    {
        public int CopyId { get; private set; }

        public bool Available { get; private set; }

        public int MovieId { get; private set; }

        public IDbEngine Db => throw new NotImplementedException();

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

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Rent()
        {
            Available = false;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}
