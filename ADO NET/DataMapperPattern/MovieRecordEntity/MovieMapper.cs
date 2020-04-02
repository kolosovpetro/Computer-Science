using System;
using System.Collections.Generic;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.MovieRecordEntity
{
    internal sealed class MovieMapper : RentalDataBase, ISelectable<IMovieRecord>, IUpdatable<IMovieRecord>,
        IInsertable<IMovieRecord>, IIdentityMap<IMovieRecord>
    {
        public IDictionary<int, IMovieRecord> CacheDictionary { get; }

        // singleton pattern applied

        public static MovieMapper Instance { get; } = new MovieMapper();

        static MovieMapper() { }

        private MovieMapper()
        {
            CacheDictionary = new Dictionary<int, IMovieRecord>();
        }

        public void Insert(IMovieRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO movies " +
                    "(title, year, age_restriction, movie_id, price) " +
                    "VALUES " +
                    "(@title, @year, @age_restriction, @movie_id, @price)", conn))
                {
                    cmd.Parameters.AddWithValue("@title", entity.Title);
                    cmd.Parameters.AddWithValue("@year", entity.Year);
                    cmd.Parameters.AddWithValue("@age_restriction", entity.AgeRestriction);
                    cmd.Parameters.AddWithValue("@movie_id", entity.MovieId);
                    cmd.Parameters.AddWithValue("@price", entity.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IMovieRecord Select(int movieId)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var command = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM movies " +
                    "WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", movieId);

                    var reader = command.ExecuteReader();

                    if (!reader.HasRows)
                        throw new Exception("No such movie in database");

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

        public void Update(IMovieRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
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
                    cmd.Parameters.AddWithValue("@age_restriction", entity.AgeRestriction);
                    cmd.Parameters.AddWithValue("@movie_id", entity.MovieId);
                    cmd.Parameters.AddWithValue("@price", entity.Price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCache(IMovieRecord movie)
        {
            throw new NotImplementedException();
        }
    }
}
