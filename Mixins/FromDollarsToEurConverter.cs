namespace Mixins
{
    class FromDollarsToEurConverter : ICurrencyConverter
    {
        private readonly double currentRate = 0.866;
        public double ConvertCurrency(double amount)
        {
            return amount * currentRate;
        }
    }
}
