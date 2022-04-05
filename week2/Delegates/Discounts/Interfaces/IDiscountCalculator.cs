namespace Discounts.Interfaces
{
    /// <summary>
    /// Defines discount calculation method, which implementation depends on client's type
    /// </summary>
    public interface IDiscountCalculator
    {
        /// <summary>
        /// Calculates discount
        /// </summary>
        /// <returns>Discount as a decimal</returns>
        decimal Calculate();
    }
}
