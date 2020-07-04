using System;
using System.Linq;
using System.Text;
using static System.Char;

namespace CaesarСipher.Implementation
{
    public static class Decoder
    {
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Decode(string text, int shift)
        {
            if (shift < 0) throw new InvalidOperationException("Shift must be greater or equal 0");
            
            var shiftedAlphabet = ShiftAlphabet(shift);
            
            var builder = new StringBuilder(text.Length);

            foreach (var item in text)
            {
                if (Alphabet.Contains(item.ToString().ToUpper()))
                {
                    var index = Alphabet.IndexOf(item.ToString().ToUpper(), StringComparison.Ordinal);
                    
                    switch (IsLower(item))
                    {
                        case true:
                            builder.Append(shiftedAlphabet[index].ToString().ToLower());
                            break;
                        default:
                            builder.Append(shiftedAlphabet[index]);
                            break;
                    }
                    
                    continue;
                }

                builder.Append(item);
            }

            return builder.ToString();
        }

        public static char[] ShiftAlphabet(int shift)
        {
            if (shift < 0)
                throw new InvalidOperationException("Shift must be greater or equal 0");

            var skip = Alphabet.Skip(shift).ToArray();

            var take = Alphabet.Take(shift).ToArray();

            var concat = skip.Concat(take).ToArray();

            return concat;
        }
    }
}