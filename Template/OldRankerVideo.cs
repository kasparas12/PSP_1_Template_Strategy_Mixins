using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class OldRankerVideo : Video
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
        public OldRankerVideo(string url, string searchTerm, string title, int views)
            : base(url, searchTerm, title, views) { }

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
