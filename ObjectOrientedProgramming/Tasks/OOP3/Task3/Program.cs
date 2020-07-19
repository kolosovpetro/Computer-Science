using System;

namespace Task3
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Mp3Player();

            while (true)
            {
                string initialGenre;
                while (true)
                {
                    Console.WriteLine("Provide the song genre. \nIt suppose to be one of the following: " +
                        "Alternative rock, Heavy Metal, Hip-Hop, Rap, Rock > ");
                    
                    initialGenre = Console.ReadLine();
                    
                    if (initialGenre != null && (initialGenre.ToLower() == "alternative rock"
                                                 || initialGenre.ToLower() == "heavy metal"
                                                 || initialGenre.ToLower() == "hip-hop"
                                                 || initialGenre.ToLower() == "rap"
                                                 || initialGenre.ToLower() == "rock"))
                        break;
                }

                Console.WriteLine("Provide the name of the Artist >");
                var initialArtist = Console.ReadLine();
                Console.WriteLine("Provide the song name > ");
                var initialSongName = Console.ReadLine();

                switch (initialGenre.ToLower())
                {
                    case "alternative rock":
                    {
                        var ar = new AlterntativeRock(initialSongName, initialArtist);
                        player.Add(ar);
                        break;
                    }
                    case "heavy metal":
                    {
                        var hm = new HeavyMetal(initialSongName, initialArtist);
                        player.Add(hm);
                        break;
                    }
                    case "hip-hop":
                    {
                        var hh = new HipHop(initialSongName, initialArtist);
                        player.Add(hh);
                        break;
                    }
                    case "rap":
                    {
                        var r = new Rap(initialSongName, initialArtist);
                        player.Add(r);
                        break;
                    }
                    case "rock":
                    {
                        var r1 = new Rock(initialSongName, initialArtist);
                        player.Add(r1);
                        break;
                    }
                }

                Console.WriteLine("Enter Y(y) if you want to add other song, Or press and key to listen playlist");
                var quiteOrNot = Console.ReadLine();

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
