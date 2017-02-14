using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class ImppsProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports IMPP property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }


            if (vcard.Impps == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var impp in vcard.Impps)
            {
                string key = "IMPP";

                if (impp.Preference > 0)
                {
                    key = key + ";PREF=" + impp.Preference;
                }

                builder.Append(DefaultSerializer.GetVCardString(key, impp.Address.ToString(), false, vcard.Version));
            }

            return builder.ToString();
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            var impp = new Impp();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");

            impp.Preference = preference.Value.ConvertTo<int>();
            impp.Address = new Uri(token.Values[0], UriKind.RelativeOrAbsolute);

            var impps = (List<Impp>) vcard.Impps ?? new List<Impp>();
            impps.Add(impp);
            vcard.Impps = impps;
        }
    }
}