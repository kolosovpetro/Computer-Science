using System;
using System.Collections.Generic;
using Npgsql;

namespace ActiveRecordPattern
{
    internal class MovieRecord
    {
        private static readonly string ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["Rental"].ToString();
        public int Id { get; }
        public string Title { get; }
        public int Year { get; }
        public double Price { get; private set; }
        public List<CopyRecord> Copies { get; }

        public MovieRecord(int id, string title, int year, double price, List<CopyRecord> copies = null)
        {
            Id = id;
            Title = title;
            Year = year;
            Price = price;
            Copies = copies;
        }
        public override string ToString()
        {
            return $"Movie {Id}: {Title} produced in {Year} costs {Price} and has {Copies.Count} copies";
        }

        public static MovieRecord GetById(int id)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM movies WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    var reader = command.ExecuteReader();

                    if (!reader.HasRows) 
                        return null;

                    reader.Read();
                    var price = Convert.ToDouble(reader["price"]);
                    var copies = CopyRecord.GetByMovieId(id);

                    return new MovieRecord(id, (string)reader["title"], (int)reader["year"], price, copies);
                }
            }
        }

        public void Save()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                // This is an UPSERT operation - if record doesn't exist in the database it is created, otherwise it is updated
                using (var command = new NpgsqlCommand("INSERT INTO movies(movie_id, title, year, price) " +
                    "VALUES (@ID, @title, @year, @price) " +
                    "ON CONFLICT (movie_id) DO UPDATE " +
                    "SET title = @title, year = @year, price = @price", conn))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@title", Title);
                    command.Parameters.AddWithValue("@year", Year);
                    command.Parameters.AddWithValue("@price", Price);
                    command.ExecuteNonQuery();
                }

                // We need to save every copy in our list. 
                // Notice the "?" symbol - Copies might be an empty list, so we need protection from NullReferenceException
                
                Copies?.ForEach(obj => obj.Save());
            }
        }

        public void Remove()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                // If the movie has any copies this operation will fail

                using (var command = new NpgsqlCommand("DELETE FROM movies WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ChangePrice(double price)
        {
            Price = price;       // Change price of object in memory
            Save();                 // Changes price of row in database
        }
    }
}