using Discounts.Interfaces;

namespace Discounts.Clients.PermanentClient
{
    internal class PermanentClientDiscountCalculator : IDiscountCalculator
    {
        private PermanentClient client;

        internal PermanentClientDiscountCalculator(PermanentClient client) => this.client = client;

        public decimal Calculate() => client.OrderSize > 100000 ? 0.15m : 0.1m;        
    }
}
