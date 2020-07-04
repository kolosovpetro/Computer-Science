using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using static CaesarСipher.Implementation.Decoder;
using static CaesarСipher.Implementation.Encoder;

namespace CaesarСipher.TDD
{
    [TestFixture]
    public class EncoderTests
    {
        [Test]
        public void EncodeTest()
        { 
            // encode test
            Encode("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD", 23)
                .Should().Be("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG");
        }
    }
}