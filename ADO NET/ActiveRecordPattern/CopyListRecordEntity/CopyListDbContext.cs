using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListDbContext<T> : IConnectable, ISelectable<T> where T : CopyListRecord
    {
        public string ConnectionString { get; }

        public CopyListDbContext()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public T Select(int id)
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
                        CopyListRecord copyListRecord = new CopyListRecord();

                        while (reader.Read())
                        {
                            var copy = new CopyRecord();
                            copy.SetMovieId((int)reader["movie_id"]);
                            copy.SetCopyId((int)reader["copy_id"]);
                            copy.SetAvailable((bool)reader["available"]);
                            copyListRecord.AddCopy(copy);
                        }

                        return (T)copyListRecord;
                    }
                }
            }

            throw new Exception("No any copies in relation");
        }
    }
}
