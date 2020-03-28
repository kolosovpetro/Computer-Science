using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecord : ICopyListRecord
    {
        public List<CopyRecord> CopiesList { get; private set; }

        public int MovieId { get; }

        public int TotalCopiesCount
        {
            get
            {
                return CopiesList.Count;
            }
        }

        public int AvailableCopiesCount
        {
            get
            {
                return CopiesList.Where(p => p.Available == true).Count();
            }
        }

        public CopyListRecord()
        {
            CopiesList = new List<CopyRecord>();
        }

        public void AddCopy(CopyRecord copy)
        {
            CopiesList.Add(copy);
        }
    }
}
