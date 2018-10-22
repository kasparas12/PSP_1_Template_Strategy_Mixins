using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    class NewRanker : IRanker
    {
        public string DetermineTopic(string resourceContent)
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

        public string GetAlgorithmDescription() => "The new Panda SERP algorithm";

        public bool IsSpammy(string topic, IWebResource webResource)
        {
            List<string> words = webResource.Content.Split(' ').ToList<string>();
            var totalLength = words.Count;
            int counter = 0;
            double rate;
            Console.WriteLine($"Total words: {totalLength}");
            foreach(var word in words)
            {
                if (word.Contains(topic))
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
