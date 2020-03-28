using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    internal class CopyListDbContext : RentalDataBase, ISelectable<ICopyListRecord>
    {
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

                    var newCopiesList = new List<ICopyRecord>();

                    while (reader.Read())
                    {
                        CopyRecord copy = new CopyRecord();
                        copy.SetMovieId((int)reader["movie_id"]);
                        copy.SetCopyId((int)reader["copy_id"]);
                        copy.SetAvailable((bool)reader["available"]);
                        newCopiesList.Add(copy);
                    }

                    var newCopyListRecord = new CopyListRecord();
                    newCopyListRecord.SetAllCopies(newCopiesList);

                    return newCopyListRecord;
                }
            }
        }
    }
}
