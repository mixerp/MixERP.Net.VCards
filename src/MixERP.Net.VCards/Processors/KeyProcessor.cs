using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class KeyProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //The property "KEY" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return Base64StringProcessor.SerializeBase64String(vcard.Key, "KEY", string.Empty, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Key = token.Values[0];
        }
    }
}