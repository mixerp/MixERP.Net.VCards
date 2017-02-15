using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class KeyProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "KEY" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return Base64StringProcessor.SerializeBase64String(vcard.Key, "KEY", string.Empty, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Key = token.Values[0];
        }
    }
}