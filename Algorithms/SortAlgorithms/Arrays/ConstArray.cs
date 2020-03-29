using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class ConstArray : AbstractArray
    {
        public ConstArray(int newSize) : base(newSize)
        {
            ArrayType = "Constant Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.ConstArray(Size);
        }
    }
}
