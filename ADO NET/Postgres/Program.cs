using System;
using Npgsql;

namespace Postgres
{
    class Program
    {
        static void Main(string[] args)
        {
            Postgres p = new Postgres("localhost", "postgres", "postgres", "rental");
            NpgsqlCommand c1;
            string command;
            NpgsqlDataReader dr;

            Console.WriteLine(p.IsAvailable());         // checks if db is available

            // Create a program, that takes movie_id from the user and displays details about the movie

            Console.WriteLine("Enter movie id you want to display info about > ");
            p.con.Open();
            int id = Inputs.ReadInt();
            command = "SELECT * FROM movies WHERE movie_id = @id";
            c1 = new NpgsqlCommand(command, p.con);
            c1.Parameters.AddWithValue("@id", id);

            try
            {
                dr = c1.ExecuteReader();

                if (!dr.HasRows) throw new NpgsqlException("No such movie in data base");

                Console.WriteLine($"Details on movie with id {id}: ");

                while (dr.Read())
                {
                    Console.WriteLine($"Title: {dr["title"]}, " +
                        $"year: {dr["year"]}, " +
                        $"age restiction: {dr["age_restriction"]}, " +
                        $"price: {dr["price"]}");
                }

                dr.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Also display all actors that are starring in the movie

            command = "SELECT first_name, last_name " +
                "FROM actors a " +
                "JOIN starring s ON s.actor_id = a.actor_id " +
                "JOIN movies m ON m.movie_id = s.movie_id " +
                "WHERE m.movie_id = @id";
            c1 = new NpgsqlCommand(command, p.con);
            c1.Parameters.AddWithValue("@id", id);

            try
            {
                dr = c1.ExecuteReader();

                if (!dr.HasRows) throw new NpgsqlException("No such movie in data base");

                Console.WriteLine($"Info on actors of the movie with id {id}: ");

                while (dr.Read())
                {
                    Console.WriteLine($"First name: {dr["first_name"]}, Last name: {dr["last_name"]}");
                }

                dr.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Also display all the copies of the movie

            command = "SELECT * " +
                "FROM copies c " +
                "JOIN rentals r ON r.copy_id = c.copy_id " +
                "JOIN clients cl ON cl.client_id = r.client_id " +
                "WHERE movie_id = @id AND available = true";
            c1 = new NpgsqlCommand(command, p.con);
            c1.Parameters.AddWithValue("@id", id);

            try
            {
                dr = c1.ExecuteReader();

                if (!dr.HasRows) throw new NpgsqlException("No such movie in data base");

                Console.WriteLine($"Info on copies of the movie with id {id}: ");

                while (dr.Read())
                {
                    Console.WriteLine($"Available copy id: {dr["copy_id"]}");
                }

                dr.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
