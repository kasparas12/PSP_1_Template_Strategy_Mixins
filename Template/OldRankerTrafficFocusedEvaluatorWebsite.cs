using System;
using System.Collections.Generic;

namespace Template
{
    class OldRankerTrafficFocusedEvaluatorWebsite : Website
    {
        private readonly static int thousandRate = 5;
        private static readonly List<string> blackList = new List<string>()
        {
            "Drugs",
            "Alcohol",
            "Guns",
            "Violence",
            "Pornography",
            "Gambling",
            "Casino"
        };

        public OldRankerTrafficFocusedEvaluatorWebsite(string url, int age, string location, int currentPosition, string searchTerm, int trafficPerMonth)
        : base(url,age,location,currentPosition,searchTerm,trafficPerMonth) { }

        protected override string DetermineTopic(string resourceContent)
        {
            var titleStart = resourceContent.IndexOf("<title>");
            var titleEnd = resourceContent.IndexOf("</title>");
            string topic = String.Empty;
            if (titleStart == -1 || titleEnd == -1)
            {
                topic = "undefinedTopic";
                return topic;
            }
            else
            {
                topic = resourceContent.Substring(titleStart + 7, titleEnd - titleStart - 7);
                return topic;
            }
        }

        protected override double EstimateWorth(Website website)
        {
            return website.TrafficPerMonth / 1000 * thousandRate;
        }

        protected override string GetAlgorithmDescription() => "Old and not effective SERP algorithm";

        protected override bool IsSpammy(string topic, IWebResource webResource)
        {
            foreach (var word in blackList)
            {
                if (topic.ToLower().Contains(word.ToLower()) || webResource.Content.ToLower().Contains(word.ToLower()) || webResource.Url.ToLower().Contains(word.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
