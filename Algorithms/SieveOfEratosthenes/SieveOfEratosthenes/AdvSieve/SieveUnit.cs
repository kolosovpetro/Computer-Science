namespace SieveOfEratosthenes.AdvSieve
{
    public class SieveUnit
    {
        public int Index { get; }
        public bool IsPrime { get; set; }

        public SieveUnit(int index)
        {
            Index = index;
        }

        public override string ToString()
        {
            return IsPrime switch
            {
                true => $"{Index} - is Prime",
                _ => $"{Index} is NOT Prime"
            };
        }
    }
}