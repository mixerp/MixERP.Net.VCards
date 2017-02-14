using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    internal static class EmailTypeLookup
    {
        private static readonly Dictionary<EmailType, string> Lookup = new Dictionary<EmailType, string>
        {
            {EmailType.AmericaOnline, "AOL"},
            {EmailType.AppleLink, "AppleLink"},
            {EmailType.ATTMail, "ATTMail"},
            {EmailType.CompuServeInformationServices, "CIS"},
            {EmailType.EWorld, "eWorld"},
            {EmailType.Smtp, "INTERNET"},
            {EmailType.IBMMail, "IBMMail"},
            {EmailType.MCIMail, "MCIMail"},
            {EmailType.PowerShare, "POWERSHARE"},
            {EmailType.Prodigy, "PRODIGY"},
            {EmailType.Telex, "TLX"},
            {EmailType.X400, "X400"}
        };

        internal static string ToVCardString(this EmailType type)
        {
            return Lookup[type];
        }

        internal static string ToVCardString(this EmailType? type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            return Lookup[type.Value];
        }

        internal static EmailType Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return EmailType.Smtp;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}