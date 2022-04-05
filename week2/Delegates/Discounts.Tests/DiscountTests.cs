using Discounts.Clients.NewClient;
using Discounts.Clients.PermanentClient;
using Xunit;

namespace Discounts.Tests
{
    public class DiscountTests
    {
        [Fact]
        public void Calculates_Correct_Discount_For_New_Client()
        {
            // Arrange
            var client = NewClient.Create();
            var expectedDiscount = 0m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Calculates_Correct_Discount_For_Permanent_Client()
        {
            // Arrange
            var client = PermanentClient.Create();
            var expectedDiscount = 0.1m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Calculates_Correct_Discount_For_Permanent_Client_With_Large_Order_Size()
        {
            // Arrange
            var client = PermanentClient.Create();
            client.OrderSize = 100001;
            var expectedDiscount = 0.15m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }
    }
}