using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    public static class RelationTypeLookup
    {
        private static readonly Dictionary<RelationType, string> Lookup = new Dictionary<RelationType, string>
        {
            {RelationType.Contact, "contact"},
            {RelationType.Acquaintance, "acquaintance"},
            {RelationType.Friend, "friend"},
            {RelationType.Met, "met"},
            {RelationType.CoWorker, "co-worker"},
            {RelationType.Colleague, "colleague"},
            {RelationType.CoResident, "co-resident"},
            {RelationType.Neighbor, "neighbor"},
            {RelationType.Child, "child"},
            {RelationType.Parent, "parent"},
            {RelationType.Sibling, "sibling"},
            {RelationType.Spouse, "spouse"},
            {RelationType.Kin, "kin"},
            {RelationType.Muse, "muse"},
            {RelationType.Crush, "crush"},
            {RelationType.Date, "date"},
            {RelationType.Sweetheart, "sweetheart"},
            {RelationType.Me, "me"},
            {RelationType.Agent, "agent"},
            {RelationType.Emergency, "emergency"}
        };

        public static string ToVCardString(this RelationType type)
        {
            return Lookup[type];
        }

        public static RelationType Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return RelationType.Contact;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}