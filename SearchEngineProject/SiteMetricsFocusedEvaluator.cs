using System.Collections.Generic;

namespace SearchEngineProject
{
    class SiteMetricsFocusedEvaluator : IEvaluator
    {
        private readonly static List<string> specialCountries = new List<string>()
        {
            "USA",
            "Germany",
            "United Kingdom",
            "Canada",
            "Spain"
        };
        public double EstimateWorth(Website website)
        {
            double worth = 0;
            if (website.Age > 5)
            {
                worth += 1000 * website.Age;
            } else
            {
                worth += 200 * website.Age;
            }

            foreach (var country in specialCountries)
            {
                if (country == website.Location)
                {
                    worth += 5000;
                }
            }

            return worth;
        }
    }
}
