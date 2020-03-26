using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class Copy : ICopy
    {
        public int CopyId { get; private set; }

        public bool Available { get; private set; }

        public int MovieId { get; private set; }

        public Copy(int copyId, bool available, int movieId)
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
    }
}
