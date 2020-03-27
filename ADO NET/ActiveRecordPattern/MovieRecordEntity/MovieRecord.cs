using ActiveRecordPattern.ConnectionString;
using Npgsql;
using System;

namespace ActiveRecordPattern.MovieRecordEntity
{
    class MovieRecord : IMovieRecord
    {
        public IConnectionString ConnectionStringSetter { get; }

        public string ConnectionString { get; }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public int AgeRestionction { get; private set; }

        public int MovieId { get; private set; }

        public double Price { get; private set; }

        public MovieRecord(int id)
        {
            MovieId = id;
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
            SetMovieData();
        }

        public MovieRecord(string title, int year, int ageRestionction, int movieId, double price)
        {
            Title = title;
            Year = year;
            AgeRestionction = ageRestionction;
            MovieId = movieId;
            Price = price;
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
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

        public void Insert()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO movies " +
                    "(title, year, age_restriction, movie_id, price) " +
                    "VALUES " +
                    "(@title, @year, @age_restriction, @movie_id, @price)", conn))
                {
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@age_restriction", AgeRestionction);
                    cmd.Parameters.AddWithValue("@movie_id", MovieId);
                    cmd.Parameters.AddWithValue("@price", Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE movies " +
                    "SET " +
                    "year = @year, " +
                    "age_restriction = @age_restriction, " +
                    "movie_id = @movie_id, " +
                    "price = @price " +
                    "WHERE title = @title", conn))
                {
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@year", Year);
                    cmd.Parameters.AddWithValue("@age_restriction", AgeRestionction);
                    cmd.Parameters.AddWithValue("@movie_id", MovieId);
                    cmd.Parameters.AddWithValue("@price", Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
