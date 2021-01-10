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

        public string json { get; set; }

        
    }
}