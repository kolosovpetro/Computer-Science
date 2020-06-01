using System.Collections.Generic;
using System.Linq;
using DataMapperPattern.CopyRecordEntity;

namespace DataMapperPattern.CopyListRecordEntity
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
