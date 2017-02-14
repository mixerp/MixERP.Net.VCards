using System;
using System.Collections.Generic;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class CalendarAddressesProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports CALADRURI property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            return UrlProcessor.SerializeUris(vcard.CalendarAddresses, "CALURI", vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var uri = new Uri(value, UriKind.RelativeOrAbsolute);

            var urls = (List<Uri>) vcard.CalendarAddresses ?? new List<Uri>();
            urls.Add(uri);
            vcard.CalendarAddresses = urls;
        }
    }
}