using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class Base64StringProcessor
    {
        public static string SerializeBase64String(string value, string key, string type, VCardVersion version)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            /***************************************************************
                V2.1

                PHOTO;VALUE=URL:file:///jqpublic.gif

                OR

                PHOTO;ENCODING=BASE64;TYPE=GIF:
                    R0lGODdhfgA4AOYAAAAAAK+vr62trVIxa6WlpZ+fnzEpCEpzlAha/0Kc74+PjyGM
                    SuecKRhrtX9/fzExORBSjCEYCGtra2NjYyF7nDGE50JrhAg51qWtOTl7vee1MWu1
                    50o5e3PO/3sxcwAx/4R7GBgQOcDAwFoAQt61hJyMGHuUSpRKIf8A/wAY54yMjHtz
                ...

            **************************************************************/


            string encoding = "BASE64";
            if (version == VCardVersion.V3)
            {
                /***************************************************************
                    Looks like this in V3.0

                    PHOTO;VALUE=uri:http://www.abc.com/pub/photos
                     /jqpublic.gif

                    OR

                    PHOTO;ENCODING=b;TYPE=JPEG:MIICajCCAdOgAwIBAgICBEUwDQYJKoZIhvcN
                     AQEEBQAwdzELMAkGA1UEBhMCVVMxLDAqBgNVBAoTI05ldHNjYXBlIENvbW11bm
                     ljYXRpb25zIENvcnBvcmF0aW9uMRwwGgYDVQQLExNJbmZvcm1hdGlvbiBTeXN0
                     <...remainder of "B" encoded binary data...>
                **************************************************************/

                encoding = "b";
            }
            else if (version == VCardVersion.V4)
            {
                /***************************************************************
                    Looks like this in V4.0
                    PHOTO:data:image/jpeg;base64,MIICajCCAdOgAwIBAgICBEUwDQYJKoZIhv
                    AQEEBQAwdzELMAkGA1UEBhMCVVMxLDAqBgNVBAoTI05ldHNjYXBlIENvbW11bm
                    ljYXRpb25zIENvcnBvcmF0aW9uMRwwGgYDVQQLExNJbmZvcm1hdGlvbiBTeXN0
                    <...remainder of base64-encoded data...>
                **************************************************************/
                encoding = string.Empty;
            }

            return DefaultSerializer.GetVCardString(key, value, false, version, type, encoding);
        }
    }
}