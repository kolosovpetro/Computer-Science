using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Rap : Song
    {
        private string Genre;

        public Rap(string newTrackName, string newArtist) :
            base(newTrackName, newArtist)
        { this.Genre = "Rap"; }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this.Genre} ");
        }
    }
}
