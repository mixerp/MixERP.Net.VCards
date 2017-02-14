using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class UidProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("UID", vcard.UniqueIdentifier, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.UniqueIdentifier = token.Values[0];
        }
    }
}