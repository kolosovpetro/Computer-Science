using ActiveRecordPattern.CopyRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    interface ICopyListRecord
    {
        string ConnectionString { get; }
        int MovieId { get; }
        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        List<ICopy> Copies { get; }

        // setters

        IEnumerable<ICopy> AvailableCopies();
    }
}
