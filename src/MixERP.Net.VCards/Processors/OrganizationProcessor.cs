using MixERP.Net.VCards.Models;
using System.Linq;

namespace MixERP.Net.VCards.Processors
{
    internal static class OrganizationProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return GroupProcessor.Serialize("ORG", vcard.Version, string.Empty, false, vcard.Organization, vcard.OrganizationalUnit);
        }

        internal static void Parse(Token token, ref VCard vcard)
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