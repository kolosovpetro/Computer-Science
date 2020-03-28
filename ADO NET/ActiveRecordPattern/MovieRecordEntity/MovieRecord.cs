namespace ActiveRecordPattern.MovieRecordEntity
{
    class MovieRecord : IMovieRecord
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public int AgeRestionction { get; private set; }

        public int MovieId { get; private set; }

        public double Price { get; private set; }

        public MovieRecord() { }

        public MovieRecord(string title, int year, int ageRestionction, int movieId, double price)
        {
            Title = title;
            Year = year;
            AgeRestionction = ageRestionction;
            MovieId = movieId;
            Price = price;
        }

        public override string ToString()
        {
            return $"Movie title: {Title}, " +
                $"produced in {Year}, " +
                $"restriction {AgeRestionction}+, " +
                $"price {Price}";
        }

        public void SetMovieId(int newId)
        {
            MovieId = newId;
        }

        public void ChangeAgeRestriction(int newRestriction)
        {
            AgeRestionction = newRestriction;
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void ChangeYear(int newYear)
        {
            Year = newYear;
        }
    }
}
