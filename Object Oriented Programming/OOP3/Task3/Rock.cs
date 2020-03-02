using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Rock : Song
    {
        private string Genre;

        public Rock(string newTrackName, string newArtist) :
            base(newTrackName, newArtist)
        { this.Genre = "Rock"; }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this.Genre} ");
        }
    }
}
