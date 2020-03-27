﻿using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DBActions;
using Npgsql;
using System;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecordDbEngine : IConnectable, ISelectable
    {
        public string ConnectionString { get; }

        public CopyListRecordDbEngine()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public IMovieEntity Select(int id)
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
                        var copyListRecord = new CopyListRecord();

                        while (reader.Read())
                        {
                            var copy = new CopyRecord();
                            copy.ChangeMovieId((int)reader["movie_id"]);
                            copy.ChangeCopyId((int)reader["copy_id"]);
                            copy.ChangeAvailable((bool)reader["available"]);
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