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
        List<ICopyRecord> Copies { get; }

        // methods

        IEnumerable<ICopyRecord> AvailableCopies();
    }
}
