using ActiveRecordPattern.DataBaseContexts;
using Npgsql;
using System;

namespace ActiveRecordPattern.ClientRecordEntity
{
    class ClientDbContext : IConnectable, ISelectable<IClientRecord>, IUpdatable<IClientRecord>, IInsertable<IClientRecord>
    {
        public string ConnectionString { get; }

        public ClientDbContext()
        {
            ConnectionString = System
            .Configuration
            .ConfigurationManager
            .ConnectionStrings["Rental"]
            .ToString();
        }

        public void Insert(IClientRecord entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
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
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM clients " +
                    "WHERE client_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", clientId);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        var clnt = new ClientRecord();
                        reader.Read();
                        clnt.SetClientId((int)reader["client_id"]);
                        clnt.SetFirstName((string)reader["first_name"]);
                        clnt.SetLastName((string)reader["last_name"]);
                        clnt.SetBirthday(Convert.ToDateTime(reader["birthday"]));
                        return clnt;
                    }
                }

                throw new Exception("No such client in relation");
            }
        }

        public void Update(IClientRecord entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(
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
