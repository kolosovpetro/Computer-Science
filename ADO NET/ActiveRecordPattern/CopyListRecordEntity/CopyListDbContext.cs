using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    internal class CopyListDbContext : RentalDataBase, ISelectable<ICopyListRecord>
    {
        public ICopyListRecord Select(int id)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE movie_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows) 
                        throw new Exception("No any copies in relation");

                    var copyListRecord = new CopyListRecord();

                    while (reader.Read())
                    {
                        var copy = new CopyRecord();
                        copy.SetMovieId((int)reader["movie_id"]);
                        copy.SetCopyId((int)reader["copy_id"]);
                        copy.SetAvailable((bool)reader["available"]);
                        copyListRecord.AddCopy(copy);
                    }

                    return copyListRecord;
                }
            }
        }
    }
}
