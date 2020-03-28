using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    internal class CopyListRecord : ICopyListRecord
    {
        public IEnumerable<ICopyRecord> CopiesList { get; }

        public int TotalCopiesCount => CopiesList.Count();

        public int AvailableCopiesCount
        {
            get
            {
                return CopiesList.Count(p => p.Available);
            }
        }

        public CopyListRecord()
        {
            CopiesList = new List<ICopyRecord>();
        }

        public void AddCopy(ICopyRecord copy)
        {
            CopiesList.Append(copy);
        }
    }
}
