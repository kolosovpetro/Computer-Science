using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class AscArray : AbstractArray
    {
        public AscArray(int newSize) : base(newSize)
        {
            ArrayType = "Ascending Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.SortedAscArray(Size);
        }
    }
}
