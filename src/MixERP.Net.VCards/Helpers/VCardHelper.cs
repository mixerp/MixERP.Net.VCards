using System.Text.RegularExpressions;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            return Regex.Split(contents, "((BEGIN:VCARD)(.*)(END:VCARD))");
        }
    }
}