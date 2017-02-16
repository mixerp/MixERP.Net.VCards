using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    public static class GeographyProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if(vcard.Longitude == 0 && vcard.Latitude == 0)
            {
                return string.Empty;
            }

            return GroupProcessor.Serialize("GEO", vcard.Version, string.Empty, false, vcard.Longitude.ToString("N2"), vcard.Latitude.ToString("N2"));
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (token.Values.Length > 0)
            {
                vcard.Longitude = token.Values[0].ConvertTo<double>();
            }

            if (token.Values.Length > 1)
            {
                vcard.Latitude = token.Values[1].ConvertTo<double>();
            }
        }
    }
}