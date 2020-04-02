using System;
using System.Collections.Generic;
using DataMapperPattern.DataBaseContexts;
using Npgsql;

namespace DataMapperPattern.ClientRecordEntity
{
    internal class ClientDbContext : RentalDataBase, ISelectable<IClientRecord>, IUpdatable<IClientRecord>,
        IInsertable<IClientRecord>, IIdentityMap<IClientRecord>
    {
        public IDictionary<int, IClientRecord> CacheDictionary { get; }
        

        public static ClientDbContext Instance { get; } = new ClientDbContext();

        private ClientDbContext()
        {
            CacheDictionary = new Dictionary<int, IClientRecord>();
        }

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

        public IClientRecord Select(int movieId)
        {
            if (CacheDictionary.ContainsKey(movieId))
            {
                return CacheDictionary[movieId];
            }

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(
                    "SELECT * " +
                    "FROM clients " +
                    "WHERE client_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", movieId);

                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        throw new Exception("No such client in relation");

                    IClientRecord client = new ClientRecord();
                    reader.Read();
                    client.SetClientId((int)reader["client_id"]);
                    client.SetFirstName((string)reader["first_name"]);
                    client.SetLastName((string)reader["last_name"]);
                    client.SetBirthday(Convert.ToDateTime(reader["birthday"]));
                    CacheDictionary.Add(movieId, client);
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

        public void UpdateCache(IClientRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
