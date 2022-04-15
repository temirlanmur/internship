namespace LINQConsole
{
    public class Consumer
    {
        public int Code { get; set; }
        public int YearOfBirth { get; set; }
        public string Address { get; set; }
    }

    public class Article
    {
        public string Number { get; set; }
        public string Category { get; set; }
        public string CountryOfOrigin { get; set; }
    }

    public class Discount
    {
        public int ConsumerCode { get; set; }
        public string StoreName { get; set; }
        public int Value { get; set; }
    }

    public class Price
    {
        public string ArticleNumber { get; set; }
        public string StoreName { get; set; }
        public int Value { get; set; }
    }

    public class Purchase
    {
        public int ConsumerCode { get; set; }
        public string ArticleNumber { get; set; }
        public string StoreName { get; set; }        
    }

}
