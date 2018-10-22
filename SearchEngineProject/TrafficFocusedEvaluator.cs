using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    class TrafficFocusedEvaluator : IEvaluator
    {
        private readonly static int thousandRate = 5;
        public double EstimateWorth(Website website)
        {
            return website.TrafficPerMonth / 1000 * thousandRate;
        }
    }
}
