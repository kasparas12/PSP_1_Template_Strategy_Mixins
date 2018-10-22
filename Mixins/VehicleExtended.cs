using System;

namespace Mixins
{
    public class VehicleExtended : Vehicle, ITaxCalculator, IEUCriteriaEvaluator, ICurrencyConverter
    {
        private ITaxCalculator _tc;
        private IEUCriteriaEvaluator _ea;
        private ICurrencyConverter _cc;

        public VehicleExtended(string brand, string model, int year, int price, Fuel fuel, int run, DateTime checkUpDate, ITaxCalculator tc, IEUCriteriaEvaluator ea, ICurrencyConverter cc)
        :base(brand, model, year, price, fuel, run, checkUpDate)
        {
            _tc = tc;
            _ea = ea;
            _cc = cc;
        }
        public double CalculateTaxes(decimal amount)
        {
            return _tc.CalculateTaxes(amount);
        }

        public double ConvertCurrency(double amount)
        {
            return _cc.ConvertCurrency(amount);
        }

        public bool IsEUCriteriaMatched(int age)
        {
            return _ea.IsEUCriteriaMatched(age);
        }
    }
}
