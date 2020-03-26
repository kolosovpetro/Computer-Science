using ActiveRecordPattern.CopyRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecord : ICopyListRecord
    {
        public int MovieId { get; private set; }

        public List<ICopy> Copies { get; private set; }

        public IEnumerable<ICopy> AvailableCopies()
        {
            throw new NotImplementedException();
        }

        public void SetCopies(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
