using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Postgres
{
    class Program
    {
        static void Main(string[] args)
        {
            Postgres p = new Postgres("localhost", "postgres", "postgres", "rental");

            Console.WriteLine(p.IsAvailable());         // checks if db is available

            // Create a program, that takes movie_id from the user and displays details about the movie

            Console.WriteLine("Enter movie id you want to display info about > ");
            p.con.Open();
            int id = Inputs.ReadInt();
            string command = "SELECT * FROM movies WHERE movie_id = @id";
            NpgsqlCommand c1 = new NpgsqlCommand(command, p.con);
            c1.Parameters.AddWithValue("@id", id);

            try
            {
                NpgsqlDataReader dr = c1.ExecuteReader();

                if (!dr.HasRows) throw new NpgsqlException("No such movie in data base");

                Console.WriteLine($"Details on movie with id {id}: ");

                while (dr.Read())
                {
                    Console.WriteLine($"Title: {dr["title"]}, year: {dr["year"]}, age restiction: {dr["age_restriction"]}, price: {dr["price"]}");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Also display all actors that are starring in the movie


        }
    }
}
