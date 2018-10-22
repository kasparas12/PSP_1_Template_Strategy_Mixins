using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    interface IRanker
    {
        string DetermineTopic(string resourceContent);
        bool IsSpammy(string topic, IWebResource webResource);
        string GetAlgorithmDescription();
    }
}
