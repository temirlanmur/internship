namespace Discounts
{
    /// <summary>
    /// Defines client's methods
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Gets & sets order size for the client
        /// </summary>
        int OrderSize { get; set; }

        /// <summary>
        /// Returns discount for the client
        /// </summary>
        /// <returns></returns>
        decimal CalculateDiscount();
    }
}
