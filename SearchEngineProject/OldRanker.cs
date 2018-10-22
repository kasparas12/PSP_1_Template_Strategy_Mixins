using System;
using System.Collections.Generic;
using System.Configuration;
using HtmlAgilityPack;

namespace SearchEngineProject
{
    class OldRanker : IRanker
    {
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


        // Determine topic according <title> tag
        public string DetermineTopic(string resourceContent)
        {
            var titleStart = resourceContent.IndexOf("<title>");
            var titleEnd = resourceContent.IndexOf("</title>");
            string topic = String.Empty;
            if (titleStart == -1 || titleEnd == -1)
            {
                topic = "undefinedTopic";
                return topic;
            } else
            {
                topic = resourceContent.Substring(titleStart + 7, titleEnd - titleStart - 7);
                return topic;
            }
        }

        public string GetAlgorithmDescription() => "Old and not effective SERP algorithm";

        // Checking for blacklisted words in url, content, topic
        public bool IsSpammy(string topic, IWebResource webResource)
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
