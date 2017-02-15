using System;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class LastRevisionProcessor
    {
        public static string Serialize(DateTime? value, VCardVersion version)
        {
            return DateTimeProcessor.Serialize(value, "REV", version);
        }

        public static void Parse(Token token, ref VCard vcard)
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