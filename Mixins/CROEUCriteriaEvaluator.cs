using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    class CROEUCriteriaEvaluator : IEUCriteriaEvaluator
    {
        private static readonly int membershipDate = 2013;

        public bool IsEUCriteriaMatched(int age)
        {
            return DateTime.Today.Year - age >= membershipDate ? true : false;
        }
    }
}
