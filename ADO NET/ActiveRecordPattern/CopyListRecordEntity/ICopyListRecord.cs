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
        List<ICopyRecord> CopiesList { get; }

        // setters

        void AddCopy(ICopyRecord copy);

    }
}
