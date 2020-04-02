using System;
using System.Collections.Generic;
using DataMapperPattern.CopyRecordEntity;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.CopyListRecordEntity
{
    internal class CopyListMapper : RentalDataBase, ISelectable<ICopyListRecord>,
        IIdentityMap<ICopyListRecord>
    {
        public IDictionary<int, ICopyListRecord> CacheDictionary { get; }
        
        public static CopyListMapper Instance { get; } = new CopyListMapper();

        private CopyListMapper()
        {
            CacheDictionary = new Dictionary<int, ICopyListRecord>();
        }

        public ICopyListRecord Select(int movieId)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE movie_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", movieId);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        throw new Exception("No any copies in relation");

                    var copiesList = new List<ICopyRecord>();

                    while (reader.Read())
                    {
                        var copy = new CopyRecord();
                        copy.SetMovieId((int)reader["movie_id"]);
                        copy.SetCopyId((int)reader["copy_id"]);
                        copy.SetAvailable((bool)reader["available"]);
                        copiesList.Add(copy);
                    }

                    var copyListRecord = new CopyListRecord();
                    copyListRecord.SetAllCopies(copiesList);

                    return copyListRecord;
                }
            }
        }

        public void UpdateCache(ICopyListRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
