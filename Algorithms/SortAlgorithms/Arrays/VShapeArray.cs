using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class VShapeArray : AbstractArray
    {
        public VShapeArray(int newSize) : base(newSize)
        {
            ArrayType = "VShape Array";
        }

        public override void SetArray()
        {
            Array = ArrayGenerator.VShapeArray(Size);
        }
    }
}
