using System;
using System.Linq;
using NumericalSystems.Auxiliaries;

namespace NumericalSystems.Converters
{
    internal class ConvertFromDecimal
    {
        public static string Convert(string input, int @base)
        {
            if (input.Contains(FormatSymbols.Sep1))
                input = input.Replace(FormatSymbols.Sep1, FormatSymbols.Sep2);

            var tokens = input.Split(FormatSymbols.Sep2);

            if (!input.Contains(FormatSymbols.Sep2))
                return IntPartConverterFromDecimal(input, @base);

            if (input.Contains(FormatSymbols.Sep2) && IntPartConverterFromDecimal(tokens[0], @base) == "")
                return "0" + FormatSymbols.Sep2 + FloatPartConverterFromDecimal(tokens[1], @base);

            return IntPartConverterFromDecimal(tokens[0], @base) + FormatSymbols.Sep2 +
                   FloatPartConverterFromDecimal(tokens[1], @base);
        }

        private static string IntPartConverterFromDecimal(string intPart, int @base)
        {
            var value = int.Parse(intPart);

            var result = "";

            while (value > 0)
            {
                var remainder = value % @base;
                if (remainder > 9) result = result + FormatSymbols.HexagonalTable[remainder];
                if (remainder <= 9) result = result + remainder.ToString();
                value = value / @base;
            }

            return Misc.ReverseString(result);
        }

        private static string FloatPartConverterFromDecimal(string floatPart, int @base)
        {
            var value = double.Parse(floatPart) / Math.Pow(10, floatPart.Length);

            string result = default;

            var t = 0;

            while (t < 10)
            {
                value *= @base;
                var remainder = (int)value;

                if (remainder > 9)
                    result = result + FormatSymbols.HexagonalTable[remainder];

                if (remainder <= 9)
                    result = result + remainder;

                value -= (int)value;

                t++;
            }

            return result;
        }
    }
}
