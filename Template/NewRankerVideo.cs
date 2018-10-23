using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Template
{
    class NewRankerVideo : Video
    {
        public NewRankerVideo(string url, string searchTerm, string title, int views)
            : base(url, searchTerm, title, views) { }

        protected override string GetAlgorithmDescription() => "The new Panda SERP algorithm";

        protected override bool IsSpammy(string topic, IWebResource webResource)
        {
            List<string> words = webResource.Content.Split(' ').ToList();
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
