using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class SoundProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "SOUND" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return Base64StringProcessor.SerializeBase64String(vcard.Sound, "SOUND", "BASIC", vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Sound = token.Values[0];
        }
    }
}