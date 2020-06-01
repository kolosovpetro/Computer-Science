using Npgsql;

namespace Postgres
{
    internal interface IPostgres
    {
        string Host { get; }
        string Username { get; }
        string Password { get; }
        string Database { get; }
        bool IsAvailable();
        NpgsqlConnection Conn { get; }
    }
}
