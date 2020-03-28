using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListDbContext : RentalDataBase, ISelectable<ICopyListRecord>
    {
        public CopyListDbContext() : base() { }

        public ICopyListRecord Select(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE movie_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        ICopyListRecord copyListRecord = new CopyListRecord();

                        while (reader.Read())
                        {
                            CopyRecord copy = new CopyRecord();
                            copy.SetMovieId((int)reader["movie_id"]);
                            copy.SetCopyId((int)reader["copy_id"]);
                            copy.SetAvailable((bool)reader["available"]);
                            copyListRecord.AddCopy(copy);
                        }

                        return copyListRecord;
                    }
                }
            }

            throw new Exception("No any copies in relation");
        }
    }
}
