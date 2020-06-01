using System;

namespace Task3
{
    internal abstract class Song
    {
        private string SongName { get; }
        private string Artist { get; }

        protected Song(string newSongName, string newArtist)
        {
            SongName = newSongName;
            Artist = newArtist;
        }

        public virtual void Play()
        {
            Console.WriteLine($"Now plays: {SongName} - by {Artist}");
        }
    }
}