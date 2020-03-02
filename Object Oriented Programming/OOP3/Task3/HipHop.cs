using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class HipHop : Rap
    {
        private string Genre;
        public HipHop(string newTrackName, string newArtist) :
            base(newTrackName, newArtist)
        { this.Genre = "Hip-Hop"; }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this.Genre} ");
        }
    }
}
