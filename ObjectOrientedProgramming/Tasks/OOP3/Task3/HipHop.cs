using System;

namespace Task3
{
    internal class HipHop : Rap
    {
        private readonly string _genre;

        public HipHop(string newTrackName, string newArtist) : base(newTrackName, newArtist)
        {
            _genre = "Hip-Hop";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this._genre} ");
        }
    }
}
