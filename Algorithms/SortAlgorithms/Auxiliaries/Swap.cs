namespace SortAlgorithms.Auxiliaries
{
    internal class Swap
    {
        public static void DoSwap(ref int A, ref int B)
        {
            (A, B) = (B, A);
        }
        
    }
}
