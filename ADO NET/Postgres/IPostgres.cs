using Npgsql;

namespace Postgres
{
    interface IPostgres
    {
        string Host { get; }
        string Username { get; }
        string Password { get; }
        string Database { get; }
        bool IsAvailable();
        NpgsqlConnection con { get; }
    }
}
