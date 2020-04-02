using System;
using System.Collections.Generic;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.RentalsRecordEntity
{
    internal class RentalsDbContext : RentalDataBase, ISelectable<IEnumerable<IRentalsRecord>>, IUpdatable<IRentalsRecord>,
        IInsertable<IRentalsRecord>
    {
        public void Insert(IRentalsRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
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

        public IEnumerable<IRentalsRecord> Select(int movieId)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM rentals " +
                    "WHERE client_id = @client_id", conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", movieId);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows) 
                        throw new Exception("No such rental in relation");

                    var rentList = new List<RentalsRecord>();

                    while (reader.Read())
                    {
                        var rent = new RentalsRecord();
                        rent.SetClientId((int)reader["client_id"]);
                        rent.SetCopyId((int)reader["copy_id"]);
                        rent.SetDateOfRental(Convert.ToDateTime(reader["date_of_rental"]));
                        rent.SetDateOfReturn(Convert.ToDateTime(reader["date_of_return"]));
                        rentList.Add(rent);
                    }

                    return rentList;
                }
            }
        }

        public void Update(IRentalsRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
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
