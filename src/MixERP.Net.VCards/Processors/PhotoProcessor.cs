using System;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    public static class PhotoProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if(vcard.Photo == null)
            {
                return string.Empty;
            }

            var extension = vcard.Photo.Extension.Coalesce("jpg");
            return Base64StringProcessor.SerializeBase64String(vcard.Photo.Contents, "PHOTO", extension, vcard.Version);
        }

        private static bool IsBase64(string contents)
        {
            try
            {
                byte[] converted = Convert.FromBase64String(contents);
                return true;
            }
            catch
            {
                //swallow
            }

            return false;
        }

        public static Photo GetPhoto(Token token, VCard vcard)
        {
            bool isEmbedded = false;
            string extension = "jpg";

            var data = token.Values[0];

            if (data.StartsWith("data:image", StringComparison.OrdinalIgnoreCase))
            {
                extension = data.Replace(@"data:image/", string.Empty).Coalesce("jpg");

                /*The value is expected to begin with base64,....
                For example:
                PHOTO:data:image/jpeg;base64,MIICajCCAdOgAwIBAgICBEUwDQYJKoZIhv
                AQEEBQAwdzELMAkGA1UEBhMCVVMxLDAqBgNVBAoTI05ldHNjYXBlIENvbW11bm
                ljYXRpb25zIENvcnBvcmF0aW9uMRwwGgYDVQQLExNJbmZvcm1hdGlvbiBTeXN0
                <...remainder of base64-encoded data...>
                ****/

                data = token.Values[1].Split(',')[1];
                isEmbedded = true;
            }

            if (!isEmbedded)
            {
                isEmbedded = IsBase64(data);
            }

            return new Photo(isEmbedded, extension, data);
        }
        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Photo = GetPhoto(token, vcard);
        }
    }
}