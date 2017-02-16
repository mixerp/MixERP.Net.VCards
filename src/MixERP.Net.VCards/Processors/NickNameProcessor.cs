using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class NickNameProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.NickName))
            {
                return string.Empty;
            }

            //The property "NICKNAME" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("NICKNAME", vcard.NickName, false, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.NickName = token.Values[0];
        }
    }
}