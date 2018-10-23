using System;

namespace Template
{
    abstract class Video : IWebResource
    {
        public string Url { get; set; }
        public string Content { get; set; }
        public string SearchTerm { get; set; }
        public string Title { get; set; }
        public int Views { get; set; }
        private bool _deleted;
        public Video(string url, string searchTerm, string title, int views)
        {
            Url = url;
            SearchTerm = searchTerm;
            Title = title;
            Views = views;
        }

        public bool ToBeSuspended()
        {
            Console.WriteLine($"Checking video using {GetAlgorithmDescription()}");
            if (IsSpammy(Title, this))
            {
                Console.WriteLine("Content does not match title, video will be removed");
                _deleted = true;
                return true;
            }
            else
            {
                Console.WriteLine("Content match title, video will not be removed");
                _deleted = false;
                return false;
            }
        }

        abstract protected bool IsSpammy(string topic, IWebResource webResouece);
        abstract protected string GetAlgorithmDescription();
    }
}
