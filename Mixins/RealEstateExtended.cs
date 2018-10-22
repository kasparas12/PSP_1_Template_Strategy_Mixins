using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public class RealEstateExtended : RealEstate, ITaxCalculator, IEUCriteriaEvaluator, ICurrencyConverter
    {
        private ITaxCalculator _tc;
        private IEUCriteriaEvaluator _ea;
        private ICurrencyConverter _cc;

        public RealEstateExtended(string name, decimal price, int age, string location, int width, int height, ITaxCalculator tc, IEUCriteriaEvaluator ea, ICurrencyConverter cc)
        : base(name, price, age, location, width, height)
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
