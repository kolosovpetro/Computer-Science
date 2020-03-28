using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class CopyDbContext<T> : IConnectable, ISelectable<T>, IUpdateable<T>, IInsertable<T> where T : CopyRecord
    {
        public string ConnectionString { get; }

        public CopyDbContext()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public void Insert(T entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO copies " +
                    "(copy_id, available, movie_id)" +
                    "VALUES " +
                    "(@copy_id, @available, @movie_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@copy_id", entity.CopyId);
                    cmd.Parameters.AddWithValue("@available", entity.Available);
                    cmd.Parameters.AddWithValue("@movie_id", entity.MovieId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public T Select(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE copy_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        CopyRecord newCopy = new CopyRecord();
                        reader.Read();
                        newCopy.SetMovieId((int)reader["movie_id"]);
                        newCopy.SetCopyId((int)reader["copy_id"]);
                        newCopy.SetAvailable((bool)reader["available"]);
                        return (T)newCopy;
                    }
                }
            }

            throw new Exception("No such item in relation");
        }

        public void Update(T entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE copies " +
                    "SET " +
                    "available = @available " +
                    "WHERE copy_id = @copy_id", conn))
                {
                    cmd.Parameters.AddWithValue("@available", entity.Available);
                    cmd.Parameters.AddWithValue("@copy_id", entity.CopyId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
