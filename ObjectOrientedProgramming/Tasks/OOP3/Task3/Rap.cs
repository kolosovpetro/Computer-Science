using System;

namespace Task3
{
    internal class Rap : Song
    {
        private readonly string _genre;

        public Rap(string newTrackName, string newArtist) : base(newTrackName, newArtist)
        {
            _genre = "Rap";
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this._genre} ");
        }
    }
}
