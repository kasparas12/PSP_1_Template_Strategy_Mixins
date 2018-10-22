using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    class LTEUAgeEvaluator : IEUCriteriaEvaluator
    {
        private static readonly int _dateOfMembership = 2004;
        public bool IsEUCriteriaMatched(int age)
        {
            return age > _dateOfMembership ? true : false;
        }
    }
}
