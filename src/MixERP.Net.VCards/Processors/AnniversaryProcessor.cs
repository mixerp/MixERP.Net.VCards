using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class AnniversaryProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports ANNIVERSARY property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            return DateTimeProcessor.Serialize(vcard.Anniversary, "ANNIVERSARY", vcard.Version);
        }


        public static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var date = DateTimeProcessor.Parse(value);
            vcard.Anniversary = date;
        }
    }
}