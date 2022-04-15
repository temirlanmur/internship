// TASK:
// For each country (product manufactor) and each store, determine the consumer with the highest year of birth
// who bought one or more goods produced in this country in this store (first, the name of the country, then
// the name of the store, then the year of birth of the consumer, his code, and also the total cost goods from
// this country purchased in this store). If there is no information about sold goods for some "country-shop"
// pair, then data about this pair is not displayed. If for some pair "country-store" there are several consumers
// with the highest year of birth, then data about all such consumers should be displayed. Information about
// each triple "country-shop-consumer" should be displayed on a new line and sorted by country names in
// alphabetical order, for identical country names - by store names (also in alphabetical order), and for
// identical stores - by increasing consumer codes. 

using LINQConsole;

var consumers = new List<Consumer>();
var articles = new List<Article>();
var discounts = new List<Discount>();
var prices = new List<Price>();
var purchases = new List<Purchase>();

// Step 1: group purchases in order to obtain the amount of duplicates
var purchasesCounted =
        from purchase in purchases
        group purchase by new { purchase.ConsumerCode, purchase.ArticleNumber, purchase.StoreName } into g
        let count = g.Count()
        select new
        {
            g.Key.ConsumerCode,
            g.Key.ArticleNumber,
            g.Key.StoreName,
            Count = count
        };

// Step 2: join on prices
var purchasesWithPrices = 
        from purchase in purchasesCounted
        join price in prices
        on new { purchase.ArticleNumber, purchase.StoreName } equals new { price.ArticleNumber, price.StoreName }        
        select new { 
            ConsumerCode = purchase.ConsumerCode, 
            ArticleNumber = purchase.ArticleNumber,
            StoreName = purchase.StoreName,
            Price = price.Value,
            Count = purchase.Count
        };

// Step 3: join on discounts, if any, and compute total expenditure
var discountedPurchases = 
        from purchase in purchasesWithPrices
        join discount in discounts
        on new { purchase.ConsumerCode, purchase.StoreName } equals new { discount.ConsumerCode, discount.StoreName } into gj
        from discount in gj.DefaultIfEmpty()
        select new
        {
            ConsumerCode = purchase.ConsumerCode,
            ArticleNumber = purchase.ArticleNumber,
            StoreName = purchase.StoreName,
            Expenditure = (discount == null) ? (purchase.Price * purchase.Count) : (purchase.Price * (100 - discount.Value) / 100 * purchase.Count)
        };

// Step 4: join on other tables to get information about the article and consumer
var query =
        from purchase in discountedPurchases
        join article in articles
        on purchase.ArticleNumber equals article.Number        
        join consumer in consumers
        on purchase.ConsumerCode equals consumer.Code
        orderby article.CountryOfOrigin
        orderby purchase.StoreName
        select new
        {
            Country = article.CountryOfOrigin,
            StoreName = purchase.StoreName,
            ConsumerYearOfBirth = consumer.YearOfBirth,
            ConsumerCode = purchase.ConsumerCode,
            Expenditure = purchase.Expenditure
        };

// Step 5: retrieve those with highest year of birth
var result =
        from expenditure in query
        group expenditure by new { expenditure.Country, expenditure.StoreName } into g
        from x in g
        where x.ConsumerYearOfBirth == g.Max(x => x.ConsumerYearOfBirth)
        select new
        {
            x.Country,
            x.StoreName,
            x.ConsumerYearOfBirth,
            x.ConsumerCode,
            x.Expenditure
        };
        