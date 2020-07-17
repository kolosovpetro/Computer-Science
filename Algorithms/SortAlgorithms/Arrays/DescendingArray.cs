using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class DescendingArray : AbstractArray
    {
        public DescendingArray(int size) : base(size)
        {
            ArrayType = "Descending Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.SortedDscArray(Size);
        }
    }
}
