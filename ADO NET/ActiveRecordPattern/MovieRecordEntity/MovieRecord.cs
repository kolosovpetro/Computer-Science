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

        public IConnectionString ConnectionStringSetter { get; }

        public string ConnectionString { get; }

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

        public MovieRecord(int id)
        {
            MovieId = id;
            CopyListRecord = new CopyListRecord(id);
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
            SetMovieData();
        }

        public override string ToString()
        {
            return $"Movie title: {Title}, " +
                $"produced in {Year}, " +
                $"restriction {AgeRestionction}+, " +
                $"price {Price}, " +
                $"Available {CopyListRecord.AvailableCopiesCount} / {CopyListRecord.TotalCopiesCount}";
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

        private void SetMovieData()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM movies WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", MovieId);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        SetMovieId((int)reader["movie_id"]);
                        ChangeTitle((string)reader["title"]);
                        ChangeYear((int)reader["year"]);
                        ChangePrice(Convert.ToDouble(reader["price"]));
                        ChangeAgeRestriction((int)reader["age_restriction"]);
                        return;
                    }
                }
            }

            throw new Exception("No such movie in database");       // may be to make this exception custom
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
