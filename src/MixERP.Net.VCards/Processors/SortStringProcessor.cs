using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class SortStringProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //Please note that the property "SORT-STRING" only exists for VCardVersion 3.0
            //where VCardVersion 4.0 uses "SORT-AS" key in N property
            if (vcard.Version != VCardVersion.V3)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(vcard.SortString))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("SORT-STRING", vcard.SortString, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            if (!string.IsNullOrWhiteSpace(vcard.SortString))
            {
                return;
            }

            vcard.SortString = token.Values[0];
        }
    }
}