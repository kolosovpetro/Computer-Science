using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using static CaesarСipher.Implementation.Decoder;

namespace CaesarСipher.TDD
{
    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        public void SkipTakeConcatTest()
        {
            const int shift = 23;
            var skip = Alphabet.Skip(shift).ToArray();
            skip.Length.Should().Be(3);
            skip[0].Should().Be('X');
            skip[1].Should().Be('Y');
            skip[2].Should().Be('Z');

            var take = Alphabet.Take(shift).ToArray();
            take.Length.Should().Be(23);
            take[0].Should().Be('A');
            take[22].Should().Be('W');

            var concat = skip.Concat(take).ToArray();
            concat.Length.Should().Be(26);
            concat[0].Should().Be('X');
            concat[1].Should().Be('Y');
            concat[2].Should().Be('Z');
            concat[25].Should().Be('W');
        }
        
        [Test]
        public void ShiftAlphabetTest()
        {
            Action act = () => ShiftAlphabet(-1);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Shift must be greater or equal 0");

            var shiftedAlphabet = ShiftAlphabet(23);
            shiftedAlphabet.Length.Should().Be(26);
            shiftedAlphabet[0].Should().Be('X');
            shiftedAlphabet[1].Should().Be('Y');
            shiftedAlphabet[2].Should().Be('Z');
            shiftedAlphabet[25].Should().Be('W');
        }
        
        [Test]
        public void DecodeTest()
        {
            Action act = () => Decode("abcd", -1);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Shift must be greater or equal 0");

            Decode("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 23)
                .Should().Be("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD");
        }
    }
}