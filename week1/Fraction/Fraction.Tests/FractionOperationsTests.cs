using FractionConsole;
using System;
using Xunit;

namespace Fractions.Tests
{
    public class FractionOperationsTests
    {
        [Fact]
        public void Fraction_Sum_Is_Computed_Correctly()
        {
            // Arrange
            var fractionA = Fraction.Create(3, 4);
            var fractionB = Fraction.Create(5, 6);
            var expectedResult = Fraction.Create(19, 12);

            // Act
            var sum = fractionA.Add(fractionB);

            // Assert
            Assert.Equal(expectedResult, sum);
        }

        [Fact]
        public void Fraction_Difference_Is_Computed_Correctly()
        {
            // Arrange
            var fractionA = Fraction.Create(3, -4);
            var fractionB = Fraction.Create(5, 6);
            var expectedResult = Fraction.Create(-19, 12);

            // Act
            var sum = fractionA.Substract(fractionB);

            // Assert
            Assert.Equal(expectedResult, sum);
        }

        [Fact]
        public void Fraction_Multiplication_Is_Computed_Correctly()
        {
            // Arrange
            var fractionA = Fraction.Create(194, 256);
            var fractionB = Fraction.Create(400, 544);
            var expectedResult = Fraction.Create(2425, 4352);

            // Act
            var sum = fractionA.Multiply(fractionB);

            // Assert
            Assert.Equal(expectedResult, sum);
        }

        [Fact]
        public void Fraction_Division_Is_Computed_Correctly()
        {
            // Arrange
            var fractionA = Fraction.Create(-9, 5);
            var fractionB = Fraction.Create(3, 25);
            var expectedResult = Fraction.Create(-15, 1);

            // Act
            var sum = fractionA.Divide(fractionB);

            // Assert
            Assert.Equal(expectedResult, sum);
        }

        [Fact]
        public void Division_By_Zero_Throws_Exception()
        {
            // Arrange
            var fractionA = Fraction.Create(3, -4);
            var fractionB = Fraction.Create(0, 6);            

            // Assert
            Assert.Throws<DivideByZeroException>(() => fractionA.Divide(fractionB));
        }

        [Theory]
        [InlineData(3, 4, 0.75)]
        [InlineData(15, -150, -0.1)]
        [InlineData(0, 7, 0)]
        public void Conversion_To_Double_Works_Correctly(
            int numerator, 
            int denominator, 
            double expected)
        {
            // Arrange
            var fraction = Fraction.Create(numerator, denominator);
            
            // Act
            var toDouble = fraction.ToDouble();

            // Assert
            Assert.Equal(expected, toDouble);
        }
    }
}