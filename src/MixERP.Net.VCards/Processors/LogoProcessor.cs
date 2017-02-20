using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Helpers;
using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    public static class LogoProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.Logo == null)
            {
                return string.Empty;
            }

            var extension = vcard.Logo.Extension.Coalesce("jpg");
            var mimeType = ImageMimeHelper.GetMimeType(extension);

            return Base64StringProcessor.SerializeBase64String(vcard.Logo.Contents, "LOGO", mimeType, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Logo = PhotoProcessor.GetPhoto(token, vcard);
        }
    }
}