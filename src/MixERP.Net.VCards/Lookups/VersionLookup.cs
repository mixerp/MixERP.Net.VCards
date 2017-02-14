using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    internal static class VersionLookup
    {
        private static readonly Dictionary<VCardVersion, string> Lookup = new Dictionary<VCardVersion, string>
        {
            {VCardVersion.V2_1, "2.1"},
            {VCardVersion.V3, "3.0"},
            {VCardVersion.V4, "4.0"}
        };

        internal static string ToVCardString(this VCardVersion addressType)
        {
            return Lookup[addressType];
        }

        internal static VCardVersion Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return VCardVersion.V2_1;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}