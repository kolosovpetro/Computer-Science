using System;
using System.Globalization;
using System.Linq;
using NumericalSystems.Auxiliaries;

namespace NumericalSystems.Converters
{
    internal class ConvertToDecimal
    {
        public static string Convert(string input, int @base)
        {
            if (input.Contains(FormatSymbols.Sep1))
                input = input.Replace(FormatSymbols.Sep1, FormatSymbols.Sep2);

            var tokens = input.Split(FormatSymbols.Sep2);

            // if we work with integers this condition to be executed
            if (!input.Contains(FormatSymbols.Sep2))
                return IntPartConverterToDecimal(input, @base);

            if (tokens[0] == $"0{FormatSymbols.Sep2}")
                return FormatSymbols.Sep2 + FloatPartConverterToDecimal(tokens[1], @base);

            return IntPartConverterToDecimal(tokens[0], @base) + FloatPartConverterToDecimal(tokens[1], @base);
        }

        public static string IntPartConverterToDecimal(string integerPart, int @base)
        {
            double result = default;

            if (integerPart.StartsWith(FormatSymbols.Hexagonal))
                integerPart = integerPart.Replace(FormatSymbols.Hexagonal, "");

            if (integerPart.StartsWith(FormatSymbols.Octal.ToString()))
                integerPart = integerPart.Replace(FormatSymbols.Octal.ToString(), "");

            // reverse initial string to simplify loop
            integerPart = Misc.ReverseString(integerPart);

            for (var i = 0; i < integerPart.Length; i++)
            {
                var hexIndex = Array.IndexOf(FormatSymbols.HexagonalTable, integerPart[i]);

                // case for hexadecimals
                if (!int.TryParse(integerPart[i].ToString(), out _) && hexIndex != -1)
                    result += hexIndex * Math.Pow(@base, i);

                // case for binary, octal, decimal
                else if (int.TryParse(integerPart[i].ToString(), out var t))
                    result += t * Math.Pow(@base, i);

                else if (hexIndex == -1)
                    throw new Exception("Wrong number format");
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        public static string FloatPartConverterToDecimal(string floatPart, int @base)
        {
            double result = default;

            for (var i = 0; i < floatPart.Length; i++)
            {
                var hexIndex = Array.IndexOf(FormatSymbols.HexagonalTable, floatPart[i]);

                if (!int.TryParse(floatPart[i].ToString(), out _) && hexIndex != -1)
                    result += hexIndex * Math.Pow(@base, -i - 1);

                else if (int.TryParse(floatPart[i].ToString(), out var t))
                    result += t * Math.Pow(@base, -i - 1);

                else if (hexIndex == -1)
                    throw new Exception("Wrong number format");
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
