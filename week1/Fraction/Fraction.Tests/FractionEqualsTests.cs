using FractionConsole;
using Xunit;

namespace Fractions.Tests
{
    public class FractionEqualsTests
    {
        [Theory]
        [InlineData(1, 2, 0.5d, true)]
        [InlineData(1, 2, 0.5f, true)]        
        [InlineData(2, 1, 2, true)]
        [InlineData(1, 2, 0.7d, false)]
        [InlineData(1, 2, 0.7f, false)]
        [InlineData(2, 1, 7, false)]
        public void Fraction_Equals_Method_Works_Correctly_With_Numeric_Types(
            int fractionNumerator,
            int fractionDenominator,
            object objToCompare,
            bool comparisonResult)
        {
            // Arrange
            var fraction = Fraction.Create(fractionNumerator, fractionDenominator);
            
            // Act
            var result = fraction.Equals(objToCompare);

            // Assert
            Assert.Equal(comparisonResult, result);
        }

        [Theory]
        [InlineData(1, 2, 11, 22, true)]
        [InlineData(-3, 9, 1, -3, true)]
        [InlineData(0, 150, 0, 2, true)]
        [InlineData(1, 2, 3, 4, false)]        
        public void Fraction_Equals_Method_Works_Correctly_With_Other_Fractions(
            int fractionANumerator,
            int fractionADenominator,
            int fractionBNumerator,
            int fractionBDenominator,
            bool comparisonResult)
        {
            // Arrange
            var fractionA = Fraction.Create(fractionANumerator, fractionADenominator);
            var fractionB = Fraction.Create(fractionBNumerator, fractionBDenominator);

            // Act
            var result = fractionA.Equals(fractionB);

            // Assert
            Assert.Equal(comparisonResult, result);
        }
    }
}
