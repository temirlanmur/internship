namespace Discounts.Interfaces
{
    /// <summary>
    /// Defines client's methods
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Returns discount for the client
        /// </summary>
        /// <returns></returns>
        decimal CalculateDiscount();      
    }
}
