using System;
using System.Linq;

namespace NumericalSystems
{
    class newNumConverter
    {
        private string InitialInput;
        private readonly int Base;
        private readonly string DecimalForm;
        private readonly string BinaryForm;
        private readonly string OctalForm;
        private readonly string HexForm;
        private const char sep1 = '.';
        private const char sep2 = ',';
        private const char OctSign = '0';
        private const string HexSign = "0x";
        private char[] HexTable = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private string[] tokens = null;

        public newNumConverter(string newInitialInput)
        {
            if (newInitialInput.Contains(sep1)) newInitialInput = newInitialInput.Replace(sep1, sep2);
            this.InitialInput = newInitialInput;
            this.Base = getNewBase(this.InitialInput);
            if (this.Base == 10) this.DecimalForm = this.InitialInput;
            else this.DecimalForm = NewToDecimal(this.InitialInput, this.Base);
            if (this.Base == 16) this.HexForm = this.InitialInput;
            else this.HexForm = HexSign + NewFromDecimal(this.DecimalForm, 16);
            if (this.Base == 8) this.OctalForm = this.InitialInput;
            else this.OctalForm = OctSign + NewFromDecimal(this.DecimalForm, 8);
            if (this.Base == 2) this.BinaryForm = this.InitialInput;
            else this.BinaryForm = NewFromDecimal(this.DecimalForm, 2);
        }

        public string PrintBase { get { return $"The base is: {this.Base}"; } }
        public string PrintDecimalForm { get { return $"In Dec form: {this.DecimalForm}"; } }
        public string PrintBinaryForm { get { return $"In Bin form: {this.BinaryForm}"; } }
        public string PrintOctalForm { get { return $"In Oct form: {this.OctalForm}"; } }
        public string PrintHexForm { get { return $"In Hex form: {this.HexForm}"; } }

        private string NewToDecimal(string Code, int Base)
        {
            if (Code.Contains(sep1)) Code = Code.Replace(sep1, sep2);
            if (Code.Contains(sep2)) tokens = Code.Split(sep2);

            // if we work with integers this condition to be executed
            if (!Code.Contains(sep2)) return IntPartConverterToDecimal(Code, Base);

            if (tokens[0] == $"0{sep2}") return sep2 + FloatPartConverterToDecimal(tokens[1], Base);

            return IntPartConverterToDecimal(tokens[0], Base) + FloatPartConverterToDecimal(tokens[1], Base);
        }
        private string IntPartConverterToDecimal(string InitialInput, int Base)
        {
            double Result = 0;
            if (InitialInput.StartsWith(HexSign)) InitialInput = InitialInput.Replace(HexSign, "");
            if (InitialInput.StartsWith(OctSign.ToString())) InitialInput = InitialInput.Replace(OctSign.ToString(), "");

            InitialInput = ReverseString(InitialInput);                    // reverse initial string to simplify loop

            for (int i = 0; i < InitialInput.Length; i++)
            {
                int HexIndex = Array.IndexOf(HexTable, InitialInput[i]);

                // hexadecimals
                if (!int.TryParse(InitialInput[i].ToString(), out int t) && HexIndex != -1) Result += HexIndex * Math.Pow(Base, i);

                // bin, oct, dec
                else if (int.TryParse(InitialInput[i].ToString(), out int t1)) Result += t1 * Math.Pow(Base, i);
                else if (HexIndex == -1) throw new Exception("Wrong number format");
            }

            return Result.ToString();
        }
        private string FloatPartConverterToDecimal(string InitialInput, int Base)
        {
            double Result = 0;
            for (int i = 0; i < InitialInput.Length; i++)
            {
                int HexIndex = Array.IndexOf(HexTable, InitialInput[i]);
                if (!int.TryParse(InitialInput[i].ToString(), out int t) && HexIndex != -1)
                    Result += HexIndex * Math.Pow(Base, -i - 1);
                else if (int.TryParse(InitialInput[i].ToString(), out int t1))
                    Result += t1 * Math.Pow(Base, -i - 1);
                else if (HexIndex == -1)
                    throw new Exception("Wrong number format");
            }
            return Result.ToString();
        }

        private string NewFromDecimal(string Code, int Base)
        {
            if (Code.Contains(sep1)) Code = Code.Replace(sep1, sep2);
            if (Code.Contains(sep2)) tokens = Code.Split(sep2);
            if (!Code.Contains(sep2))
                return IntPartConverterFromDecimal(Code, Base);
            if (Code.Contains(sep2) && IntPartConverterFromDecimal(tokens[0], Base) == "")
                return "0" + sep2 + FloatPartConverterFromDecimal(tokens[1], Base);
            return IntPartConverterFromDecimal(tokens[0], Base) + sep2 + FloatPartConverterFromDecimal(tokens[1], Base);
        }
        private string IntPartConverterFromDecimal(string InitialInput, int Base)
        {
            int Value = int.Parse(InitialInput);
            string Result = "";
            while (Value > 0)
            {
                int remainder = Value % Base;
                if (remainder > 9) Result = Result + HexTable[remainder];
                if (remainder <= 9) Result = Result + remainder.ToString();
                Value = Value / Base;
            }
            return ReverseString(Result);
        }
        private string FloatPartConverterFromDecimal(string InitialInput, int Base)
        {
            double Value = double.Parse(InitialInput) / Math.Pow(10, InitialInput.Length);
            string Result = "";
            int t = 0;
            while (t < 10)
            {
                Value = Value * Base;
                int remainder = (int)Value;
                if (remainder > 9) Result = Result + HexTable[remainder];
                if (remainder <= 9) Result = Result + remainder.ToString();
                Value = Value - (int)Value;
                t++;
            }
            return Result;
        }

        private string ReverseString(string Word)
        {
            return string.Join("", Word.Reverse());
        }
        private int getNewBase(string InitialInput)
        {
            int t;
            double d;

            // replace the separator by Enviromental one
            if (InitialInput.Contains(sep1)) InitialInput = InitialInput.Replace(sep1, sep2);

            // (if string NOT starts from 0 (OctSign) AND tryparse is true) 
            // OR 
            // (double tryparse is TRUE and result of double parse is equal to string)
            if ((!InitialInput.StartsWith(OctSign.ToString()) && int.TryParse(InitialInput, out t))
                || (double.TryParse(InitialInput, out d) && string.Equals(d.ToString(), InitialInput))) return 10;

            // if string starts from 0 (OctSign) AND double tryparse is true OR string starts with '00.'
            else if ((InitialInput.StartsWith(OctSign.ToString())
                && double.TryParse(InitialInput, out d)) || InitialInput.StartsWith($"{OctSign}0.")) return 8;

            // if (string starts from HexSign OR starts from "HexSign+0.") AND string consists not more than one separator
            else if ((InitialInput.StartsWith(HexSign) || InitialInput.StartsWith($"{HexSign}0."))
                && InitialInput.Split(sep2).Length - 1 < 2) return 16;
            else throw new Exception("Wrong Input format");
        }
        private bool arrayTermInString(string String, char[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (String.ToLower().Contains(array[i].ToString().ToLower())) return true;
            return false;
        }

    }
}
