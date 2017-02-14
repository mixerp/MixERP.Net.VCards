using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class KindProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports KIND property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("KIND", vcard.Kind.ToVCardString(), true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Kind = KindLookup.Parse(token.Values[0]);
        }
    }
}