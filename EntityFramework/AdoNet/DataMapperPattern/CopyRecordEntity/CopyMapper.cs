using System;
using System.Collections.Generic;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.CopyRecordEntity
{
    internal sealed class CopyMapper : RentalDataBase, ISelectable<ICopyRecord>, IUpdatable<ICopyRecord>,
        IInsertable<ICopyRecord>, IIdentityMap<ICopyRecord>
    {
        public IDictionary<int, ICopyRecord> CacheDictionary { get; }

        public static CopyMapper Instance { get; } = new CopyMapper();

        static CopyMapper() { }

        private CopyMapper()
        {
            CacheDictionary = new Dictionary<int, ICopyRecord>();
        }

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
            if (CacheDictionary.ContainsKey(movieId))
            {
                return CacheDictionary[movieId];
            }

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
                    CacheDictionary.Add(movieId, copy);
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

        public void UpdateCache(ICopyRecord copy)
        {
            throw new NotImplementedException();
        }
    }
}
