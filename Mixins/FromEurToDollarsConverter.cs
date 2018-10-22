using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    class FromEurToDollarsConverter : ICurrencyConverter
    {
        private readonly double currentRate = 1.15;
        public double ConvertCurrency(double amount)
        {
            return amount * currentRate;
        }
    }
}
