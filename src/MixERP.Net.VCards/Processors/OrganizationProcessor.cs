using MixERP.Net.VCards.Models;
using System.Linq;

namespace MixERP.Net.VCards.Processors
{
    public static class OrganizationProcessor
    {
        public static string Serialize(VCard vcard)
        {
            return GroupProcessor.Serialize("ORG", vcard.Version, string.Empty, false, vcard.Organization, vcard.OrganizationalUnit);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (token.Values.Length > 0)
            {
                vcard.Organization = token.Values[0];
            }

            if (token.Values.Length > 1)
            {
                vcard.OrganizationalUnit = string.Join(";", token.Values.Skip(1));
            }
        }
    }
}