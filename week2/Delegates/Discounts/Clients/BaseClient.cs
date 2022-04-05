using Discounts.Interfaces;

namespace Discounts.Clients
{
    /// <summary>
    /// Stores some common functionality for different client types
    /// </summary>
    public class BaseClient
    {
        internal IDiscountCalculator? _discountCalculator;
    }
}
