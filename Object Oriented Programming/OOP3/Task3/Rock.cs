using System;

namespace Task3
{
    internal class Rock : Song
    {
        private readonly string _genre;

        public Rock(string newTrackName, string newArtist) : base(newTrackName, newArtist)
        {
            _genre = "Rock";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {_genre} ");
        }
        
    }
}
