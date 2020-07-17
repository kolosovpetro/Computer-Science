using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class VShapeArray : AbstractArray
    {
        public VShapeArray(int size) : base(size)
        {
            ArrayType = "VShape Array";
        }

        public override void SetArray()
        {
            Array = ArrayGenerator.VShapeArray(Size);
        }
    }
}
