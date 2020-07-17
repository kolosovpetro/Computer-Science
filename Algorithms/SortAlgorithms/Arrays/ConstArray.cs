using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class ConstArray : AbstractArray
    {
        public ConstArray(int size) : base(size)
        {
            ArrayType = "Constant Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.ConstArray(Size);
        }
    }
}
