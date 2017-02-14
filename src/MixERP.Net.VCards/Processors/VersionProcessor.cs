using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class VersionProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("VERSION", vcard.Version.ToVCardString(), false, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string version = token.Values[0];
            vcard.Version = VersionLookup.Parse(version);
        }
    }
}