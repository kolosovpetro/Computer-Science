using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // setters
        void ChangeTitle(string newTitle);
        void ChangeYear(int newYear);
        void ChangeAgeRestriction(int newRestriction);
        void ChangePrice(double newPrice);
        void Update();
    }
}
