using System;
using PostgreDatabaseFirst.Facades;
using PostgreDatabaseFirst.Queries;

namespace PostgreDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var selectionFacade = new SelectionFacade();
            //selectionFacade.ExecuteAll();

            JoinFacade joinFacade = new JoinFacade();
            joinFacade.ExecuteAll();

            #region JoinQueries

            // Task 1: For every copy display it’s ID and title of the movie. Order the results by
            // copy ID

            // Task 2: Display the titles of all the movies with copies 
            // available in the rental store.
            // Eliminate duplicates

            // Task 3: Display IDs of copies of movies produced in 1984

            // Task 4: For every rental display date of rental, date of return 
            // and name of client that made the rental

            // Task 5: For every rental display name of the client that made the rental and title
            // of the rented movie

            // Task 6: Display titles and years of production of all the movies rented 
            // by Gary Goodspeed

            #endregion

        }
    }
}
