using System;

namespace Template
{
    abstract class Website : IWebResource
    {
        private static readonly int _premiumCriteria = 5000;

        public string Url { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public int CurrentPosition { get; set; }
        public string SearchTerm { get; set; }
        public int TrafficPerMonth { get; set; }
        public bool IsPremium { get; set; }

        public Website(string url, int age, string location, int currentPosition, string searchTerm, int trafficPerMonth)
        {
            Url = url;
            Age = age;
            Location = location;
            CurrentPosition = currentPosition;
            SearchTerm = searchTerm;
            TrafficPerMonth = trafficPerMonth;
        }

        public bool CheckForPremiumStatus()
        {
            var value = EstimateWorth(this);
            Console.WriteLine($"Estimated website value: {value}");
            if (value > _premiumCriteria)
            {
                IsPremium = true;
                Console.WriteLine("Site applicable to premium");
            }
            else
            {
                IsPremium = false;
                Console.WriteLine("Site not applicable to premium");
            }
            return IsPremium;
        }

        public int RecalculateSERP()
        {
            var websiteTopic = getWebsiteTopic();

            if (!isWebSpammy(websiteTopic))
            {
                alterRanking(true);
            }
            else
            {
                alterRanking(false);
            }

            return CurrentPosition;
        }

        private string getWebsiteTopic()
        {
            var topic = DetermineTopic(Content);
            Console.WriteLine($"Website topic: {topic}");
            return topic;
        }

        private bool isWebSpammy(string websiteTopic)
        {
            bool isSpammy = IsSpammy(websiteTopic, this);
            Console.WriteLine($"This website is considered spammy ? {isSpammy}");
            return isSpammy;
        }

        private void alterRanking(bool up)
        {
            Console.WriteLine($"Previous rank: {CurrentPosition}");
            if (up)
            {
                if (CurrentPosition > 1)
                {
                    CurrentPosition--;
                    Console.WriteLine($"Website went up after checking with {GetAlgorithmDescription()} algorithm");
                }
            }
            else
            {
                CurrentPosition++;
                Console.WriteLine($"Website went down after checking with {GetAlgorithmDescription()} algorithm");
            }
        }

        abstract protected string DetermineTopic(string resourceContent);
        abstract protected bool IsSpammy(string topic, IWebResource webResouece);
        abstract protected string GetAlgorithmDescription();
        abstract protected double EstimateWorth(Website website);
    }
}
