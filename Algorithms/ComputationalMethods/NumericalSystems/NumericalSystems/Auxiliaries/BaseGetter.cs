using System;
using System.Globalization;
using System.Linq;

namespace NumericalSystems.Auxiliaries
{
    internal class BaseGetter
    {
        public static int GetBase(string input)
        {
            // replace the separator by Environmental one
            if (input.Contains(FormatSymbols.Sep1))
                input = input.Replace(FormatSymbols.Sep1, FormatSymbols.Sep2);

            // (if string NOT starts from 0 (OctSign) AND try parse is true) 
            // OR 
            // (double try parse is TRUE and result of double parse is equal to string)
            if (!input.StartsWith(FormatSymbols.Octal.ToString())
                && int.TryParse(input, out _)
                || double.TryParse(input, out var d)
                && string.Equals(d.ToString(CultureInfo.InvariantCulture), input))
                return 10;

            // if string starts from 0 (OctSign) AND double try parse is true OR string starts with '00.'
            if (input.StartsWith(FormatSymbols.Octal.ToString())
                && double.TryParse(input, out d)
                || input.StartsWith($"{FormatSymbols.Octal}0."))
                return 8;

            // if (string starts from HexSign OR starts from "HexSign+0.")
            // AND string consists not more than one separator
            if ((input.StartsWith(FormatSymbols.Hexagonal)
                 || input.StartsWith($"{FormatSymbols.Hexagonal}0."))
                && input.Split(FormatSymbols.Sep2).Length - 1 < 2)
                return 16;

            throw new Exception("Wrong Input format");
        }
    }
}
