using System;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class SourceUriProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports SOURCE property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            if (vcard.Source == null)
            {
                return string.Empty;
            }

            string source = vcard.Source.ToString();

            return DefaultSerializer.GetVCardString("SOURCE", source, false, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];

            if (!string.IsNullOrWhiteSpace(value))
            {
                vcard.Source = new Uri(value, UriKind.RelativeOrAbsolute);
            }
        }
    }
}