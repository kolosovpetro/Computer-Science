using ActiveRecordPattern.ConnectionString;
using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    interface ICopyListRecord
    {
        // properties

        IConnectionString ConnectionStringSetter { get; }
        string ConnectionString { get; }
        int MovieId { get; }
        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        List<ICopy> Copies { get; }

        // methods

        IEnumerable<ICopy> AvailableCopies();
    }
}
