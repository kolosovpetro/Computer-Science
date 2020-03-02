using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    abstract class Song
    {
        protected string SongName { get; private set; }
        protected string Artist { get; private set; }

        public Song(string newSongName, string newArtist)
        {
            this.SongName = newSongName;
            this.Artist = newArtist;
        }

        public virtual void Play()
        {
            Console.WriteLine($"Now plays: {this.SongName} - by {this.Artist}");
        }

    }
}
