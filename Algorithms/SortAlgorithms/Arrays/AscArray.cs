using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    class AscArray : AbstractArray
    {
        public AscArray(int newSize) : base(newSize)
        {
            this.ArrayType = "Ascending Array";
        }
        public override void SetArray()
        {
            this.Array = ArrayGenerator.SortedAscArray(this.Size);
        }
    }
}
