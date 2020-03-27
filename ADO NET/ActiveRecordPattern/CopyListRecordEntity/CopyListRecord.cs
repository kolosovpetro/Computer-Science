using ActiveRecordPattern.ConnectionString;
using ActiveRecordPattern.CopyRecordEntity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActiveRecordPattern.CopyListRecordEntity
{
    class CopyListRecord : ICopyListRecord
    {
        public IConnectionString ConnectionStringSetter { get; }

        public string ConnectionString { get; }

        public int MovieId { get; }

        public List<ICopy> Copies { get; private set; }

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

        public CopyListRecord(int movieId)
        {
            MovieId = movieId;
            Copies = new List<ICopy>();
            ConnectionStringSetter = new RentalConnectionString();
            ConnectionString = ConnectionStringSetter.ConnectionString;
            SetCopies();
        }

        public IEnumerable<ICopy> AvailableCopies()
        {
            return Copies.Where(p => p.Available == true);
        }

        private void SetCopies()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM copies WHERE movie_id = @ID", conn))
                {
                    command.Parameters.AddWithValue("@ID", MovieId);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Copies.Add(new Copy((int)reader["copy_id"], (bool)reader["available"], (int)reader["movie_id"]));
                        // too long constructor overload, consider use of Builder pattern
                    }
                }
            }
        }
    }
}
