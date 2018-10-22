namespace Mixins
{
    class LithuaniaIncomeTaxCalculator : ITaxCalculator
    {
        private static readonly double incomeTax = 0.15;
        public double CalculateTaxes(decimal amount)
        {
            return (int)amount * incomeTax;
        }
    }
}
