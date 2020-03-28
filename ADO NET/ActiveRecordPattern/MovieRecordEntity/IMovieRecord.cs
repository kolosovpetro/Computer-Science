namespace ActiveRecordPattern.MovieRecordEntity
{
    interface IMovieRecord
    {
        // properties

        int MovieId { get; }
        string Title { get; }
        int Year { get; }
        int AgeRestionction { get; }
        double Price { get; }

        // setters

        void SetMovieId(int newId);
        void ChangeTitle(string newTitle);
        void ChangeYear(int newYear);
        void ChangeAgeRestriction(int newRestriction);
        void ChangePrice(double newPrice);

    }
}
