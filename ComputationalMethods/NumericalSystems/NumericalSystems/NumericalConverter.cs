using System;
using System.Globalization;
using System.Linq;

namespace NumericalSystems
{
    internal class NumericalConverter
    {
        private readonly int _base;
        private readonly string _decimalForm;
        private readonly string _binaryForm;
        private readonly string _octalForm;
        private readonly string _hexForm;

        private readonly char[] _hexTable =
            {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        private string[] _tokens;
        private const char Sep1 = '.';
        private const char Sep2 = ',';
        private const char OctSign = '0';
        private const string HexSign = "0x";


        public string PrintBase => $"The base is: {_base}";
        public string PrintDecimalForm => $"In Dec form: {_decimalForm}";
        public string PrintBinaryForm => $"In Bin form: {_binaryForm}";
        public string PrintOctalForm => $"In Oct form: {_octalForm}";
        public string PrintHexForm => $"In Hex form: {_hexForm}";

        public NumericalConverter(string newInitialInput)
        {
            if (newInitialInput.Contains(Sep1))
                newInitialInput = newInitialInput.Replace(Sep1, Sep2);

            var initialInput = newInitialInput;

            _base = GetBase(initialInput);

            // case when base == 10
            _decimalForm = _base == 10 ? initialInput : ConvertWholeNumberToDecimal(initialInput, _base);

            // case when base == 16
            _hexForm = _base == 16 ? initialInput : HexSign + ConvertWholeNumberFromDecimal(_decimalForm, 16);

            // case when base == 8
            _octalForm = _base == 8 ? initialInput : OctSign + ConvertWholeNumberFromDecimal(_decimalForm, 8);

            // case when base == 2
            _binaryForm = _base == 2 ? initialInput : ConvertWholeNumberFromDecimal(_decimalForm, 2);
        }

        private string ConvertWholeNumberToDecimal(string input, int @base)
        {
            if (input.Contains(Sep1))
                input = input.Replace(Sep1, Sep2);

            if (input.Contains(Sep2))
                _tokens = input.Split(Sep2);

            // if we work with integers this condition to be executed
            if (!input.Contains(Sep2))
                return IntPartConverterToDecimal(input, @base);

            if (_tokens[0] == $"0{Sep2}")
                return Sep2 + FloatPartConverterToDecimal(_tokens[1], @base);

            return IntPartConverterToDecimal(_tokens[0], @base) + FloatPartConverterToDecimal(_tokens[1], @base);
        }

        private string IntPartConverterToDecimal(string integerPart, int @base)
        {
            double result = default;

            if (integerPart.StartsWith(HexSign))
                integerPart = integerPart.Replace(HexSign, "");

            if (integerPart.StartsWith(OctSign.ToString()))
                integerPart = integerPart.Replace(OctSign.ToString(), "");

            // reverse initial string to simplify loop
            integerPart = ReverseString(integerPart);

            for (var i = 0; i < integerPart.Length; i++)
            {
                var hexIndex = Array.IndexOf(_hexTable, integerPart[i]);

                // case for hexadecimals
                if (!int.TryParse(integerPart[i].ToString(), out _) && hexIndex != -1)
                    result += hexIndex * Math.Pow(@base, i);

                // case for binary, octal, decimal
                else if (int.TryParse(integerPart[i].ToString(), out int t))
                    result += t * Math.Pow(@base, i);

                else if (hexIndex == -1)
                    throw new Exception("Wrong number format");
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private string FloatPartConverterToDecimal(string floatPart, int @base)
        {
            double result = default;

            for (var i = 0; i < floatPart.Length; i++)
            {
                var hexIndex = Array.IndexOf(_hexTable, floatPart[i]);

                if (!int.TryParse(floatPart[i].ToString(), out _) && hexIndex != -1)
                    result += hexIndex * Math.Pow(@base, -i - 1);

                else if (int.TryParse(floatPart[i].ToString(), out var t))
                    result += t * Math.Pow(@base, -i - 1);

                else if (hexIndex == -1)
                    throw new Exception("Wrong number format");
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private string ConvertWholeNumberFromDecimal(string input, int @base)
        {
            if (input.Contains(Sep1))
                input = input.Replace(Sep1, Sep2);

            if (input.Contains(Sep2))
                _tokens = input.Split(Sep2);

            if (!input.Contains(Sep2))
                return IntPartConverterFromDecimal(input, @base);

            if (input.Contains(Sep2) && IntPartConverterFromDecimal(_tokens[0], @base) == "")
                return "0" + Sep2 + FloatPartConverterFromDecimal(_tokens[1], @base);

            return IntPartConverterFromDecimal(_tokens[0], @base) + Sep2 +
                   FloatPartConverterFromDecimal(_tokens[1], @base);
        }

        private string IntPartConverterFromDecimal(string intPart, int @base)
        {
            var value = int.Parse(intPart);

            var result = "";

            while (value > 0)
            {
                var remainder = value % @base;
                if (remainder > 9) result = result + _hexTable[remainder];
                if (remainder <= 9) result = result + remainder.ToString();
                value = value / @base;
            }

            return ReverseString(result);
        }

        private string FloatPartConverterFromDecimal(string floatPart, int @base)
        {
            var value = double.Parse(floatPart) / Math.Pow(10, floatPart.Length);

            string result = default;

            var t = 0;

            while (t < 10)
            {
                value *= @base;
                var remainder = (int) value;

                if (remainder > 9)
                    result = result + _hexTable[remainder];

                if (remainder <= 9)
                    result = result + remainder;

                value -= (int) value;

                t++;
            }

            return result;
        }

        private static string ReverseString(string input)
        {
            return string.Join("", input.Reverse());
        }

        private static int GetBase(string initialInput)
        {
            // replace the separator by Environmental one
            if (initialInput.Contains(Sep1))
                initialInput = initialInput.Replace(Sep1, Sep2);

            // (if string NOT starts from 0 (OctSign) AND tryparse is true) 
            // OR 
            // (double try parse is TRUE and result of double parse is equal to string)
            if (!initialInput.StartsWith(OctSign.ToString())
                && int.TryParse(initialInput, out _)
                || double.TryParse(initialInput, out var d)
                && string.Equals(d.ToString(CultureInfo.InvariantCulture), initialInput))
                return 10;

            // if string starts from 0 (OctSign) AND double try parse is true OR string starts with '00.'
            if (initialInput.StartsWith(OctSign.ToString())
                && double.TryParse(initialInput, out d)
                || initialInput.StartsWith($"{OctSign}0."))
                return 8;

            // if (string starts from HexSign OR starts from "HexSign+0.")
            // AND string consists not more than one separator
            if ((initialInput.StartsWith(HexSign)
                 || initialInput.StartsWith($"{HexSign}0."))
                && initialInput.Split(Sep2).Length - 1 < 2)
                return 16;
            throw new Exception("Wrong Input format");
        }
    }
}