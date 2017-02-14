using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class TitleProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("TITLE", vcard.Title, false, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Title = token.Values[0];
        }
    }
}