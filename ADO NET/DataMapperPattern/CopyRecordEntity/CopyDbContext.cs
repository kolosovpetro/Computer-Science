using System;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.CopyRecordEntity
{
    internal class CopyDbContext : RentalDataBase, ISelectable<ICopyRecord>, IUpdatable<ICopyRecord>,
        IInsertable<ICopyRecord>
    {
        public static CopyDbContext Instance { get; } = new CopyDbContext();

        private CopyDbContext() { }

        public void Insert(ICopyRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
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

        public ICopyRecord Select(int movieId)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE copy_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", movieId);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        throw new Exception("No such item in relation");

                    ICopyRecord copy = new CopyRecord();
                    reader.Read();
                    copy.SetMovieId((int)reader["movie_id"]);
                    copy.SetCopyId((int)reader["copy_id"]);
                    copy.SetAvailable((bool)reader["available"]);
                    return copy;
                }
            }
        }

        public void Update(ICopyRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
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
