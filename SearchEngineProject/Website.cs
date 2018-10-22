using System;

namespace SearchEngineProject
{
    class Website : IWebResource
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
        private IRanker _ranker { get; set; }
        private IEvaluator _evaluator { get; set; }

        public Website(string url, int age, string location, int currentPosition, string searchTerm, int trafficPerMonth, IRanker ranker, IEvaluator evaluator)
        {
            Url = url;
            Age = age;
            Location = location;
            CurrentPosition = currentPosition;
            SearchTerm = searchTerm;
            TrafficPerMonth = trafficPerMonth;
            _ranker = ranker;
            _evaluator = evaluator;
        }


        public bool CheckForPremiumStatus()
        {
            var value = _evaluator.EstimateWorth(this);
            Console.WriteLine($"Estimated website value: {value}");
            if (value > _premiumCriteria)
            {
                IsPremium = true;
                Console.WriteLine("Site applicable to premium");
            } else
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
            } else
            {
                alterRanking(false);
            }

            return CurrentPosition;
        }

        public void ChangeRankerStrategy(IRanker ranker)
        {
            _ranker = ranker;
        }

        public void ChangeEvaluatorStrategy(IEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        private string getWebsiteTopic()
        {
            var topic = _ranker.DetermineTopic(Content);
            Console.WriteLine($"Website topic: {topic}");
            return topic;
        }

        private bool isWebSpammy(string websiteTopic)
        {
            bool isSpammy = _ranker.IsSpammy(websiteTopic, this);
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
                    Console.WriteLine($"Website went up after checking with {_ranker.GetAlgorithmDescription()} algorithm");
                }
            }
            else
            {
                CurrentPosition++;
                Console.WriteLine($"Website went down after checking with {_ranker.GetAlgorithmDescription()} algorithm");
            }
        }
    }
}
