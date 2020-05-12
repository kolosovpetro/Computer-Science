using System;

namespace Task3
{
    internal class HeavyMetal : Rock
    {
        private readonly string _genre;

        public HeavyMetal(string newSongName, string newArtist) : base(newSongName, newArtist)
        {
            _genre = "Heavy Metal";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {_genre} ");
        }
    }
}
