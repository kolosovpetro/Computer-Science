using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class AscendingArray : AbstractArray
    {
        public AscendingArray(int size) : base(size)
        {
            ArrayType = "Ascending Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.SortedAscArray(Size);
        }
    }
}
