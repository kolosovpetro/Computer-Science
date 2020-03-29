using System;

namespace NumericalIntegration
{
    internal class Auxiliary
    {
        public static int InputOfTypeInt(int min, int max)
        {
            int result;

            while (true)
            {
                var toParse = Console.ReadLine();

                try
                {
                    result = int.Parse(toParse ?? throw new InvalidOperationException("Null reference provided."));

                    if (result < min || result > max) throw new FormatException();

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
