using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class ClassificationProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "CLASS" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("CLASS", ClassificationLookup.ToVCardString(vcard.Classification), true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Classification = ClassificationLookup.Parse(token.Values[0]);
        }
    }
}