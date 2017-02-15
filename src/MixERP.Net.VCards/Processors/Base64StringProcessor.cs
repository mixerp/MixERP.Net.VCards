using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class Base64StringProcessor
    {
        internal static string SerializeBase64String(string value, string key, string type, VCardVersion version)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            /***************************************************************
                V2.1


            **************************************************************/


            string encoding = "BASE64";
            if (version == VCardVersion.V3)
            {
                /***************************************************************
                    Looks like this in V3.0


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