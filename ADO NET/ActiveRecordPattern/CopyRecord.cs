using System.Collections.Generic;
using Npgsql;

namespace ActiveRecordPattern
{
    internal class CopyRecord
    {
        private static readonly string ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["Rental"].ToString();
        public int Id { get; }
        public bool Available { get; }
        public int MovieId { get; }
        public CopyRecord(int id, bool available, int movieId)
        {
            Id = id;
            Available = available;
            MovieId = movieId;
        }

        public static CopyRecord GetById(int id)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM copies WHERE copy_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    var reader = command.ExecuteReader();

                    if (!reader.HasRows) 
                        return null;

                    reader.Read();
                    return new CopyRecord(id, (bool)reader["available"], (int)reader["movie_id"]);
                }
            }
        }

        public static List<CopyRecord> GetByMovieId(int movieId)
        {
            var list = new List<CopyRecord>();

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM copies WHERE movie_id = @movieID", conn))
                {
                    command.Parameters.AddWithValue("@movieID", movieId);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new CopyRecord((int)reader["copy_id"], (bool)reader["available"], (int)reader["movie_id"]));
                    }
                }
            }
            return list;
        }

        public void Save()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                // This is an UPSERT operation - if record doesn't exist in the database it is created, otherwise it is updated
               
                using (var command = new NpgsqlCommand("INSERT INTO copies(copy_id, available, movie_id) " +
                    "VALUES (@ID, @available, @movieId) " +
                    "ON CONFLICT (copy_id) DO UPDATE " +
                    "SET available = @available, movie_id = @movieId", conn))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@available", Available);
                    command.Parameters.AddWithValue("@movieId", MovieId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM copies WHERE copy_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}