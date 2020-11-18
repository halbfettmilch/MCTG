using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class RequestContext
    {   // the requestet context to interact with
        public string http_verb { get; set; }

        public string requested { get; set; }

        public string http_version { get; set; }

        public SortedDictionary<string, string> data { get; set; }

        public List <SortedDictionary<string, string>> payload { get; set; }

        public RequestContext()
        {
            payload= new List<SortedDictionary<string, string>>();
        }
    }
}