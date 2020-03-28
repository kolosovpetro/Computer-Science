using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    interface ICopyListRecord
    {
        // properties
        int MovieId { get; }
        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        List<CopyRecord> CopiesList { get; }

        // setters

        void AddCopy(CopyRecord copy);

    }
}
