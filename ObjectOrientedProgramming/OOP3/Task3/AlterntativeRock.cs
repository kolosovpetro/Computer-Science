using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class AlterntativeRock : Rock
    {
        private string Genre;
        public AlterntativeRock(string newTrackName, string newArtist) :
            base(newTrackName, newArtist)
        { this.Genre = "Alterntative Rock"; }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($" of genre: {this.Genre} ");
        }
    }
}
