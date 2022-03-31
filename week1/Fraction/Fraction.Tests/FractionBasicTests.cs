using FractionConsole;
using System;
using Xunit;

namespace Fractions.Tests
{
    public class FractionBasicTests
    {
        [Theory]
        [InlineData(7)]
        [InlineData(-11)]
        [InlineData(0)]
        public void Creating_Fraction_With_0_Denominator_Throws_Exception(int numerator)
        {            
            Assert.Throws<ArgumentException>(() => Fraction.Create(numerator, 0));
        }

        [Theory]
        [InlineData(75, 100, 3, 4)]
        [InlineData(22, -11, -2, 1)]
        [InlineData(-578, -19074, 1, 33)]
        [InlineData(0, -33, 0, 1)]
        public void Fraction_Is_Reduced_Correctly(
            int fractionNumerator,
            int fractionDenominator,
            int reducedNumerator,
            int reducedDenominator)
        {
            // Act
            var fraction = Fraction.Create(fractionNumerator, fractionDenominator);

            // Assert
            Assert.Equal(reducedNumerator, fraction.Numerator);
            Assert.Equal(reducedDenominator, fraction.Denominator);
        }
    }
}
