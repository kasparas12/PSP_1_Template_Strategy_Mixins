using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    interface IWebResource
    {
        string Url { get; set; }
        string Content { get; set; }
        string SearchTerm { get; set; }

    }
}
