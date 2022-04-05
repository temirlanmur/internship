using Discounts.Interfaces;

namespace Discounts.Clients.PermanentClient
{
    public class PermanentClient : BaseClient, IClient
    {
        public int OrderSize { get; set; }

        private PermanentClient() { }

        public static PermanentClient Create()
        {
            var client = new PermanentClient();
            client._discountCalculator = new PermanentClientDiscountCalculator(client);

            return client;
        }

        public decimal CalculateDiscount() => _discountCalculator.Calculate();        
    }
}
