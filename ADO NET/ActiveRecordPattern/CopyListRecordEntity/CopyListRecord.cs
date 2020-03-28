using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    internal class CopyListRecord : ICopyListRecord
    {
        public IEnumerable<ICopyRecord> CopiesList { get; private set; }

        public int TotalCopiesCount => CopiesList.Count();

        public int AvailableCopiesCount
        {
            get
            {
                return CopiesList.Count(p => p.Available);
            }
        }

        public void SetAllCopies(IEnumerable<ICopyRecord> newCopiesList)
        {
            CopiesList = newCopiesList;
        }
    }
}
