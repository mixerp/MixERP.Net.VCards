using System.Collections.Generic;
using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class EmailsProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.Emails == null || vcard.Emails.Count() == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var email in vcard.Emails)
            {
                if (string.IsNullOrWhiteSpace(email.EmailAddress))
                {
                    continue;
                }

                string type = email.Type.ToVCardString();

                string key = "EMAIL";

                if (vcard.Version == VCardVersion.V4)
                {
                    if (email.Preference > 0)
                    {
                        key = key + ";PREF=" + email.Preference;
                    }
                }

                builder.Append(GroupProcessor.Serialize(key, vcard.Version, type, true, email.EmailAddress));
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(token.Values[0]))
            {
                return;
            }

            var email = new Email();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");
            var type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE");

            email.Preference = preference.Value.ConvertTo<int>();
            email.Type = EmailTypeLookup.Parse(type.Value);
            email.EmailAddress = token.Values[0];

            var emails = (List<Email>) vcard.Emails ?? new List<Email>();
            emails.Add(email);
            vcard.Emails = emails;
        }
    }
}