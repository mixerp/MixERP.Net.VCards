using System;
using System.Collections.Generic;
using System.Text;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class UrlProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            string url = vcard.Url.ToString();
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("URL", url, true, vcard.Version);
        }

        internal static string SerializeUris(IEnumerable<Uri> uris, string key, VCardVersion version)
        {
            var builder = new StringBuilder();
            if (uris == null)
            {
                return string.Empty;
            }

            int preference = 0;

            foreach (var uri in uris)
            {
                preference++;

                string memberKey = key;

                memberKey = memberKey + ";PREF=" + preference;

                builder.Append(DefaultSerializer.GetVCardString(memberKey, uri.ToString(), false, version));
            }

            return builder.ToString();
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string url = token.Values[0];
            if (!string.IsNullOrWhiteSpace(url))
            {
                vcard.Url = new Uri(url, UriKind.RelativeOrAbsolute);
            }
        }
    }
}