using System;

namespace Mixins
{
    class LTEUCriteriaEvaluator : IEUCriteriaEvaluator
    {
        private static readonly int membershipDate = 2004;

        public bool IsEUCriteriaMatched(int age)
        {
            return DateTime.Today.Year - age >= membershipDate ? true : false;
        }
    }
}
