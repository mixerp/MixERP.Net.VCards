using System;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class LastRevisionProcessor
    {
        internal static string Serialize(DateTime? value, VCardVersion version)
        {
            return DateTimeProcessor.Serialize(value, "REV", version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var date = DateTimeProcessor.Parse(value);
            vcard.LastRevision = date;
        }
    }
}