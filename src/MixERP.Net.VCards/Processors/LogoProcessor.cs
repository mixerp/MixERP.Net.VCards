using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    public static class LogoProcessor
    {
        public static string Serialize(VCard vcard)
        {
            return Base64StringProcessor.SerializeBase64String(vcard.Logo, "LOGO", "GIF", vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Logo = token.Values[0];
        }
    }
}