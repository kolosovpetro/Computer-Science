using ActiveRecordPattern.ConnectionString;
using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.CopyRecordEntity;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ActiveRecordPattern.MovieRecordEntity
{
    class MovieRecord : IMovieRecord
    {
        private ICopyListRecord CopyListRecord;
        public static string ConnectionString { get; private set; }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public int AgeRestionction { get; private set; }

        public int MovieId { get; private set; }

        public double Price { get; private set; }

        public IEnumerable<ICopy> CopiesList
        {
            get
            {
                return CopyListRecord.Copies;
            }
        }

        public IConnectionString ConnectionStringSetter { get; }

        public MovieRecord(string title, int year, int ageRestionction, int id, double price)
        {
            Title = title;
            Year = year;
            AgeRestionction = ageRestionction;
            MovieId = id;
            Price = price;
            CopyListRecord = new CopyListRecord(id);
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
        }

        public override string ToString()
        {
            return $"Movie title: {Title}, " +
                $"produced in {Year}, " +
                $"restriction {AgeRestionction}+, " +
                $"price {Price}, " +
                $"Available {CopyListRecord.AvailableCopiesCount} / {CopyListRecord.TotalCopiesCount}";
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

        public static IMovieRecord GetMovieById(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM movies WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        double price = Convert.ToDouble(reader["price"]);

                        // constructor below is really overloaded, consider use of pattern "Builder"

                        return new MovieRecord((string)reader["title"], (int)reader["year"], (int)reader["age_restriction"], (int)reader["movie_id"], price);
                    }
                }
            }

            return null;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
