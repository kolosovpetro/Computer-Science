using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    class DscArray : AbstractArray
    {
        public DscArray(int newSize) : base(newSize)
        {
            this.ArrayType = "Descending Array";
        }
        public override void SetArray()
        {
            this.Array = ArrayGenerator.SortedDscArray(this.Size);
        }
    }
}
