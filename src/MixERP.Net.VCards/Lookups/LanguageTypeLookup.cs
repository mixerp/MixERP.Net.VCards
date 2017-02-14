using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    internal static class LanguageTypeLookup
    {
        private static readonly Dictionary<LanguageType, string> Lookup = new Dictionary<LanguageType, string>
        {
            {LanguageType.Home, "home"},
            {LanguageType.Work, "work"},
            {LanguageType.Unknown, "unknown"}
        };

        internal static string ToVCardString(this LanguageType type)
        {
            return Lookup[type];
        }

        internal static LanguageType Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return LanguageType.Unknown;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}