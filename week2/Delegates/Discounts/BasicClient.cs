namespace Discounts
{
    public delegate decimal DiscountCalculator(int? orderSize = null);
    
    public class BasicClient : IClient
    {
        public int OrderSize { get; set; }
        private readonly DiscountCalculator _discountCalculator;

        /// <summary>
        /// Creates client with provided discount calculation method
        /// </summary>        
        /// <param name="discountCalculator"></param>
        public BasicClient(DiscountCalculator discountCalculator)
        {            
            _discountCalculator = discountCalculator;
        }

        public decimal CalculateDiscount() => _discountCalculator(OrderSize);        
    }
}
