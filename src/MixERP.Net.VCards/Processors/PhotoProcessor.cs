using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    public static class PhotoProcessor
    {
        public static string Serialize(VCard vcard)
        {
            return Base64StringProcessor.SerializeBase64String(vcard.Photo, "PHOTO", "GIF", vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Photo = token.Values[0];
        }
    }
}