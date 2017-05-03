using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MixERP.Net.VCards.Helpers;
using MixERP.Net.VCards.Parser;

namespace MixERP.Net.VCards
{
    public static class Deserializer
    {
        public static VCard GetVCard(string contents)
        {
            var vcard = new VCard();

            if (string.IsNullOrWhiteSpace(contents) || !contents.TrimStart().StartsWith("BEGIN:VCARD") || !contents.TrimEnd().EndsWith("END:VCARD"))
            {
                return vcard;
            }

            var tokens = TokenParser.Parse(contents);
            foreach (var token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token.Key))
                {
                    continue;
                }

                var keys = AllParsers.Parsers.Keys.ToList();

                foreach (var key in keys)
                {
                    var pattern = "^" + Regex.Escape(key).Replace("\\*", ".*") + "$";
                    var match = Regex.IsMatch(token.Key, pattern,
                        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

                    if (!match)
                    {
                        continue;
                    }

                    var implementation = AllParsers.Parsers[key];
                    implementation.Invoke(token, ref vcard);
                }
            }

            return vcard;
        }

        public static IEnumerable<VCard> GetVCards(string contents)
        {
            var cards = VCardHelper.SplitCards(contents);
            cards = cards.Where(x => !string.IsNullOrWhiteSpace(x.Trim())).ToArray();
            return cards.Select(GetVCard).ToList();
        }

        public static IEnumerable<VCard> Deserialize(string path)
        {
            var cards = FileHelper.ReadVCardString(path);
            cards = cards.Where(x => !string.IsNullOrWhiteSpace(x.Trim())).ToArray();
            return cards.Select(GetVCard).ToList();
        }
    }
}