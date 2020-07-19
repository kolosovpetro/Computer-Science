using System.Collections.Generic;
using DataMapperPattern.CopyRecordEntity;

namespace DataMapperPattern.CopyListRecordEntity
{
    internal interface ICopyListRecord
    {
        // properties

        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        IEnumerable<ICopyRecord> CopiesList { get; }

        // setters

        void SetAllCopies(IEnumerable<ICopyRecord> newCopiesList);
    }
}
