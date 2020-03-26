using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern.CopyRecordEntity
{
    interface ICopy
    {
        int CopyId { get; }
        bool Available { get; }
        int MovieId { get; }

        // setters

        void ChangeCopyId(int newId);
        void ChangeAvailable(bool newState);
        void ChangeMovieId(int newId);
        void Update();
    }
}
