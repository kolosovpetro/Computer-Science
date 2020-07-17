using SortAlgorithms.Interfaces;
using SortAlgorithms.Auxiliaries;

namespace SortAlgorithms.Arrays
{
    internal abstract class AbstractArray : IAbstractArray
    {
        protected int[] Array { get; set; }
        protected string ArrayType { get; set; }
        public int Size { get; }

        protected AbstractArray(int size)
        {
            Size = size;
            Array = ArrayGenerator.RandomArray(Size);
        }

        public virtual void SetArray()
        {
            Array = ArrayGenerator.RandomArray(Size);
        }

        public int[] GetArray()
        {
            return Array;
        }

        public string GetArrayType()
        {
            return ArrayType;
        }
    }
}
