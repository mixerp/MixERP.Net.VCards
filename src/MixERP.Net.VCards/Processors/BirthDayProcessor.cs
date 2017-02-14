using MixERP.Net.VCards.Models;

namespace MixERP.Net.VCards.Processors
{
    internal static class BirthDayProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DateTimeProcessor.Serialize(vcard.BirthDay, "BDAY", vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var date = DateTimeProcessor.Parse(value);
            vcard.BirthDay = date;
        }
    }
}