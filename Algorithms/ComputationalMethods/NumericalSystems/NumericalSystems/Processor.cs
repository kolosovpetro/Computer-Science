using System.Linq;
using NumericalSystems.Auxiliaries;
using NumericalSystems.Converters;

namespace NumericalSystems
{
    internal class Processor
    {
        private readonly int _base;
        private readonly string _decimalForm;
        private readonly string _binaryForm;
        private readonly string _octalForm;
        private readonly string _hexForm;

        public string Base => $"The base is: {_base}";
        public string Decimal => $"In Dec form: {_decimalForm}";
        public string Binary => $"In Bin form: {_binaryForm}";
        public string Octal => $"In Oct form: {_octalForm}";
        public string Hexagonal => $"In Hex form: {_hexForm}";

        public Processor(string input)
        {
            if (input.Contains(FormatSymbols.Sep1)) 
                input = input.Replace(FormatSymbols.Sep1, FormatSymbols.Sep2);
            var input1 = input;
            _base = BaseGetter.GetBase(input1);
            _decimalForm = _base == 10 ? input1 : ConvertToDecimal.Convert(input1, _base);
            _hexForm = _base == 16 ? input1 : FormatSymbols.Hexagonal + ConvertFromDecimal.Convert(_decimalForm, 16);
            _octalForm = _base == 8 ? input1 : FormatSymbols.Octal + ConvertFromDecimal.Convert(_decimalForm, 8);
            _binaryForm = _base == 2 ? input1 : ConvertFromDecimal.Convert(_decimalForm, 2);
        }

    }
}