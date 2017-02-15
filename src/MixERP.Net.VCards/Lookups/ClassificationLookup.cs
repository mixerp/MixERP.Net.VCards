using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    public static class ClassificationLookup
    {
        private static readonly Dictionary<ClassificationType, string> Lookup = new Dictionary<ClassificationType, string>
        {
            {ClassificationType.Confidential, "CONFIDENTIAL"},
            {ClassificationType.Private, "PRIVATE"},
            {ClassificationType.Public, "PUBLIC"}
        };

        public static string ToVCardString(ClassificationType type)
        {
            return Lookup[type];
        }

        public static ClassificationType Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return ClassificationType.Private;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}