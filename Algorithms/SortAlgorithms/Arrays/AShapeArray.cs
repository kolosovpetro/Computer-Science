using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    class AShapeArray : AbstractArray
    {
        public AShapeArray(int newSize) : base(newSize)
        {
            this.ArrayType = "AShape Array";
        }
        public override void SetArray()
        {
            this.Array = ArrayGenerator.AShapeArray(this.Size);
        }
    }
}
