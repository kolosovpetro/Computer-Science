using ActiveRecordPattern.CopyRecordEntity;
using ActiveRecordPattern.DBActions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecord : ICopyListRecord, IEntity
    {
        public string ConnectionString { get; }

        public int MovieId { get; }

        public List<ICopyRecord> Copies { get; private set; }

        public int TotalCopiesCount
        {
            get
            {
                return Copies.Count;
            }
        }

        public int AvailableCopiesCount
        {
            get
            {
                return Copies.Where(p => p.Available == true).Count();
            }
        }

        public IDbEngine Db => throw new NotImplementedException();

        public CopyListRecord(int movieId)
        {
            MovieId = movieId;
            Copies = new List<ICopyRecord>();
            SetCopies();
        }

        public override string ToString()
        {
            return $"Movie id: {MovieId}, " +
                $"Total copies: {TotalCopiesCount}, " +
                $"Available copies: {AvailableCopiesCount}";
        }

        public IEnumerable<ICopyRecord> AvailableCopies()
        {
            return Copies.Where(p => p.Available == true);
        }

        private void SetCopies()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM copies " +
                    "WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", MovieId);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Copies.Add(new CopyRecord((int)reader["copy_id"], (bool)reader["available"], (int)reader["movie_id"]));
                        // too long constructor overload, consider use of Builder pattern
                    }
                }
            }
        }
    }
}
