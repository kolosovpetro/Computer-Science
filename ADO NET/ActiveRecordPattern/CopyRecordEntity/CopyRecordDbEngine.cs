using ActiveRecordPattern.DBActions;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyRecordEntity
{
    class CopyRecordDbEngine : IConnectable, ISelectable, IUpdateable, IInsertable
    {
        public string ConnectionString { get; }

        public CopyRecordDbEngine()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public void Insert(IMovieEntity entity)
        {
            if (entity is CopyRecord cop)
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
                        cmd.Parameters.AddWithValue("@copy_id", cop.CopyId);
                        cmd.Parameters.AddWithValue("@available", cop.Available);
                        cmd.Parameters.AddWithValue("@movie_id", cop.MovieId);
                        cmd.ExecuteNonQuery();
                        return;
                    }
                }
            }

            throw new Exception("Unsupported object provided");
        }

        public IMovieEntity Select(int id)
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
                        newCopy.ChangeMovieId((int)reader["movie_id"]);
                        newCopy.ChangeCopyId((int)reader["copy_id"]);
                        newCopy.ChangeAvailable((bool)reader["available"]);
                        return newCopy;
                    }
                }
            }

            throw new Exception("No such item in relation");
        }

        public void Update(IMovieEntity entity)
        {
            if (entity is CopyRecord cop)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(
                        "UPDATE copies " +
                        "SET " +
                        "available = @available " +
                        "WHERE movie_id = @movie_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@available", cop.Available);
                        cmd.Parameters.AddWithValue("@movie_id", cop.MovieId);
                        cmd.ExecuteNonQuery();
                        return;
                    }
                }
            }

            throw new Exception("Unsupported object provided");
        }
    }
}
