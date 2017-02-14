using System;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Models
{
    public sealed class Relation
    {
        public RelationType Type { get; set; }
        public int Preference { get; set; }
        public Uri RelationUri { get; set; }
    }
}