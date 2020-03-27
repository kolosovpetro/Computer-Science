using ActiveRecordPattern.ConnectionString;
using System;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class Copy : ICopy
    {
        private IConnectionString ConnectionStringSetter;

        private string ConnectionString;

        public int CopyId { get; private set; }

        public bool Available { get; private set; }

        public int MovieId { get; private set; }

        public Copy(int copyId, bool available, int movieId)
        {
            CopyId = copyId;
            Available = available;
            MovieId = movieId;
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
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
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}
