using System;
using System.Collections.Generic;
using System.Linq;


namespace Template
{
    class NewRankerSiteMetricsFocusedEvaluatorWebsite : Website
    {

        private readonly static List<string> specialCountries = new List<string>()
        {
            "USA",
            "Germany",
            "United Kingdom",
            "Canada",
            "Spain"
        };

        public NewRankerSiteMetricsFocusedEvaluatorWebsite(string url, int age, string location, int currentPosition, string searchTerm, int trafficPerMonth)
        : base(url, age, location, currentPosition, searchTerm, trafficPerMonth) { }

        protected override string DetermineTopic(string resourceContent)
        {
            var titleStart = resourceContent.IndexOf("<h1>");
            var titleEnd = resourceContent.IndexOf("</h1>");
            string topic = String.Empty;
            if (titleStart == -1 || titleEnd == -1)
            {
                topic = "undefinedTopic";
                return topic;
            }
            else
            {
                topic = resourceContent.Substring(titleStart + 4, titleEnd - titleStart - 4);
                return topic;
            }
        }

        protected override double EstimateWorth(Website website)
        {
            double worth = 0;
            if (website.Age > 5)
            {
                worth += 1000 * website.Age;
            }
            else
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

        protected override string GetAlgorithmDescription() => "The new Panda SERP algorithm";

        protected override bool IsSpammy(string topic, IWebResource webResource)
        {
            List<string> words = webResource.Content.Split(' ').ToList<string>();
            var totalLength = words.Count;
            int counter = 0;
            double rate;
            Console.WriteLine($"Total words: {totalLength}");
            foreach (var word in words)
            {
                if (topic.Contains(word))
                {
                    counter++;
                    rate = (double)((double)counter / (double)totalLength);
                    if (rate > 0.05)
                    {
                        Console.WriteLine($"Detected topic frequency rate is: {rate}, it is spammy rate!!");
                        return true;
                    }
                }
            }
            rate = (double)((double)counter / (double)totalLength);
            Console.WriteLine($"Detected topic frequency rate is: {rate}, it is normal rate");
            return false;
        }
    }
}
