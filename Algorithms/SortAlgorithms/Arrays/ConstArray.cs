using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    class ConstArray : AbstractArray
    {
        public ConstArray(int newSize) : base(newSize)
        {
            this.ArrayType = "Constant Array";
        }
        public override void SetArray()
        {
            this.Array = ArrayGenerator.ConstArray(this.Size);
        }
    }
}
