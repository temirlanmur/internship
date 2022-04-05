using Discounts.Interfaces;

namespace Discounts.Clients.NewClient
{
    public class NewClient : BaseClient, IClient
    {
        private NewClient() { }

        public static NewClient Create()
        {
            var client = new NewClient
            {
                _discountCalculator = new NewClientDiscountCalculator()
            };

            return client;
        }

        public decimal CalculateDiscount() => _discountCalculator.Calculate();
    }
}
