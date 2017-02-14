using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class NickNameProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //The property "NICKNAME" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("NICKNAME", vcard.NickName, false, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.NickName = token.Values[0];
        }
    }
}