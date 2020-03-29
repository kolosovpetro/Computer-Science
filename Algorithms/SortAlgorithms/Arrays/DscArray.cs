using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class DscArray : AbstractArray
    {
        public DscArray(int newSize) : base(newSize)
        {
            ArrayType = "Descending Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.SortedDscArray(Size);
        }
    }
}
