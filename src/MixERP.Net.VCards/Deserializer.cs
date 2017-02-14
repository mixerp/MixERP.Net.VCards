using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Helpers;
using MixERP.Net.VCards.Parser;

namespace MixERP.Net.VCards
{
    public static class Deserializer
    {
        public static VCard FromString(string contents)
        {
            var vcard = new VCard();

            if (string.IsNullOrWhiteSpace(contents))
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

                if (AllParsers.Parsers.ContainsKey(token.Key))
                {
                    var implementation = AllParsers.Parsers[token.Key];
                    implementation.Invoke(token, ref vcard);
                }
            }

            return vcard;
        }


        public static IEnumerable<VCard> Deserialize(string path)
        {
            var cards = FileHelper.ReadVCardString(path);
            cards = cards.Where(x => !string.IsNullOrWhiteSpace(x.Trim())).ToArray();
            return cards.Select(FromString).ToList();
        }
    }
}