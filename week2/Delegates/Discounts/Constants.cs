namespace Discounts
{    
    static class Constants
    {
        /// <summary>
        /// Defines discount calculation methods for the clients
        /// </summary>        
        internal static readonly Dictionary<string, DiscountCalculator> Calculators = new()
        {
            { "new", (_) => 0m },
            { "permanentLarge", (orderSize) => orderSize > 100000 ? .15m : .1m },
            { "permanentSmall", (_) => .05m }
        };
    }
}
