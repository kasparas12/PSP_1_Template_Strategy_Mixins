namespace Mixins
{
    class PolandIncomeTaxCalculator : ITaxCalculator
    {
        private static readonly double minIncomeTax = 0.18;
        private static readonly double maxIncomeTax = 0.32;

        public double CalculateTaxes(decimal amount)
        {
            if (amount > 85000)
            {
                return (int)amount * maxIncomeTax;
            }
            else
            {
                return (int)amount * minIncomeTax;
            }
        }
    }
}
