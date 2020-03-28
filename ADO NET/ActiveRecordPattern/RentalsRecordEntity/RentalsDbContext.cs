using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ActiveRecordPattern.RentalsRecordEntity
{
    class RentalsDbContext : IConnectable, ISelectable<IEnumerable<IRentalsRecord>>, IUpdatable<IRentalsRecord>, IInsertable<IRentalsRecord>
    {
        public string ConnectionString { get; }

        public RentalsDbContext()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public void Insert(IRentalsRecord entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO rentals " +
                    "(copy_id, client_id, date_of_rental, date_of_return) " +
                    "VALUES " +
                    "(@copy_id, @client_id, @date_of_rental, @date_of_return)", conn))
                {
                    cmd.Parameters.AddWithValue("@copy_id", entity.CopyId);
                    cmd.Parameters.AddWithValue("@client_id", entity.ClientId);
                    cmd.Parameters.AddWithValue("@date_of_rental", entity.DateOfRental);
                    cmd.Parameters.AddWithValue("@date_of_return", entity.DateOfReturn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IRentalsRecord> Select(int clientId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM rentals " +
                    "WHERE client_id = @client_id", conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", clientId);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        List<RentalsRecord> rentRec = new List<RentalsRecord>();

                        while (reader.Read())
                        {
                            var rent = new RentalsRecord();
                            rent.SetClientId((int)reader["client_id"]);
                            rent.SetCopyId((int)reader["copy_id"]);
                            rent.SetDateOfRental(Convert.ToDateTime(reader["date_of_rental"]));
                            rent.SetDateOfReturn(Convert.ToDateTime(reader["date_of_return"]));
                            rentRec.Add(rent);
                        }

                        return rentRec;
                    }

                    throw new Exception("No such rental in relation");
                }
            }
        }

        public void Update(IRentalsRecord entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE rentals " +
                    "SET " +
                    "date_of_rental = @date_of_rental, " +
                    "date_of_return = @date_of_return " +
                    "WHERE copy_id = @copy_id AND client_id = @client_id", conn))
                {
                    cmd.Parameters.AddWithValue("@date_of_rental", entity.DateOfRental);
                    cmd.Parameters.AddWithValue("@date_of_return", entity.DateOfReturn);
                    cmd.Parameters.AddWithValue("@copy_id", entity.CopyId);
                    cmd.Parameters.AddWithValue("@client_id", entity.ClientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
