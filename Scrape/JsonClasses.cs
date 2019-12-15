using System;
using System.Collections.Generic;
using System.Text;

namespace Scrape
{
    
    public class Groups
    {
        public string id { get; set; }
        public string prop_num { get; set; }
        public string name { get; set; }
        public string parent_id { get; set; }
        public string mid_price { get; set; }
        public string mid_change { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Match_data
    {
    }

    public class Val
    {
        public List<Groups> groups { get; set; }
        public List<Match_data> match_data { get; set; }
    }

    public class RootObject
    {
        public string code { get; set; }
        public string msg { get; set; }
        public Val val { get; set; }
    }
    
}
