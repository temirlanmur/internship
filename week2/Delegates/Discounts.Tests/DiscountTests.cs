using Xunit;

namespace Discounts.Tests
{
    public class DiscountTests
    {
        [Fact]
        public void Calculates_Correct_Discount_For_New_Client()
        {
            // Arrange
            var client = ClientFactory.Create("new");
            client.OrderSize = 1;
            var expectedDiscount = 0m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Calculates_Correct_Discount_For_Permanent_Client_With_Large_Order_1()
        {
            // Arrange
            var client = ClientFactory.Create("permanentLarge");
            client.OrderSize = 100001;
            var expectedDiscount = .15m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Calculates_Correct_Discount_For_Permanent_Client_With_Large_Order_2()
        {
            // Arrange
            var client = ClientFactory.Create("permanentLarge");
            client.OrderSize = 20;
            var expectedDiscount = .1m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Calculates_Correct_Discount_For_Permanent_Client_With_Small_Order()
        {
            // Arrange
            var client = ClientFactory.Create("permanentSmall");
            client.OrderSize = 20;
            var expectedDiscount = .05m;

            // Act
            var clientDiscount = client.CalculateDiscount();

            // Assert
            Assert.Equal(expectedDiscount, clientDiscount);
        }

        [Fact]
        public void Creates_Null_If_Client_Type_Does_Not_Exist()
        {
            // Arrange
            var client = ClientFactory.Create("someRandomType");
            
            // Assert
            Assert.Null(client);
        }
    }
}