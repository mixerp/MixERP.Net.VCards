using System.Collections.Generic;
using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class LanguagesProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.Languages == null || vcard.Languages.Count() == 0)
            {
                return string.Empty;
            }

            //Only vCard 4.0 supports LANG property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }


            if (vcard.Languages == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var language in vcard.Languages)
            {
                if (string.IsNullOrWhiteSpace(language.Name))
                {
                    continue;
                }

                string key = "LANG";

                key = key + ";TYPE=" + language.Type.ToVCardString();

                if (language.Preference > 0)
                {
                    key = key + ";PREF=" + language.Preference;
                }

                builder.Append(DefaultSerializer.GetVCardString(key, language.Name, false, vcard.Version));
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(token.Values[0]))
            {
                return;
            }

            var language = new Language();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");
            var type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE");

            language.Preference = preference.Value.ConvertTo<int>();
            language.Type = LanguageTypeLookup.Parse(type.Value);
            language.Name = token.Values[0];

            var emails = (List<Language>) vcard.Languages ?? new List<Language>();
            emails.Add(language);
            vcard.Languages = emails;
        }
    }
}