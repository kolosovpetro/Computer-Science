using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MP3Player player = new MP3Player();

            while (true)
            {
                string initialGenre;
                while (true)
                {
                    Console.WriteLine("Provide the song genre. \nIt suppose to be one of the following: " +
                        "Alternative rock, Heavy Metal, Hip-Hop, Rap, Rock > ");
                    initialGenre = Console.ReadLine();
                    if (initialGenre.ToLower() == "alternative rock"
                        || initialGenre.ToLower() == "heavy metal"
                        || initialGenre.ToLower() == "hip-hop"
                        || initialGenre.ToLower() == "rap"
                        || initialGenre.ToLower() == "rock")
                        break;
                }

                Console.WriteLine("Provide the name of the Artist >");
                string initialArtist = Console.ReadLine();
                Console.WriteLine("Provide the song name > ");
                string initialSongName = Console.ReadLine();

                if (initialGenre.ToLower() == "alternative rock")
                {
                    Song ar = new AlterntativeRock(initialSongName, initialArtist);
                    player.Add(ar);
                }

                if (initialGenre.ToLower() == "heavy metal")
                {
                    Song hm = new HeavyMetal(initialSongName, initialArtist);
                    player.Add(hm);
                }

                if (initialGenre.ToLower() == "hip-hop")
                {
                    Song hh = new HipHop(initialSongName, initialArtist);
                    player.Add(hh);
                }

                if (initialGenre.ToLower() == "rap")
                {
                    Song r = new Rap(initialSongName, initialArtist);
                    player.Add(r);
                }

                if (initialGenre.ToLower() == "rock")
                {
                    Song r1 = new Rock(initialSongName, initialArtist);
                    player.Add(r1);
                }

                Console.WriteLine("Enter Y(y) if you want to add other song, Or press and key to listen playlist");
                string quiteOrNot = Console.ReadLine();

                if (quiteOrNot != "Y" && quiteOrNot != "y")
                {
                    break;
                }
            }

            Console.Clear();

            Console.WriteLine("Player starting ...");
            Console.WriteLine("Successfully started and playing a playlist ...");
            player.PlaylistPlay();
        }
    }
}
