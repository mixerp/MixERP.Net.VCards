using System.Text.RegularExpressions;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            var rx = new Regex("BEGIN:VCARD(?s)(.*?)END:VCARD");
            var matches = rx.Matches(contents);
            var cards = new string[matches.Count];

            for (var i = 0; i < matches.Count; i++)
            {
                cards[i] = matches[i].ToString();
            }

            return cards;
        }
    }
}
