using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ActiveRecordPattern.RentalsRecordEntity
{
    class RentalsDbContext : IConnectable, ISelectable<List<RentalsRecord>>, IUpdateable<RentalsRecord>, IInsertable<RentalsRecord>
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

        public void Insert(RentalsRecord entity)
        {
            throw new NotImplementedException();
        }

        public List<RentalsRecord> Select(int clientId)
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

                        while(reader.Read())
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

        public void Update(RentalsRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
