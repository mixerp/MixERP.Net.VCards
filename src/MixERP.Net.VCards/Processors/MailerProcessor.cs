using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class MailerProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("MAILER", vcard.Mailer, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Mailer = token.Values[0];
        }
    }
}