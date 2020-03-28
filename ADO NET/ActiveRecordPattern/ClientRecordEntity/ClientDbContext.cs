using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.ClientRecordEntity
{
    internal class ClientDbContext : RentalDataBase, ISelectable<IClientRecord>, IUpdatable<IClientRecord>,
        IInsertable<IClientRecord>
    {
        public void Insert(IClientRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO clients " +
                    "(client_id, first_name, last_name, birthday) " +
                    "VALUES " +
                    "(@client_id, @first_name, @last_name, @birthday)", conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", entity.ClientId);
                    cmd.Parameters.AddWithValue("@first_name", entity.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", entity.LastName);
                    cmd.Parameters.AddWithValue("@birthday", entity.Birthday);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IClientRecord Select(int clientId)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM clients " +
                    "WHERE client_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", clientId);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        throw new Exception("No such client in relation");

                    IClientRecord client = new ClientRecord();
                    reader.Read();
                    client.SetClientId((int)reader["client_id"]);
                    client.SetFirstName((string)reader["first_name"]);
                    client.SetLastName((string)reader["last_name"]);
                    client.SetBirthday(Convert.ToDateTime(reader["birthday"]));
                    return client;
                }
            }
        }

        public void Update(IClientRecord entity)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "UPDATE clients " +
                    "SET " +
                    "first_name = @first_name, " +
                    "last_name = @last_name, " +
                    "birthday = @birthday " +
                    "WHERE client_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", entity.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", entity.LastName);
                    cmd.Parameters.AddWithValue("@birthday", entity.Birthday);
                    cmd.Parameters.AddWithValue("@id", entity.ClientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
