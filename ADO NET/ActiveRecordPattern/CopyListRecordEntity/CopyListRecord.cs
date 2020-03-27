using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecord : ICopyListRecord
    {
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

        public List<ICopyRecord> CopiesList { get; private set; }

        public CopyListRecord()
        {
            CopiesList = new List<ICopyRecord>();
        }

        public void AddCopy(ICopyRecord copy)
        {
            CopiesList.Add(copy);
        }
    }
}
