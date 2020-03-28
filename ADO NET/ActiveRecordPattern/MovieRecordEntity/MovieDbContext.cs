using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.MovieRecordEntity
{
    class MovieDbContext : RentalDataBase, ISelectable<IMovieRecord>, IUpdatable<IMovieRecord>,
        IInsertable<IMovieRecord>
    {
        public MovieDbContext() : base() { }

        public void Insert(IMovieRecord entity)
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
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@year", entity.Year);
                    cmd.Parameters.AddWithValue("@age_restriction", entity.AgeRestionction);
                    cmd.Parameters.AddWithValue("@movie_id", entity.MovieId);
                    cmd.Parameters.AddWithValue("@price", entity.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IMovieRecord Select(int MovieId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var command = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM movies " +
                    "WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", MovieId);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        IMovieRecord mov = new MovieRecord();
                        mov.SetMovieId((int)reader["movie_id"]);
                        mov.ChangeTitle((string)reader["title"]);
                        mov.ChangeYear((int)reader["year"]);
                        mov.ChangePrice(Convert.ToDouble(reader["price"]));
                        mov.ChangeAgeRestriction((int)reader["age_restriction"]);
                        return mov;
                    }
                }
            }

            throw new Exception("No such movie in database");       // may be to make this exception custom
        }

        public void Update(IMovieRecord entity)
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
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@year", entity.Year);
                    cmd.Parameters.AddWithValue("@age_restriction", entity.AgeRestionction);
                    cmd.Parameters.AddWithValue("@movie_id", entity.MovieId);
                    cmd.Parameters.AddWithValue("@price", entity.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
