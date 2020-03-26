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
        int MovieId { get; }
        List<ICopy> Copies { get; }

        // setters

        void SetCopies(int movieId);
        IEnumerable<ICopy> AvailableCopies();
    }
}
