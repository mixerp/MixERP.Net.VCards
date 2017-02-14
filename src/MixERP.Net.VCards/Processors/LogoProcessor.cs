using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    internal static class LogoProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return Base64ImageProcessor.SerializeBase64String(vcard.Logo, "LOGO", "GIF", vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Logo = token.Values[0];
        }
    }
}