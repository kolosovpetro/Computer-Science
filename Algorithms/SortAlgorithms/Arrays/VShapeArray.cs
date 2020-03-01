using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    class VShapeArray : AbstractArray
    {
        public VShapeArray(int newSize) : base(newSize)
        {
            this.ArrayType = "VShape Array";
        }
        public override void SetArray()
        {
            this.Array = ArrayGenerator.VShapeArray(this.Size);
        }
    }
}
