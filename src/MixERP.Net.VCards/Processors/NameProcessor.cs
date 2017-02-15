using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class NameProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if ((vcard.Version == VCardVersion.V2_1 && vcard.Version == VCardVersion.V3) || string.IsNullOrWhiteSpace(vcard.SortString))
            {
                return GroupProcessor.Serialize("N", vcard.Version, string.Empty, true, vcard.LastName, vcard.FirstName, vcard.MiddleName, vcard.Prefix, vcard.Suffix);
            }

            /*****************************************************************
                RFC 6350 examples for V4.0:
                FN:Rene van der Harten
                N;SORT-AS="Harten,Rene":van der Harten;Rene,J.;Sir;R.D.O.N.

                FN:Robert Pau Shou Chang
                N;SORT-AS="Pau Shou Chang,Robert":Shou Chang;Robert,Pau;;

                FN:Osamu Koura
                N;SORT-AS="Koura,Osamu":Koura;Osamu;;

                FN:Oscar del Pozo
                N;SORT-AS="Pozo,Oscar":del Pozo Triscon;Oscar;;

                FN:Chistine d'Aboville
                N;SORT-AS="Aboville,Christine":d'Aboville;Christine;;
             *****************************************************************/

            string key = "N;SORT-AS=\"{sortAs}\"";
            key = key.Replace("{sortAs}", vcard.SortString);

            return GroupProcessor.Serialize(key, vcard.Version, string.Empty, true, vcard.LastName, vcard.FirstName, vcard.MiddleName, vcard.Prefix, vcard.Suffix);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (token.AdditionalKeyMembers.ContainsKey("SORT-AS"))
            {
                vcard.SortString = token.AdditionalKeyMembers["SORT-AS"];
            }

            if (token.Values.Length > 0)
            {
                vcard.LastName = token.Values[0];
            }

            if (token.Values.Length > 1)
            {
                vcard.FirstName = token.Values[1];
            }

            if (token.Values.Length > 2)
            {
                vcard.MiddleName = token.Values[2];
            }

            if (token.Values.Length > 3)
            {
                vcard.Prefix = token.Values[3];
            }

            if (token.Values.Length > 4)
            {
                vcard.Suffix = token.Values[4];
            }
        }
    }
}