using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal class AShapeArray : AbstractArray
    {
        public AShapeArray(int size) : base(size)
        {
            ArrayType = "AShape Array";
        }
        public override void SetArray()
        {
            Array = ArrayGenerator.AShapeArray(Size);
        }
    }
}
