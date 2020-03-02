using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class HeavyMetal : Rock
    {
        private string Genre;
        public HeavyMetal(string newSongName, string newArtist) :
            base(newSongName, newArtist)
        { this.Genre = "Heavy Metal"; }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this.Genre} ");
        }
    }
}
