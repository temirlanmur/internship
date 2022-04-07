namespace Discounts
{
    public static class ClientFactory
    {
        /// <summary>
        /// Creates client instance of provided type.
        /// Returns null, if clientType is not defined
        /// </summary>
        /// <param name="clientType"></param>        
        /// <returns></returns>
        public static IClient? Create(string clientType)
        {
            if (Constants.Calculators.ContainsKey(clientType))
                return new BasicClient(Constants.Calculators[clientType]);
            else
                return null;
        }
    }
}
