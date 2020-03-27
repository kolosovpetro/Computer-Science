using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DBActions;
using System.Collections.Generic;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    interface ICopyListRecord : IMovieEntity
    {
        // properties

        int TotalCopiesCount { get; }
        int AvailableCopiesCount { get; }
        List<ICopyRecord> CopiesList { get; }

        // setters

        void AddCopy(ICopyRecord copy);

    }
}
