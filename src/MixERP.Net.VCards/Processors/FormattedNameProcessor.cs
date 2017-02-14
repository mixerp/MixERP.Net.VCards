using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class FormattedNameProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("FN", vcard.FormattedName, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.FormattedName = token.Values[0];
        }
    }
}