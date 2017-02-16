using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    public static class TitleProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.Title))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("TITLE", vcard.Title, false, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Title = token.Values[0];
        }
    }
}