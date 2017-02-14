using System.Collections.Generic;

namespace MixERP.Net.VCards.Models
{
    public class Token
    {
        public string Key { get; set; }
        public Dictionary<string, string> AdditionalKeyMembers { get; set; }
        public string[] Values { get; set; }
    }
}