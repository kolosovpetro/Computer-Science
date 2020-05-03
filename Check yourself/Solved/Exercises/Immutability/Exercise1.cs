// TODO: Make Dna immutable without removing any functions.

namespace Exercises.Immutability
{
	using System.Collections.Generic;

	public enum Pair
    {
        AxT,
        GxC
    }

    public class Dna
    {
        private readonly IList<Pair> _chain;

        public int Count
        {
            get { return _chain.Count; }
        }

        public Pair this[int index]
        {
            get { return _chain[index]; }
        }

        public Dna()
        {
            _chain = new List<Pair>();
        }

        public void Add(Pair pair)
        {
            _chain.Add(pair);
        }

        public void Concat(Dna dna)
        {
            for(var i = 0; i < dna.Count; ++i)
                Add(dna[i]);
        }
    }
}
