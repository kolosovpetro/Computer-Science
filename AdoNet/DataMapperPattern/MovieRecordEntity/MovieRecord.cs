namespace DataMapperPattern.MovieRecordEntity
{
    internal class MovieRecord : IMovieRecord
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public int AgeRestriction { get; private set; }

        public int MovieId { get; private set; }

        public double Price { get; private set; }

        public MovieRecord() { }

        public MovieRecord(string title, int year, int ageRestriction, int movieId, double price)
        {
            Title = title;
            Year = year;
            AgeRestriction = ageRestriction;
            MovieId = movieId;
            Price = price;
        }

        public override string ToString()
        {
            return $"Movie title: {Title}, " +
                $"produced in {Year}, " +
                $"restriction {AgeRestriction}+, " +
                $"price {Price}";
        }

        public void SetMovieId(int newId)
        {
            MovieId = newId;
        }

        public void ChangeAgeRestriction(int newRestriction)
        {
            AgeRestriction = newRestriction;
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
