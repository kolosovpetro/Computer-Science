using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Jean-Luc Picard’s journal. Write a program which reads lines of text written by the user 
            // in the console and writes them into Captain’s journal. 
            // To start writing into the journal the user should enter “start”. 
            // To end writing into the journal the user should enter “stop”. 
            // Whatever the user enters before “start” or after “stop” should be discarded. 
            // After entering the whole content, the program should create a file titled 
            //<current-date>.txt 
            // with the content in the following format:
            // Captain’s log
            // Stardate < current - date >
            // First line…
            // Second line…
            // …
            // Jean - Luc Picard

            CaptainsJournal cj = new CaptainsJournal();
            cj.WriteLog();

            // Add another option – Stats – to your tic-tac-toe game.
            // After selecting New game both players should enter their usernames. 
            // After finishing each game the program should write the result of the game into a text file 
            // before going back to the main menu.
            // After selecting Stats the program should print out a list of all players 
            // whose scores are recorded in the stats file and ask the user if he / she wants to see 
            // stats for a single player or for a pair. 
            // If the user selects stats for a single player, he / she has to provide his username 
            // and the program prints the number of this player’s games and the ratio of won games to 
            // total games.
            // In case of selecting stats for a pair of players, 
            // the program asks for both players’ names and prints out the total number of
            //their games and what percent of games each of them won.


        }
    }
}
