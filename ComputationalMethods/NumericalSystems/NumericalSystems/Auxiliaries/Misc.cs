using System.Linq;

namespace NumericalSystems.Auxiliaries
{
    internal class Misc
    {
        public static string ReverseString(string input)
        {
            return string.Join("", input.Reverse());
        }
    }
}
