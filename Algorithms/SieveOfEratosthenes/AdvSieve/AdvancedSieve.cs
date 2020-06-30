namespace SieveOfEratosthenes.AdvSieve
{
    public class AdvancedSieve
    {
        private int Count { get; }
        public SieveUnit[] Sieve { get; private set; }
        private const int FirstPrime = 2;

        public AdvancedSieve(int count)
        {
            Count = count;
        }

        public void GenerateEratosthenes()
        {
            for (var i = FirstPrime; i < Count; i++)
            {
                if (Sieve[i].IsPrime)
                {
                    Exclude(i);
                }
            }
        }

        public void ResetSieve()
        {
            Sieve = new SieveUnit[Count];

            for (var i = 0; i < Count; i++)
            {
                Sieve[i] = new SieveUnit(i);

                if (i < 2)
                {
                    Sieve[i].IsPrime = false;
                    continue;
                }

                Sieve[i].IsPrime = true;
            }
        }

        public void Exclude(int iterator)
        {
            for (var i = 2 * iterator; i < Count; i += iterator)
            {
                if (!Sieve[i].IsPrime)
                {
                    continue;
                }

                Sieve[i].IsPrime = false;
            }
        }
    }
}