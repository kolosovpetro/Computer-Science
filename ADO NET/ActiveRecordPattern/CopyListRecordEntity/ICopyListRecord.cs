using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    internal interface ICopyListRecord
    {
        // properties

        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        IEnumerable<ICopyRecord> CopiesList { get; }

        // setters

        void AddCopy(ICopyRecord copy);

    }
}
