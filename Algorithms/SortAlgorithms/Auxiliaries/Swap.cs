namespace SortAlgorithms.Auxiliaries
{
    internal static class Swap
    {
        public static void DoSwap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        
    }
}
