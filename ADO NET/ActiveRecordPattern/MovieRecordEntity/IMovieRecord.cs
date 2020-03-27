using ActiveRecordPattern.ConnectionString;
using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using System.Collections.Generic;

namespace ActiveRecordPattern.MovieRecordEntity
{
    interface IMovieRecord
    {
        // properties

        string Title { get; }
        int Year { get; }
        int AgeRestionction { get; }
        int MovieId { get; }
        double Price { get; }
        IEnumerable<ICopy> CopiesList { get; }
        IConnectionString ConnectionStringSetter { get; }

        // setters

        void SetMovieId(int newId);
        void ChangeTitle(string newTitle);
        void ChangeYear(int newYear);
        void ChangeAgeRestriction(int newRestriction);
        void ChangePrice(double newPrice);

        // methods

        void Update();
    }
}
