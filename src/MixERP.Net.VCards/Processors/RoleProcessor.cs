using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class RoleProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("ROLE", vcard.Role, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Role = token.Values[0];
        }
    }
}